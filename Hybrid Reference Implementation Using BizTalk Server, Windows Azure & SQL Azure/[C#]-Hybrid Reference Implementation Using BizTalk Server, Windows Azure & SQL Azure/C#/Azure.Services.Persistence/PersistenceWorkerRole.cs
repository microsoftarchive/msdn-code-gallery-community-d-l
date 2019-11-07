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
    using System.ServiceModel;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Discovery;
    using Contoso.Cloud.Integration.Common.Activities;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    /// <summary>
    /// Implements a worker role dedicated to hosting of the Persistence service.
    /// </summary>
    [ServiceBusHostWorkerRole(typeof(PersistenceService), ServiceBusEndpoint = "PersistenceService")]
    public class PersistenceWorkerRole : ReliableWorkerRoleBase
    {
        /// <summary>
        /// Extends the Run phase that is called by Windows Azure runtime after the role instance has been initialized.
        /// </summary>
        protected override void OnRoleRun()
        {
            IServiceBusHostWorkerRoleExtension serviceHostExtension = Extensions.Find<IServiceBusHostWorkerRoleExtension>();

            if (serviceHostExtension != null)
            {
                PersistenceService persistenceService = serviceHostExtension.FindServiceHost<PersistenceService>();

                if(persistenceService != null)
                {
                    persistenceService.PersistDataStreamCompleted += new OperationCompletedDelegate<PersistenceQueueItemInfo>(OnPersistDataStreamCompleted);
                }

                serviceHostExtension.StartAll();
            }
        }

        /// <summary>
        /// Extends the OnStart phase that is called by Windows Azure runtime to initialize the role instance.
        /// </summary>
        /// <returns>True if initialization succeeds, otherwise false.</returns>
        protected override bool OnRoleStart()
        {
            this.EnsureExists<EndpointConfigurationDiscoveryExtension>();
            this.EnsureExists<ActivityTrackingEventStreamExtension>();

            IEndpointConfigurationDiscoveryExtension discoveryExtension = Extensions.Find<IEndpointConfigurationDiscoveryExtension>();

            var contractTypeMatchCondition = ServiceEndpointDiscoveryCondition.ContractTypeExactMatch(typeof(IPersistenceServiceContract));
            var bindingTypeMatchCondition = ServiceEndpointDiscoveryCondition.BindingTypeExactMatch(typeof(NetTcpRelayBinding));

            discoveryExtension.RegisterDiscoveryAction(new [] { contractTypeMatchCondition, bindingTypeMatchCondition }, (endpoint) =>
            {
                NetTcpRelayBinding relayBinding = endpoint.Binding as NetTcpRelayBinding;
                
                if (relayBinding != null)
                {
                    relayBinding.TransferMode = TransferMode.Streamed;
                }
            });

            return true;
        }

        /// <summary>
        /// Extends the OnStop phase that is called by Windows Azure runtime when the role instance is to be stopped.
        /// </summary>
        protected override void OnRoleStop()
        {
        }

        #region Private methods
        private void OnPersistDataStreamCompleted(PersistenceQueueItemInfo queueItemInfo)
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(queueItemInfo.QueueItemId, queueItemInfo.QueueItemType, queueItemInfo.QueueItemSize);

            IInterRoleCommunicationExtension interCommExtension = Extensions.Find<IInterRoleCommunicationExtension>();

            if (interCommExtension != null)
            {
                InterRoleCommunicationEvent e = new InterRoleCommunicationEvent(queueItemInfo);
                interCommExtension.Publish(e);
            }

            TraceManager.WorkerRoleComponent.TraceOut(callToken);
        }
        #endregion
    }
}
