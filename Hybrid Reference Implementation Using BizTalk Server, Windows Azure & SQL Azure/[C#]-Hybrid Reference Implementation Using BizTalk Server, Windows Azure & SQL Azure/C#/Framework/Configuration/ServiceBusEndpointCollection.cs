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
    /// Implements a collection of configuration elements describing Windows Azure Service Bus endpoints represented by <see cref="ServiceBusEndpointInfo"/> objects.
    /// </summary>
    public class ServiceBusEndpointCollection : NamedElementCollection<ServiceBusEndpointInfo>
    {
        #region Private members
        private readonly object lockObj = new object();
        internal ServiceBusConfigurationSettings Owner { private get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="ServiceBusEndpointCollection"/> object.
        /// </summary>
        public ServiceBusEndpointCollection()
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the Windows Azure Service Bus endpoint definition.
        /// </summary>
        /// <param name="name">The unique name under which the endpoint definition is registered in the collection.</param>
        /// <returns>The instance of the <see cref="ServiceBusEndpointInfo"/> object containing the endpoint definition, or a null reference if no such endpoint definition was found under the specified name.</returns>
        public new ServiceBusEndpointInfo this[string name]
        {
            get 
            { 
                ServiceBusEndpointInfo endpointInfo = Get(name);

                if (endpointInfo != null)
                {
                    if (String.IsNullOrEmpty(endpointInfo.IssuerName))
                    {
                        endpointInfo.IssuerName = Owner.DefaultIssuerName;
                    }

                    if (String.IsNullOrEmpty(endpointInfo.IssuerSecret))
                    {
                        endpointInfo.IssuerSecret = Owner.DefaultIssuerSecret;
                    }
                }

                return endpointInfo;
            }
            set 
            {
                if (Contains(name))
                {
                    lock (SyncRoot)
                    {
                        if (Contains(name))
                        {
                            Remove(name);
                        }
                        Add(value);
                    }
                }
                else
                {
                    Add(value);
                }
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new Windows Azure Service Bus endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        public void Add(string endpointName, string serviceNamespace, string servicePath)
        {
            InternalAdd(new ServiceBusEndpointInfo(endpointName, serviceNamespace, servicePath));
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus endpoint definition into the collection of endpoints. 
        /// Allows specifying the desired relay mode for the new endpoint.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="relayMode">The connection mode for the endpoint.</param>
        /// <param name="transferMode">The optional message transfer mode for the endpoint.</param>
        public void Add(string endpointName, string serviceNamespace, string servicePath, ServiceBusEndpointType relayMode, ServiceBusTransferMode transferMode = ServiceBusTransferMode.Buffered)
        {
            InternalAdd(new ServiceBusEndpointInfo(endpointName, serviceNamespace, servicePath, null, null, relayMode, transferMode));
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus endpoint definition into the collection of endpoints. 
        /// Allows specifying endpoint-specific security credentials in a form of issuer name and secret.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        public void Add(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            InternalAdd(new ServiceBusEndpointInfo(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret));
        }

        /// <summary>
        ///  Adds a new Windows Azure Service Bus endpoint definition into the collection of endpoints.
        ///  Allows specifying the desired relay mode as well as endpoint-specific security credentials in a form of issuer name and secret.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <param name="relayMode">The connection mode for the endpoint.</param>
        /// <param name="transferMode">The optional message transfer mode for the endpoint.</param>
        public void Add(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret, ServiceBusEndpointType relayMode, ServiceBusTransferMode transferMode = ServiceBusTransferMode.Buffered)
        {
            InternalAdd(new ServiceBusEndpointInfo(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, relayMode, transferMode));
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus relay endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        public void AddRelayEndpoint(string endpointName, string serviceNamespace, string servicePath)
        {
            Add(endpointName, serviceNamespace, servicePath, ServiceBusEndpointType.Relay, ServiceBusTransferMode.Buffered);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus relay endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="transferMode">The optional message transfer mode for the endpoint.</param>
        public void AddRelayEndpoint(string endpointName, string serviceNamespace, string servicePath, ServiceBusTransferMode transferMode)
        {
            Add(endpointName, serviceNamespace, servicePath, ServiceBusEndpointType.Relay, transferMode);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus relay endpoint definition into the collection of endpoints.
        /// Allows specifying endpoint-specific security credentials in a form of issuer name and secret.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        public void AddRelayEndpoint(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            Add(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, ServiceBusEndpointType.Relay, ServiceBusTransferMode.Buffered);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus relay endpoint definition into the collection of endpoints.
        /// Allows specifying endpoint-specific security credentials in a form of issuer name and secret.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <param name="transferMode">The optional message transfer mode for the endpoint.</param>
        public void AddRelayEndpoint(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret, ServiceBusTransferMode transferMode)
        {
            Add(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, ServiceBusEndpointType.Relay, transferMode);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus one-way multicast (event relay) endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        public void AddEventingEndpoint(string endpointName, string serviceNamespace, string servicePath)
        {
            Add(endpointName, serviceNamespace, servicePath, ServiceBusEndpointType.Eventing, ServiceBusTransferMode.Buffered);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus one-way multicast (event relay) endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="transferMode">The optional message transfer mode for the endpoint.</param>
        public void AddEventingEndpoint(string endpointName, string serviceNamespace, string servicePath, ServiceBusTransferMode transferMode)
        {
            Add(endpointName, serviceNamespace, servicePath, ServiceBusEndpointType.Eventing, transferMode);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus one-way multicast (event relay) endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        public void AddEventingEndpoint(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret)
        {
            Add(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, ServiceBusEndpointType.Eventing, ServiceBusTransferMode.Buffered);
        }

        /// <summary>
        /// Adds a new Windows Azure Service Bus one-way multicast (event relay) endpoint definition into the collection of endpoints.
        /// </summary>
        /// <param name="endpointName">The unique name under which the endpoint definition will be registered in the configuration.</param>
        /// <param name="serviceNamespace">The service namespace name used by the endpoint.</param>
        /// <param name="servicePath">The service path used by the endpoint.</param>
        /// <param name="issuerName">The issuer name.</param>
        /// <param name="issuerSecret">The issuer secret.</param>
        /// <param name="transferMode">The optional message transfer mode for the endpoint.</param>
        public void AddEventingEndpoint(string endpointName, string serviceNamespace, string servicePath, string issuerName, string issuerSecret, ServiceBusTransferMode transferMode)
        {
            Add(endpointName, serviceNamespace, servicePath, issuerName, issuerSecret, ServiceBusEndpointType.Eventing, transferMode);
        }
        #endregion

        #region Private methods
        private void InternalAdd(ServiceBusEndpointInfo sbEndpointInfo)
        {
            if (!Contains(sbEndpointInfo.Name))
            {
                lock (this.lockObj)
                {
                    if (!Contains(sbEndpointInfo.Name))
                    {
                        Add(sbEndpointInfo);
                    }
                }
            }
        }
        #endregion
    }
}
