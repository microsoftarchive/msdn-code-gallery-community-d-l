//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The WorkItemScheduler worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Extensions
{
    #region Using references
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Globalization;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Common;
    using Contoso.Cloud.Integration.Common.Activities;
    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    using Contoso.Cloud.Integration.Azure.Services.Common.RulesEngine;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Properties;
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
            owner.EnsureExists<ActivityTrackingEventStreamExtension>();

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
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(e.FromInstanceID, e.ToInstanceID);

            if (this.owner != null)
            {
                PersistenceQueueItemInfo queueItemInfo = e.Payload as PersistenceQueueItemInfo;

                if (queueItemInfo != null)
                {
                    HandlePersistenceQueueItem(queueItemInfo);
                }
            }

            TraceManager.WorkerRoleComponent.TraceOut(callToken);
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

            this.owner.Extensions.Demand<IRulesEngineServiceClientExtension>();
            this.owner.Extensions.Demand<IWorkItemSchedulerConfigurationExtension>();
            this.owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();
            this.owner.Extensions.Demand<ICloudStorageProviderExtension>();
            this.owner.Extensions.Demand<IInterRoleCommunicationExtension>();

            IRulesEngineServiceClientExtension rulesEngineExtension = this.owner.Extensions.Find<IRulesEngineServiceClientExtension>();
            IWorkItemSchedulerConfigurationExtension configSettingsExtension = this.owner.Extensions.Find<IWorkItemSchedulerConfigurationExtension>();
            IRoleConfigurationSettingsExtension roleConfigExtension = this.owner.Extensions.Find<IRoleConfigurationSettingsExtension>();
            ICloudStorageProviderExtension storageProviderExtension = this.owner.Extensions.Find<ICloudStorageProviderExtension>();
            IActivityTrackingEventStreamExtension trackingEventStreamExtension = this.owner.Extensions.Find<IActivityTrackingEventStreamExtension>();
            IInterRoleCommunicationExtension interCommExtension = this.owner.Extensions.Find<IInterRoleCommunicationExtension>();

            // Update BAM activity to indicate when we started the dequeue operation.
            if (trackingEventStreamExtension != null)
            {
                InventoryDataTrackingActivity activity = new InventoryDataTrackingActivity(itemInfo.QueueItemId.ToString()) { DequeueOperationStarted = DateTime.UtcNow };
                trackingEventStreamExtension.UpdateActivity(activity);
            }

            var xPathLib = roleConfigExtension.GetSection<XPathQueryLibrary>(XPathQueryLibrary.SectionName);
            var batchInfo = rulesEngineExtension.ExecutePolicy<PersistenceQueueItemBatchInfo>(configSettingsExtension.Settings.HandlingPolicyName, itemInfo, new MessageTypeFact(itemInfo.QueueItemType));

            // Verify the batch metadata to ensure we have everything we need to be able to perform de-batching.
            ValidateBatchMetadata(itemInfo, batchInfo);

            // Replace the XPath query references with actual expressions taken from the XPath Library.
            batchInfo.BodyItemXPath = xPathLib.Queries.Contains(batchInfo.BodyItemXPath) ? xPathLib.GetXPathQuery(batchInfo.BodyItemXPath) : batchInfo.BodyItemXPath;
            batchInfo.BodyItemCountXPath = xPathLib.Queries.Contains(batchInfo.BodyItemCountXPath) ? xPathLib.GetXPathQuery(batchInfo.BodyItemCountXPath) : batchInfo.BodyItemCountXPath;

            var headerXPathList = from item in batchInfo.HeaderSegments where xPathLib.Queries.Contains(item) select new { Segment = item, XPath = xPathLib.GetXPathQuery(item) };
            var bodyXPathList = from item in batchInfo.BodySegments where xPathLib.Queries.Contains(item) select new { Segment = item, XPath = xPathLib.GetXPathQuery(item) };
            var footerXPathList = from item in batchInfo.FooterSegments where xPathLib.Queries.Contains(item) select new { Segment = item, XPath = xPathLib.GetXPathQuery(item) };

            foreach (var item in headerXPathList.ToList())
            {
                batchInfo.HeaderSegments.Remove(item.Segment);
                batchInfo.HeaderSegments.Add(item.XPath);
            }

            foreach (var item in bodyXPathList.ToList())
            {
                batchInfo.BodySegments.Remove(item.Segment);
                batchInfo.BodySegments.Add(item.XPath);
            }

            foreach (var item in footerXPathList.ToList())
            {
                batchInfo.FooterSegments.Remove(item.Segment);
                batchInfo.FooterSegments.Add(item.XPath);
            }

            int fromItem = 1, toItem = fromItem, maxItems = configSettingsExtension.Settings.XmlBatchSize;
            var taskParameters = new List<DequeueXmlDataTaskState>();

            using (SqlAzurePersistenceQueue persistenceQueue = new SqlAzurePersistenceQueue())
            {
                persistenceQueue.Open(WellKnownDatabaseName.PersistenceQueue);

                using (XmlReader resultReader = persistenceQueue.QueryXmlData(itemInfo.QueueItemId, new string[] { batchInfo.BodyItemCountXPath }, xPathLib.Namespaces.NamespaceManager))
                {
                    maxItems = resultReader.ReadContentAsInt();
                }
            }

            do
            {
                toItem = fromItem + configSettingsExtension.Settings.XmlBatchSize - 1;

                taskParameters.Add(new DequeueXmlDataTaskState()
                {
                    QueueItemInfo = itemInfo,
                    HeaderSegments = new List<string>(batchInfo.HeaderSegments),
                    BodySegments = new List<string>(from query in batchInfo.BodySegments select String.Format(query, fromItem, toItem)),
                    FooterSegments = new List<string>(batchInfo.FooterSegments),
                    StartItemIndex = fromItem,
                    EndItemIndex = toItem,
                    ItemDetectionXPath = batchInfo.BodyItemXPath,
                    Settings = configSettingsExtension.Settings,
                    StorageProvider = storageProviderExtension,
                    NamespaceManager = xPathLib.Namespaces.NamespaceManager
                });

                fromItem += configSettingsExtension.Settings.XmlBatchSize;
            }
            while (toItem < maxItems);

            // Before we start putting work items on queue, notify the respective queue listeners that they should expect work to arrive.
            CloudQueueWorkDetectedTriggerEvent trigger = new CloudQueueWorkDetectedTriggerEvent(configSettingsExtension.Settings.CloudStorageAccount, configSettingsExtension.Settings.DestinationQueue, maxItems, PayloadSizeKind.MessageCount);

            // Package the trigger into an inter-role communication event.
            var interRoleEvent = new InterRoleCommunicationEvent(trigger);

            // Publish inter-role communication event via the Service Bus one-way multicast.
            interCommExtension.Publish(interRoleEvent);

            var stateCollection = from x in taskParameters.AsParallel<DequeueXmlDataTaskState>()
                                  orderby x.StartItemIndex
                                  select x;

            foreach (var state in stateCollection)
            {
                try
                {
                    DequeueXmlDataTaskMain(state);
                }
                catch (Exception ex)
                {
                    TraceManager.WorkerRoleComponent.TraceError(ex);
                }
            }

            // Update BAM activity to indicate when we completed the dequeue operation.
            if (trackingEventStreamExtension != null)
            {
                InventoryDataTrackingActivity activity = new InventoryDataTrackingActivity(itemInfo.QueueItemId.ToString()) { DequeueOperationCompleted = DateTime.UtcNow };
                trackingEventStreamExtension.UpdateActivity(activity);
            }
        }

        private void ValidateBatchMetadata(PersistenceQueueItemInfo itemInfo, PersistenceQueueItemBatchInfo batchInfo)
        {
            Guard.ArgumentNotNull(itemInfo, "itemInfo");

            if (batchInfo != null)
            {
                // Header segments are optional but we should check if they are provided if corresponding collection is not empty.
                if (batchInfo.HeaderSegments != null && batchInfo.HeaderSegments.Count == 0)
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.InstalledUICulture, ExceptionMessages.NoHeaderSegments, itemInfo.QueueItemId, itemInfo.QueueItemType));
                }

                // Body segments are compulsory, these must always be provided.
                if (!(batchInfo.BodySegments != null && batchInfo.BodySegments.Count > 0))
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.InstalledUICulture, ExceptionMessages.NoBodySegments, itemInfo.QueueItemId, itemInfo.QueueItemType));
                }

                // Footer segments are optional but we should check if they are provided if corresponding collection is not empty.
                if (batchInfo.FooterSegments != null && batchInfo.FooterSegments.Count == 0)
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.InstalledUICulture, ExceptionMessages.NoFooterSegments, itemInfo.QueueItemId, itemInfo.QueueItemType));
                }
            }
            else
            {
                throw new CloudApplicationException(String.Format(CultureInfo.InstalledUICulture, ExceptionMessages.UnresolvedBatchMetadata, itemInfo.QueueItemId, itemInfo.QueueItemType));
            }
        }

        private void DequeueXmlDataTaskMain(DequeueXmlDataTaskState state)
        {
            Guard.ArgumentNotNull(state, "state");

            using (ICloudQueueStorage workItemQueue = state.StorageProvider.GetQueueStorage(state.Settings.CloudStorageAccount))
            using (SqlAzurePersistenceQueue dbQueue = new SqlAzurePersistenceQueue())
            {
                dbQueue.Open(WellKnownDatabaseName.PersistenceQueue);

                using (XmlReader xmlReader = dbQueue.DequeueXmlData(state.QueueItemInfo.QueueItemId, state.HeaderSegments, state.BodySegments, state.FooterSegments, state.NamespaceManager))
                {
                    if (xmlReader != null)
                    {
                        XDocument batch = XDocument.Load(xmlReader);

                        // Check for presence of any items in the batch.
                        bool batchFound = (batch.XPathSelectElement(state.ItemDetectionXPath) != null);

                        if (batchFound)
                        {
                            workItemQueue.Put<XDocument>(state.Settings.DestinationQueue, batch);
                        }
                    }
                }
            }
        }
        #endregion

        #region DequeueXmlDataTaskState class declaration
        private class DequeueXmlDataTaskState
        {
            public PersistenceQueueItemInfo QueueItemInfo;
            public int StartItemIndex;
            public int EndItemIndex;
            public List<string> HeaderSegments;
            public List<string> BodySegments;
            public List<string> FooterSegments;
            public string ItemDetectionXPath;
            public WorkItemSchedulerConfigurationSettings Settings;
            public ICloudStorageProviderExtension StorageProvider;
            public XmlNamespaceManager NamespaceManager;
        } 
        #endregion
    }
}
