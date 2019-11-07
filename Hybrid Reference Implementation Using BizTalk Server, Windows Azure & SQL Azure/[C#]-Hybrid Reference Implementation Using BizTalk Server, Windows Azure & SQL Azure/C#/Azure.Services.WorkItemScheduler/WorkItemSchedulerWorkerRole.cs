//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The WorkItemScheduler worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler
{
    #region Using references
    using System;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Extensions;
    #endregion

    /// <summary>
    /// Implements a worker role dedicated to work items scheduling.
    /// </summary>
    public class WorkItemSchedulerWorkerRole : ReliableWorkerRoleBase
    {
        #region Private members
        private IDisposable interCommSubscription; 
        #endregion

        #region Protected methods
        /// <summary>
        /// Extends the Run phase that is called by Windows Azure runtime after the role instance has been initialized.
        /// </summary>
        protected override void OnRoleRun()
        {
            IInterRoleCommunicationExtension interCommExtension = Extensions.Find<IInterRoleCommunicationExtension>();
            IInterRoleEventSubscriberExtension subscriber = Extensions.Find<IInterRoleEventSubscriberExtension>();

            if (interCommExtension != null && subscriber != null)
            {
                this.interCommSubscription = interCommExtension.Subscribe(subscriber);
            }
        }

        /// <summary>
        /// Extends the OnStart phase that is called by Windows Azure runtime to initialize the role instance.
        /// </summary>
        /// <returns>True if initialization succeeds, otherwise false.</returns>
        protected override bool OnRoleStart()
        {
            this.EnsureExists<WorkItemSchedulerConfigurationExtension>();
            this.EnsureExists<InterRoleEventSubscriberExtension>();

            return true;
        }

        /// <summary>
        /// Extends the OnStop phase that is called by Windows Azure runtime when the role instance is to be stopped.
        /// </summary>
        protected override void OnRoleStop()
        {
            if (this.interCommSubscription != null)
            {
                this.interCommSubscription.Dispose();
                this.interCommSubscription = null;
            }
        } 
        #endregion
    }
}