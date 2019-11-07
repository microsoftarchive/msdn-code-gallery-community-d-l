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
    using System.Globalization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    #region IInterRoleCommunicationExtension interface
    /// <summary>
    /// Defines a contract supported by a role extension which provides an interface to the inter-role communication service.
    /// </summary>
    public interface IInterRoleCommunicationExtension : ICloudServiceComponentExtension, IInterRoleCommunicationServiceContract
    {
    }
    #endregion

    #region IInterRoleEventSubscriberExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for receiving and handling inter-role communication events.
    /// </summary>
    public interface IInterRoleEventSubscriberExtension : ICloudServiceComponentExtension, IObserver<InterRoleCommunicationEvent>
    {
    }
    #endregion

    /// <summary>
    /// Implements a role extension which provides an interface to the inter-role communication service.
    /// </summary>
    public class InterRoleEventRelayCommunicationExtension : IInterRoleCommunicationExtension
    {
        #region Private members
        private IExtensibleCloudServiceComponent workerRole;
        private ReliableServiceBusClient<IInterRoleCommunicationServiceChannel> publisher;
        private IInterRoleCommunicationServiceContract subscriber;
        private readonly object subscriberLock = new object();
        private readonly object publisherLock = new object();
        #endregion

        #region IInterRoleCommunicationExtension implementation
        /// <summary>
        /// Publishes the specified inter-role communication event into publish/subscribe messaging infrastructure.
        /// </summary>
        /// <param name="e">The inter-role communication event to be published.</param>
        public void Publish(InterRoleCommunicationEvent e)
        {
            // Wrap a call to the Publish into a retry policy-aware scope. This is because NetEventRelayBinding may return a fault if there are no 
            // subscribers listening on the Service Bus URI. This behavior may be changed in the future releases of the Windows Azure Service Bus.
            Publisher.RetryPolicy.ExecuteAction(() =>
            {
                Publisher.Client.Publish(e);
            });
        }

        /// <summary>
        ///  Registers the specified subscriber to receive inter-role communication events.
        /// </summary>
        /// <param name="subscriber">The object that is to receive notifications.</param>
        /// <returns>The observer's interface that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<InterRoleCommunicationEvent> subscriber)
        {
            return Subscriber.Subscribe(subscriber);
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
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            if (this.publisher != null)
            {
                this.publisher.Dispose();
                this.publisher = null;
            }
        }
        #endregion

        #region Private methods
        private ReliableServiceBusClient<IInterRoleCommunicationServiceChannel> Publisher
        {
            get
            {
                if (null == this.publisher)
                {
                    lock (this.publisherLock)
                    {
                        if (null == this.publisher)
                        {
                            this.workerRole.Extensions.Demand<IRoleConfigurationSettingsExtension>();
                            this.workerRole.Extensions.Demand<IServiceBusHostWorkerRoleExtension>();

                            IRoleConfigurationSettingsExtension roleConfigExtension = this.workerRole.Extensions.Find<IRoleConfigurationSettingsExtension>();
                            IServiceBusHostWorkerRoleExtension serviceHostExtension = this.workerRole.Extensions.Find<IServiceBusHostWorkerRoleExtension>();

                            ServiceBusEndpointInfo sbEndpointInfo = null;

                            if ((sbEndpointInfo = serviceHostExtension.FindServiceEndpoint<IInterRoleCommunicationServiceContract>()) != null)
                            {
                                this.publisher = new ReliableServiceBusClient<IInterRoleCommunicationServiceChannel>(sbEndpointInfo, roleConfigExtension.CommunicationRetryPolicy);
                            }
                        }
                    }
                }

                Guard.ArgumentNotNull(this.publisher, "publisher");
                return this.publisher;
            }
        }

        private IInterRoleCommunicationServiceContract Subscriber
        {
            get
            {
                if (null == this.subscriber)
                {
                    lock (this.subscriberLock)
                    {
                        if (null == this.subscriber)
                        {
                            if (this.workerRole != null)
                            {
                                this.workerRole.Extensions.Demand<IServiceBusHostWorkerRoleExtension>();

                                IServiceBusHostWorkerRoleExtension serviceHostExtension = this.workerRole.Extensions.Find<IServiceBusHostWorkerRoleExtension>();
                                this.subscriber = serviceHostExtension.FindServiceHost<IInterRoleCommunicationServiceContract>();
                            }
                            else
                            {
                                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.CloudRoleExtensionNotAttached, this.GetType().Name));
                            }
                        }
                    }
                }

                Guard.ArgumentNotNull(this.subscriber, "subscriber");
                return this.subscriber;
            }
        } 
        #endregion
    }
}