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
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Represents a location of a queue in the Windows Azure storage infrastructure.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    public class CloudQueueLocation
    {
        #region Public properties
        /// <summary>
        /// Represents an unknown, non-discoverable location.
        /// </summary>
        public readonly static CloudQueueLocation Unknown = new CloudQueueLocation();

        /// <summary>
        /// The name of the storage account on which the queue is located.
        /// </summary>
        [DataMember]
        public string StorageAccount { get; set; }

        /// <summary>
        /// The actual name of the queue.
        /// </summary>
        [DataMember]
        public string QueueName { get; set; }

        /// <summary>
        /// The visibility timeout (in seconds) indicating when messages should become visible in the queue 
        /// again if they not consumed and deleted from the queue.
        /// </summary>
        [DataMember]
        public TimeSpan VisibilityTimeout { get; set; }

        /// <summary>
        /// Indicates whether or not the queue location is discoverable without asserting its physical presence.
        /// </summary>
        [IgnoreDataMember]
        public bool IsDiscoverable
        {
            get { return !String.IsNullOrEmpty(StorageAccount) && !String.IsNullOrEmpty(QueueName); }
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Determines whether or not the specified location is null or is considered as unknown.
        /// This method does not check if the queue is actually present in the given location.
        /// </summary>
        /// <param name="location">The location to be validated.</param>
        /// <returns>A flag indicating whether or not the specified location is null or is considered as unknown</returns>
        public static bool IsUnknown(CloudQueueLocation location)
        {
            return !(location != null && location != Unknown);
        }
        #endregion
    }
}
