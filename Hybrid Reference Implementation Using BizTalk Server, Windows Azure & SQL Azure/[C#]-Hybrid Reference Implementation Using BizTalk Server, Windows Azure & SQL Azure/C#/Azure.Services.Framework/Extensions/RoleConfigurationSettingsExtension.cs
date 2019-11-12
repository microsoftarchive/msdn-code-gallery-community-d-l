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
    using System.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Data;
    #endregion

    #region IRoleConfigurationSettingsExtension interface
    /// <summary>
    /// Defines a contract that must be supported by an extension responsible for abstracting access to the application configuration.
    /// </summary>
    public interface IRoleConfigurationSettingsExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns the retry policy defined in the application configuration and assigned to all communications with the Service Bus.
        /// </summary>
        RetryPolicy CommunicationRetryPolicy { get; }

        /// <summary>
        /// Returns the retry policy defined in the application configuration and assigned to all operations with the Windows Azure storage.
        /// </summary>
        RetryPolicy StorageRetryPolicy { get; }

        /// <summary>
        /// Returns the retry policy defined in the application configuration and assigned to handle databases operations in SQL Azure.
        /// </summary>
        RetryPolicy DatabaseRetryPolicy { get; }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration as default.
        /// </summary>
        ServiceBusEndpointInfo DefaultServiceBusEndpoint { get; }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration and assigned for one-way communication with the on-premises services.
        /// </summary>
        ServiceBusEndpointInfo OnPremiseRelayOneWayEndpoint { get; }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration and assigned for two-way communication with the on-premises services.
        /// </summary>
        ServiceBusEndpointInfo OnPremiseRelayTwoWayEndpoint { get; }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration under the specified name.
        /// </summary>
        /// <param name="endpointName">The name of the Service Bus endpoint definition.</param>
        /// <returns>An object holding the Service Bus endpoint information.</returns>
        ServiceBusEndpointInfo GetServiceBusEndpoint(string endpointName);

        /// <summary>
        /// Returns a database connection string defined in the application configuration under the specified name.
        /// </summary>
        /// <param name="name">The name of the SQL connection string definition</param>
        /// <returns>The connection string defined in the application configuration under the specified name.</returns>
        string GetConnectionString(string name);

        /// <summary>
        /// Retrieves the specified configuration section by its name. 
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <typeparam name="T">The type representing the configuration section in the configuration object model.</typeparam>
        /// <returns>An instance of the specified configuration section, or null reference if a section by that name is not found.</returns>
        T GetSection<T>(string sectionName) where T : ConfigurationSection;

        /// <summary>
        /// Retrieves a configuration section defined by the fully-qualified name of its holding type T.
        /// </summary>
        /// <typeparam name="T">The type representing the configuration section in the configuration object model.</typeparam>
        /// <returns>An instance of the specified configuration section, or null reference if a section by that name is not found.</returns>
        T GetSection<T>() where T : ConfigurationSection;
   }
    #endregion

    /// <summary>
    /// Implements the extension responsible for abstracting access to the application configuration from role instances.
    /// </summary>
    public class RoleConfigurationSettingsExtension : IRoleConfigurationSettingsExtension
    {
        #region IRoleConfigurationSettingsExtension implementation
        /// <summary>
        /// Returns the retry policy defined in the application configuration and assigned to all communications with the Service Bus.
        /// </summary>
        public RetryPolicy CommunicationRetryPolicy 
        {
            get
            {
                RetryPolicyConfigurationSettings retryPolicySettings = GetSection<RetryPolicyConfigurationSettings>(RetryPolicyConfigurationSettings.SectionName);
                return retryPolicySettings != null && !String.IsNullOrEmpty(retryPolicySettings.DefaultCommunicationPolicy) ? RetryPolicyFactory.GetRetryPolicy<ServiceBusTransientErrorDetectionStrategy>(retryPolicySettings.DefaultCommunicationPolicy) : RetryPolicy.NoRetry;
            }
        }

        /// <summary>
        /// Returns the retry policy defined in the application configuration and assigned to all operations with the Windows Azure storage.
        /// </summary>
        public RetryPolicy StorageRetryPolicy 
        {
            get
            {
                RetryPolicyConfigurationSettings retryPolicySettings = GetSection<RetryPolicyConfigurationSettings>(RetryPolicyConfigurationSettings.SectionName);
                return retryPolicySettings != null && !String.IsNullOrEmpty(retryPolicySettings.DefaultStoragePolicy) ? RetryPolicyFactory.GetRetryPolicy<StorageTransientErrorDetectionStrategy>(retryPolicySettings.DefaultStoragePolicy) : RetryPolicy.NoRetry;
            }
        }

        /// <summary>
        /// Returns the retry policy defined in the application configuration and assigned to handle databases operations in SQL Azure.
        /// </summary>
        public RetryPolicy DatabaseRetryPolicy
        {
            get
            {
                RetryPolicyConfigurationSettings retryPolicySettings = GetSection<RetryPolicyConfigurationSettings>(RetryPolicyConfigurationSettings.SectionName);
                return retryPolicySettings != null && !String.IsNullOrEmpty(retryPolicySettings.DefaultSqlConnectionPolicy) ? RetryPolicyFactory.GetRetryPolicy<SqlAzureTransientErrorDetectionStrategy>(retryPolicySettings.DefaultSqlConnectionPolicy) : RetryPolicy.NoRetry;
            }
        }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration as default.
        /// </summary>
        public ServiceBusEndpointInfo DefaultServiceBusEndpoint
        {
            get { return ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[ApplicationConfiguration.Current.ServiceBusSettings.DefaultEndpoint]; }
        }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration and assigned for one-way communication with the on-premises services.
        /// </summary>
        public ServiceBusEndpointInfo OnPremiseRelayOneWayEndpoint 
        {
            get { return ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[WellKnownEndpointName.GenericCloudRequestOnRamp]; }
        }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration and assigned for two-way communication with the on-premises services.
        /// </summary>
        public ServiceBusEndpointInfo OnPremiseRelayTwoWayEndpoint
        {
            get { return ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[WellKnownEndpointName.GenericCloudRequestResponseOnRamp]; }
        }

        /// <summary>
        /// Returns a Service Bus endpoint defined in the application configuration under the specified name.
        /// </summary>
        /// <param name="endpointName">The name of the Service Bus endpoint definition.</param>
        /// <returns>An object holding the Service Bus endpoint information.</returns>
        public ServiceBusEndpointInfo GetServiceBusEndpoint(string endpointName)
        {
            return !String.IsNullOrEmpty(endpointName) ? ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[endpointName] : DefaultServiceBusEndpoint;
        }

        /// <summary>
        /// Retrieves the specified configuration section by its name. 
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <typeparam name="T">The type representing the configuration section in the configuration object model.</typeparam>
        /// <returns>An instance of the specified configuration section, or null reference if a section by that name is not found.</returns>
        public T GetSection<T>(string sectionName) where T : ConfigurationSection
        {
            return ApplicationConfiguration.Current.GetConfigurationSection<T>(sectionName);
        }

        /// <summary>
        /// Retrieves a configuration section defined by the fully-qualified name of its holding type T.
        /// </summary>
        /// <typeparam name="T">The type representing the configuration section in the configuration object model.</typeparam>
        /// <returns>An instance of the specified configuration section, or null reference if a section by that name is not found.</returns>
        public T GetSection<T>() where T : ConfigurationSection
        {
            return GetSection<T>(typeof(T).AssemblyQualifiedName);
        }

        /// <summary>
        /// Returns a database connection string defined in the application configuration under the specified name.
        /// </summary>
        /// <param name="name">The name of the SQL connection string definition</param>
        /// <returns>The connection string defined in the application configuration under the specified name.</returns>
        public string GetConnectionString(string name)
        {
            return ApplicationConfiguration.Current.Databases.ConnectionStrings[name];
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
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
