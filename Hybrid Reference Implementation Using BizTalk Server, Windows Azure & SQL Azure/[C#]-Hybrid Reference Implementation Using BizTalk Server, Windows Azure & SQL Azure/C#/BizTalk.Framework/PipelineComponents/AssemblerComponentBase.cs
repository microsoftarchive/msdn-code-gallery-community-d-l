//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.PipelineComponents
{
    #region Using references
    using System;
    using System.Resources;
    using System.Diagnostics;

    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Provides a base class that can be extended by a custom implementation of an assembler pipeline component.
    /// </summary>
    [ComponentCategory(CategoryTypes.CATID_AssemblingSerializer)]
    public abstract class AssemblerComponentBase : PipelineComponentBase, IAssemblerComponent
    {
        #region Private members
        private IPipelineContext pipelineContext;
        private bool addDocumentCalled;
        private Stopwatch addDocumentStopwatch;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblerComponentBase"/> using the specified resource manager.
        /// </summary>
        /// <param name="resourceManager">The resource manager object providing access to the component resources.</param>
        protected AssemblerComponentBase(ResourceManager resourceManager)
            : base(resourceManager)
        {
        }
        #endregion

        #region PipelineComponentBase implementations
        /// <summary>
        /// Returns the pipeline context that us available for this instance of the component.
        /// </summary>
        protected override IPipelineContext PipelineContext
        {
            get
            {
                if (this.pipelineContext != null)
                {
                    return this.pipelineContext;
                }
                else
                {
                    throw new InvalidOperationException(ExceptionMessages.PipelineContextNotInitialized);
                }
            }
        }
        #endregion

        #region IAssemblerComponent implementations
        /// <summary>
        /// Builds an output interchange from the message that was added by the AddDocument method.
        /// </summary>
        /// <param name="pContext">The <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> that contains the current pipeline context.</param>
        /// <returns>The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> that contains the assembled document.</returns>
        IBaseMessage IAssemblerComponent.Assemble(IPipelineContext pContext)
        {
            Guard.ArgumentNotNull(pContext, "pContext");

            // Write a TraceIn event indicating when execution started.
            var callToken = PipelineTraceManager.TraceIn(pContext.PipelineID, pContext.PipelineName, pContext.StageID, pContext.StageIndex, pContext.ComponentIndex);

            try
            {
                // Store a reference to IPipelineContext as soon as it's known to the component. 
                this.pipelineContext = pContext;

                // The instance of the benchmark activity to measure execution time for the Assemble method.
                PipelineComponentBenchmarkActivity benchmarkActivity = null;

                // A stopwatch object will help accurately measure how long the user-defined portion of the
                // the Assemble method takes.
                Stopwatch benchmarkStopwatch = null;

                // If BAM instrumentation is enabled, begin the benchmark activity to indicate when Assemble phase started.
                if (EnableActivityTracking)
                {
                    ActivityBase startedBenchmarkActivity = this.BenchmarkActivity;

                    if (null == startedBenchmarkActivity)
                    {
                        startedBenchmarkActivity = BeginBenchmarkActivity(pContext, Guid.NewGuid().ToString());
                    }

                    benchmarkActivity = new PipelineComponentBenchmarkActivity(startedBenchmarkActivity.ActivityID);
                    benchmarkActivity.AssembleStarted = DateTime.UtcNow;

                    // Start the stopwatch so that timer starts measuring elapsed time.
                    benchmarkStopwatch = Stopwatch.StartNew();
                }

                // Write the Start event to measure how long it takes to execute the user-defined implementation of the Assemble method.
                var scopeStarted = PipelineTraceManager.TraceStartScope(this.Name, callToken);

                // Execute the user-defined implementation of the Assemble method.
                IBaseMessage outputMessage = Assemble(pContext);

                // Once finished, write the End event along with calculated duration.
                PipelineTraceManager.TraceEndScope(this.Name, scopeStarted, callToken);

                // If BAM instrumentation is enabled, update the benchmark activity to indicate when Assemble phase completed.
                if (EnableActivityTracking)
                {
                    // Safety check if benchmarkActivity is initialized (if not, something went wrong)
                    if (benchmarkActivity != null)
                    {
                        // Safety check if benchmarkStopwatch is initialized (if not, something went wrong)
                        if (benchmarkStopwatch != null)
                        {
                            // Stop the timer and record the total elapsed time spent inside Disassemble.
                            benchmarkStopwatch.Stop();
                            benchmarkActivity.AssembleDurationMs = benchmarkStopwatch.Elapsed.TotalMilliseconds;
                        }

                        // Record the date and time when the Assemble method completed.
                        benchmarkActivity.AssembleCompleted = DateTime.UtcNow;

                        // Complete the benchmark activity as Assemble will be called last.
                        PipelineEventStream.CompleteActivity(benchmarkActivity);
                    }

                    // We are done, check if we should stop the instance-level stopwatch used by AddDocument.
                    if (addDocumentStopwatch != null)
                    {
                        addDocumentStopwatch.Stop();
                    }
                }

                if (outputMessage != null)
                {
                    PipelineTraceManager.TraceOut(callToken, outputMessage.MessageID, outputMessage.PartCount);
                }
                else
                {
                    PipelineTraceManager.TraceOut(callToken);
                }

                return outputMessage;
            }
            catch (Exception e)
            {
                // Put component name as a source in this exception so that the error message could reflect this.
                e.Source = this.Name;

                // Trace the exception details.
                PipelineTraceManager.TraceError(e, EnableDetailedExceptions, callToken);

                // Re-throw the exception so that it can be handled by the caller.
                throw;
            }
        }

        /// <summary>
        /// Adds the document to the list of messages that are included in an interchange. 
        /// </summary>
        /// <param name="pContext">The <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> that contains the current pipeline context.</param>
        /// <param name="pInMsg">The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> that contains the document to be added to the message set.</param>
        void IAssemblerComponent.AddDocument(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            Guard.ArgumentNotNull(pContext, "pContext");
            Guard.ArgumentNotNull(pInMsg, "pInMsg");

            // Write a TraceIn event indicating when execution started.
            var callToken = PipelineTraceManager.TraceIn(pContext.PipelineID, pContext.PipelineName, pContext.StageID, pContext.StageIndex, pContext.ComponentIndex);

            try
            {
                // Store a reference to IPipelineContext as soon as it's known to the component. 
                this.pipelineContext = pContext;

                // The instance of the benchmark activity to measure execution time for the AddDocument method.
                PipelineComponentBenchmarkActivity benchmarkActivity = null;

                // Check if we are entering AddDocument method for the first time.
                if (!this.addDocumentCalled)
                {
                    this.addDocumentCalled = true;

                    // If BAM instrumentation is enabled, update the AddDocumentStarted milestone.
                    if (EnableActivityTracking)
                    {
                        ActivityBase startedBenchmarkActivity = this.BenchmarkActivity;

                        if (null == startedBenchmarkActivity)
                        {
                            startedBenchmarkActivity = BeginBenchmarkActivity(pContext, Guid.NewGuid().ToString());
                        }

                        benchmarkActivity = new PipelineComponentBenchmarkActivity(startedBenchmarkActivity.ActivityID);
                        benchmarkActivity.AddDocumentStarted = DateTime.UtcNow;

                        PipelineEventStream.UpdateActivity(benchmarkActivity);

                        // Start the stopwatch so that timer starts measuring elapsed time.
                        addDocumentStopwatch = Stopwatch.StartNew();
                    }
                }

                // Write the Start event to measure how long it takes to execute the user-defined implementation of the AddDocument method.
                var scopeStarted = PipelineTraceManager.TraceStartScope(this.Name, callToken);

                // Execute the user-defined implementation of the AddDocument method.
                AddDocument(pContext, pInMsg);

                // Once finished, write the End event along with calculated duration.
                PipelineTraceManager.TraceEndScope(this.Name, scopeStarted, callToken);

                // If BAM instrumentation is enabled, update the AddDocumentCompleted milestone.
                if (EnableActivityTracking)
                {
                    double addDocumentDurationMs = Double.NaN;

                    // Safety check if getNextStopwatch is initialized (if not, something went wrong)
                    if (addDocumentStopwatch != null)
                    {
                        // Stop the timer and record the total elapsed time spent inside the entire GetNext phase.
                        addDocumentStopwatch.Stop();
                        addDocumentDurationMs = addDocumentStopwatch.Elapsed.TotalMilliseconds;

                        // Restart the stopwatch since AddDocument is expected to be called multiple times.
                        addDocumentStopwatch.Start();
                    }

                    ActivityBase startedBenchmarkActivity = this.BenchmarkActivity;

                    if (null == startedBenchmarkActivity)
                    {
                        startedBenchmarkActivity = BeginBenchmarkActivity(pContext, Guid.NewGuid().ToString());
                    }

                    benchmarkActivity = new PipelineComponentBenchmarkActivity(startedBenchmarkActivity.ActivityID);
                    benchmarkActivity.AddDocumentCompleted = DateTime.UtcNow;
                    benchmarkActivity.AddDocumentDurationMs = addDocumentDurationMs;
                    
                    PipelineEventStream.UpdateActivity(benchmarkActivity);
                }

                // Write a TraceOut event indicating when execution finished.
                PipelineTraceManager.TraceOut(callToken);
            }
            catch (Exception e)
            {
                // Put component name as a source in this exception so that the error message could reflect this.
                e.Source = this.Name;

                // Trace the exception details.
                PipelineTraceManager.TraceError(e, EnableDetailedExceptions, callToken);

                // Re-throw the exception so that it can be handled by the caller.
                throw;
            }
        }
        #endregion

        #region AssemblerComponentBase abstract members
        /// <summary>
        /// Builds an output interchange from the message that was added by the AddDocument method.
        /// </summary>
        /// <param name="pContext">Reference to a <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object/interface that contains the current pipeline context.</param>
        /// <returns>The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> that contains the assembled document.</returns>
        public abstract IBaseMessage Assemble(IPipelineContext pContext);

        /// <summary>
        /// Adds the document to the list of messages that are included in an interchange.
        /// </summary>
        /// <param name="pContext">Reference to a <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object/interface that contains the current pipeline context.</param>
        /// <param name="pInMsg">The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> that contains the document to be added to the message set.</param>
        public abstract void AddDocument(IPipelineContext pContext, IBaseMessage pInMsg);
        #endregion
    }
}
