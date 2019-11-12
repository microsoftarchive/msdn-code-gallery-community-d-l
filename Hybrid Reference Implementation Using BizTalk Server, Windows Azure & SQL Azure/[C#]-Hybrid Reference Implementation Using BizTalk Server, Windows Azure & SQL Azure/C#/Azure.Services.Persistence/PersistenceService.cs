//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Persistence worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Persistence
{
    #region Using references
    using System;
    using System.IO;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Common;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    #endregion

    /// <summary>
    /// Provides an implementation of the Persistence service that supports the <see cref="IPersistenceServiceContract"/> contract.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public sealed class PersistenceService : IPersistenceServiceContract
    {
        #region IPersistenceService implementation
        /// <summary>
        /// Occurs when the entire data stream has been successfully persisted into the underlying durable store.
        /// </summary>
        public event OperationCompletedDelegate<PersistenceQueueItemInfo> PersistDataStreamCompleted;

        /// <summary>
        /// Persists the specified stream of data into the queue and returns an unique identify that corresponds to the persisted queue item.
        /// </summary>
        /// <param name="data">The stream containing the data to be persisted.</param>
        /// <returns>The unique identity of the queue item.</returns>
        public Guid PersistDataStream(Stream data)
        {
            Guard.ArgumentNotNull(data, "data");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(data.GetType().FullName);

            PersistenceQueueItemInfo queueItemInfo = null;

            using (SqlAzurePersistenceQueue dbQueue = new SqlAzurePersistenceQueue(StreamingMode.FixedBuffer))
            {
                dbQueue.Open(WellKnownDatabaseName.PersistenceQueue);
                queueItemInfo = dbQueue.Enqueue(data);
            }

            if (PersistDataStreamCompleted != null)
            {
                PersistDataStreamCompleted(queueItemInfo);
            }

            TraceManager.WorkerRoleComponent.TraceOut(callToken, queueItemInfo.QueueItemId);
            return queueItemInfo.QueueItemId;
        }
        #endregion
    }
}
