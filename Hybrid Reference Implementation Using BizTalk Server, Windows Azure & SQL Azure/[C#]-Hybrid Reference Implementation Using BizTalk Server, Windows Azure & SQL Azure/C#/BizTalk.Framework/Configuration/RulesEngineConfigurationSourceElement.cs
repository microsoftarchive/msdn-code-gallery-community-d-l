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
namespace Contoso.Cloud.Integration.BizTalk.Core.Configuration
{
    #region Using references
    using System;
    using System.ComponentModel;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Represents the configuration settings that describe a <see cref="RulesEngineConfigurationSource"/>.
    /// </summary>
    [ResourceDescription(typeof(Resources), "RulesEngineConfigurationSourceElementDescription")]
    [ResourceDisplayName(typeof(Resources), "RulesEngineConfigurationSourceElementDisplayName")]
    [Browsable(true)]
    [EnvironmentalOverrides(false)]
    public class RulesEngineConfigurationSourceElement : ConfigurationSourceElement
    {
        /// <summary>
        /// The name of the configuration parameter in the appSettings section of app.config containing a name of the BRE policy
        /// responsible for returning the application configuration settings.
        /// </summary>
        private const string ConfigPolicyNameProperty = "policyName";

        /// <summary>
        /// The name of the configuration parameter in the appSettings section of app.config containing a version number of the BRE policy
        /// responsible for returning the application configuration settings.
        /// </summary>
        private const string ConfigPolicyVersionProperty = "policyVersion";

        /// <summary>
        /// Initializes a new instance of the RulesEngineConfigurationSourceElement class with a default name and default BRE policy settings.
        /// </summary>
        public RulesEngineConfigurationSourceElement() : this(Resources.RulesEngineConfigurationSourceName, String.Empty, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RulesEngineConfigurationSourceElement class with a name and an path.
        /// </summary>
        /// <param name="name">The instance name.</param>
        /// <param name="configPolicy">The BRE policy which will be invoked to retrieve the configuration data.</param>
        /// <param name="configVersion">The version of the BRE policy which will be invoked to retrieve the configuration data.</param>
        public RulesEngineConfigurationSourceElement(string name, string configPolicy, Version configVersion) : base(name, typeof(RulesEngineConfigurationSource))
        {
            this.ConfigPolicy = configPolicy;
            this.ConfigVersion = configVersion;
        }

        /// <summary>
        /// Gets or sets the name of the BRE policy. This is a required field.
        /// </summary>
        [ConfigurationProperty(ConfigPolicyNameProperty, IsRequired = true)]
        [ResourceDescription(typeof(Resources), "RulesEngineConfigurationSourceElementConfigPolicyDescription")]
        [ResourceDisplayName(typeof(Resources), "RulesEngineConfigurationSourceElementConfigPolicyDisplayName")]
        public string ConfigPolicy
        {
            get { return (string)this[ConfigPolicyNameProperty]; }
            set { this[ConfigPolicyNameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the version of the BRE policy. This is a required field.
        /// </summary>
        [ConfigurationProperty(ConfigPolicyVersionProperty, IsRequired = false)]
        [ResourceDescription(typeof(Resources), "RulesEngineConfigurationSourceElementConfigVersionDescription")]
        [ResourceDisplayName(typeof(Resources), "RulesEngineConfigurationSourceElementConfigVersionDisplayName")]
        [TypeConverter(typeof(VersionTypeConverter))]
        public Version ConfigVersion
        {
            get { return (Version)this[ConfigPolicyVersionProperty]; }
            set { this[ConfigPolicyVersionProperty] = value; }
        }

        /// <summary>
        /// Returns a new RulesEngineConfigurationSource configured with the specified settings.
        /// </summary>
        /// <returns>A new configuration source.</returns>
        public override IConfigurationSource CreateSource()
        {
            return new RulesEngineConfigurationSource(ConfigPolicy, ConfigVersion);
        }

        ///<summary>
        /// Returns a new <see cref="IDesignConfigurationSource"/> configured based on this configuration element.
        ///</summary>
        /// <param name="rootSource">The object that is used by Enterprise Library at design time and provides the ability to retrieve, add, and remove sections.</param>
        ///<returns>Returns a new <see cref="IDesignConfigurationSource"/> or null if this source does not have design-time support.</returns>
        public override IDesignConfigurationSource CreateDesignSource(IDesignConfigurationSource rootSource)
        {
            return null;
        }
    }
}
