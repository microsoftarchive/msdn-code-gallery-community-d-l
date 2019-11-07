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
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Configuration;
    #endregion

    #region IWorkItemSchedulerConfigurationExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for providing 
    /// access to the Work Item Scheduler service configuration settings.
    /// </summary>
    public interface IWorkItemSchedulerConfigurationExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns configuration settings used by the Work Item Scheduler service.
        /// </summary>
        WorkItemSchedulerConfigurationSettings Settings { get; }
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for providing access to the Work Item Scheduler service configuration settings.
    /// </summary>
    public class WorkItemSchedulerConfigurationExtension : IWorkItemSchedulerConfigurationExtension
    {
        #region Private members
        private WorkItemSchedulerConfigurationSettings settings;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();
            IRoleConfigurationSettingsExtension roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();

            this.settings = new WorkItemSchedulerConfigurationSettings(roleConfigExtension.GetSection<ApplicationConfigurationSettings>(WorkItemSchedulerConfigurationSettings.SectionName));
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region IWorkItemSchedulerConfigurationExtension implementation
        /// <summary>
        /// Returns configuration settings used by the Work Item Scheduler service.
        /// </summary>
        public WorkItemSchedulerConfigurationSettings Settings
        {
            get 
            {
                Guard.ArgumentNotNull(this.settings, "settings");
                return this.settings; 
            }
        }
        #endregion
    }
}
