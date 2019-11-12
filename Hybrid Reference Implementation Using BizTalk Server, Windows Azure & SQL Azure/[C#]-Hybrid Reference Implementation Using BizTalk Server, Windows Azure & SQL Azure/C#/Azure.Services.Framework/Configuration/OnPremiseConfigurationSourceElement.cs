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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Configuration
{
    #region Using references
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Globalization;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;

    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Represents the configuration settings that describe a OnPremiseConfigurationSourceElement.
    /// </summary>
    [ResourceDescription(typeof(Resources), "OnPremiseConfigurationSourceElementDescription")]
    [ResourceDisplayName(typeof(Resources), "OnPremiseConfigurationSourceElementDisplayName")]
    [Browsable(true)]
    [EnvironmentalOverrides(false)]
    public class OnPremiseConfigurationSourceElement : ConfigurationSourceElement
    {
        /// <summary>
        /// The name of the configuration parameter in app.config containing the Azure Service Bus service namespace.
        /// </summary>
        private const string ServiceNamespaceProperty = "serviceNamespace";

        /// <summary>
        /// The name of the configuration parameter in app.config containing the Azure Service Bus service path.
        /// </summary>
        private const string ServicePathProperty = "servicePath";

        /// <summary>
        /// The name of the configuration parameter in app.config defining whether or not the usage of the default service bus endpoint is permitted.
        /// </summary>
        private const string UseDefaultServiceBusEndpointProperty = "useDefaultServiceBusEndpoint";

        /// <summary>
        /// The name of the configuration parameter in app.config defining the name of a Service Bus endpoint.
        /// </summary>
        private const string ServiceBusEndpointProperty = "serviceBusEndpoint";

        /// <summary>
        /// Initializes a new instance of the OnPremiseConfigurationSourceElement class with a default name.
        /// </summary>
        public OnPremiseConfigurationSourceElement() : base(Resources.OnPremiseConfigurationSourceName, typeof(OnPremiseConfigurationSource))
        {
        }

        /// <summary>
        /// Gets or sets the value of the Azure Service Bus service namespace. This is a required field.
        /// </summary>
        [ConfigurationProperty(ServiceNamespaceProperty, IsRequired = false)]
        [ResourceDisplayName(typeof(Resources), "OnPremiseConfigurationSourceElementServiceNamespaceDisplayName")]
        [ResourceDescription(typeof(Resources), "OnPremiseConfigurationSourceElementServiceNamespaceDescription")]
        public string ServiceNamespace
        {
            get { return (string)this[ServiceNamespaceProperty]; }
            set { this[ServiceNamespaceProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the value of the Azure Service Bus service path. This is an optional field.
        /// </summary>
        [ConfigurationProperty(ServicePathProperty, IsRequired = false)]
        [ResourceDisplayName(typeof(Resources), "OnPremiseConfigurationSourceElementServicePathDisplayName")]
        [ResourceDescription(typeof(Resources), "OnPremiseConfigurationSourceElementServicePathDescription")]
        public string ServicePath
        {
            get { return (string)this[ServicePathProperty]; }
            set { this[ServicePathProperty] = value; }
        }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the usage of the default service bus endpoint is permitted.
        /// </summary>
        [ConfigurationProperty(UseDefaultServiceBusEndpointProperty, IsRequired = false, DefaultValue = true)]
        [ResourceDisplayName(typeof(Resources), "OnPremiseConfigurationSourceElementUseDefaultServiceBusEndpointDisplayName")]
        [ResourceDescription(typeof(Resources), "OnPremiseConfigurationSourceElementUseDefaultServiceBusEndpointDescription")]
        public bool UseDefaultServiceBusEndpoint
        {
            get { return Convert.ToBoolean(this[UseDefaultServiceBusEndpointProperty]); }
            set { this[UseDefaultServiceBusEndpointProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the value of the configuration parameter in app.config defining the name of a Service Bus endpoint. This is an optional field.
        /// </summary>
        [ConfigurationProperty(ServiceBusEndpointProperty, IsRequired = false)]
        [ResourceDisplayName(typeof(Resources), "OnPremiseConfigurationSourceElementServiceBusEndpointDisplayName")]
        [ResourceDescription(typeof(Resources), "OnPremiseConfigurationSourceElementServiceBusEndpointDescription")]
        public string ServiceBusEndpoint
        {
            get { return (string)this[ServiceBusEndpointProperty]; }
            set { this[ServiceBusEndpointProperty] = value; }
        }

        /// <summary>
        /// Returns a new OnPremiseConfigurationSource configured with the specified settings.
        /// </summary>
        /// <returns>A new configuration source.</returns>
        public override IConfigurationSource CreateSource()
        {
            // The initial configuration containing the Service Bus endpoint information is expected to be defined in app.config.
            string configFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            
            SystemConfigurationSource systemConfig = new SystemConfigurationSource();
            ServiceBusConfigurationSettings serviceBusConfig = systemConfig.GetSection(ServiceBusConfigurationSettings.SectionName) as ServiceBusConfigurationSettings;

            if (serviceBusConfig != null)
            {
                ServiceBusEndpointInfo defaultEndpointInfo = UseDefaultServiceBusEndpoint ? serviceBusConfig.Endpoints[serviceBusConfig.DefaultEndpoint] : serviceBusConfig.Endpoints[ServiceBusEndpoint];
                if (defaultEndpointInfo != null)
                {
                    return new OnPremiseConfigurationSource(defaultEndpointInfo);
                }
                else
                {
                    if (UseDefaultServiceBusEndpoint)
                    {
                        throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.DefaultServiceBusEndpointNotFound, configFileName, ServiceBusConfigurationSettings.SectionName));
                    }
                    else
                    {
                        throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.SpecifiedServiceBusEndpointNotFoundInConfigFile, configFileName, ServiceBusConfigurationSettings.SectionName, ServiceBusEndpoint));
                    }
                }
            }
            else
            {
                throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigFile, configFileName, ServiceBusConfigurationSettings.SectionName));
            }
        }

        /// <summary>
        /// Returns a new <see cref="IDesignConfigurationSource"/> configured based on this configuration element.
        /// </summary>
        /// <param name="rootSource">The object that is used by Enterprise Library at design time and provides the ability to retrieve, add, and remove sections.</param>
        /// <returns>Returns a new <see cref="IDesignConfigurationSource"/> or null if this source does not have design-time support.</returns>
        public override IDesignConfigurationSource CreateDesignSource(IDesignConfigurationSource rootSource)
        {
            return null;
        }
    }
}
