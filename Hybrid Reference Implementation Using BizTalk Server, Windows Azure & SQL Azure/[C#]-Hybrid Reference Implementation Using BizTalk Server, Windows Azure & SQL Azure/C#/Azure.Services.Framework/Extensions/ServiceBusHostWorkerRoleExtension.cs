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
    using System.Globalization;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    #region IServiceBusHostWorkerRoleExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for supporting declarative bindings between Service Bus hosts and worker roles.
    /// </summary>
    public interface IServiceBusHostWorkerRoleExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Starts all service hosts that are declaratively attached to the hosting worker role.
        /// </summary>
        void StartAll();

        /// <summary>
        /// Starts the service hosts that are declaratively attached to the hosting worker role and the AutoStart attribute of which matches the specified value.
        /// </summary>
        /// <param name="autoStartOnly">A flag indicating whether to start only those service hosts that are marked with the AutoStart attribute.</param>
        void StartAll(bool autoStartOnly);

        /// <summary>
        /// Searches for and returns a service host that is assigned to a contract of the specified type T.
        /// </summary>
        /// <typeparam name="T">The type of the service contract.</typeparam>
        /// <returns>The singleton instance of the service contract implementation hosted by the service host.</returns>
        T FindServiceHost<T>() where T : class;

        /// <summary>
        /// Searches for and returns a Service Bus endpoint definition that is assigned to a service contract of the specified type T.
        /// </summary>
        /// <typeparam name="T">The type of the service contract.</typeparam>
        /// <returns>The endpoint definition found for the specified contract type, or null reference if the matching endpoint has not been found.</returns>
        ServiceBusEndpointInfo FindServiceEndpoint<T>();
    } 
    #endregion

    /// <summary>
    /// Implements the extension responsible for supporting declarative bindings between Service Bus hosts and worker roles.
    /// </summary>
    public class ServiceBusHostWorkerRoleExtension : IServiceBusHostWorkerRoleExtension
    {
        #region Private members
        private IExtensibleCloudServiceComponent workerRole;
        private readonly IDictionary<ServiceBusEndpointInfo, ServiceBusListenerRegistration> serviceEndpoints = new Dictionary<ServiceBusEndpointInfo, ServiceBusListenerRegistration>();
        #endregion

        #region IServiceBusHostWorkerRoleExtension implementation
        /// <summary>
        /// Starts all service hosts that are declaratively attached to the hosting worker role.
        /// </summary>
        public void StartAll()
        {
            StartAll(false);
        }

        /// <summary>
        /// Starts the service hosts that are declaratively attached to the hosting worker role and the AutoStart attribute of which matches the specified value.
        /// </summary>
        /// <param name="autoStartOnly">A flag indicating whether to start only those service hosts that are marked with the AutoStart attribute.</param>
        public void StartAll(bool autoStartOnly)
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(autoStartOnly);
            var startScopeOpenServiceHosts = TraceManager.WorkerRoleComponent.TraceStartScope(TraceLogMessages.ScopeOpenServiceHosts, callToken);

            if (this.workerRole != null)
            {
                IRoleConfigurationSettingsExtension roleConfigExtension = this.workerRole.Extensions.Find<IRoleConfigurationSettingsExtension>();

                if (roleConfigExtension != null)
                {
                    foreach (var ep in serviceEndpoints.Values)
                    {
                        if (null == ep.ServiceHost)
                        {
                            TraceManager.WorkerRoleComponent.TraceInfo(TraceLogMessages.AboutToCreateServiceHost, ep.ServiceType.FullName, ep.EndpointInfo.Name, ep.EndpointInfo.ServiceNamespace, ep.EndpointInfo.ServicePath, ep.EndpointInfo.EndpointType);
                            ep.ServiceHost = new ReliableServiceBusHost<object>(ServiceBusHostFactory.CreateServiceBusHost(ep.EndpointInfo, ep.ServiceType), roleConfigExtension.CommunicationRetryPolicy);
                        }

                        if (ep.ServiceHost != null && ep.ServiceHost.State != CommunicationState.Opened && (!autoStartOnly || ep.AutoStart))
                        {
                            ep.ServiceHost.Open();
                        }
                    }
                }
            }
            else
            {
                throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.CloudRoleExtensionNotAttached, this.GetType().Name));
            }

            TraceManager.WorkerRoleComponent.TraceEndScope(TraceLogMessages.ScopeOpenServiceHosts, startScopeOpenServiceHosts, callToken);
            TraceManager.WorkerRoleComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Searches for and returns a service host that is assigned to a contract of the specified type T.
        /// </summary>
        /// <typeparam name="T">The type of the service contract.</typeparam>
        /// <returns>The singleton instance of the service contract implementation hosted by the service host.</returns>
        public T FindServiceHost<T>() where T : class
        {
            ReliableServiceBusHost<object> serviceBusHost = null;

            foreach (var ep in serviceEndpoints.Values)
            {
                if (ep.ServiceHost != null && (serviceBusHost = (ep.ServiceHost as ReliableServiceBusHost<object>)) != null)
                {
                    if (serviceBusHost.ServiceInstance != null && typeof(T).IsAssignableFrom(serviceBusHost.ServiceInstance.GetType()))
                    {
                        return serviceBusHost.ServiceInstance as T;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Searches for and returns a Service Bus endpoint definition that is assigned to a service contract of the specified type T.
        /// </summary>
        /// <typeparam name="T">The type of the service contract.</typeparam>
        /// <returns>The endpoint definition found for the specified contract type, or null reference if the matching endpoint has not been found.</returns>
        public ServiceBusEndpointInfo FindServiceEndpoint<T>()
        {
            return this.serviceEndpoints.Where(x => x.Value.ServiceType == typeof(T) || typeof(T).IsAssignableFrom(x.Value.ServiceType)).Select(y => y.Key).FirstOrDefault();
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            this.workerRole = owner;
            ConfigureServiceHostWorkerRole(this.workerRole);
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            DisposeServiceHosts();
        }
        #endregion

        #region Private members
        private void ConfigureServiceHostWorkerRole(IExtensibleCloudServiceComponent ownerRole)
        {
           var callToken = TraceManager.WorkerRoleComponent.TraceIn(ownerRole != null ? ownerRole.GetType().FullName : null);
            var startScopeCreateServiceHosts = TraceManager.WorkerRoleComponent.TraceStartScope(TraceLogMessages.ScopeCreateServiceHosts, callToken);

            if (ownerRole != null)
            {
                IList<ServiceBusHostWorkerRoleAttribute> serviceHostAttributes = FrameworkUtility.GetDeclarativeAttributes<ServiceBusHostWorkerRoleAttribute>(ownerRole.GetType());
                IRoleConfigurationSettingsExtension roleConfigExtension = ownerRole.Extensions.Find<IRoleConfigurationSettingsExtension>();

                if (serviceHostAttributes != null && serviceHostAttributes.Count > 0 && roleConfigExtension != null)
                {
                    ServiceBusEndpointInfo endpointInfo = null;
                    ServiceBusListenerRegistration listenerInfo = null;

                    foreach (ServiceBusHostWorkerRoleAttribute serviceHostAttr in serviceHostAttributes)
                    {
                        endpointInfo = roleConfigExtension.GetServiceBusEndpoint(serviceHostAttr.ServiceBusEndpoint);

                        if (endpointInfo != null)
                        {
                            listenerInfo = new ServiceBusListenerRegistration()
                            {
                                ServiceType = serviceHostAttr.ServiceType,
                                EndpointInfo = endpointInfo,
                                AutoStart = serviceHostAttr.AutoStart
                            };

                            // All services that are enabled for auto-start will have their service hosts pre-initialized but not as yet openned.
                            if (listenerInfo.AutoStart)
                            {
                                TraceManager.WorkerRoleComponent.TraceInfo(TraceLogMessages.AboutToCreateServiceHost, listenerInfo.ServiceType.FullName, endpointInfo.Name, endpointInfo.ServiceNamespace, endpointInfo.ServicePath, endpointInfo.EndpointType);
                                listenerInfo.ServiceHost = new ReliableServiceBusHost<object>(ServiceBusHostFactory.CreateServiceBusHost(endpointInfo, listenerInfo.ServiceType), roleConfigExtension.CommunicationRetryPolicy);
                            }

                            this.serviceEndpoints.Add(endpointInfo, listenerInfo);
                        }
                        else
                        {
                            throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.SpecifiedServiceBusEndpointNotFound, serviceHostAttr.ServiceBusEndpoint, ServiceBusConfigurationSettings.SectionName));
                        }
                    }
                }
            }

            TraceManager.WorkerRoleComponent.TraceEndScope(TraceLogMessages.ScopeCreateServiceHosts, startScopeCreateServiceHosts, callToken);
            TraceManager.WorkerRoleComponent.TraceOut(callToken);
        }

        private void DisposeServiceHosts()
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn();
            var startScopeDisposeServiceHosts = TraceManager.WorkerRoleComponent.TraceStartScope(TraceLogMessages.ScopeDisposeServiceHosts, callToken);

            foreach (var ep in serviceEndpoints.Values)
            {
                try
                {
                    if (ep.ServiceHost != null)
                    {
                        ep.ServiceHost.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Trace and ignore any exceptions as stopping individual service hosts should not impact the others.
                    TraceManager.WorkerRoleComponent.TraceError(ex);
                }
            }
            
            this.serviceEndpoints.Clear();

            TraceManager.WorkerRoleComponent.TraceEndScope(TraceLogMessages.ScopeDisposeServiceHosts, startScopeDisposeServiceHosts, callToken);
            TraceManager.WorkerRoleComponent.TraceOut(callToken);
        }
        #endregion

        #region ServiceBusListenerRegistration class declaration
        private class ServiceBusListenerRegistration
        {
            public ServiceBusEndpointInfo EndpointInfo { get; set; }
            public ICommunicationObject ServiceHost { get; set; }
            public Type ServiceType { get; set; }
            public bool AutoStart { get; set; }
        } 
        #endregion
    }
}
