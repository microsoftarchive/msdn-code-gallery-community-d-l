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
    /// Provides a base class that can be extended by a custom implementation of a disassembler pipeline component.
    /// </summary>
    [ComponentCategory(CategoryTypes.CATID_DisassemblingParser)]
    public abstract class DisassemblerComponentBase : PipelineComponentBase, IDisassemblerComponent
    {
        #region Private members
        private IPipelineContext pipelineContext;
        private bool getNextCalled;
        private Stopwatch getNextStopwatch;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DisassemblerComponentBase"/> using the specified resource manager.
        /// </summary>
        /// <param name="resourceManager">The resource manager object providing access to the component resources.</param>
        protected DisassemblerComponentBase(ResourceManager resourceManager) : base(resourceManager)
        {
        }
        #endregion

        #region PipelineComponentBase overrides
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

        #region IDisassemblerComponent implementation
        /// <summary>
        /// Performs the disassembling of an incoming document.
        /// </summary>
        /// <param name="pContext">The <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> containing the current pipeline context.</param>
        /// <param name="pInMsg">The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> containing the message to be disassembled.</param>
        void IDisassemblerComponent.Disassemble(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            Guard.ArgumentNotNull(pContext, "pContext");
            Guard.ArgumentNotNull(pInMsg, "pInMsg");

            // Write a TraceIn event indicating when execution started.
            var callToken = PipelineTraceManager.TraceIn(pContext.PipelineID, pContext.PipelineName, pContext.StageID, pContext.StageIndex, pContext.ComponentIndex);

            try
            {
                // Store a reference to IPipelineContext as soon as it's known to the component. 
                this.pipelineContext = pContext;

                // The instance of the benchmark activity to measure execution time for the Disassemble method.
                PipelineComponentBenchmarkActivity benchmarkActivity = null;

                // A stopwatch object will help accurately measure how long the user-defined portion of the
                // the Disassemble method takes.
                Stopwatch benchmarkStopwatch = null;

                // If BAM instrumentation is enabled, begin the benchmark activity to indicate when Disassemble phase started.
                if (EnableActivityTracking)
                {
                    ActivityBase startedActivity = BeginBenchmarkActivity(pContext, pInMsg.Context != null ? (new SystemMessageContext(pInMsg.Context)).InterchangeID : Guid.NewGuid().ToString());
                    
                    benchmarkActivity = new PipelineComponentBenchmarkActivity(startedActivity.ActivityID);
                    benchmarkActivity.DisassembleStarted = DateTime.UtcNow;

                    // Start the stopwatch so that timer starts measuring elapsed time.
                    benchmarkStopwatch = Stopwatch.StartNew();
                }

                // Write the Start event to measure how long it takes to execute the user-defined implementation of the Disassemble method.
                var scopeStarted = PipelineTraceManager.TraceStartScope(this.Name, callToken);

                // Execute the user-defined implementation of the Disassemble method.
                Disassemble(pContext, pInMsg);

                // Once finished, write the End event along with calculated duration.
                PipelineTraceManager.TraceEndScope(this.Name, scopeStarted, callToken);

                // If BAM instrumentation is enabled, update the benchmark activity to indicate when Disassemble phase completed.
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
                            benchmarkActivity.DisassembleDurationMs = benchmarkStopwatch.Elapsed.TotalMilliseconds;
                        }

                        // Record the date and time when the Disassemble method completed.
                        benchmarkActivity.DisassembleCompleted = DateTime.UtcNow;
 
                        PipelineEventStream.UpdateActivity(benchmarkActivity);
                    }
                }

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

        /// <summary>
        /// Gets the next message from the message set resulting from the disassembler execution.
        /// </summary>
        /// <param name="pContext">The <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> for the current pipeline.</param>
        /// <returns>A pointer to the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> containing the next message from the disassembled document. Returns NULL if there are no more messages left.</returns>
        IBaseMessage IDisassemblerComponent.GetNext(IPipelineContext pContext)
        {
            Guard.ArgumentNotNull(pContext, "pContext");

            // Write a TraceIn event indicating when execution started.
            var callToken = PipelineTraceManager.TraceIn(pContext.PipelineID, pContext.PipelineName, pContext.StageID, pContext.StageIndex, pContext.ComponentIndex);

            try
            {
                // The instance of the benchmark activity to measure execution time for the GetNext method.
                PipelineComponentBenchmarkActivity benchmarkActivity = null;

                // Check if we are enterting GetNext method for the first time.
                if(!this.getNextCalled)
                {
                    this.getNextCalled = true;

                    // If BAM instrumentation is enabled, update the GetNextStarted milestone.
                    if (EnableActivityTracking)
                    {
                        benchmarkActivity = new PipelineComponentBenchmarkActivity(BenchmarkActivity.ActivityID);
                        benchmarkActivity.GetNextStarted = DateTime.UtcNow;

                        PipelineEventStream.UpdateActivity(benchmarkActivity);

                        // Start the stopwatch so that timer starts measuring elapsed time.
                        getNextStopwatch = Stopwatch.StartNew();
                    }
                }

                // Write the Start event to measure how long it takes to execute the user-defined implementation of the GetNext method.
                var scopeStarted = PipelineTraceManager.TraceStartScope(this.Name, callToken);

                // Execute the user-defined implementation of the GetNext method.
                IBaseMessage outputMessage = GetNext(pContext);

                // Once finished, write the End event along with calculated duration.
                PipelineTraceManager.TraceEndScope(this.Name, scopeStarted, callToken);

                if (outputMessage != null)
                {
                    PipelineTraceManager.TraceOut(callToken, outputMessage.MessageID, outputMessage.PartCount);
                }
                else
                {
                    // If no more messages are available and BAM instrumentation is enabled, update the GetNextCompleted milestone and complete the benchmark activity.
                    if (EnableActivityTracking)
                    {
                        double getNextDurationMs = Double.NaN;

                        // Safety check if getNextStopwatch is initialized (if not, something went wrong)
                        if (getNextStopwatch != null)
                        {
                            // Stop the timer and record the total elapsed time spent inside the entire GetNext phase.
                            getNextStopwatch.Stop();
                            getNextDurationMs = getNextStopwatch.Elapsed.TotalMilliseconds;
                        }

                        if (null == benchmarkActivity)
                        {
                            benchmarkActivity = new PipelineComponentBenchmarkActivity(BenchmarkActivity.ActivityID);
                        }

                        // Record the date and time when the last GetNext method completed.
                        benchmarkActivity.GetNextCompleted = DateTime.UtcNow;
                        benchmarkActivity.GetNextDurationMs = getNextDurationMs;

                        // Complete the benchmark activity as GetNext returning no results indicates the end of cycle.
                        PipelineEventStream.CompleteActivity(benchmarkActivity);
                    }

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
        #endregion

        #region DisassemblerComponentBase abstract members
        /// <summary>
        /// Performs the disassembling of an incoming document.
        /// </summary>
        /// <param name="pContext">The <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> containing the current pipeline context.</param>
        /// <param name="pInMsg">The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> containing the message to be disassembled.</param>
        public abstract void Disassemble(IPipelineContext pContext, IBaseMessage pInMsg);

        /// <summary>
        /// Gets the next message from the message set resulting from the disassembler execution.
        /// </summary>
        /// <param name="pContext">The <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> for the current pipeline.</param>
        /// <returns>A pointer to the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> containing the next message from the disassembled document. Returns NULL if there are no more messages left.</returns>
        public abstract IBaseMessage GetNext(IPipelineContext pContext);
        #endregion
    }
}
