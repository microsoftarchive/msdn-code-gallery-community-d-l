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
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Channels;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Provides a set of factory methods for creating instances of the Service Bus client communication channel.
    /// </summary>
    public static class ServiceBusClientFactory
    {
        #region Public methods
        /// <summary>
        /// Returns a client communication channel of type <typeparamref name="T"/> for communication with the specified Service Bus relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the client communication channel. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>An instance of the communication channel of a specified type that is bound to the specified endpoint.</returns>
        public static T CreateServiceBusRelayClient<T>(ServiceBusEndpointInfo sbEndpointInfo) where T: IClientChannel
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            return CreateServiceBusRelayClient<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret);
        }

        /// <summary>
        /// Returns a client communication channel of type <typeparamref name="T"/> for communication with the specified Service Bus relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the client communication channel. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
        /// <param name="serviceNamespace">The service namespace name used by the application.</param>
        /// <param name="servicePath">The service path that follows the host name section of the URI.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <returns>An instance of the communication channel of a specified type that is bound to the specified endpoint.</returns>
        public static T CreateServiceBusRelayClient<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret) where T : IClientChannel
        {
            var relayBinding = new NetTcpRelayBinding(EndToEndSecurityMode.None, RelayClientAuthenticationType.None);
            return CreateServiceBusClient<T>(serviceNamespace, servicePath, issuerName, issuerSecret, relayBinding);
        }

        /// <summary>
        /// Returns a client communication channel of type <typeparamref name="T"/> for communication with the specified Service Bus one-way event relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the client communication channel. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>An instance of the communication channel of a specified type that is bound to the specified endpoint.</returns>
        public static T CreateServiceBusEventRelayClient<T>(ServiceBusEndpointInfo sbEndpointInfo) where T : IClientChannel
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            return CreateServiceBusEventRelayClient<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret);
        }

        /// <summary>
        /// Returns a client communication channel of type <typeparamref name="T"/> for communication with the specified Service Bus one-way event relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the client communication channel. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
        /// <param name="serviceNamespace">The service namespace name used by the application.</param>
        /// <param name="servicePath">The service path that follows the host name section of the URI.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <returns>An instance of the communication channel of a specified type that is bound to the specified endpoint.</returns>
        public static T CreateServiceBusEventRelayClient<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret) where T : IClientChannel
        {
            var eventRelayBinding = new NetEventRelayBinding(EndToEndSecurityMode.None, RelayEventSubscriberAuthenticationType.None);
            return CreateServiceBusClient<T>(serviceNamespace, servicePath, issuerName, issuerSecret, eventRelayBinding);
        }

        /// <summary>
        /// Returns a client communication channel of type <typeparamref name="T"/> for communication with the specified Service Bus endpoint.
        /// The type of endpoint is determined from the endpoint details supplied in the <see cref="ServiceBusEndpointInfo"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of the client communication channel. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>An instance of the communication channel of a specified type that is bound to the specified endpoint.</returns>
        public static T CreateServiceBusClient<T>(ServiceBusEndpointInfo sbEndpointInfo) where T : IClientChannel
        {
            ChannelFactory<T> clientChannelFactory = CreateServiceBusClientChannelFactory<T>(sbEndpointInfo);
            return clientChannelFactory.CreateChannel();
        }

        /// <summary>
        /// Returns a client channel factory for type <typeparamref name="T"/> to be used for communication with the specified Service Bus endpoint.
        /// The type of endpoint is determined from the endpoint details supplied in the <see cref="ServiceBusEndpointInfo"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of the client communication channel. Must inherit from service contract as well as <see cref="System.ServiceModel.IClientChannel"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>An instance of the communication channel factory that will be used for creating a communication channel of specified type <typeparamref name="T"/>.</returns>
        public static ChannelFactory<T> CreateServiceBusClientChannelFactory<T>(ServiceBusEndpointInfo sbEndpointInfo) where T : IClientChannel
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            Binding binding = null;

            switch (sbEndpointInfo.EndpointType)
            {
                case ServiceBusEndpointType.Eventing:

                    binding = new NetEventRelayBinding(EndToEndSecurityMode.None, RelayEventSubscriberAuthenticationType.None);
                    break;

                case ServiceBusEndpointType.Relay:
                case ServiceBusEndpointType.HybridRelay:

                    NetTcpRelayBinding tcpRelayBinding = new NetTcpRelayBinding(EndToEndSecurityMode.None, RelayClientAuthenticationType.None);
                    tcpRelayBinding.ConnectionMode = (sbEndpointInfo.EndpointType == ServiceBusEndpointType.HybridRelay ? TcpRelayConnectionMode.Hybrid : TcpRelayConnectionMode.Relayed);
                    
                    switch(sbEndpointInfo.TransferMode)
                    {
                        case ServiceBusTransferMode.Buffered:
                            tcpRelayBinding.TransferMode = TransferMode.Buffered;
                            break;
                        case ServiceBusTransferMode.Streamed:
                            tcpRelayBinding.TransferMode = TransferMode.Streamed;
                            break;
                        case ServiceBusTransferMode.StreamedRequest:
                            tcpRelayBinding.TransferMode = TransferMode.StreamedRequest;
                            break;
                        case ServiceBusTransferMode.StreamedResponse:
                            tcpRelayBinding.TransferMode = TransferMode.StreamedResponse;
                            break;
                    }

                    binding = tcpRelayBinding;
                    break;

                default:
                    return null;
            }

            return CreateServiceBusClientChannelFactory<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret, binding);
        }
        #endregion

        #region Private methods
        private static T CreateServiceBusClient<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Binding binding)
        {
            ChannelFactory<T> clientChannelFactory = CreateServiceBusClientChannelFactory<T>(serviceNamespace, servicePath, issuerName, issuerSecret, binding);
            return clientChannelFactory.CreateChannel();
        }

        private static ChannelFactory<T> CreateServiceBusClientChannelFactory<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Binding binding)
        {
            Guard.ArgumentNotNullOrEmptyString(serviceNamespace, "serviceNamespace");
            Guard.ArgumentNotNullOrEmptyString(servicePath, "servicePath");
            Guard.ArgumentNotNullOrEmptyString(issuerName, "issuerName");
            Guard.ArgumentNotNullOrEmptyString(issuerSecret, "issuerSecret");
            Guard.ArgumentNotNull(binding, "binding");

            var callToken = TraceManager.DebugComponent.TraceIn(serviceNamespace, servicePath, binding.Name);

            var address = ServiceBusEnvironment.CreateServiceUri(WellKnownProtocolScheme.ServiceBus, serviceNamespace, servicePath);

            var credentialsBehaviour = new TransportClientEndpointBehavior();

            credentialsBehaviour.CredentialType = TransportClientCredentialType.SharedSecret;
            credentialsBehaviour.Credentials.SharedSecret.IssuerName = issuerName;
            credentialsBehaviour.Credentials.SharedSecret.IssuerSecret = issuerSecret;

            var endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(T)), binding, new EndpointAddress(address));
            endpoint.Behaviors.Add(credentialsBehaviour);

            // Apply default endpoint configuration.
            ServiceEndpointConfiguration.ConfigureDefaults(endpoint);

            ChannelFactory<T> clientChannelFactory = new ChannelFactory<T>(endpoint);

            TraceManager.DebugComponent.TraceOut(callToken, endpoint.Address.Uri);

            return clientChannelFactory;
        }
        #endregion
    }
}