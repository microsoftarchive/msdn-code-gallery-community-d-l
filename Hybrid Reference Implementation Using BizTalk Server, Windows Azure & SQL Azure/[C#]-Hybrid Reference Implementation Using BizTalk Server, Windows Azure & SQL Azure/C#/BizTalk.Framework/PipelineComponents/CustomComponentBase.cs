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
    /// Provides a base class that can be extended by a user-defined implementation of a custom pipeline component.
    /// </summary>
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public abstract class CustomComponentBase : PipelineComponentBase, IComponent
    {
        #region Private members
        private IPipelineContext pipelineContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomComponentBase"/> using the specified resource manager.
        /// </summary>
        /// <param name="resourceManager">The resource manager object providing access to the component resources.</param>
        protected CustomComponentBase(ResourceManager resourceManager)
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

        #region IComponent implementations
        /// <summary>
        /// Provides the explicit implementation of the IComponent.Execute interface method. This enables wrapping the
        /// user implementation of the Execute method into a fully instrumented scope with tracing, exception handing and
        /// BAM tracking capability provided "out-of-the-box". 
        /// </summary>
        /// <param name="pContext">A reference to IPipelineContext object that contains the current pipeline context.</param>
        /// <param name="pInMsg">A reference to IBaseMessage object that contains the message to process.</param>
        /// <returns>A reference to the returned IBaseMessage object which will contain the output message.</returns>
        IBaseMessage IComponent.Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            // Validate input arguments.
            Guard.ArgumentNotNull(pContext, "pContext");
            Guard.ArgumentNotNull(pInMsg, "pInMsg");

            // Trace the fact that the Execute method has been invoked.
            var callToken = PipelineTraceManager.TraceIn(pContext.PipelineID, pContext.PipelineName, pContext.StageID, pContext.StageIndex, pContext.ComponentIndex);

            try
            {
                // Store a reference to IPipelineContext as soon as it's known to the component. 
                this.pipelineContext = pContext;

                // The instance of the benchmark activity to measure execution time for the Execute method.
                PipelineComponentBenchmarkActivity benchmarkActivity = null;

                // A stopwatch object will help accurately measure how long the user-defined portion of the
                // the Execute method takes.
                Stopwatch benchmarkStopwatch = null;

                // If BAM instrumentation is enabled, begin the benchmark activity to indicate when Execute phase started.
                if (EnableActivityTracking)
                {
                    ActivityBase startedActivity = BeginBenchmarkActivity(pContext, pInMsg.MessageID.ToString());

                    benchmarkActivity = new PipelineComponentBenchmarkActivity(startedActivity.ActivityID);
                    benchmarkActivity.ExecuteStarted = DateTime.UtcNow;

                    // Start the stopwatch so that timer starts measuring elapsed time.
                    benchmarkStopwatch = Stopwatch.StartNew();
                }

                // Write the Start event to measure how long it takes to execute the user-defined implementation of the Execute method.
                var scopeStarted = PipelineTraceManager.TraceStartScope(this.Name, callToken);

                // Execute the user-defined implementation of the Execute method.
                IBaseMessage outputMessage = Execute(pContext, pInMsg);

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
                            benchmarkActivity.ExecuteDurationMs = benchmarkStopwatch.Elapsed.TotalMilliseconds;
                        }

                        // Record the date and time when the Execute method completed.
                        benchmarkActivity.ExecuteCompleted = DateTime.UtcNow;

                        PipelineEventStream.CompleteActivity(benchmarkActivity);
                    }
                }

                // Check if the user-defined implementation of the Execute method returned any message.
                if (outputMessage != null)
                {
                    // Trace the fact that the Execute method is completed and add extra data items (message ID and part count) to the trace log.
                    PipelineTraceManager.TraceOut(callToken, outputMessage.MessageID, outputMessage.PartCount);
                }
                else
                {
                    // Trace the fact that the Execute method is completed.
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

        #region CustomComponentBase abstract members
        /// <summary>
        /// Executes a pipeline component to process the input message and returns the result message.
        /// </summary>
        /// <param name="pContext">A reference to <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object that contains the current pipeline context.</param>
        /// <param name="pInMsg">A reference to <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object that contains the message to process.</param>
        /// <returns>A reference to the returned <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object which will contain the output message.</returns>
        public abstract IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg);
        #endregion
    }
}