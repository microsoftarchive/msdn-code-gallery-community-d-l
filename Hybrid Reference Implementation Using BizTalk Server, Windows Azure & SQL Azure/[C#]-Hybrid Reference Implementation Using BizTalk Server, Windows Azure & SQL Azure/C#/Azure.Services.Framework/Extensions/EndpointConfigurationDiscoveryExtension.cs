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
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Discovery;
    #endregion

    #region IEndpointConfigurationDiscoveryExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for interfacing with the service endpoint configuration.
    /// </summary>
    public interface IEndpointConfigurationDiscoveryExtension : ICloudServiceComponentExtension, IObserver<ServiceEndpoint>
    {
        /// <summary>
        /// Registers an user-defined action that is triggered whenever a service endpoint matches the specified discovery condition.
        /// </summary>
        /// <param name="condition">The condition that will be used during evaluation.</param>
        /// <param name="action">The user-defined action that will be invoked upon satisfying the discovery condition.</param>
        void RegisterDiscoveryAction(DiscoveryCondition condition, Action<ServiceEndpoint> action);

        /// <summary>
        /// Registers an user-defined action that is triggered whenever a service endpoint matches all discovery conditions specified.
        /// </summary>
        /// <param name="conditions">One or more conditions that will be used during evaluation.</param>
        /// <param name="action">The user-defined action that will be invoked upon satisfying the discovery condition.</param>
        void RegisterDiscoveryAction(IEnumerable<DiscoveryCondition> conditions, Action<ServiceEndpoint> action);
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for interfacing with the service endpoint configuration.
    /// This extension enables the user code to observe the events when WCF service configuration is applied.
    /// </summary>
    public class EndpointConfigurationDiscoveryExtension : IEndpointConfigurationDiscoveryExtension
    {
        #region Private methods
        private readonly ConcurrentDictionary<IList<DiscoveryCondition>, Action<ServiceEndpoint>> discoveryActions;
        private IDisposable discoveryClientRegistration;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the extension.
        /// </summary>
        public EndpointConfigurationDiscoveryExtension()
        {
            this.discoveryActions = new ConcurrentDictionary<IList<DiscoveryCondition>, Action<ServiceEndpoint>>();
        } 
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            this.discoveryClientRegistration = ServiceEndpointConfiguration.RegisterDiscoveryClient(this);
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            if (this.discoveryClientRegistration != null)
            {
                this.discoveryClientRegistration.Dispose();
            }

            this.discoveryActions.Clear();
        }
        #endregion

        #region IObserver<ServiceEndpoint> implementation
        /// <summary>
        /// Gets called by the provider to notify the observer about a new service endpoint being configured.
        /// </summary>
        /// <param name="endpoint">The instance of a WCF service endpoint that is being configured.</param>
        public void OnNext(ServiceEndpoint endpoint)
        {
            Guard.ArgumentNotNull(endpoint, "endpoint");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(endpoint.Name, endpoint.ListenUri);

            try
            {
                var actions = from x in discoveryActions
                           where x.Key.Count == (from y in x.Key
                           where y.Evaluate(endpoint) select y).Count()
                           select x.Value;

                foreach (var action in actions)
                {
                    action(endpoint);
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Gets called by the provider to indicate that it has finished sending notifications to observers.
        /// </summary>
        public void OnCompleted()
        {
        }

        /// <summary>
        /// Gets called by the provider to indicate that data is unavailable, inaccessible, or corrupted, 
        /// or that the provider has experienced some other error condition.
        /// </summary>
        /// <param name="error">The exception that resulted in an error condition.</param>
        public void OnError(Exception error)
        {
        }
        #endregion

        #region IEndpointConfigurationDiscoveryExtension implementation
        /// <summary>
        /// Registers an user-defined action that is triggered whenever a service endpoint matches the specified discovery condition.
        /// </summary>
        /// <param name="condition">The condition that will be used during evaluation.</param>
        /// <param name="action">The user-defined action that will be invoked upon satisfying the discovery condition.</param>
        public void RegisterDiscoveryAction(DiscoveryCondition condition, Action<ServiceEndpoint> action)
        {
            Guard.ArgumentNotNull(condition, "condition");
            Guard.ArgumentNotNull(action, "action");

            RegisterDiscoveryAction(new[] { condition }, action);
        }

        /// <summary>
        /// Registers an user-defined action that is triggered whenever a service endpoint matches all discovery conditions specified.
        /// </summary>
        /// <param name="conditions">One or more conditions that will be used during evaluation.</param>
        /// <param name="action">The user-defined action that will be invoked upon satisfying the discovery condition.</param>
        public void RegisterDiscoveryAction(IEnumerable<DiscoveryCondition> conditions, Action<ServiceEndpoint> action)
        {
            Guard.ArgumentNotNull(conditions, "conditions");
            Guard.ArgumentNotNull(action, "action");

            this.discoveryActions.AddOrUpdate(new List<DiscoveryCondition>(conditions), action, (key, oldValue) => { return action; });
        }
        #endregion
    }
}
