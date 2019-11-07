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
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Represents a generic event for inter-role communication carrying the sender's identity and useful event payload.
    /// </summary>
    [DataContract(Namespace = WellKnownNamespace.DataContracts.Infrastructure)]
    [KnownType(typeof(PersistenceQueueItemInfo))]
    [KnownType(typeof(RoleConfigurationSectionRefreshEvent))]
    [KnownType(typeof(RoleGracefulRecycleEvent))]
    [KnownType(typeof(CloudQueueWorkDetectedTriggerEvent))]
    public class InterRoleCommunicationEvent
    {
        #region Public properties
        /// <summary>
        /// The event payload, namely a DataContract-serializable object that carries the information about the event.
        /// </summary>
        [DataMember]
        public object Payload { get; private set; }

        /// <summary>
        /// The role instance ID of the sender.
        /// </summary>
        [DataMember]
        public string FromInstanceID { get; set; }

        /// <summary>
        /// The role instance ID of the received.
        /// </summary>
        [DataMember]
        public string ToInstanceID { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the inter-role communication event originated from the specified role instance ID and specified payload.
        /// </summary>
        /// <param name="payload">The event payload.</param>
        public InterRoleCommunicationEvent(object payload)
        {
            Payload = payload;
        }
        #endregion
    }
}
