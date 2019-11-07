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
    #endregion

    /// <summary>
    /// Implements a declarative attribute that can be applied to a worker role to enable the role instances
    /// to automatically participate in queue service operations.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class QueueServiceWorkerRoleAttribute : Attribute
    {
        #region Private members
        private CloudQueueLocation queueLocation = new CloudQueueLocation(); 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the QueueServiceWorkerRoleAttribute class with a default visibility timeout.
        /// </summary>
        private QueueServiceWorkerRoleAttribute()
        {
            // Set the default visibility timeout a safe value to prevent race condition.
            VisibilityTimeout = CloudEnvironment.SafeQueueVisibilityTimeout;

            // Set the default number of queue listeners;
            NumberOfListeners = 1;
        }

        /// <summary>
        /// Initializes a new instance of the QueueServiceWorkerRoleAttribute class with the default queue storage account 
        /// and queue name on which service instances will be listening.
        /// </summary>
        /// <param name="queueName">The name of the queue on which service instances will be listening.</param>
        public QueueServiceWorkerRoleAttribute(string queueName) : this()
        {
            QueueName = queueName;
        }

        /// <summary>
        /// Initializes a new instance of the QueueServiceWorkerRoleAttribute class with the name of storage account 
        /// and queue on which service instances will be listening.
        /// </summary>
        /// <param name="storageAccount">The name of the storage account definition in the application configuration.</param>
        /// <param name="queueName">The name of the queue on which service instances will be listening.</param>
        public QueueServiceWorkerRoleAttribute(string storageAccount, string queueName) : this()
        {
            StorageAccount = storageAccount;
            QueueName = queueName;
        } 
        #endregion

        #region Public properties
        /// <summary>
        /// The name of the storage account definition in the application configuration.
        /// </summary>
        public string StorageAccount 
        {
            get { return this.queueLocation.StorageAccount; }
            set { this.queueLocation.StorageAccount = value; }
        }

        /// <summary>
        /// The name of the queue on which service instances will be listening.
        /// </summary>
        public string QueueName
        {
            get { return this.queueLocation.QueueName; }
            set { this.queueLocation.QueueName = value; }
        }

        /// <summary>
        /// The visibility timeout (in seconds) indicating when messages should become visible in the queue 
        /// again if they not consumed and deleted from the queue.
        /// </summary>
        public int VisibilityTimeoutSeconds
        {
            get { return Convert.ToInt32(this.queueLocation.VisibilityTimeout.TotalSeconds); }
            set { this.queueLocation.VisibilityTimeout = TimeSpan.FromSeconds(value); }
        }

        /// <summary>
        /// The visibility timeout indicating when messages should become visible in the queue 
        /// again if they not consumed and deleted from the queue.
        /// </summary>
        public TimeSpan VisibilityTimeout 
        {
            get { return this.queueLocation.VisibilityTimeout; }
            set { this.queueLocation.VisibilityTimeout = value; }
        }

        /// <summary>
        /// The number of worker threads listening on the queue.
        /// </summary>
        public int NumberOfListeners { get; set; }

        /// <summary>
        /// The location of the queue in the Azure storage fabric and storage account namespace.
        /// </summary>
        public CloudQueueLocation QueueLocation
        {
            get { return this.queueLocation; }
        }
        #endregion
    }
}