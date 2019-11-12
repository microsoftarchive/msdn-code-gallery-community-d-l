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
namespace Contoso.Cloud.Integration.Azure.Services.Framework
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Implements the reliability layer between the Windows Azure Service Bus Message Buffers and client code to ensure that all major operations 
    /// against HTTP/REST endpoints such as sending or receiving messages will respect potential transient conditions that may manifest 
    /// themselves in a highly multi-tenant hosting environment such as Windows Azure.
    /// </summary>
    /// <typeparam name="T">The type of message payload that is stored on the message buffer.</typeparam>
    public sealed class ReliableServiceBusQueue<T> : IDisposable
    {
        #region Private members
        private const int DefaultSendTimeoutSec = 30;
        private const int DefaultRetrieveTimeoutSec = 30;
        private const string DefaultMessageAction = "urn:Message";
        private static readonly MessageVersion DefaultQueueMessageVersion = MessageVersion.Soap12WSAddressing10;

        private readonly RetryPolicy retryPolicy;
        private readonly ServiceBusEndpointInfo sbEndpointInfo;
        private readonly MessageBufferPolicy queuePolicy;
        private readonly MessageBufferClient queueClient;

        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus Message Buffer client connected to the specified message buffer 
        /// located on the specified Service Bus endpoint. No retry policy will be enforced when using this constructor overload.
        /// </summary>
        /// <param name="queueName">The name of the target message buffer (queue).</param>
        /// <param name="sbEndpointInfo">The endpoint details.</param>
        public ReliableServiceBusQueue(string queueName, ServiceBusEndpointInfo sbEndpointInfo)
            : this(queueName, sbEndpointInfo, RetryPolicy.NoRetry)
        {
        }

        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Service Bus Message Buffer client connected to the specified message buffer 
        /// located on the specified Service Bus endpoint and utilizing the specified custom retry policy.
        /// </summary>
        /// <param name="queueName">The name of the target message buffer (queue).</param>
        /// <param name="sbEndpointInfo">The endpoint details.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying HTTP/REST-based infrastructure.</param>
        public ReliableServiceBusQueue(string queueName, ServiceBusEndpointInfo sbEndpointInfo, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.sbEndpointInfo = sbEndpointInfo;
            this.retryPolicy = retryPolicy;

            this.queuePolicy = new MessageBufferPolicy
            {
                ExpiresAfter = TimeSpan.FromMinutes(120),
                MaxMessageCount = 100000, 
                OverflowPolicy = OverflowPolicy.RejectIncomingMessage
            };

            var address = ServiceBusEnvironment.CreateServiceUri(WellKnownProtocolScheme.SecureHttp, sbEndpointInfo.ServiceNamespace, String.Concat(sbEndpointInfo.ServicePath, !sbEndpointInfo.ServicePath.EndsWith("/") ? "/" : "", queueName));
            var credentialsBehaviour = new TransportClientEndpointBehavior();

            credentialsBehaviour.CredentialType = TransportClientCredentialType.SharedSecret;
            credentialsBehaviour.Credentials.SharedSecret.IssuerName = sbEndpointInfo.IssuerName;
            credentialsBehaviour.Credentials.SharedSecret.IssuerSecret = sbEndpointInfo.IssuerSecret;

            MessageBufferClient msgBufferClient = null;

            this.retryPolicy.ExecuteAction(() =>
            {
                msgBufferClient = MessageBufferClient.CreateMessageBuffer(credentialsBehaviour, address, this.queuePolicy, DefaultQueueMessageVersion);
            });

            this.queueClient = msgBufferClient;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns a message buffer access policy which is being used by this object.
        /// </summary>
        public MessageBufferPolicy QueuePolicy
        {
            get { return this.queuePolicy; }
        }

        /// <summary>
        /// Returns the retry policy that is being used for ensuring reliable access to the underlying WCF infrastructure.
        /// </summary>
        public RetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Sends the specified message using the default timeout. 
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        public void Send(T message)
        {
            Send(message, TimeSpan.FromSeconds(DefaultSendTimeoutSec));
        }

        /// <summary>
        /// Sends the specified message using the specified timeout. 
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        /// <param name="timeout">The length of time to wait for the method to finish before returning a failure.</param>
        public void Send(T message, TimeSpan timeout)
        {
            this.retryPolicy.ExecuteAction(() =>
            {
                using (Message wcfMessage = Message.CreateMessage(DefaultQueueMessageVersion, DefaultMessageAction, message))
                {
                    this.queueClient.Send(wcfMessage, timeout);
                }
            });
        }

        /// <summary>
        /// Retrieves the first message from the message buffer, using the default timeout. 
        /// </summary>
        /// <returns>Returns an instance of <typeparamref name="T"/> that contains the message.</returns>
        public T Retrieve()
        {
            return Retrieve(TimeSpan.FromSeconds(DefaultRetrieveTimeoutSec));
        }

        /// <summary>
        /// Retrieves the first message from the message buffer, using the specified timeout.
        /// If receive operation times out, returns the default instance of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="timeout">The length of time to wait for the method to return. The default is one minute, which is the maximum supported timeout value.</param>
        /// <returns>Returns an instance of <typeparamref name="T"/> that contains the message.</returns>
        public T Retrieve(TimeSpan timeout)
        {
            return this.retryPolicy.ExecuteAction<T>(() =>
            {
                try
                {
                    using (Message wfcMessage = this.queueClient.Retrieve(timeout))
                    {
                        if (wfcMessage != null)
                        {
                            return wfcMessage.GetBody<T>();
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
                catch (TimeoutException)
                {
                    return default(T);
                }
            });
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (queueClient != null)
                    {
                        try
                        {
                            queueClient.DeleteMessageBuffer();
                        }
                        catch
                        {
                            // Should ensure a safe disposal, just ignore any exceptions here and don't let them damage the runtime.
                        }
                    }
                }
            }

            this.disposed = true;
        }


        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableServiceBusQueue()
        {
            this.Dispose(false);
        }
        #endregion
    }
}
