//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    #endregion

    #region IActivityTrackingEventStreamExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for handling BAM activity tracking events.
    /// </summary>
    public interface IActivityTrackingEventStreamExtension : IActivityTrackingEventStream, ICloudServiceComponentExtension
    {
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for handling BAM activity tracking events.
    /// </summary>
    public class ActivityTrackingEventStreamExtension : IActivityTrackingEventStreamExtension
    {
        #region Private members
        private ReliableServiceBusClient<IActivityTrackingServiceChannel> activityTrackingClient;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            IRoleConfigurationSettingsExtension roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();

            if (roleConfigExtension != null)
            {
                this.activityTrackingClient = new ReliableServiceBusClient<IActivityTrackingServiceChannel>(roleConfigExtension.OnPremiseRelayOneWayEndpoint, roleConfigExtension.CommunicationRetryPolicy);
            }
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            Dispose();
        }
        #endregion

        #region IActivityTrackingEventStream implementation
        /// <summary>
        /// Tells the remote event stream to invoke the BeginActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void BeginActivity(ActivityBase activity)
        {
            if (null == this.activityTrackingClient) return;

            Guard.ArgumentNotNull(activity, "activity");
            Guard.ArgumentNotNullOrEmptyString(activity.ActivityName, "activity.ActivityName");
            Guard.ArgumentNotNullOrEmptyString(activity.ActivityID, "activity.ActivityID");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            try
            {
                this.activityTrackingClient.Client.BeginActivity(activity);
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Tells the remote event stream to invoke the UpdateActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void UpdateActivity(ActivityBase activity)
        {
            if (null == this.activityTrackingClient) return;

            Guard.ArgumentNotNull(activity, "activity");
            Guard.ArgumentNotNullOrEmptyString(activity.ActivityName, "activity.ActivityName");
            Guard.ArgumentNotNullOrEmptyString(activity.ActivityID, "activity.ActivityID");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            try
            {
                this.activityTrackingClient.Client.UpdateActivity(activity);
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Tells the remote event stream to invoke the EndActivity operation.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void EndActivity(ActivityBase activity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tells the remote event stream to invoke the UpdateActivity and EndActivity operations.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void CompleteActivity(ActivityBase activity)
        {
            if (null == this.activityTrackingClient) return;

            Guard.ArgumentNotNull(activity, "activity");
            Guard.ArgumentNotNullOrEmptyString(activity.ActivityName, "activity.ActivityName");
            Guard.ArgumentNotNullOrEmptyString(activity.ActivityID, "activity.ActivityID");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(activity.ActivityName, activity.ActivityID);

            try
            {
                this.activityTrackingClient.Client.CompleteActivity(activity);
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Tells the remote event stream to invoke the BeginActivity, UpdateActivity and EndActivity operations. 
        /// If activity has a continuation token, continuation will also be enabled.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void BeginAndCompleteActivity(ActivityBase activity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a relationship between this activity and a parent activity.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        /// <param name="parent">The parent activity instance.</param>
        public void LinkToParent(ActivityBase activity, ActivityBase parent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a relationship between this activity and a child activity.
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        /// <param name="child">The child activity instance.</param>
        public void LinkToChild(ActivityBase activity, ActivityBase child)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enables continuation for the specified activity. Invokes the EndActivity operation against the event stream 
        /// after the activity is enabled for continuation
        /// </summary>
        /// <param name="activity">The activity instance.</param>
        public void ContinueActivity(ActivityBase activity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.activityTrackingClient != null)
            {
                this.activityTrackingClient.Dispose();
                this.activityTrackingClient = null;
            }
        }
        #endregion
    }
}
