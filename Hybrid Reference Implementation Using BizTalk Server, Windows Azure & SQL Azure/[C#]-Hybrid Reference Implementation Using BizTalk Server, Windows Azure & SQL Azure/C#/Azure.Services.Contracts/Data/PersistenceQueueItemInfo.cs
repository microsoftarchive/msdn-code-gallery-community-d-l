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
    using System.ServiceModel;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements a data transfer object carrying the details of an item in the Persistence Queue.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.General)]
    public class PersistenceQueueItemInfo
    {
        /// <summary>
        /// Returns the unique identity of the item.
        /// </summary>
        [DataMember]
        public Guid QueueItemId { get; private set; }

        /// <summary>
        /// Returns the size of the item's payload.
        /// </summary>
        [DataMember]
        public long QueueItemSize { get; private set; }

        /// <summary>
        /// Returns the type of the item (empty for binary payload, a concatenated value of the XML namespace and root node name for XML payload).
        /// </summary>
        [DataMember]
        public string QueueItemType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the data transfer object carrying the details of an item in the Persistence Queue.
        /// </summary>
        /// <param name="itemId">The unique identity of the item</param>
        /// <param name="itemSize">The size of the item's payload</param>
        /// <param name="itemType">The type of the item (empty for binary payload, a concatenated value of the XML namespace and root node name for XML payload)</param>
        public PersistenceQueueItemInfo(Guid itemId, long itemSize, string itemType)
        {
            QueueItemId = itemId;
            QueueItemSize = itemSize;
            QueueItemType = itemType;
        }
    }
}
