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
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration element describing a Windows Azure Service Bus endpoint.
    /// </summary>
    public sealed class ServiceBusEndpointInfo : NamedConfigurationElement
    {
        #region Private members
        private const string ServicePathProperty = "servicePath";
        private const string ServiceNamespaceProperty = "serviceNamespace";
        private const string EndpointTypeProperty = "endpointType";
        private const string IssuerNameProperty = "issuerName";
        private const string IssuerSecretProperty = "issuerSecret";
        private const string TopicNameProperty = "topicName";
        private const string QueueNameProperty = "queueName";
        private const string TransferModeProperty = "transferMode";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="ServiceBusEndpointInfo"/> object with default settings.
        /// </summary>
        public ServiceBusEndpointInfo() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ServiceBusEndpointInfo"/> object with the specified endpoint name and its location.
        /// The default connection mode for the new endpoint will be set to Relayed.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        public ServiceBusEndpointInfo(string endpointName, string serviceNamespace, string servicePath) : this(endpointName, serviceNamespace, servicePath, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ServiceBusEndpointInfo"/> object with the specified endpoint name, its location and authentication parameters.
        /// The default connection mode for the new endpoint will be set to Relayed.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        public ServiceBusEndpointInfo(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
            : this(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, ServiceBusEndpointType.Relay, ServiceBusTransferMode.Buffered)
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="ServiceBusEndpointInfo"/> object with the specified endpoint name, its location, authentication parameters
        /// and custom relay mode.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <param name="endpointType">The type of the endpoint.</param>
        /// <param name="transferMode">The message transfer mode for the endpoint.</param>
        public ServiceBusEndpointInfo(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret, ServiceBusEndpointType endpointType, ServiceBusTransferMode transferMode)
            : this()
        {
            Guard.ArgumentNotNullOrEmptyString(endpointName, "endpointName");
            Guard.ArgumentNotNullOrEmptyString(serviceNamespace, "serviceNamespace");
            Guard.ArgumentNotNullOrEmptyString(servicePath, "servicePath");

            Name = endpointName;
            ServiceNamespace = serviceNamespace;
            ServicePath = servicePath;
            IssuerName = issuerName;
            IssuerSecret = issuerSecret;
            EndpointType = endpointType;
            TransferMode = transferMode;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the service namespace name used by the endpoint.
        /// </summary>
        [ConfigurationProperty(ServiceNamespaceProperty, IsRequired = true)]
        public string ServiceNamespace
        {
            get { return (string)base[ServiceNamespaceProperty]; }
            set { base[ServiceNamespaceProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the service namespace name used by the endpoint.
        /// </summary>
        [ConfigurationProperty(ServicePathProperty, IsRequired = false)]
        public string ServicePath
        {
            get { return (string)base[ServicePathProperty]; }
            set { base[ServicePathProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the service identity configured in Access Control Service for the Windows Azure Service Bus namespace.
        /// </summary>
        [ConfigurationProperty(IssuerNameProperty, IsRequired = false)]
        public string IssuerName
        {
            get { return (string)base[IssuerNameProperty]; }
            set { base[IssuerNameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the key for the service identity configured in Access Control Service for the Windows Azure Service Bus namespace.
        /// </summary>
        [ConfigurationProperty(IssuerSecretProperty, IsRequired = false)]
        public string IssuerSecret
        {
            get { return (string)base[IssuerSecretProperty]; }
            set { base[IssuerSecretProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the topic endpoint in Windows Azure Service Bus.
        /// </summary>
        [ConfigurationProperty(TopicNameProperty, IsRequired = false)]
        public string TopicName
        {
            get { return (string)base[TopicNameProperty]; }
            set { base[TopicNameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the queue endpoint in Windows Azure Service Bus.
        /// </summary>
        [ConfigurationProperty(QueueNameProperty, IsRequired = false)]
        public string QueueName
        {
            get { return (string)base[QueueNameProperty]; }
            set { base[QueueNameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the type of the Windows Azure Service Bus endpoint.
        /// </summary>
        [ConfigurationProperty(EndpointTypeProperty, IsRequired = true)]
        public ServiceBusEndpointType EndpointType
        {
            get { return (ServiceBusEndpointType)base[EndpointTypeProperty]; }
            set { base[EndpointTypeProperty] = value; }
        }
        
        /// <summary>
        /// Gets or sets the message transfer mode for the endpoint.
        /// </summary>
        [ConfigurationProperty(TransferModeProperty, IsRequired = false)]
        public ServiceBusTransferMode TransferMode
        {
            get { return (ServiceBusTransferMode)base[TransferModeProperty]; }
            set { base[TransferModeProperty] = value; }
        }
        #endregion
    }
}
