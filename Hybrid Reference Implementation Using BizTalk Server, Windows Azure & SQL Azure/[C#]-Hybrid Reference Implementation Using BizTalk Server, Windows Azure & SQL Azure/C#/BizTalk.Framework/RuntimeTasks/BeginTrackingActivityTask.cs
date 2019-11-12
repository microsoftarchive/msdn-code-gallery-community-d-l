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
namespace Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks
{
    #region Using references
    using System;
    
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Core.ActivityTracking;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for initiating a BAM tracking activity.
    /// </summary>
    public sealed class BeginTrackingActivityTask : TrackingActivityTaskBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BeginTrackingActivityTask"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public BeginTrackingActivityTask(IMessagingRuntimeExtension owner) : base(owner)
        {
        }
        #endregion

        #region TrackingActivityTaskBase implementation
        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public override void Run(RuntimeTaskExecutionContext context)
        {
            var callToken = TraceManager.CustomComponent.TraceIn();

            base.Run(context);

            if (CurrentActivity != null)
            {
                using (IActivityTrackingEventStream eventStream = ActivityTrackingEventStreamFactory.CreateEventStream(context.PipelineContext))
                {
                    eventStream.BeginActivity(CurrentActivity);

                    if (!String.IsNullOrEmpty(CurrentActivity.ContinuationToken))
                    {
                        eventStream.ContinueActivity(CurrentActivity);
                    }
                }
            }

            TraceManager.CustomComponent.TraceOut(callToken);
        }
        #endregion
    }
}
