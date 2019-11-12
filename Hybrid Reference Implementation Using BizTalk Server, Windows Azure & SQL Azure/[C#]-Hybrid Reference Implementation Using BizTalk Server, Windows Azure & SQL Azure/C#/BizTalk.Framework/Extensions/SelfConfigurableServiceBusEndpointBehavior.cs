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
namespace Contoso.Cloud.Integration.BizTalk.Core.Extensions
{
    #region Using statements
    using System;
    using System.Configuration;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a WCF endpoint behavior extension responsible for configuring the Windows Azure Service Bus binding at runtime.
    /// </summary>
    public class SelfConfigurableServiceBusEndpointBehavior : IEndpointBehavior
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SelfConfigurableServiceBusEndpointBehavior"/> class.
        /// </summary>
        /// <param name="endpointName">The name of the Windows Azure Service Bus endpoint definition in the application configuration.</param>
        public SelfConfigurableServiceBusEndpointBehavior(string endpointName)
        {
            ServiceBusEndpointName = endpointName;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the value of the mandatory property containing the name of the Windows Azure Service Bus endpoint
        /// definition in the application configuration.
        /// </summary>
        public string ServiceBusEndpointName
        {
            get;
            private set;
        }
        #endregion

        #region IEndpointBehavior implementation
        /// <summary>
        /// Enables to pass data at runtime to bindings to support custom behavior.
        /// </summary>
        /// <param name="endpoint">The endpoint to modify.</param>
        /// <param name="bindingParameters">The objects that binding elements require to support the behavior.</param>
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // Validate input parameters.
            Guard.ArgumentNotNull(endpoint, "endpoint");

            // Trace the method entry event.
            var callToken = TraceManager.CustomComponent.TraceIn(endpoint.Name, endpoint.ListenUri);

            // Get the Service Bus endpoint definition by its name from the current application configuration.
            // TODO: Check if config is not null
            ServiceBusEndpointInfo sbEndpointInfo = ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[ServiceBusEndpointName];

            // Check if we found a definition.
            if (sbEndpointInfo != null)
            {
                // Trace an information event telling that we have found the Service Bus endpoint definition.
                TraceManager.CustomComponent.TraceInfo(TraceLogMessages.ApplyingServiceBusEndpointConfiguration, ServiceBusEndpointName, endpoint.Name, sbEndpointInfo.ServiceNamespace, sbEndpointInfo.ServicePath, sbEndpointInfo.EndpointType);

                // Look for a TransportClientEndpointBehavior implementation in the collection of registered behaviors.
                var credentialsBehaviour = endpoint.Behaviors.Find<TransportClientEndpointBehavior>();

                // Check if TransportClientEndpointBehavior was registered.
                if (credentialsBehaviour != null)
                {
                    // Configure the TransportClientEndpointBehavior with credentials captured from the application configuration.
                    credentialsBehaviour.CredentialType = TransportClientCredentialType.SharedSecret;
                    credentialsBehaviour.Credentials.SharedSecret.IssuerName = sbEndpointInfo.IssuerName;
                    credentialsBehaviour.Credentials.SharedSecret.IssuerSecret = sbEndpointInfo.IssuerSecret;

                    // Check if we need to perform any changes at the WCF binding level.
                    var relayBinding = endpoint.Binding as NetTcpRelayBinding;

                    // If it is a NetTcpRelayBinding, we need to ensure that its ConnectionMode property matches the one defined in the application configuration.
                    if (relayBinding != null)
                    {
                        // Configure ConnectionMode with the value from the ServiceBusEndpointInfo configuration object.
                        switch (sbEndpointInfo.EndpointType)
                        {
                            case ServiceBusEndpointType.Relay:
                                relayBinding.ConnectionMode = TcpRelayConnectionMode.Relayed;
                                break;
                            case ServiceBusEndpointType.HybridRelay:
                                relayBinding.ConnectionMode = TcpRelayConnectionMode.Hybrid;
                                break;
                        }
                    }
                }
            }
            else
            {
                // Trace a warning event, do not throw an exception as Service Bus binding will report on missing credentials anyway.
                TraceManager.CustomComponent.TraceWarning(TraceLogMessages.ServiceBusEndpointDefinitionNotFound, ServiceBusEndpointName);
            }

            // Trace an event indicating that we are done.
            TraceManager.CustomComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Enables modifications or extensions of the client across an endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint that is to be customized.</param>
        /// <param name="clientRuntime">The client runtime to be customized.</param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            // No implementation is required.
        }

        /// <summary>
        /// Enables modifications or extensions of the service across an endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint that exposes the contract.</param>
        /// <param name="endpointDispatcher">The endpoint dispatcher to be modified or extended.</param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // No implementation is required.
        }

        /// <summary>
        /// Enables to validate and confirm that the endpoint meets some intended criteria.
        /// </summary>
        /// <param name="endpoint">The endpoint to validate.</param>
        public void Validate(ServiceEndpoint endpoint)
        {
            // Validate input parameters.
            Guard.ArgumentNotNull(endpoint, "endpoint");

            // Trace the method entry event.
            var callToken = TraceManager.CustomComponent.TraceIn(endpoint.Name, endpoint.ListenUri);

            // Look for a TransportClientEndpointBehavior implementation in the collection of registered behaviors.
            var credentialsBehaviour = endpoint.Behaviors.Find<TransportClientEndpointBehavior>();

            // If not found, create a new instance of TransportClientEndpointBehavior and register it in the behavior collection.
            if (null == credentialsBehaviour)
            {
                endpoint.Behaviors.Add(new TransportClientEndpointBehavior());
            }

            // Trace an event indicating that we are done.
            TraceManager.CustomComponent.TraceOut(callToken);
        }
        #endregion
    }
}