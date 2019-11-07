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
    using System.Linq;

    using Microsoft.ServiceBus.Messaging;
    using Microsoft.ServiceBus.Messaging.Filters;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides value-add extension methods for Windows Azure Service Bus entities such as topics, queues and subscriptions.
    /// </summary>
    public static class ServiceBusEntityExtensionMethods
    {
        /// <summary>
        /// Verifies whether a subscription with the specified name exists in the topic.
        /// </summary>
        /// <param name="topic">The topic entity for which the extension method will be invoked.</param>
        /// <param name="name">The name of the subscription to be located.</param>
        /// <returns>True if a matching subscription has been found, otherwise false.</returns>
        public static bool HasSubscription(this Topic topic, string name)
        {
            return topic.GetSubscriptions().Where(s => s.Name == name).Count() > 0;
        }

        /// <summary>
        /// Adds a subscription to this topic with the specified name and <see cref="Microsoft.ServiceBus.Messaging.Filters.FilterExpression"/> as the default filter. 
        /// Uses the specified retry policy when adding subscription to the topic.
        /// </summary>
        /// <param name="topic">The topic entity for which the extension method will be invoked.</param>
        /// <param name="name">The name of the subscription to be added.</param>
        /// <param name="filter">The filter to be used as default.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        /// <returns>An instance of the <see cref="Microsoft.ServiceBus.Messaging.Subscription"/> management entity.</returns>
        public static Subscription AddSubscription(this Topic topic, string name, FilterExpression filter, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            return retryPolicy.ExecuteAction<Subscription>(() => { return topic.AddSubscription(name, filter); });
        }

        /// <summary>
        /// Removes the specified subscription from the topic. Uses the specified retry policy when removing subscription.
        /// </summary>
        /// <param name="topic">The topic entity for which the extension method will be invoked.</param>
        /// <param name="name">The name of the subscription to be removed.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        public static void RemoveSubscription(this Topic topic, string name, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { topic.RemoveSubscription(name); });
        }

        /// <summary>
        /// Completes the receive operation of a message and indicates that the message should be marked as processed and deleted or archived.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="msg">The brokered message instance for which the extension method will be invoked.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        public static void Complete(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.Complete(); });
        }

        /// <summary>
        /// Indicates that the receiver wants to relinquish the message lock ownership and return the message back to the queue or topic.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="msg">The brokered message instance for which the extension method will be invoked.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        public static void Abandon(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.Abandon(); });
        }

        /// <summary>
        /// Indicates that the receiver wants to defer the processing for this message to a later time.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="msg">The brokered message instance for which the extension method will be invoked.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        public static void Defer(this BrokeredMessage msg, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            retryPolicy.ExecuteAction(() => { msg.Defer(); });
        }

        /// <summary>
        /// Creates a new client for the specified topic identified by its path.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="factory">The factory object instance for which the extension method will be invoked.</param>
        /// <param name="path">The topic path relative to the service namespace base address.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        /// <returns>The newly created topic client. The <see cref="Microsoft.ServiceBus.Messaging.TopicClient"/> is used as an anchor class to perform run-time operations, such as creating sender/receiver or add/remove subscription.</returns>
        public static TopicClient CreateTopicClient(this MessagingFactory factory, string path, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            return retryPolicy.ExecuteAction<TopicClient>(() => { return factory.CreateTopicClient(path); });
        }

        /// <summary>
        /// Creates a new client for the specified subscription.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="factory">The factory object instance for which the extension method will be invoked.</param>
        /// <param name="subscription">The subscription for which a client is being requested.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        /// <returns>The newly created subscription client.</returns>
        public static SubscriptionClient CreateSubscriptionClient(this MessagingFactory factory, Subscription subscription, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            return retryPolicy.ExecuteAction<SubscriptionClient>(() => { return factory.CreateSubscriptionClient(subscription); });
        }

        /// <summary>
        /// Creates a message sender that can be used for sending messages to a topic.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="client">The topic client object instance for which the extension method will be invoked.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        /// <returns>An instance of the <see cref="Microsoft.ServiceBus.Messaging.MessageSender"/> class that is used to send messages to a topic.</returns>
        public static MessageSender CreateSender(this TopicClient client, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            return retryPolicy.ExecuteAction<MessageSender>(() => { return client.CreateSender(); });
        }

        /// <summary>
        /// Creates a new message receiver that can be used for receiving messages from a subscription.
        /// Uses the specified retry policy when invoking the operation in order to shield from transient exceptions.
        /// </summary>
        /// <param name="client">The subscription client object instance for which the extension method will be invoked.</param>
        /// <param name="receiveMode">The message receive mode.</param>
        /// <param name="retryPolicy">The policy governing retry-aware behavior should a transient exception occur.</param>
        /// <returns>An instance of the <see cref="Microsoft.ServiceBus.Messaging.MessageReceiver"/> class that is used to receive and acknowledge messages from a subscription.</returns>
        public static MessageReceiver CreateReceiver(this SubscriptionClient client, ReceiveMode receiveMode, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            return retryPolicy.ExecuteAction<MessageReceiver>(() => { return client.CreateReceiver(receiveMode); });
        }
    }
}
