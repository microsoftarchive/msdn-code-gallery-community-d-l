//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Work Item Processor worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Configuration;
    #endregion

    #region IWorkItemProcessorConfigurationExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for providing 
    /// access to the Work Item Processor service configuration settings.
    /// </summary>
    public interface IWorkItemProcessorConfigurationExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns configuration settings used by the Work Item Processor service.
        /// </summary>
        WorkItemProcessorConfigurationSettings Settings { get; }
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for providing access to the Work Item Processor service configuration settings.
    /// </summary>
    public class WorkItemProcessorConfigurationExtension : IWorkItemProcessorConfigurationExtension
    {
        #region Private members
        private WorkItemProcessorConfigurationSettings settings;
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

            this.settings = new WorkItemProcessorConfigurationSettings(roleConfigExtension.GetSection<ApplicationConfigurationSettings>(WorkItemProcessorConfigurationSettings.SectionName));
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region IWorkItemProcessorConfigurationExtension implementation
        /// <summary>
        /// Returns configuration settings used by the Work Item Processor service.
        /// </summary>
        public WorkItemProcessorConfigurationSettings Settings
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
