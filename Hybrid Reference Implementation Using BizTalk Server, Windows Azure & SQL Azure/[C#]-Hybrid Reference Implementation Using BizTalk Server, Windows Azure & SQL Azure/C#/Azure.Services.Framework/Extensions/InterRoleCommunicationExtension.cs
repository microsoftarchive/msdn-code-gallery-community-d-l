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
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Runtime.Remoting.Messaging;

    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Description;
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.ServiceBus.Messaging.Filters;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Internal;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Implements a role extension which provides access to the inter-role communication service
    /// and enables registering subscriptions for inter-role communication events.
    /// </summary>
    public class InterRoleCommunicationExtension : IInterRoleCommunicationExtension
    {
        #region Private members
        private readonly ConcurrentDictionary<IObserver<InterRoleCommunicationEvent>, int> subscribers = new ConcurrentDictionary<IObserver<InterRoleCommunicationEvent>, int>();
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        private readonly object senderLock = new object(), receiverLock = new object();
        private readonly string senderInstanceID;
        private readonly InterRoleCommunicationSettings settings;

        private Subscription ircSubscription;
        private ServiceBusNamespaceClient managementClient;
        private Action<BrokeredMessage> sendAction;
        private Action receiveAction;
        private AsyncCallback endSend, endReceive;
        private ServiceBusEndpointInfo serviceBusEndpoint;
        private RetryPolicy retryPolicy;
        private MessagingFactory messagingFactory;
        private TopicClient topicClient;
        private SubscriptionClient subscriptionClient;
        private MessageSender ircEventSender;
        private MessageReceiver ircEventReceiver;
        private IAsyncResult receiveHandle;

        private const string MsgCtxPropNameFromInstanceID = "FromInstanceID";
        private const string MsgCtxPropNameToInstanceID = "ToInstanceID";
        private const string MsgCtxPropValueAny = "*";
        private const string SubscriptionNamePrefix = "IRC-";
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="InterRoleCommunicationExtension"/> object with default settings.
        /// </summary>
        public InterRoleCommunicationExtension()
        {
            // Initialize internal fields.
            this.settings = InterRoleCommunicationSettings.Default;
            this.senderInstanceID = FrameworkUtility.GetHashedValue(CloudEnvironment.DeploymentId, CloudEnvironment.CurrentRoleInstanceId);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns runtime settings for the <see cref="InterRoleCommunicationExtension"/> component.
        /// </summary>
        public InterRoleCommunicationSettings Settings
        {
            get { return this.settings; }
        }
        #endregion

        #region IInterRoleCommunicationServiceContract implementation
        /// <summary>
        /// Publishes the specified inter-role communication event into publish/subscribe messaging infrastructure.
        /// </summary>
        /// <param name="e">The inter-role communication event to be published.</param>
        public void Publish(InterRoleCommunicationEvent e)
        {
            Guard.ArgumentNotNull(e, "e");

            var eventMsg = BrokeredMessage.CreateMessage(e);

            // Configure event routing properties.
            eventMsg.Properties[MsgCtxPropNameFromInstanceID] = e.FromInstanceID = this.senderInstanceID;
            eventMsg.Properties[MsgCtxPropNameToInstanceID] = String.IsNullOrEmpty(e.ToInstanceID) ? MsgCtxPropValueAny : e.ToInstanceID;

            // Configure other message properties and settings.
            eventMsg.TimeToLive = this.settings.EventTimeToLive;

            // Send the event asynchronously.
            this.sendAction.BeginInvoke(eventMsg, this.endSend, null);
        }
        #endregion

        #region IObservable<InterRoleCommunicationEvent> implementation
        /// <summary>
        ///  Registers the specified subscriber to receive inter-role communication events.
        /// </summary>
        /// <param name="subscriber">The object that is to receive notifications.</param>
        /// <returns>The observer's interface that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<InterRoleCommunicationEvent> subscriber)
        {
            bool firstSubscriber = (this.subscribers.Count == 0);

            this.subscribers.AddOrUpdate(subscriber, 0, (key, oldValue) => { return oldValue + 1; });

            if (firstSubscriber)
            {
                // Start receiving events asynchronously.
                this.receiveHandle = this.receiveAction.BeginInvoke(this.endReceive, null);
            }

            // Return a special object that provides the ability to cancel this subscription.
            return new AnonymousDisposable(() =>
            {
                int count;
                this.subscribers.TryRemove(subscriber, out count);
            });
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();
            IRoleConfigurationSettingsExtension roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();

            this.serviceBusEndpoint = roleConfigExtension.GetServiceBusEndpoint(WellKnownEndpointName.InterRoleCommunication);
            this.retryPolicy = roleConfigExtension.CommunicationRetryPolicy;

            if (this.serviceBusEndpoint != null)
            {
                // Configure Service Bus credentials and entity URI.
                var credentials = TransportClientCredentialBase.CreateSharedSecretCredential(this.serviceBusEndpoint.IssuerName, this.serviceBusEndpoint.IssuerSecret);
                var address = ServiceBusEnvironment.CreateServiceUri(WellKnownProtocolScheme.ServiceBus, this.serviceBusEndpoint.ServiceNamespace, String.Empty);

                // Configure Service Bus messaging factory and namespace client which is required for subscription management.
                this.messagingFactory = MessagingFactory.Create(address, credentials);
                this.managementClient = new ServiceBusNamespaceClient(address, credentials);

                ConfigureTopicClient();
                ConfigureSubscriptionClient(this.ircSubscription = ConfigureSubscription(String.Concat(SubscriptionNamePrefix, this.senderInstanceID)));

                // Configure event receive action.
                this.receiveAction = (() =>
                {
                    BrokeredMessage msg = null;

                    this.retryPolicy.ExecuteAction(() =>
                    {
                        // Make sure we are not told to stop receiving while we are retrying.
                        if (!cts.IsCancellationRequested)
                        {
                            if (EventReceiver.TryReceive(Settings.EventWaitTimeout, out msg))
                            {
                                try
                                {
                                    // Make sure we are not told to stop receiving while we were waiting for a new message.
                                    if (!cts.IsCancellationRequested)
                                    {
                                        // Extract the event data from brokered message.
                                        InterRoleCommunicationEvent e = msg.GetBody<InterRoleCommunicationEvent>();

                                        // Notify all registered subscribers.
                                        NotifySubscribers(e);

                                        // Mark brokered message as complete.
                                        msg.Complete(this.retryPolicy);
                                    }
                                    else
                                    {
                                        msg.Defer(this.retryPolicy);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Abandons a brokered message and unlocks the message.
                                    msg.Abandon(this.retryPolicy);

                                    // Log an error.
                                    TraceManager.ServiceComponent.TraceError(ex);
                                }
                            }
                        }
                    });
                });

                // Configure event receive complete action.
                this.endReceive = ((ar) =>
                {
                    this.receiveAction.EndInvoke(ar);

                    if (!cts.IsCancellationRequested)
                    {
                        this.receiveHandle = this.receiveAction.BeginInvoke(this.endReceive, null);
                    }
                });

                // Configure event send action.
                this.sendAction = ((e) =>
                {
                    this.retryPolicy.ExecuteAction(() => { EventSender.Send(e); });
                });

                // Configure event send complete action.
                this.endSend = ((ar) =>
                {
                    sendAction.EndInvoke(ar);
                });
            }
            else
            {
                throw new CloudApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.SpecifiedServiceBusEndpointNotFound, WellKnownEndpointName.InterRoleCommunication, ServiceBusConfigurationSettings.SectionName));
            }
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            this.subscribers.Clear();

            if (this.cts != null)
            {
                this.cts.Cancel();

                // Wait for receive operation to complete gracefully.
                if (this.receiveHandle != null)
                {
                    this.receiveHandle.AsyncWaitHandle.WaitOne(this.settings.EventWaitTimeout);
                    this.receiveHandle = null;
                }

                this.cts.Dispose();
            }

            if (this.ircEventSender != null)
            {
                this.ircEventSender.SafeClose();
                this.ircEventSender = null;
            }

            if (this.ircEventReceiver != null)
            {
                this.ircEventReceiver.SafeClose();
                this.ircEventReceiver = null;
            }

            if (this.topicClient != null)
            {
                this.topicClient.SafeClose();
                this.topicClient = null;
            }

            if (this.subscriptionClient != null)
            {
                this.subscriptionClient.SafeClose();
                this.subscriptionClient = null;
            }

            if (this.messagingFactory != null)
            {
                this.messagingFactory.SafeClose();
                this.messagingFactory = null;
            }

            if (this.ircSubscription != null)
            {
                try
                {
                    RemoveSubscription(this.ircSubscription);
                }
                catch
                {
                    // We should not fail while disposing.
                }
            }
        }
        #endregion

        #region Private properties
        private MessageSender EventSender
        {
            get
            {
                if (!this.ircEventSender.IsValidState())
                {
                    lock (this.senderLock)
                    {
                        if (!this.ircEventSender.IsValidState())
                        {
                            this.ircEventSender.SafeClose();
                            this.topicClient.SafeClose();

                            ConfigureTopicClient();
                        }
                    }
                }

                return this.ircEventSender;
            }
        }

        private MessageReceiver EventReceiver
        {
            get
            {
                if (!this.ircEventReceiver.IsValidState())
                {
                    lock (this.receiverLock)
                    {
                        if (!this.ircEventReceiver.IsValidState())
                        {
                            this.ircEventReceiver.SafeClose();
                            this.subscriptionClient.SafeClose();

                            ConfigureSubscriptionClient(this.ircSubscription);
                        }
                    }
                }

                return this.ircEventReceiver;
            }
        }
        #endregion

        #region Private methods
        private void ConfigureTopicClient()
        {
            Guard.ArgumentNotNull(this.serviceBusEndpoint, "serviceBusEndpoint");
            Guard.ArgumentNotNull(this.messagingFactory, "messagingFactory");
            Guard.ArgumentNotNull(this.retryPolicy, "retryPolicy");

            this.topicClient = this.messagingFactory.CreateTopicClient(this.serviceBusEndpoint.TopicName, this.retryPolicy);
            this.ircEventSender = this.topicClient.CreateSender(this.retryPolicy);
        }

        private Subscription ConfigureSubscription(string subscriptionName)
        {
            Guard.ArgumentNotNullOrEmptyString(subscriptionName, "subscriptionName");
            Guard.ArgumentNotNull(this.serviceBusEndpoint, "serviceBusEndpoint");
            Guard.ArgumentNotNull(this.managementClient, "managementClient");

            Topic ircTopic = this.managementClient.GetTopic(this.serviceBusEndpoint.TopicName);
            Subscription ircSubscription = null;

            try
            {
                ircSubscription = ircTopic.GetSubscriptions().Where(s => s.Name == subscriptionName).FirstOrDefault();

                if (null == ircSubscription)
                {
                    StringBuilder expressionBuilder = new StringBuilder();

                    if (!this.settings.EnableCarbonCopy)
                    {
                        expressionBuilder.AppendFormat("FromInstanceID <> '{0}'", senderInstanceID);
                        expressionBuilder.Append(" AND ");
                    }

                    expressionBuilder.AppendFormat("(ToInstanceID = '{0}' OR ToInstanceID = '*')", senderInstanceID);

                    ircSubscription = ircTopic.AddSubscription(subscriptionName, new SqlFilterExpression(expressionBuilder.ToString()), this.retryPolicy);
                }
            }
            catch (MessagingEntityAlreadyExistsException)
            {
                // A subscription under the same name was already created, not a problem, we will reuse the existing subscription.
                ircSubscription = ircTopic.GetSubscriptions().Where(s => s.Name == subscriptionName).FirstOrDefault();
            }

            return ircSubscription;
        }

        private void ConfigureSubscriptionClient(Subscription ircSubscription)
        {
            Guard.ArgumentNotNull(ircSubscription, "ircSubscription");

            this.subscriptionClient = this.messagingFactory.CreateSubscriptionClient(ircSubscription, this.retryPolicy);
            this.ircEventReceiver = this.subscriptionClient.CreateReceiver(ReceiveMode.PeekLock, this.retryPolicy);
        }

        private void RemoveSubscription(Subscription ircSubscription)
        {
            Guard.ArgumentNotNull(ircSubscription, "ircSubscription");
            Guard.ArgumentNotNull(ircSubscription.NamespaceClient, "ircSubscription.NamespaceClient");

            Topic ircTopic = ircSubscription.NamespaceClient.GetTopic(this.serviceBusEndpoint.TopicName);
            ircTopic.RemoveSubscription(ircSubscription.Name, this.retryPolicy);
        }

        private void NotifySubscribers(InterRoleCommunicationEvent e)
        {
            Guard.ArgumentNotNull(e, "e");

            // Invokes the specified action for each subscriber.
            Parallel.ForEach(this.subscribers, ((subscriber) =>
            {
                try
                {
                    // Notify the subscriber.
                    subscriber.Key.OnNext(e);
                }
                catch (Exception ex)
                {
                    // Do not allow any subscriber to generate a fault and affect other subscribers.
                    try
                    {
                        // Notifies the subscriber that the event provider has experienced an error condition.
                        subscriber.Key.OnError(ex);
                    }
                    catch (Exception fault)
                    {
                        // Log an error.
                        TraceManager.ServiceComponent.TraceError(fault);
                    }
                }
            }));

        }
        #endregion
    }
}
