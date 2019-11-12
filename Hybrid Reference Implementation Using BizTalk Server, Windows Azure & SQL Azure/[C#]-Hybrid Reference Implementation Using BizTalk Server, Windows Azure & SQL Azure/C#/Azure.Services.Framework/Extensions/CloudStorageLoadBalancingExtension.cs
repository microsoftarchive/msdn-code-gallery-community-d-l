//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Extensions
{
    #region Using references
    using System;
    using System.Linq;
    using System.Threading;
    using System.ServiceModel;
    using System.Collections.Generic;

    using Microsoft.WindowsAzure.StorageClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    #region ICloudStorageLoadBalancingExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for facilitating storage operations across multiple storage accounts, queues and containers.
    /// </summary>
    public interface ICloudStorageLoadBalancingExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Suggests the best location for a queue taking into account the load balancing criteria.
        /// </summary>
        /// <returns>The location of a queue in the Azure storage infrastructure.</returns>
        CloudQueueLocation FindQueueLocation();

        /// <summary>
        /// Suggests the best location for a blob taking into account the load balancing criteria.
        /// </summary>
        /// <returns>The location of a blob in the Azure storage infrastructure.</returns>
        CloudBlobLocation FindBlobLocation();

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudQueueStorage"/> that corresponds to the Azure storage selected on the basis of a load balancing criteria.
        /// </summary>
        /// <returns>The object that provides access to the Azure queue storage.</returns>
        ICloudQueueStorage GetQueueStorage();

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudQueueStorage"/> that corresponds to the Azure storage as defined in the specified location object.
        /// </summary>
        /// <param name="location">The specified location of a queue in the Azure storage infrastructure.</param>
        /// <returns>The object that provides access to the Azure queue storage.</returns>
        ICloudQueueStorage GetQueueStorage(CloudQueueLocation location);

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudBlobStorage"/> that corresponds to the Azure storage selected on the basis of a load balancing criteria.
        /// </summary>
        /// <returns>The object that provides access to the Azure blob storage.</returns>
        ICloudBlobStorage GetBlobStorage();

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudBlobStorage"/> that corresponds to the Azure storage as defined in the specified location object.
        /// </summary>
        /// <param name="location">The specified location of a blob in the Azure storage infrastructure.</param>
        /// <returns>The object that provides access to the Azure blob storage.</returns>
        ICloudBlobStorage GetBlobStorage(CloudBlobLocation location);
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for facilitating storage operations across multiple storage accounts, queues and containers.
    /// </summary>
    public class CloudStorageLoadBalancingExtension : ICloudStorageLoadBalancingExtension
    {
        #region Private methods
        private readonly IList<StorageAccountInfo> storageAccounts;
        private ICloudStorageProviderExtension cloudStorageProvider;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the extension using a collection of storage accounts enabled for load-balancing operations.
        /// </summary>
        /// <param name="storageAccounts">The list of storage accounts enabled for load-balancing operations.</param>
        public CloudStorageLoadBalancingExtension(IEnumerable<StorageAccountInfo> storageAccounts)
        {
            Guard.ArgumentNotNull(storageAccounts, "storageAccounts");

            this.storageAccounts = new List<StorageAccountInfo>(storageAccounts);
            this.ContainerNamePrefix = Resources.LoadBalancedContainerNamePrefix;

            if (0 == this.storageAccounts.Count)
            {
                throw new CloudApplicationException(ExceptionMessages.StorageAccountCollectionIsEmpty);
            }
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets a prefix that identifies the blob container names used by this extension for load-balancing operations.
        /// </summary>
        public string ContainerNamePrefix { get; set; }
        #endregion

        #region ICloudStorageLoadBalancingExtension implementation
        /// <summary>
        /// Suggests the best location for a queue taking into account the load balancing criteria.
        /// </summary>
        /// <returns>The location of a queue in the Azure storage infrastructure.</returns>
        public CloudQueueLocation FindQueueLocation()
        {
            return CloudQueueLocation.Unknown;
        }

        /// <summary>
        /// Suggests the best location for a blob taking into account the load balancing criteria.
        /// </summary>
        /// <returns>The location of a blob in the Azure storage infrastructure.</returns>
        public CloudBlobLocation FindBlobLocation()
        {
            var callToken = TraceManager.CloudStorageComponent.TraceIn();
            var blobLocation = CloudBlobLocation.Unknown;

            try
            {
                string storageAccountName = null, containerName = null;
                int minBlobCount = Int32.MaxValue;

                var availableAccounts = from storageAccount in this.storageAccounts.AsParallel<StorageAccountInfo>() select storageAccount;

                // Enumerate through all storage accounts enabled to load balancing.
                foreach (var storageAccount in availableAccounts)
                {
                    // Access the target storage account.
                    using (ICloudBlobStorage blobStorage = this.cloudStorageProvider.GetBlobStorage(storageAccount.AccountName))
                    {
                        // Obtain a list of all containers in the current storage account.
                        var availableContainers = blobStorage.GetContainers(new ContainerRequestOptions() { NamePrefix = ContainerNamePrefix, ListingDetails = ContainerListingDetails.None });

                        // Validate whether or not the current storage account is empty.
                        if (availableContainers != null)
                        {
                            // Enable parallelization when iterating through the collection of container names.
                            var targetContainers = from i in availableContainers.AsParallel<string>() select i;

                            // Enumerate through all containers enabled to load balancing.
                            foreach (var name in targetContainers)
                            {
                                // Obtain the minimum number of blobs in a given container.
                                int newMinValue = Math.Min(minBlobCount, blobStorage.GetCount(name));

                                // When a new minimum is found, capture its value and retain the names of the storage account and container for further reference.
                                if (newMinValue != minBlobCount)
                                {
                                    Interlocked.Exchange<string>(ref storageAccountName, storageAccount.AccountName);
                                    Interlocked.Exchange<string>(ref containerName, name);
                                    Interlocked.Exchange(ref minBlobCount, newMinValue);
                                }
                            }
                        }
                    }
                }

                if (!String.IsNullOrEmpty(storageAccountName) && !String.IsNullOrEmpty(containerName))
                {
                    blobLocation = new CloudBlobLocation(storageAccountName, containerName, null);
                }
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, blobLocation.StorageAccount, blobLocation.ContainerName);
            }

            return blobLocation;
        }

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudQueueStorage"/> that corresponds to the Azure storage as defined in the specified location object.
        /// </summary>
        /// <param name="location">The specified location of a queue in the Azure storage infrastructure.</param>
        /// <returns>The object that provides access to the Azure queue storage.</returns>
        public ICloudQueueStorage GetQueueStorage(CloudQueueLocation location)
        {
            Guard.ArgumentNotNull(location, "location");
            Guard.ArgumentNotNull(this.cloudStorageProvider, "cloudStorageProvider");

            return this.cloudStorageProvider.GetQueueStorage(location.StorageAccount);
        }
        
        /// <summary>
        /// Returns the implementation of the <see cref="ICloudQueueStorage"/> that corresponds to the Azure storage selected on the basis of a load balancing criteria.
        /// </summary>
        /// <returns>The object that provides access to the Azure queue storage.</returns>
        public ICloudQueueStorage GetQueueStorage()
        {
            return GetQueueStorage(FindQueueLocation());
        }

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudBlobStorage"/> that corresponds to the Azure storage as defined in the specified location object.
        /// </summary>
        /// <param name="location">The specified location of a blob in the Azure storage infrastructure.</param>
        /// <returns>The object that provides access to the Azure blob storage.</returns>
        public ICloudBlobStorage GetBlobStorage(CloudBlobLocation location)
        {
            Guard.ArgumentNotNull(location, "location");
            Guard.ArgumentNotNull(this.cloudStorageProvider, "cloudStorageProvider");

            return this.cloudStorageProvider.GetBlobStorage(location.StorageAccount);
        }

        /// <summary>
        /// Returns the implementation of the <see cref="ICloudBlobStorage"/> that corresponds to the Azure storage selected on the basis of a load balancing criteria.
        /// </summary>
        /// <returns>The object that provides access to the Azure blob storage.</returns>
        public ICloudBlobStorage GetBlobStorage()
        {
            return GetBlobStorage(FindBlobLocation());
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<ICloudStorageProviderExtension>();

            this.cloudStorageProvider = owner.Extensions.Find<ICloudStorageProviderExtension>();
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
