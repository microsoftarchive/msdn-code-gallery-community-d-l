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
namespace Contoso.Cloud.Integration.BizTalk.Core.ActivityTracking
{
    #region Using references
    using System;

    using Microsoft.BizTalk.Bam.EventObservation;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a custom tracking stream which relays generic <see cref="ActivityBase"/> instances to an existing BAM event stream.
    /// </summary>
    [Serializable]
    public class ActivityTrackingEventStream : IActivityTrackingEventStream
    {
        #region Private members
        private readonly EventStream eventStream;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="ActivityTrackingEventStream"/> object using the specified standard BAM event stream.
        /// </summary>
        /// <param name="eventStream">The standard BAM event stream such as <seealso cref="Microsoft.BizTalk.Bam.EventObservation.BufferedEventStream"/>, <seealso cref="Microsoft.BizTalk.Bam.EventObservation.DirectEventStream"/> or <seealso cref="Microsoft.BizTalk.Bam.EventObservation.OrchestrationEventStream"/>.</param>
        public ActivityTrackingEventStream(EventStream eventStream)
        {
            Guard.ArgumentNotNull(eventStream, "eventStream");
            this.eventStream = eventStream;
        }
        #endregion

        #region IActivityTrackingEventStream members
        /// <summary>
        /// Tells the event stream to invoke the BeginActivity operation.
        /// If the specified activity carries any data items, the UpdateActivity operation will also be invoked.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void BeginActivity(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            this.eventStream.BeginActivity(activity.ActivityName, activity.ActivityID);

            if (activity.ActivityData.Count > 0)
            {
                this.eventStream.UpdateActivity(activity.ActivityName, activity.ActivityID, ActivityTrackingUtility.GetActivityData(activity));
            }

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Tells the event stream to invoke the UpdateActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void UpdateActivity(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            this.eventStream.UpdateActivity(activity.ActivityName, activity.ActivityID, ActivityTrackingUtility.GetActivityData(activity));

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Tells the event stream to invoke the EndActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void EndActivity(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            this.eventStream.EndActivity(activity.ActivityName, activity.ActivityID);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Tells the event stream to invoke the BeginActivity, UpdateActivity and EndActivity operations. 
        /// If activity has a continuation token, continuation will also be enabled.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void BeginAndCompleteActivity(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            this.eventStream.BeginActivity(activity.ActivityName, activity.ActivityID);
            this.eventStream.UpdateActivity(activity.ActivityName, activity.ActivityID, ActivityTrackingUtility.GetActivityData(activity));

            // Check if we should auto-enable continuation on this activity.
            if (!String.IsNullOrEmpty(activity.ContinuationToken))
            {
                this.eventStream.EnableContinuation(activity.ActivityName, activity.ActivityID, activity.ContinuationToken);
            }

            this.eventStream.EndActivity(activity.ActivityName, activity.ActivityID);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Tells the event stream to invoke the UpdateActivity and EndActivity operations.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void CompleteActivity(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            this.eventStream.UpdateActivity(activity.ActivityName, activity.ActivityID, ActivityTrackingUtility.GetActivityData(activity));
            this.eventStream.EndActivity(activity.ActivityName, activity.ActivityID);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Adds a relationship between this activity and a parent activity.
        /// </summary>
        /// <param name="activity">The child activity instance.</param>
        /// <param name="parent">The parent activity instance.</param>
        public void LinkToParent(ActivityBase activity, ActivityBase parent)
        {
            Guard.ArgumentNotNull(activity, "activity");
            Guard.ArgumentNotNull(parent, "parent");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID, parent.ActivityName, parent.ActivityID);

            this.eventStream.AddRelatedActivity(parent.ActivityName, parent.ActivityID, activity.ActivityName, activity.ActivityID);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Adds a relationship between this activity and a child activity.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        /// <param name="child">The child activity instance.</param>
        public void LinkToChild(ActivityBase activity, ActivityBase child)
        {
            Guard.ArgumentNotNull(activity, "activity");
            Guard.ArgumentNotNull(child, "child");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID, child.ActivityName, child.ActivityID);

            this.eventStream.AddRelatedActivity(activity.ActivityName, activity.ActivityID, child.ActivityName, child.ActivityID);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Enables continuation for the specified activity. Invokes the EndActivity operation against the event stream 
        /// after the activity is enabled for continuation
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void ContinueActivity(ActivityBase activity)
        {
            Guard.ArgumentNotNull(activity, "activity");

            var callToken = TraceManager.TrackingComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            this.eventStream.EnableContinuation(activity.ActivityName, activity.ActivityID, activity.ContinuationToken);
            this.eventStream.EndActivity(activity.ActivityName, activity.ActivityID);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        #endregion

        #region IDisposable members
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            var callToken = TraceManager.TrackingComponent.TraceIn();
            
            Dispose(true);
            GC.SuppressFinalize(this);

            TraceManager.TrackingComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.eventStream != null)
                {
                    this.eventStream.Flush();
                    // NOTE: Do not dispose eventStream instance, the BAM events will otherwise fail to appear in the tracking database.
                }
            }
        }
        #endregion
    }
}
