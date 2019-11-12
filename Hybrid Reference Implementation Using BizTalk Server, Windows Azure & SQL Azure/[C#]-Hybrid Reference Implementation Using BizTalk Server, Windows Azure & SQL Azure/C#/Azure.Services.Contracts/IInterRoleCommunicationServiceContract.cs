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
namespace Contoso.Cloud.Integration.Azure.Services.Contracts
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a contract for inter-role communication using push-based notifications.
    /// </summary>
    [ServiceContract(Name = "IInterRoleCommunicationService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IInterRoleCommunicationServiceContract : IObservable<InterRoleCommunicationEvent>
    {
        /// <summary>
        /// Multicasts the specified inter-role communication event to one or more subscribers.
        /// </summary>
        /// <param name="e">The inter-role communication event to be delivered to the subscribers.</param>
        [OperationContract(IsOneWay = true)]
        void Publish(InterRoleCommunicationEvent e);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the inter-role communication service.
    /// </summary>
    public interface IInterRoleCommunicationServiceChannel : IInterRoleCommunicationServiceContract, IClientChannel { }
}
