//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.ActivityTracking
{
    #region Using references
    using System;
    #endregion

    /// <summary>
    /// Defines an interface that must be supported by a custom tracking event stream.
    /// </summary>
    public interface IActivityTrackingEventStream : IDisposable
    {
        /// <summary>
        /// Tells the event stream to invoke the BeginActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        void BeginActivity(ActivityBase activity);

        /// <summary>
        /// Tells the event stream to invoke the UpdateActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        void UpdateActivity(ActivityBase activity);

        /// <summary>
        /// Tells the event stream to invoke the EndActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        void EndActivity(ActivityBase activity);

        /// <summary>
        /// Tells the event stream to invoke the UpdateActivity and EndActivity operations.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        void CompleteActivity(ActivityBase activity);

        /// <summary>
        /// Tells the event stream to invoke the BeginActivity, UpdateActivity and EndActivity operations. 
        /// If activity has a continuation token, continuation will also be enabled.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        void BeginAndCompleteActivity(ActivityBase activity);

        /// <summary>
        /// Adds a relationship between this activity and a parent activity.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        /// <param name="parent">The parent activity instance.</param>
        void LinkToParent(ActivityBase activity, ActivityBase parent);

        /// <summary>
        /// Adds a relationship between this activity and a child activity.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        /// <param name="child">The child activity instance.</param>
        void LinkToChild(ActivityBase activity, ActivityBase child);

        /// <summary>
        /// Enables continuation for the specified activity. Invokes the EndActivity operation against the event stream 
        /// after the activity is enabled for continuation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        void ContinueActivity(ActivityBase activity);
    }
}
