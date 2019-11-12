//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Scalable Transform worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Configuration;
    #endregion

    #region IScalableTransformConfigurationExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for providing 
    /// access to the Scalable Transform service configuration settings.
    /// </summary>
    public interface IScalableTransformConfigurationExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns configuration settings used by the Scalable Transform service.
        /// </summary>
        ScalableTransformConfigurationSettings Settings { get; }
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for providing access to the Scalable Transform service configuration settings.
    /// </summary>
    public class ScalableTransformConfigurationExtension : IScalableTransformConfigurationExtension
    {
        #region Private members
        private IRoleConfigurationSettingsExtension roleConfigExtension;
        #endregion

        #region IScalableTransformConfigurationExtension implementation
        /// <summary>
        /// Returns configuration settings used by the Scalable Transform service.
        /// </summary>
        public ScalableTransformConfigurationSettings Settings
        {
            get
            {
                Guard.ArgumentNotNull(this.roleConfigExtension, "roleConfigExtension");
                return this.roleConfigExtension.GetSection<ScalableTransformConfigurationSettings>();
            }
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();
            this.roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion
    }
}
