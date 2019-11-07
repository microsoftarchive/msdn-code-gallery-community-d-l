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
    using System.Linq;
    using System.Xml.Linq;
    using System.ServiceModel;
    using System.Globalization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Common.RulesEngine;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Properties;
    #endregion

    #region IWorkItemQueueSubscriberExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for processing work items found in the input queue.
    /// </summary>
    public interface IWorkItemQueueSubscriberExtension : ICloudServiceComponentExtension, IObserver<XDocument>
    {
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for processing work items found in the input queue. 
    /// </summary>
    public class InputQueueSubscriberExtension : IWorkItemQueueSubscriberExtension
    {
        #region Private members
        private IScalableTransformServiceClientExtension transformService;
        private ICloudStorageProviderExtension storageProviderExtension;
        private IWorkItemProcessorConfigurationExtension configSettingsExtension;
        private IRulesEngineServiceClientExtension rulesEngineExtension;
        private ICloudCacheProviderExtension cacheProviderExtension;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IScalableTransformServiceClientExtension>();
            owner.Extensions.Demand<ICloudStorageProviderExtension>();
            owner.Extensions.Demand<IWorkItemProcessorConfigurationExtension>();
            owner.Extensions.Demand<IRulesEngineServiceClientExtension>();
            owner.Extensions.Demand<ICloudCacheProviderExtension>();

            this.transformService = owner.Extensions.Find<IScalableTransformServiceClientExtension>();
            this.storageProviderExtension = owner.Extensions.Find<ICloudStorageProviderExtension>();
            this.configSettingsExtension = owner.Extensions.Find<IWorkItemProcessorConfigurationExtension>();
            this.rulesEngineExtension = owner.Extensions.Find<IRulesEngineServiceClientExtension>();
            this.cacheProviderExtension = owner.Extensions.Find<ICloudCacheProviderExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region IObserver implementation
        /// <summary>
        /// Gets called by the provider to notify this subscriber about a new item retrieved from the queue.
        /// </summary>
        /// <param name="item">The queue item retrieved from the source queue.</param>
        public void OnNext(XDocument item)
        {
            Guard.ArgumentNotNull(item, "item");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(item.Root.Name);

            try
            {
                string transformName = ResolveTransformName(item);

                if (!String.IsNullOrEmpty(transformName))
                {
                    XDocument transformedDoc = this.transformService.ApplyTransform(transformName, item);

                    using (ICloudQueueStorage outputQueue = this.storageProviderExtension.GetQueueStorage(this.configSettingsExtension.Settings.CloudStorageAccount))
                    {
                        outputQueue.Put<XDocument>(this.configSettingsExtension.Settings.OutputQueue, transformedDoc);
                    }
                }
                else
                {
                    throw new CloudApplicationException(String.Format(CultureInfo.InstalledUICulture, ExceptionMessages.UnableToResolveTransformName, item.Root.Name, this.configSettingsExtension.Settings.HandlingPolicyName));
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Gets called by the provider to indicate that it has finished processing queue items and is about to terminate.
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
        }
        #endregion

        #region Private members
        private string ResolveTransformName(XDocument document)
        {
            Guard.ArgumentNotNull(document, "document");

            // Create a Rules Engine fact representing the message type of the item being processed.
            MessageTypeFact msgTypeFact = new MessageTypeFact(document);

            // Construct a cache key that uniquely identifies a specific cache item based on the input document type.
            string cacheKeyName = String.Concat(this.GetType().FullName, "_ResolveTransform_", msgTypeFact.Value);

            return this.cacheProviderExtension.GetOrPut(cacheKeyName, () =>
            {
                // Invoke a policy to determine the name of the map to be applied to the item being processed.
                StringDictionaryFact policyExecutionResult = this.rulesEngineExtension.ExecutePolicy<StringDictionaryFact>(this.configSettingsExtension.Settings.HandlingPolicyName, msgTypeFact);

                if (policyExecutionResult != null && policyExecutionResult.Items != null && policyExecutionResult.Items.Count > 0)
                {
                    // Take a dictionary item by it's predefined name.
                    return policyExecutionResult.Items[Resources.StringDictionaryFactValueTransformName];
                }
                else
                {
                    return null;
                }
            }) as string;
        }
        #endregion
    }
}
