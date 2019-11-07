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
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor
{
    #region Using references
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.ServiceModel;

    using Microsoft.ServiceBus;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Discovery;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Extensions;
    #endregion

    /// <summary>
    /// Implements a worker role dedicated to work items processing.
    /// </summary>
    public class WorkItemProcessorWorkerRole : ReliableWorkerRoleBase
    {
        #region Private members
        private IDisposable interCommSubscription;
        #endregion

        #region ReliableWorkerRoleBase overrides
        /// <summary>
        /// Extends the Run phase that is called by Windows Azure runtime after the role instance has been initialized.
        /// </summary>
        protected override void OnRoleRun()
        {
            // Start all registered queue listener so that we can process any work that remain outstanding at the time of role booting up.
            foreach (var queueService in Extensions.FindAll<ICloudQueueServiceWorkerRoleExtension>())
            {
                queueService.StartListener(1);
            }
        }

        /// <summary>
        /// Extends the OnStart phase that is called by Windows Azure runtime to initialize the role instance.
        /// </summary>
        /// <returns>True if initialization succeeds, otherwise false.</returns>
        protected override bool OnRoleStart()
        {
            this.EnsureExists<WorkItemProcessorConfigurationExtension>();
            this.EnsureExists<WorkQueueLocationResolverExtension>();
            this.EnsureExists<ScalableTransformServiceClientExtension>();
            this.EnsureExists<EndpointConfigurationDiscoveryExtension>();
            this.EnsureExists<RulesEngineServiceClientExtension>();
            this.EnsureExists<InterRoleEventSubscriberExtension>();

            IWorkItemProcessorConfigurationExtension configSettingsExtension = Extensions.Find<IWorkItemProcessorConfigurationExtension>();
            IEndpointConfigurationDiscoveryExtension discoveryExtension = Extensions.Find<IEndpointConfigurationDiscoveryExtension>();
            IInterRoleCommunicationExtension interCommExtension = Extensions.Find<IInterRoleCommunicationExtension>();
            IInterRoleEventSubscriberExtension interCommSubscriber = Extensions.Find<IInterRoleEventSubscriberExtension>();

            CloudQueueLocation inputQueueLocation = new CloudQueueLocation()
            {
                StorageAccount = configSettingsExtension.Settings.CloudStorageAccount,
                QueueName = configSettingsExtension.Settings.WorkItemQueue,
                VisibilityTimeout = configSettingsExtension.Settings.WorkItemQueueVisibilityTimeout
            };

            CloudQueueLocation outputQueueLocation = new CloudQueueLocation()
            {
                StorageAccount = configSettingsExtension.Settings.CloudStorageAccount,
                QueueName = configSettingsExtension.Settings.OutputQueue,
                VisibilityTimeout = configSettingsExtension.Settings.OutputQueueVisibilityTimeout
            };

            // Instantiate queue listeners.
            var inputQueueListener = new CloudQueueListenerExtension<XDocument>(inputQueueLocation);
            var outputQueueListener = new CloudQueueListenerExtension<XDocument>(outputQueueLocation);

            // Configure the input queue listener.
            inputQueueListener.QueueEmpty += HandleQueueEmptyEvent;
            inputQueueListener.DequeueBatchSize = configSettingsExtension.Settings.DequeueBatchSize;
            inputQueueListener.DequeueInterval = configSettingsExtension.Settings.MinimumIdleInterval;

            // Configure the output queue listener.
            outputQueueListener.QueueEmpty += HandleQueueEmptyEvent;
            outputQueueListener.DequeueBatchSize = configSettingsExtension.Settings.DequeueBatchSize;
            outputQueueListener.DequeueInterval = configSettingsExtension.Settings.MinimumIdleInterval;

            // Instantiate queue subscribers.
            InputQueueSubscriberExtension inputQueueSubscriber = new InputQueueSubscriberExtension();
            OutputQueueSubscriberExtension outputQueueSubscriber = new OutputQueueSubscriberExtension();

            // Register subscribers with queue listeners.
            inputQueueListener.Subscribe(inputQueueSubscriber);
            outputQueueListener.Subscribe(outputQueueSubscriber);

            // Register custom extensions for this worker role.
            Extensions.Add(inputQueueSubscriber);
            Extensions.Add(outputQueueSubscriber);
            Extensions.Add(outputQueueListener);
            Extensions.Add(inputQueueListener);

            var contractTypeMatchCondition = ServiceEndpointDiscoveryCondition.ContractTypeExactMatch(typeof(IScalableTransformationServiceContract));
            var bindingTypeMatchCondition = ServiceEndpointDiscoveryCondition.BindingTypeExactMatch(typeof(NetTcpRelayBinding));

            discoveryExtension.RegisterDiscoveryAction(new[] { contractTypeMatchCondition, bindingTypeMatchCondition }, (endpoint) =>
            {
                NetTcpRelayBinding relayBinding = endpoint.Binding as NetTcpRelayBinding;
                if (relayBinding != null)
                {
                    relayBinding.TransferMode = TransferMode.Streamed;
                }
            });

            // Register a subscriber for all inter-role communication events.
            if (interCommExtension != null && interCommSubscriber != null)
            {
                this.interCommSubscription = interCommExtension.Subscribe(interCommSubscriber);
            }

            return true;
        }

        /// <summary>
        /// Extends the OnStop phase that is called by Windows Azure runtime when the role instance is to be stopped.
        /// </summary>
        protected override void OnRoleStop()
        {
            if (this.interCommSubscription != null)
            {
                this.interCommSubscription.Dispose();
                this.interCommSubscription = null;
            }
        } 
        #endregion

        #region Private methods
        /// <summary>
        /// Implements a callback delegate which will be invoked whenever there is no more work available on the queue.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="idleCount">The value indicating how many times the queue listener has been idle.</param>
        /// <param name="delay">The time interval during which the queue listener will be instructed to sleep before performing next unit of work.</param>
        /// <returns>A boolean flag indicating that the queue listener should stop processing any further work and must terminate.</returns>
        private bool HandleQueueEmptyEvent(object sender, int idleCount, out TimeSpan delay)
        {
            // The sender is an instance of the ICloudQueueServiceWorkerRoleExtension, we can safely perform type casting.
            ICloudQueueServiceWorkerRoleExtension queueService = sender as ICloudQueueServiceWorkerRoleExtension;

            // Find out which extension is responsible for retrieving the worker role configuration settings.
            IWorkItemProcessorConfigurationExtension config = Extensions.Find<IWorkItemProcessorConfigurationExtension>();

            // Get the current state of the queue listener to determine point-in-time load characteristics.
            CloudQueueListenerInfo queueServiceState = queueService.QueryState();

            // Set up the initial parameters, read configuration settings.
            int deltaBackoffMs = 100;
            int minimumIdleIntervalMs = Convert.ToInt32(config.Settings.MinimumIdleInterval.TotalMilliseconds);
            int maximumIdleIntervalMs = Convert.ToInt32(config.Settings.MaximumIdleInterval.TotalMilliseconds);

            // Calculate a new sleep interval value that will follow a random exponential back-off curve.
            int delta = (int)((Math.Pow(2.0, (double)idleCount) - 1.0) * (new Random()).Next((int)(deltaBackoffMs * 0.8), (int)(deltaBackoffMs * 1.2)));
            int interval = Math.Min(minimumIdleIntervalMs + delta, maximumIdleIntervalMs);

            // Pass the calculated interval to the dequeue task to enable it to enter into a sleep state for the specified duration.
            delay = TimeSpan.FromMilliseconds((double)interval);

            // As soon as interval reaches its maximum, tell the source dequeue task that it must gracefully terminate itself
            // unless this is a last deqeueue task. If so, we are not going to keep it running and continue polling the queue.
            return delay.TotalMilliseconds >= maximumIdleIntervalMs;
        }

        /// <summary>
        /// Implements a callback delegate to be invoked whenever a new work has arrived to a queue while the queue listener was idle.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void HandleQueueWorkDetectedEvent(object sender)
        {
            // The sender is an instance of the ICloudQueueServiceWorkerRoleExtension, we can safely perform type casting.
            ICloudQueueServiceWorkerRoleExtension queueService = sender as ICloudQueueServiceWorkerRoleExtension;

            // Get the current state of the queue listener to determine point-in-time load characteristics.
            CloudQueueListenerInfo queueServiceState = queueService.QueryState();

            // Invoke a rule returning the number of queue tasks that would be required to handle the workload in a queue given its current depth.
            int dequeueTaskCount = GetOptimalDequeueTaskCount(queueServiceState.CurrentQueueDepth);

            // If the dequeue task count is less than computed above, start as many dequeue tasks as needed.
            if (queueServiceState.ActiveDequeueTasks < dequeueTaskCount)
            {
                // Start the required number of dequeue tasks.
                queueService.StartListener(dequeueTaskCount - queueServiceState.ActiveDequeueTasks);
            }
        }

        /// <summary>
        /// Returns the number of queue tasks that would be required to handle the workload in a queue given its current depth.
        /// </summary>
        /// <param name="currentDepth">The approximate number of items in the queue.</param>
        /// <returns>The optimal number of dequeue tasks.</returns>
        private int GetOptimalDequeueTaskCount(int currentDepth)
        {
            if (currentDepth < 100) return 10;
            if (currentDepth >= 100 && currentDepth < 1000) return 50;
            if (currentDepth >= 1000) return 100;

            // Return the minimum acceptable count.
            return 1;
        }
        #endregion
    }
}