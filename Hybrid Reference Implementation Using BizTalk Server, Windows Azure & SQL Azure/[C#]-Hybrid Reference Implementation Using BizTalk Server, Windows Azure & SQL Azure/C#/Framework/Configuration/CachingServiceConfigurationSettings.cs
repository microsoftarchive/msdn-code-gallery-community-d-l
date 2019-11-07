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
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.Security;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration section containing Windows Azure Caching Service endpoint configuration settings.
    /// </summary>
    [Serializable]
    public class CachingServiceConfigurationSettings : SerializableConfigurationSection
    {
        #region Private members
        private const string DefaultEndpointProperty = "defaultEndpoint";
        private const string DefaultRetryPolicyProperty = "defaultRetryPolicy";
        #endregion

        #region Public members
        /// <summary>
        /// The name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "CachingServiceConfiguration";
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="CachingServiceConfigurationSettings"/> object using default settings.
        /// </summary>
        public CachingServiceConfigurationSettings()
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of a Windows Azure Caching Service endpoint which is intended to be used as default.
        /// </summary>
        [ConfigurationProperty(DefaultEndpointProperty, IsRequired = true)]
        public string DefaultEndpoint
        {
            get { return (string)base[DefaultEndpointProperty]; }
            set { base[DefaultEndpointProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the default retry policy.
        /// </summary>
        [ConfigurationProperty(DefaultRetryPolicyProperty, IsRequired = false)]
        public string DefaultRetryPolicy
        {
            get { return (string)base[DefaultRetryPolicyProperty]; }
            set { base[DefaultRetryPolicyProperty] = value; }
        }

        /// <summary>
        /// Returns a collection of Windows Azure Caching Service endpoints configured for the application.
        /// </summary>
        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        [ConfigurationCollection(typeof(CachingServiceEndpointInfo))]
        public NamedElementCollection<CachingServiceEndpointInfo> Endpoints
        {
            get { return (NamedElementCollection<CachingServiceEndpointInfo>)base[String.Empty]; }
        }
        #endregion
    }
}
