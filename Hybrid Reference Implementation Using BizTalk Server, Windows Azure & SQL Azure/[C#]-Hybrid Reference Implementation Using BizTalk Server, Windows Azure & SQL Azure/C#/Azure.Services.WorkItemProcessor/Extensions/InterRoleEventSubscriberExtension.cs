//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Work Item Processor worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.Common.RulesEngine;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Properties;
    #endregion

    /// <summary>
    /// Implements the extension responsible for receiving and handling inter-role communication events.
    /// </summary>
    public class InterRoleEventSubscriberExtension : IInterRoleEventSubscriberExtension
    {
        #region Private members
        private IExtensibleCloudServiceComponent owner;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.EnsureExists<RulesEngineServiceClientExtension>();

            this.owner = owner;
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            this.owner = null;
        }
        #endregion

        #region IObserver implementation
        /// <summary>
        /// Gets called by the provider to notify this subscriber about a new inter-role communication event.
        /// </summary>
        /// <param name="e">The received inter-role communication event.</param>
        public void OnNext(InterRoleCommunicationEvent e)
        {
            Guard.ArgumentNotNull(e, "e");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(e.FromInstanceID, e.ToInstanceID);

            try
            {
                if (this.owner != null && e.Payload != null)
                {
                    if (e.Payload is PersistenceQueueItemInfo)
                    {
                        HandlePersistenceQueueItem(e.Payload as PersistenceQueueItemInfo);
                        return;
                    }

                    if (e.Payload is CloudQueueWorkDetectedTriggerEvent)
                    {
                        HandleQueueWorkDetectedTriggerEvent(e.Payload as CloudQueueWorkDetectedTriggerEvent);
                        return;
                    }
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Gets called by the provider to indicate that it has finished processing an inter-role communication event.
        /// </summary>
        public void OnCompleted()
        {
        }

        /// <summary>
        /// Gets called by the provider to indicate that data is unavailable, inaccessible, or corrupted, 
        /// or that the provider has experienced some other error condition.
        /// </summary>
        /// <param name="error">The exception that resulted in an error condition.</param>
        public void OnError(Exception error)
        {
            if (error != null)
            {
                TraceManager.WorkerRoleComponent.TraceError(error);
            }
        }
        #endregion

        #region Private members
        private void HandlePersistenceQueueItem(PersistenceQueueItemInfo itemInfo)
        {
            Guard.ArgumentNotNull(itemInfo, "itemInfo");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(itemInfo.QueueItemId, itemInfo.QueueItemType, itemInfo.QueueItemSize);

            try
            {
                this.owner.Extensions.Demand<IRulesEngineServiceClientExtension>();
                this.owner.Extensions.Demand<IWorkItemProcessorConfigurationExtension>();

                IWorkItemProcessorConfigurationExtension configSettingsExtension = this.owner.Extensions.Find<IWorkItemProcessorConfigurationExtension>();
                IRulesEngineServiceClientExtension rulesEngineExtension = this.owner.Extensions.Find<IRulesEngineServiceClientExtension>();

                // Invoke a policy to determine the number of dequeue listeners required to process this volume of data.
                StringDictionaryFact policyExecutionResult = rulesEngineExtension.ExecutePolicy<StringDictionaryFact>(configSettingsExtension.Settings.HandlingPolicyName, itemInfo);
                int dequeueTaskCount = policyExecutionResult != null && !String.IsNullOrEmpty(policyExecutionResult.Items[Resources.StringDictionaryFactValueDequeueListenerCount]) ? Convert.ToInt32(policyExecutionResult.Items[Resources.StringDictionaryFactValueDequeueListenerCount]) : 0;

                // Check if the policy has provided us with the number of queue listeners.
                if (dequeueTaskCount > 0)
                {
                    // Write the number of dequeue tasks into trace log.
                    TraceManager.WorkerRoleComponent.TraceInfo(TraceLogMessages.DequeueTaskCountInfo, itemInfo.QueueItemType, itemInfo.QueueItemSize, dequeueTaskCount);

                    // Request all queue listeners to increase the number of listeners accordingly to the given workload.
                    foreach (var queueService in this.owner.Extensions.FindAll<ICloudQueueServiceWorkerRoleExtension>())
                    {
                        // Get the queue listener state information such as queue depth, number of activity listener threads and total number of listener threads.
                        var state = queueService.QueryState();

                        // If the queue listener count is less than suggested by the policy, start as many extra listener threads as needed.
                        if (state.ActiveDequeueTasks < dequeueTaskCount)
                        {
                            queueService.StartListener(dequeueTaskCount - state.ActiveDequeueTasks);
                        }
                    }
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        private void HandleQueueWorkDetectedTriggerEvent(CloudQueueWorkDetectedTriggerEvent e)
        {
            Guard.ArgumentNotNull(e, "e");

            // Enumerate through registered queue listeners and relay the trigger event to them.
            foreach (var queueService in this.owner.Extensions.FindAll<ICloudQueueServiceWorkerRoleExtension>())
            {
                // Pass the trigger event to a given queue listener.
                queueService.OnNext(e);
            }
        }
        #endregion
    }
}
