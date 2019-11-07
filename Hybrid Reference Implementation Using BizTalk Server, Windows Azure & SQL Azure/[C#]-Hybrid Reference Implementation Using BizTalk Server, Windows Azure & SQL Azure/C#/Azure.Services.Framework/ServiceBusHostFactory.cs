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
    using System.Xml;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Channels;

    using Microsoft.ServiceBus;
    
    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Provides a set of factory methods for creating instances of the Service Bus hosts.
    /// </summary>
    public static class ServiceBusHostFactory
    {
        #region Public methods
        /// <summary>
        /// Returns a service host for the service contract of type <typeparamref name="T"/> listening on the specified relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusRelayHost<T>(ServiceBusEndpointInfo sbEndpointInfo)
        {
            return CreateServiceBusRelayHost(sbEndpointInfo, typeof(T));
        }

        /// <summary>
        /// Returns a service host for the service contract of type <paramref name="serviceType"/> listening on the specified relay endpoint.
        /// </summary>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <param name="serviceType">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusRelayHost(ServiceBusEndpointInfo sbEndpointInfo, Type serviceType)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");

            return CreateServiceBusRelayHost(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret, serviceType);
        }

        /// <summary>
        /// Returns a service host for the service contract of type <typeparamref name="T"/> listening on the specified relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</typeparam>
        /// <param name="serviceNamespace">The service namespace name used by the application.</param>
        /// <param name="servicePath">The service path that follows the host name section of the URI.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusRelayHost<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            return CreateServiceBusRelayHost(serviceNamespace, servicePath, issuerName, issuerSecret, typeof(T));
        }

        /// <summary>
        /// Returns a service host for the service contract of type <paramref name="serviceType"/> listening on the specified relay endpoint.
        /// </summary>
        /// <param name="serviceNamespace">The service namespace name used by the application.</param>
        /// <param name="servicePath">The service path that follows the host name section of the URI.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <param name="serviceType">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusRelayHost(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Type serviceType)
        {
            var relayBinding = new NetTcpRelayBinding(EndToEndSecurityMode.None, RelayClientAuthenticationType.None);
            return CreateServiceBusHost(serviceNamespace, servicePath, issuerName, issuerSecret, relayBinding, serviceType);
        }

        /// <summary>
        /// Returns a service host for the service contract of type <typeparamref name="T"/> listening on the specified one-way event relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusEventRelayHost<T>(ServiceBusEndpointInfo sbEndpointInfo)
        {
            return CreateServiceBusEventRelayHost<T>(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret);
        }

        /// <summary>
        /// Returns a service host for the service contract of type <paramref name="serviceType"/> listening on the specified one-way event relay endpoint.
        /// </summary>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <param name="serviceType">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusEventRelayHost(ServiceBusEndpointInfo sbEndpointInfo, Type serviceType)
        {
            return CreateServiceBusEventRelayHost(sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.IssuerName, sbEndpointInfo.IssuerSecret, serviceType);
        }

        /// <summary>
        /// Returns a service host for the service contract of type <typeparamref name="T"/> listening on the specified one-way event relay endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</typeparam>
        /// <param name="serviceNamespace">The service namespace name used by the application.</param>
        /// <param name="servicePath">The service path that follows the host name section of the URI.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusEventRelayHost<T>(string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            return CreateServiceBusEventRelayHost(serviceNamespace, servicePath, issuerName, issuerSecret, typeof(T));
        }

        /// <summary>
        /// Returns a service host for the service contract of type <paramref name="serviceType"/> listening on the specified one-way event relay endpoint.
        /// </summary>
        /// <param name="serviceNamespace">The service namespace name used by the application.</param>
        /// <param name="servicePath">The service path that follows the host name section of the URI.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <param name="serviceType">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusEventRelayHost(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Type serviceType)
        {
            var eventRelayBinding = new NetEventRelayBinding(EndToEndSecurityMode.None, RelayEventSubscriberAuthenticationType.None);
            return CreateServiceBusHost(serviceNamespace, servicePath, issuerName, issuerSecret, eventRelayBinding, serviceType);
        }

        /// <summary>
        /// Returns a service host for the service contract of type <typeparamref name="T"/> listening on the specified Service Bus endpoint.
        /// The type of endpoint is determined from the endpoint details supplied in the <see cref="ServiceBusEndpointInfo"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</typeparam>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusHost<T>(ServiceBusEndpointInfo sbEndpointInfo)
        {
            return CreateServiceBusHost(sbEndpointInfo, typeof(T));
        }

        /// <summary>
        /// Returns a service host for the service contract of type <paramref name="serviceType"/> listening on the specified Service Bus endpoint.
        /// The type of endpoint is determined from the endpoint details supplied in the <see cref="ServiceBusEndpointInfo"/> instance.
        /// </summary>
        /// <param name="sbEndpointInfo">The Service Bus endpoint details.</param>
        /// <param name="serviceType">The type of the service contract. Must be decorated with <see cref="System.ServiceModel.ServiceContractAttribute"/>.</param>
        /// <returns>A service host in the Created state that is initialized to listen on the specified endpoint.</returns>
        public static ServiceHost CreateServiceBusHost(ServiceBusEndpointInfo sbEndpointInfo, Type serviceType)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(serviceType, "serviceType");

            switch (sbEndpointInfo.EndpointType)
            {
                case ServiceBusEndpointType.Eventing:
                    return CreateServiceBusEventRelayHost(sbEndpointInfo, serviceType);

                case ServiceBusEndpointType.Relay:
                case ServiceBusEndpointType.HybridRelay:
                    return CreateServiceBusRelayHost(sbEndpointInfo, serviceType);

                default:
                    return null;
            }
        } 
        #endregion

        #region Private methods
        private static ServiceHost CreateServiceBusHost(string serviceNamespace, string servicePath, string issuerName, string issuerSecret, Binding binding, Type serviceType)
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

            var endpoint = new ServiceEndpoint(ContractDescription.GetContract(GetServiceContract(serviceType)), binding, new EndpointAddress(address));
            endpoint.Behaviors.Add(credentialsBehaviour);

            // Apply default endpoint configuration.
            ServiceEndpointConfiguration.ConfigureDefaults(endpoint);

            ServiceBehaviorAttribute serviceBehaviorAttr = FrameworkUtility.GetDeclarativeAttribute<ServiceBehaviorAttribute>(serviceType);
            ServiceHost host = null;

            if (serviceBehaviorAttr != null && serviceBehaviorAttr.InstanceContextMode == InstanceContextMode.Single)
            {
                host = new ServiceHost(Activator.CreateInstance(serviceType));
            }
            else
            {
                host = new ServiceHost(serviceType);
            }

            host.Description.Endpoints.Add(endpoint);
#if DEBUG
            var debugBehavior = new ServiceDebugBehavior();
            debugBehavior.IncludeExceptionDetailInFaults = true;

            host.Description.Behaviors.Remove<ServiceDebugBehavior>();
            host.Description.Behaviors.Add(debugBehavior);
#endif
            TraceManager.DebugComponent.TraceOut(callToken, endpoint.Address.Uri);

            return host;
        }

        private static Type GetServiceContract(Type serviceType)
        {
            Guard.ArgumentNotNull(serviceType, "serviceType");

            Type[] serviceInterfaces = serviceType.GetInterfaces();

            if (serviceInterfaces != null && serviceInterfaces.Length > 0)
            {
                foreach (Type serviceInterface in serviceInterfaces)
                {
                    ServiceContractAttribute serviceContractAttr = FrameworkUtility.GetDeclarativeAttribute<ServiceContractAttribute>(serviceInterface);

                    if (serviceContractAttr != null)
                    {
                        return serviceInterface;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
