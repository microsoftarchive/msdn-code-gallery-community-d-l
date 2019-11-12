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
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.Collections.Concurrent;

    using Microsoft.ServiceBus;
    #endregion

    /// <summary>
    /// Enables discovering and applying service endpoint configuration at runtime.
    /// </summary>
    public static class ServiceEndpointConfiguration
    {
        #region Private members
        private static readonly BlockingCollection<DiscoveryClientRegistration> discoveryClients = new BlockingCollection<DiscoveryClientRegistration>();
        #endregion

        #region Public members
        /// <summary>
        /// Returns the default time interval for a connection to open before the transport raises an exception.
        /// </summary>
        public const int DefaultOpenTimeoutSeconds = 60;

        /// <summary>
        /// Returns the default time interval for a connection to close before the transport raises an exception.
        /// </summary>
        public const int DefaultCloseTimeoutSeconds = 60;

        /// <summary>
        /// Returns the default time interval indicating how long a connection can remain inactive with no application messages being received before it is dropped.
        /// </summary>
        public const int DefaultReceiveTimeoutSeconds = 60;

        /// <summary>
        /// Returns the default time interval indicating how long a write operation can remain active before the transport raises an exception.
        /// </summary>
        public const int DefaultSendTimeoutSeconds = 60;

        /// <summary>
        /// Returns the default maximum allowable message size that can be received.
        /// </summary>
        public const int DefaultMaxReceivedMessageSize = Int32.MaxValue;

        /// <summary>
        /// Returns the default maximum size of any buffer pools used by the transport. 
        /// </summary>
        public const int DefaultMaxBufferPoolSize = Int32.MaxValue;

        /// <summary>
        /// Returns the default value that specifies the maximum size, in bytes, of the buffer used to store messages in memory.
        /// </summary>
        public const int DefaultMaxBufferSize = Int32.MaxValue;

        /// <summary>
        /// Returns the default maximum allowed array length.
        /// </summary>
        public const int DefaultReaderQuotasMaxArrayLength = Int32.MaxValue;

        /// <summary>
        /// Returns the default maximum allowed bytes returned for each read.
        /// </summary>
        public const int DefaultReaderQuotasMaxBytesPerRead = Int32.MaxValue;

        /// <summary>
        /// Returns the default maximum nested node depth.
        /// </summary>
        public const int DefaultReaderQuotasMaxDepth = Int32.MaxValue;

        /// <summary>
        /// Returns the default maximum characters allowed in a table name.
        /// </summary>
        public const int DefaultReaderQuotasMaxNameTableCharCount = Int32.MaxValue;

        /// <summary>
        /// Returns the default maximum string length returned by the reader.
        /// </summary>
        public const int DefaultReaderQuotasMaxStringContentLength = Int32.MaxValue;

        /// <summary>
        /// Returns the default transfer mode which indicates whether a channel uses streamed or buffered modes for the transfer of request and response messages.
        /// </summary>
        public const TransferMode DefaultTransferMode = TransferMode.Buffered;

        /// <summary>
        /// Returns the default connection mode for Windows Azure Service Bus.
        /// </summary>
        public const TcpRelayConnectionMode DefaultRelayConnectionMode = TcpRelayConnectionMode.Relayed;
        #endregion

        #region Public methods
        /// <summary>
        /// Registers a client subscription acting as an observer for all service endpoints that are relayed to the <see cref="ServiceEndpointConfiguration"/> object for initialization.
        /// </summary>
        /// <param name="discoveryClient">The instance of an object implementing the IObserver interface receiving notifications whenever a <see cref="System.ServiceModel.Description.ServiceEndpoint"/> is being configured.</param>
        /// <returns>A disposable client subscription that can be used to cancel the notifications.</returns>
        public static IDisposable RegisterDiscoveryClient(IObserver<ServiceEndpoint> discoveryClient)
        {
            DiscoveryClientRegistration registration = new DiscoveryClientRegistration(discoveryClient);
            discoveryClients.Add(registration);

            return registration;
        }

        /// <summary>
        /// Configures default settings for the specified instance of the <see cref="System.ServiceModel.Description.ServiceEndpoint"/> object.
        /// In addition, notifies all registered endpoint configuration discovery clients and let them override the endpoint configuration.
        /// </summary>
        /// <param name="endpoint">The service endpoint to be configured.</param>
        public static void ConfigureDefaults(ServiceEndpoint endpoint)
        {
            Guard.ArgumentNotNull(endpoint, "endpoint");

            // Apply general environmental settings.
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.AutoDetect;

            // Apply default binding configuration.
            ConfigureDefaults(endpoint.Binding);

            // Notify all registered endpoint configuration discovery clients.
            NotifyDiscoveryClients(endpoint);
        }

        /// <summary>
        /// Configures default settings for the specified generic WCF binding.
        /// </summary>
        /// <param name="binding">The WCF transport binding to be configured.</param>
        public static void ConfigureDefaults(Binding binding)
        {
            Guard.ArgumentNotNull(binding, "binding");

            // Apply NetOnewayRelayBinding-specific default configuration.
            if (binding is NetOnewayRelayBinding)
            {
                ConfigureDefaults(binding as NetOnewayRelayBinding);
                return;
            }

            // Apply NetTcpRelayBinding-specific default configuration.
            if (binding is NetTcpRelayBinding)
            {
                ConfigureDefaults(binding as NetTcpRelayBinding);
                return;
            }

            // Apply BasicHttpBinding-specific default configuration.
            if (binding is BasicHttpBinding)
            {
                ConfigureDefaults(binding as BasicHttpBinding);
                return;
            }
        }

        /// <summary>
        /// Configures default settings for the specified <see cref="Microsoft.ServiceBus.NetOnewayRelayBinding"/> binding.
        /// </summary>
        /// <param name="eventRelayBinding">The Service Bus transport binding to be configured.</param>
        public static void ConfigureDefaults(NetOnewayRelayBinding eventRelayBinding)
        {
            Guard.ArgumentNotNull(eventRelayBinding, "eventRelayBinding");

            eventRelayBinding.OpenTimeout = TimeSpan.FromSeconds(DefaultOpenTimeoutSeconds);
            eventRelayBinding.CloseTimeout = TimeSpan.FromSeconds(DefaultCloseTimeoutSeconds);
            eventRelayBinding.ReceiveTimeout = TimeSpan.FromSeconds(DefaultReceiveTimeoutSeconds);
            eventRelayBinding.SendTimeout = TimeSpan.FromSeconds(DefaultSendTimeoutSeconds);

            eventRelayBinding.MaxReceivedMessageSize = DefaultMaxReceivedMessageSize;
            eventRelayBinding.MaxBufferPoolSize = DefaultMaxBufferPoolSize;
            eventRelayBinding.MaxBufferSize = DefaultMaxBufferSize;

            eventRelayBinding.ReaderQuotas.MaxArrayLength = DefaultReaderQuotasMaxArrayLength;
            eventRelayBinding.ReaderQuotas.MaxBytesPerRead = DefaultReaderQuotasMaxBytesPerRead;
            eventRelayBinding.ReaderQuotas.MaxDepth = DefaultReaderQuotasMaxDepth;
            eventRelayBinding.ReaderQuotas.MaxNameTableCharCount = DefaultReaderQuotasMaxNameTableCharCount;
            eventRelayBinding.ReaderQuotas.MaxStringContentLength = DefaultReaderQuotasMaxStringContentLength;
        }

        /// <summary>
        /// Configures default settings for the specified <see cref="Microsoft.ServiceBus.NetTcpRelayBinding"/> binding.
        /// </summary>
        /// <param name="relayBinding">The Service Bus transport binding to be configured.</param>
        public static void ConfigureDefaults(NetTcpRelayBinding relayBinding)
        {
            Guard.ArgumentNotNull(relayBinding, "relayBinding");

            relayBinding.TransferMode = DefaultTransferMode;
            relayBinding.ConnectionMode = DefaultRelayConnectionMode;

            relayBinding.OpenTimeout = TimeSpan.FromSeconds(DefaultOpenTimeoutSeconds);
            relayBinding.CloseTimeout = TimeSpan.FromSeconds(DefaultCloseTimeoutSeconds);
            relayBinding.ReceiveTimeout = TimeSpan.FromSeconds(DefaultReceiveTimeoutSeconds);
            relayBinding.SendTimeout = TimeSpan.FromSeconds(DefaultSendTimeoutSeconds);

            relayBinding.MaxReceivedMessageSize = DefaultMaxReceivedMessageSize;
            relayBinding.MaxBufferPoolSize = DefaultMaxBufferPoolSize;
            relayBinding.MaxBufferSize = DefaultMaxBufferSize;

            relayBinding.ReaderQuotas.MaxArrayLength = DefaultReaderQuotasMaxArrayLength;
            relayBinding.ReaderQuotas.MaxBytesPerRead = DefaultReaderQuotasMaxBytesPerRead;
            relayBinding.ReaderQuotas.MaxDepth = DefaultReaderQuotasMaxDepth;
            relayBinding.ReaderQuotas.MaxNameTableCharCount = DefaultReaderQuotasMaxNameTableCharCount;
            relayBinding.ReaderQuotas.MaxStringContentLength = DefaultReaderQuotasMaxStringContentLength;
        }

        /// <summary>
        /// Configures default settings for the specified <see cref="System.ServiceModel.BasicHttpBinding"/> binding.
        /// </summary>
        /// <param name="httpBinding">The HTTP transport binding to be configured.</param>
        public static void ConfigureDefaults(BasicHttpBinding httpBinding)
        {
            Guard.ArgumentNotNull(httpBinding, "httpBinding");

            httpBinding.OpenTimeout = TimeSpan.FromSeconds(DefaultOpenTimeoutSeconds);
            httpBinding.CloseTimeout = TimeSpan.FromSeconds(DefaultCloseTimeoutSeconds);
            httpBinding.ReceiveTimeout = TimeSpan.FromSeconds(DefaultReceiveTimeoutSeconds);
            httpBinding.SendTimeout = TimeSpan.FromSeconds(DefaultSendTimeoutSeconds);

            httpBinding.MaxReceivedMessageSize = DefaultMaxReceivedMessageSize;
            httpBinding.MaxBufferPoolSize = DefaultMaxBufferPoolSize;
            httpBinding.MaxBufferSize = DefaultMaxBufferSize;

            httpBinding.Security.Mode = BasicHttpSecurityMode.None;
            httpBinding.TransferMode = TransferMode.Buffered;
        }
        #endregion

        #region Private methods
        private static void NotifyDiscoveryClients(ServiceEndpoint endpoint)
        {
            foreach (var registration in discoveryClients)
            {
                if (registration.IsActive)
                {
                    registration.Client.OnNext(endpoint);
                }
            }
        }
        #endregion

        #region DiscoveryClientRegistration class declaration
        private class DiscoveryClientRegistration : IDisposable
        {
            private readonly IObserver<ServiceEndpoint> client;
            private volatile bool disposed;

            public DiscoveryClientRegistration(IObserver<ServiceEndpoint> discoveryClient)
            {
                this.client = discoveryClient;
            }

            public bool IsActive
            {
                get { return !this.disposed; }
            }

            public IObserver<ServiceEndpoint> Client
            {
                get { return this.client; }
            }

            public void Dispose()
            {
                this.disposed = true;
            }
        } 
        #endregion
    }
}
