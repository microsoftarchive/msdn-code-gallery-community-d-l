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
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.ComponentModel;
    #endregion

    /// <summary>
    /// Provides the types of Windows Azure Service Bus endpoints.
    /// </summary>
    [DefaultValue(ServiceBusEndpointType.Relay)]
    public enum ServiceBusEndpointType
    {
        /// <summary>
        /// Defines an endpoint type prescribing the use of the NetTcpRelayBinding binding with Relayed connection mode.
        /// </summary>
        Relay,

        /// <summary>
        /// Defines an endpoint type prescribing the use of the NetTcpRelayBinding binding with Hybrid connection mode.
        /// </summary>
        HybridRelay,

        /// <summary>
        /// Defines an endpoint type prescribing the use of the NetEventRelayBinding binding.
        /// </summary>
        Eventing,

        /// <summary>
        /// Defines an endpoint type prescribing the use of the Service Bus queues.
        /// </summary>
        Queue,

        /// <summary>
        /// Defines an endpoint type prescribing the use of the Service Bus topics.
        /// </summary>
        Topic
    }
}
