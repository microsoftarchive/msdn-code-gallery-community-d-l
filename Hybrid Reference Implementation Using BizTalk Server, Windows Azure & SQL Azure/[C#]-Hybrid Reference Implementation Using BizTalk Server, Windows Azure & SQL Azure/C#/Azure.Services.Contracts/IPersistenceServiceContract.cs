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
    using System.IO;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Defines a service contract supported by the Persistence service.
    /// </summary>
    [ServiceContract(Name = "IPersistenceService", Namespace = WellKnownNamespace.ServiceContracts.General)]
    public interface IPersistenceServiceContract
    {
        /// <summary>
        /// Persists the specified stream of data into the queue and returns an unique identify that corresponds to the persisted queue item.
        /// </summary>
        /// <param name="data">The stream containing the data to be persisted.</param>
        /// <returns>The unique identity of the queue item.</returns>
        [OperationContract(Action = "*", ReplyAction = "*")]
        Guid PersistDataStream(Stream data);
    }

    /// <summary>
    /// Defines a client channel contract to communicate with the Persistence service.
    /// </summary>
    public interface IPersistenceServiceChannel : IPersistenceServiceContract, IClientChannel { }
}
