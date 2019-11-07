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

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    #endregion

    /// <summary>
    /// Implements the extension responsible for dynamically resolving the location of a given queue at runtime.
    /// </summary>
    public sealed class WorkQueueLocationResolverExtension : ICloudQueueLocationResolverExtension
    {
        #region Private members
        private IWorkItemProcessorConfigurationExtension configSettingsExtension;
        #endregion

        #region ICloudQueueLocationResolverExtension implementation
        /// <summary>
        /// Resolves the exact location of a given queue by its name.
        /// </summary>
        /// <param name="queueName">The name of the Windows Azure queue.</param>
        /// <returns>The location of the queue in the Windows Azure storage infrastructure.</returns>
        public CloudQueueLocation GetQueueLocation(string queueName)
        {
            Guard.ArgumentNotNullOrEmptyString(queueName, "queueName");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(queueName);

            // Assume an invalid (non-discoverable) location by default.
            CloudQueueLocation queueLocation = CloudQueueLocation.Unknown;

            try
            {
                if (queueName == "InputQueueTag")
                {
                    queueLocation = new CloudQueueLocation()
                    {
                        StorageAccount = this.configSettingsExtension.Settings.CloudStorageAccount,
                        QueueName = this.configSettingsExtension.Settings.WorkItemQueue,
                        VisibilityTimeout = this.configSettingsExtension.Settings.WorkItemQueueVisibilityTimeout
                    };
                }
                else if (queueName == "OutputQueueTag")
                {
                    queueLocation = new CloudQueueLocation()
                    {
                        StorageAccount = this.configSettingsExtension.Settings.CloudStorageAccount,
                        QueueName = this.configSettingsExtension.Settings.OutputQueue,
                        VisibilityTimeout = this.configSettingsExtension.Settings.OutputQueueVisibilityTimeout
                    };
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken, queueLocation.QueueName, queueLocation.StorageAccount, queueLocation.VisibilityTimeout);
            }

            return queueLocation;
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            this.configSettingsExtension = owner.Extensions.Find<IWorkItemProcessorConfigurationExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion
    }
}
