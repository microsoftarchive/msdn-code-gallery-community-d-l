//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains service and data contract definitions.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Contracts.Data
{
    #region Using references
    using System;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements a trigger event indicating that a new workload was put in a queue.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    public class CloudQueueWorkDetectedTriggerEvent
    {
        /// <summary>
        /// Returns the name of the storage account on which the queue is located.
        /// </summary>
        [DataMember]
        public string StorageAccount { get; private set; }

        /// <summary>
        /// Returns a name of the queue where the payload was put.
        /// </summary>
        [DataMember]
        public string QueueName { get; private set; }

        /// <summary>
        /// Returns a size of the queue's payload (e.g. the size of a message or the number of messages).
        /// </summary>
        [DataMember]
        public long PayloadSize { get; private set; }
        
        /// <summary>
        /// Returns the kind of payload size.
        /// </summary>
        [DataMember]
        public PayloadSizeKind PayloadSizeKind { get; private set; }

        /// <summary>
        /// Initializes a new instance of the trigger event indicating that a given queue in the specified account has received a new payload.
        /// </summary>
        /// <param name="storageAccount">The name of the storage account on which the queue is located.</param>
        /// <param name="queueName">The name of the queue on which a new payload was put.</param>
        public CloudQueueWorkDetectedTriggerEvent(string storageAccount, string queueName)
        {
            StorageAccount = storageAccount;
            QueueName = queueName;
        }

        /// <summary>
        /// Initializes a new instance of the trigger event indicating that a given queue in the specified account has received a new payload.
        /// </summary>
        /// <param name="storageAccount">The name of the storage account on which the queue is located.</param>
        /// <param name="queueName">The name of the queue on which a new payload was put.</param>
        /// <param name="payloadSize">The a size of the queue's payload (e.g. the size of a message or the number of messages).</param>
        /// <param name="payloadSizeKind">The kind of payload size.</param>
        public CloudQueueWorkDetectedTriggerEvent(string storageAccount, string queueName, long payloadSize, PayloadSizeKind payloadSizeKind)
        {
            StorageAccount = storageAccount;
            QueueName = queueName;
            PayloadSize = payloadSize;
            PayloadSizeKind = payloadSizeKind;
        }
    }

    /// <summary>
    /// Defines a particular kind of payload size that can be sent in the <see cref="CloudQueueWorkDetectedTriggerEvent"/> events.
    /// </summary>
    public enum PayloadSizeKind
    {
        /// <summary>
        /// Payload size represents the number of messages.
        /// </summary>
        MessageCount,

        /// <summary>
        /// Payload size represents the size of an individual message.
        /// </summary>
        MessageSize
    }
}
