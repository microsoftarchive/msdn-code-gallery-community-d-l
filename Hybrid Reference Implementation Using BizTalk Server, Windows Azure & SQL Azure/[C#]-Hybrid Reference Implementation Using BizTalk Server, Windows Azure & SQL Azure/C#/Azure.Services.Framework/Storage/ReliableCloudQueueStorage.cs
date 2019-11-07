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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Storage
{
    #region Using references
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Runtime.Serialization;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;

    using RetryPolicy = Contoso.Cloud.Integration.Framework.RetryPolicy;
    #endregion

    /// <summary>
    /// Provides reliable generics-aware access to the Windows Azure Queue storage.
    /// </summary>
    public sealed class ReliableCloudQueueStorage : ICloudQueueStorage
    {
        #region Private members
        private const int InflightMessageQueueInitialCapacity = 100;

        private readonly RetryPolicy retryPolicy;
        private readonly CloudQueueClient queueStorage;
        private readonly ICloudStorageEntitySerializer dataSerializer;
        private readonly ICloudBlobStorage overflowStorage;
        private readonly ConcurrentDictionary<object, InflightMessageInfo> inflightMessages;
        
        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudQueueStorage"/> class using the specified storage account information.
        /// Assumes the default use of <see cref="RetryPolicy.DefaultExponential"/> retry policy and default implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="storageAccountInfo">The storage account that is projected through this component.</param>
        public ReliableCloudQueueStorage(StorageAccountInfo storageAccountInfo)
            : this(storageAccountInfo, new RetryPolicy<StorageTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudQueueStorage"/> class using the specified storage account information and retry policy.
        /// </summary>
        /// <param name="storageAccountInfo">The storage account that is projected through this component.</param>
        /// <param name="retryPolicy">The specific retry policy that will ensure reliable access to the underlying storage.</param>
        public ReliableCloudQueueStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy)
            : this(storageAccountInfo, retryPolicy, new CloudStorageEntitySerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudQueueStorage"/> class using the specified storage account information, custom retry policy
        /// and custom implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="storageAccountInfo">The storage account that is projected through this component.</param>
        /// <param name="retryPolicy">The specific retry policy that will ensure reliable access to the underlying storage.</param>
        /// <param name="dataSerializer">An instance of the component which performs serialization and deserialization of storage objects.</param>
        public ReliableCloudQueueStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy, ICloudStorageEntitySerializer dataSerializer)
            : this(storageAccountInfo, retryPolicy, dataSerializer, new ReliableCloudBlobStorage(storageAccountInfo, retryPolicy, dataSerializer))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudQueueStorage"/> class using the specified storage account information, custom retry policy
        /// and custom implementation of the large message overflow store.
        /// </summary>
        /// <param name="storageAccountInfo">The storage account that is projected through this component.</param>
        /// <param name="retryPolicy">The specific retry policy that will ensure reliable access to the underlying storage.</param>
        /// <param name="overflowStorage">An instance of the component implementing overflow store that will be used for persisting large messages that cannot be accommodated in a queue due to message size constraints.</param>
        public ReliableCloudQueueStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy, ICloudBlobStorage overflowStorage)
            : this(storageAccountInfo, retryPolicy, new CloudStorageEntitySerializer(), overflowStorage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudQueueStorage"/> class using the specified storage account information, custom retry policy
        /// and custom implementation of the large message overflow store.
        /// </summary>
        /// <param name="storageAccountInfo">The storage account that is projected through this component.</param>
        /// <param name="overflowStorage">An instance of the component implementing overflow store that will be used for persisting large messages that cannot be accommodated in a queue due to message size constraints.</param>
        public ReliableCloudQueueStorage(StorageAccountInfo storageAccountInfo, ICloudBlobStorage overflowStorage)
            : this(storageAccountInfo, new RetryPolicy<StorageTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff), overflowStorage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudQueueStorage"/> class using the specified storage account information, custom retry policy,
        /// custom implementation of <see cref="ICloudStorageEntitySerializer"/> interface and custom implementation of the large message overflow store.
        /// </summary>
        /// <param name="storageAccountInfo">The storage account that is projected through this component.</param>
        /// <param name="retryPolicy">The specific retry policy that will ensure reliable access to the underlying storage.</param>
        /// <param name="dataSerializer">An instance of the component which performs serialization and deserialization of storage objects.</param>
        /// <param name="overflowStorage">An instance of the component implementing overflow store that will be used for persisting large messages that cannot be accommodated in a queue due to message size constraints.</param>
        public ReliableCloudQueueStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy, ICloudStorageEntitySerializer dataSerializer, ICloudBlobStorage overflowStorage)
        {
            Guard.ArgumentNotNull(storageAccountInfo, "storageAccountInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");
            Guard.ArgumentNotNull(dataSerializer, "dataSerializer");
            Guard.ArgumentNotNull(overflowStorage, "overflowStorage");

            this.retryPolicy = retryPolicy;
            this.dataSerializer = dataSerializer;
            this.overflowStorage = overflowStorage;

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey(storageAccountInfo.AccountName, storageAccountInfo.AccountKey), true);
            this.queueStorage = storageAccount.CreateCloudQueueClient();

            // Configure the Queue storage not to enforce any retry policies since this is something that we will be dealing ourselves.
            this.queueStorage.RetryPolicy = RetryPolicies.NoRetry();
           
            this.inflightMessages = new ConcurrentDictionary<object, InflightMessageInfo>(Environment.ProcessorCount * 4, InflightMessageQueueInitialCapacity);
        }
        #endregion

        #region ICloudQueueStorage implementation
        /// <summary>
        /// Creates a new queue.
        /// </summary>
        /// <param name="queueName">The name of a new queue.</param>
        /// <returns>A flag indicating whether or the queue did not exist and was therefore created.</returns>
        public bool CreateQueue(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(queueName);

            try
            {
                var queue = this.queueStorage.GetQueueReference(CloudUtility.GetSafeContainerName(queueName));

                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    return queue.CreateIfNotExist();
                });
            }
            catch (StorageClientException ex)
            {
                if (ex.ErrorCode == StorageErrorCode.ContainerAlreadyExists || ex.ErrorCode == StorageErrorCode.ResourceAlreadyExists)
                {
                    return false;
                }

                throw;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Puts a single message on a queue.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The target queue name on which message will be placed.</param>
        /// <param name="message">The payload to be put into a queue.</param>
        public void Put<T>(string queueName, T message)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");
            Guard.ArgumentNotNull(message, "message");

            // Obtain a reference to the queue by its name. The name will be validated against compliance with storage resource names.
            var queue = this.queueStorage.GetQueueReference(CloudUtility.GetSafeContainerName(queueName));

            CloudQueueMessage queueMessage = null;

            // Allocate a memory buffer into which messages will be serialized prior to being put on a queue.
            using (MemoryStream dataStream = new MemoryStream(Convert.ToInt32(CloudQueueMessage.MaxMessageSize)))
            {
                // Perform serialization of the message data into the target memory buffer.
                this.dataSerializer.Serialize(message, dataStream);

                // Reset the position in the buffer as we will be reading its content from the beginning.
                dataStream.Seek(0, SeekOrigin.Begin);

                // First, determine whether the specified message can be accommodated on a queue.
                if (CloudUtility.IsAllowedQueueMessageSize(dataStream.Length))
                {
                    queueMessage = new CloudQueueMessage(dataStream.ToArray());
                }
                else
                {
                    // Create an instance of a large queue item metadata message.
                    LargeQueueMessageInfo queueMsgInfo = LargeQueueMessageInfo.Create(queueName);

                    // Persist the stream of data that represents a large message into the overflow message store.
                    this.overflowStorage.Put<Stream>(queueMsgInfo.ContainerName, queueMsgInfo.BlobReference, dataStream);

                    // Invoke the Put operation recursively to enqueue the metadata message.
                    Put<LargeQueueMessageInfo>(queueName, queueMsgInfo);
                }
            }

            // Check if a message is available to be put on a queue.
            if (queueMessage != null)
            {
                Put(queue, queueMessage);
            }
        }

        /// <summary>
        /// Deletes a single message from a queue.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="message">The message to be deleted from a queue.</param>
        /// <returns>A flag indicating whether or not the specified message has actually been deleted.</returns>
        public bool Delete<T>(T message)
        {
            Guard.ArgumentNotNull(message, "message");

            int deletedMsgCount = 0;

            InflightMessageInfo inflightMessage = null;

            if (this.inflightMessages.TryRemove(message, out inflightMessage))
            {
                try
                {
                    var queue = this.queueStorage.GetQueueReference(inflightMessage.QueueName);

                    foreach (var queueMsg in inflightMessage.QueueMessages)
                    {
                        if (Delete(queue, queueMsg))
                        {
                            deletedMsgCount++;
                        }
                    }

                    // Remove large message blob (if associated with the message being deleted).
                    if (inflightMessage.LargeMessageMetadata != null)
                    {
                        this.overflowStorage.Delete(inflightMessage.LargeMessageMetadata.ContainerName, inflightMessage.LargeMessageMetadata.BlobReference);
                    }
                }
                catch
                {
                    // In the event of a failure, return the removed in-flight message back to the collection.
                    if (!this.inflightMessages.TryAdd(message, inflightMessage))
                    {
                        this.inflightMessages.AddOrUpdate(message, inflightMessage, (key, oldValue) => { return inflightMessage; });
                    }
                    throw;
                }
            }
            
            return deletedMsgCount > 0;
        }

        /// <summary>
        /// Clears all messages from the specified queue.
        /// </summary>
        /// <param name="queueName">The name of the queue that will be emptied.</param>
        public void Clear(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(queueName);

            try
            {
                var queue = this.queueStorage.GetQueueReference(CloudUtility.GetSafeContainerName(queueName));

                this.retryPolicy.ExecuteAction(() =>
                {
                    if (queue.Exists())
                    {
                        queue.Clear();
                    }
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Deletes the specified queue.
        /// </summary>
        /// <param name="queueName">The name of the queue to be deleted.</param>
        /// <returns>True if the queue name has been actually deleted, otherwise False.</returns>
        public bool DeleteQueue(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(queueName);

            try
            {
                // Must delete the associated blob storage in which large messages are persisted.
                LargeQueueMessageInfo largeMsgInfo = LargeQueueMessageInfo.Create(queueName);
                this.overflowStorage.DeleteContainer(largeMsgInfo.ContainerName);

                // Now proceed with deleting the queue.
                var queue = this.queueStorage.GetQueueReference(CloudUtility.GetSafeContainerName(queueName));

                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    if (queue.Exists())
                    {
                        queue.Delete();
                        return true;
                    }
                    return false;
                });
            }
            catch (Exception ex)
            {
                TraceManager.CloudStorageComponent.TraceError(ex);
                return false;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Retrieves a single message from the specified queue.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The name of the source queue.</param>
        /// <returns>An instance of the object that has been fetched from the queue.</returns>
        public T Get<T>(string queueName)
        {
            return Get<T>(queueName, 1).FirstOrDefault<T>();
        }

        /// <summary>
        /// Gets a collection of messages from the specified queue and applies the default visibility timeout.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The name of the source queue.</param>
        /// <param name="count">The number of messages to retrieve.</param>
        /// <returns>The list of messages retrieved from the specified queue.</returns>
        public IEnumerable<T> Get<T>(string queueName, int count)
        {
            return Get<T>(queueName, count, CloudEnvironment.SafeQueueVisibilityTimeout);
        }

        /// <summary>
        /// Gets a collection of messages from the specified queue and applies the specified visibility timeout.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the message.</typeparam>
        /// <param name="queueName">The name of the source queue.</param>
        /// <param name="count">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The timeout during which retrieved messages will remain invisible on the queue.</param>
        /// <returns>The list of messages retrieved from the specified queue.</returns>
        public IEnumerable<T> Get<T>(string queueName, int count, TimeSpan visibilityTimeout)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");
            Guard.ArgumentNotZeroOrNegativeValue(count, "count");

            try
            {
                var queue = this.queueStorage.GetQueueReference(CloudUtility.GetSafeContainerName(queueName));

                IEnumerable<CloudQueueMessage> queueMessages = this.retryPolicy.ExecuteAction<IEnumerable<CloudQueueMessage>>(() =>
                {
                    return queue.GetMessages(Math.Min(count, CloudQueueMessage.MaxNumberOfMessagesToPeek), visibilityTimeout);
                });

                if (queueMessages != null)
                {
                    Type queueMsgType = typeof(T);
                    var messages = new List<T>(count);

                    foreach (var queueMsg in queueMessages)
                    {
                        object msgObject = DeserializeQueueMessage(queueMsg, queueMsgType);

                        // Construct an in-flight message object describing the queued message.
                        InflightMessageInfo inflightMessage = new InflightMessageInfo() { QueueName = queue.Name };

                        // Register the queued message so that it can be located later on.
                        inflightMessage.QueueMessages.Add(queueMsg);

                        if (msgObject is LargeQueueMessageInfo)
                        {
                            // Looks like we are dealing a large message that needs to be fetched from blob storage.
                            inflightMessage.LargeMessageMetadata = msgObject as LargeQueueMessageInfo;

                            // Attempt to retrieve the actual message data from the blob storage.
                            T msgData = this.overflowStorage.Get<T>(inflightMessage.LargeMessageMetadata.ContainerName, inflightMessage.LargeMessageMetadata.BlobReference);

                            // If blob was found, add it to the list of messages being fetched and returned.
                            if (msgData != null)
                            {
                                messages.Add(msgData);
                                msgObject = msgData;
                            }
                            else
                            {
                                // We should skip the current message as it's data has not been located.
                                continue;
                            }
                        }
                        else
                        {
                            messages.Add((T)msgObject);
                        }

                        // Update the in-flight collection, add a new item if necessary, otherwise perform a thread-safe update.
                        this.inflightMessages.AddOrUpdate(msgObject, inflightMessage, (key, oldValue) => 
                        {
                            oldValue.QueueMessages.Clear();
                            return inflightMessage;
                        });
                    }

                    return messages;
                }
            }
            catch (Exception ex)
            {
                // We intend to never fail when fetching messages from a queue. We will still need to report on a exception and return an empty list.
                TraceManager.CloudStorageComponent.TraceError(ex);
            }

            // By default, return an empty collection of messages if the above code path didn't return a result.
            return new T[0];
        }

        /// <summary>
        /// Gets the approximate number of items in the specified queue.
        /// </summary>
        /// <param name="queueName">The name of the queue to be queried.</param>
        /// <returns>The approximate number of items in the queue.</returns>
        public int GetCount(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(queueName);
            int messageCount = 0;

            try
            {
                var queue = this.queueStorage.GetQueueReference(CloudUtility.GetSafeContainerName(queueName));

                messageCount = this.retryPolicy.ExecuteAction<int>(() =>
                {
                    return queue.RetrieveApproximateMessageCount();
                });

                return messageCount;
            }
            catch (StorageClientException ex)
            {
                if (ex.ErrorCode == StorageErrorCode.ResourceNotFound || ex.ExtendedErrorInformation.ErrorCode == QueueErrorCodeStrings.QueueNotFound)
                {
                    return 0;
                }

                throw;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, messageCount);
            }
        }
        #endregion

        #region Private methods
        private void Put(CloudQueue queue, CloudQueueMessage message)
        {
            this.retryPolicy.ExecuteAction(() =>
            {
                for (; ; )
                {
                    try
                    {
                        queue.AddMessage(message);
                        break;
                    }
                    catch (StorageClientException ex)
                    {
                        if (ex.ErrorCode != StorageErrorCode.ResourceNotFound && ex.ExtendedErrorInformation.ErrorCode != QueueErrorCodeStrings.QueueNotFound)
                        {
                            throw;
                        }

                        // We should automatically create a new queue if one is not as yet created.
                        queue.CreateIfNotExist();
                    }
                }
            });
        }

        private bool Delete(CloudQueue queue, CloudQueueMessage message)
        {
            try
            {
                this.retryPolicy.ExecuteAction(() =>
                {
                    queue.DeleteMessage(message);
                });

                return true;
            }
            catch (StorageClientException ex)
            {
                if (ex.ErrorCode != StorageErrorCode.ResourceNotFound && ex.ExtendedErrorInformation.ErrorCode != QueueErrorCodeStrings.QueueNotFound)
                {
                    throw;
                }
            }

            return false;
        }

        private object DeserializeQueueMessage(CloudQueueMessage queueMsg, Type destType)
        {
            using (MemoryStream messageData = new MemoryStream(queueMsg.AsBytes))
            {
                try
                {
                    long dataLength = messageData.Length;
                    object msgObject = this.dataSerializer.Deserialize(messageData, destType);

                    // If successful, verify whether or not we are dealing with a small message of type XElement or XDocument. This is because the de-serialization from these types
                    // will not reliably detect the serialized instances of LargeQueueMessageInfo and will return them as either XElement or XDocument.
                    if (CloudUtility.IsAllowedQueueMessageSize(dataLength) && (destType == typeof(XDocument) || destType == typeof(XElement)))
                    {
                        // Both XElement and XDocument share the same base class of type XNode, hence we can safely cast to this type.
                        XNode xmlMsgObject = msgObject as XNode;
                        
                        if (xmlMsgObject != null)
                        {
                            using (XmlReader xmlReader = xmlMsgObject.CreateReader())
                            {
                                xmlReader.MoveToContent();

                                // If the first node's name matches the name of the LargeQueueMessageInfo type, 
                                // we should treat this message as an instance of LargeQueueMessageInfo and perform de-serialization one more time.
                                if (String.Compare(xmlReader.Name, typeof(LargeQueueMessageInfo).Name, false) == 0)
                                {
                                    messageData.Seek(0, SeekOrigin.Begin);
                                    msgObject = this.dataSerializer.Deserialize(messageData, typeof(LargeQueueMessageInfo));
                                }
                            }
                        }
                    }

                    return msgObject;
                }
                catch (SerializationException)
                {
                    // Got a serialization exception, should reset the stream position.
                    messageData.Seek(0, SeekOrigin.Begin);
                }

                // Try to deserialize as LargeQueueMessageInfo.
                return this.dataSerializer.Deserialize(messageData, typeof(LargeQueueMessageInfo));
            }
        }
        #endregion

        #region IDisposable implementation
         /// <summary>
        /// Helper method to check whether the object has already been disposed.
        /// </summary>
        private void DisposedCheck()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(typeof(ReliableCloudQueueStorage).FullName);
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableCloudQueueStorage()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        /// <param name="disposing">Determines whether this was called by Dispose or by the finalizer.</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // We can safely dispose of .NET resources.
                    this.inflightMessages.Clear();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region InflightMessageInfo class declaration
        private class InflightMessageInfo
        {
            private readonly IList<CloudQueueMessage> queueMessages = new List<CloudQueueMessage>();

            public string QueueName 
            { 
                get; set; 
            }

            public LargeQueueMessageInfo LargeMessageMetadata 
            { 
                get; set; 
            }

            public IList<CloudQueueMessage> QueueMessages 
            { 
                get { return this.queueMessages; } 
            }
        } 
        #endregion
    }
}
