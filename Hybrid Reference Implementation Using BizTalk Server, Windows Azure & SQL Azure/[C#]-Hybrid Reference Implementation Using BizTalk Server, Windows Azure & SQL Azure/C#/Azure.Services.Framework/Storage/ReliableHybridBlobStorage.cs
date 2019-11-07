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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Storage
{
    #region Using references
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;

    using RetryPolicy = Contoso.Cloud.Integration.Framework.RetryPolicy;
    #endregion

    /// <summary>
    /// Implements reliable generics-aware storage layer combining Windows Azure Blob storage and Windows Azure Cache in a hybrid mode.
    /// </summary>
    public class ReliableHybridBlobStorage : ICloudBlobStorage
    {
        #region Private members
        private readonly ICloudBlobStorage blobStorage;
        private readonly ICloudBlobStorage cacheStorage;
        private readonly ICloudStorageEntitySerializer dataSerializer;
        private readonly IList<ICloudBlobStorage> storageList;

        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableHybridBlobStorage"/> class using the specified storage account information and caching service endpoint.
        /// Assumes the default use of <see cref="RetryPolicy.DefaultExponential"/> retry policy and default implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="cacheEndpointInfo">The endpoint details for Windows Azure Caching Service.</param>
        public ReliableHybridBlobStorage(StorageAccountInfo storageAccountInfo, CachingServiceEndpointInfo cacheEndpointInfo)
            : this(storageAccountInfo, cacheEndpointInfo, new CloudStorageEntitySerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableHybridBlobStorage"/> class using the specified storage account information, caching service endpoint
        /// and custom implementation of <see cref="ICloudStorageEntitySerializer"/> interface. Assumes the default use of <see cref="RetryPolicy.DefaultExponential"/> 
        /// retry policies when accessing storage and caching services.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="cacheEndpointInfo">The endpoint details for Windows Azure Caching Service.</param>
        /// <param name="dataSerializer">An instance of the component which performs serialization and deserialization of storage objects.</param>
        public ReliableHybridBlobStorage(StorageAccountInfo storageAccountInfo, CachingServiceEndpointInfo cacheEndpointInfo, ICloudStorageEntitySerializer dataSerializer)
            : this
            (
                storageAccountInfo, 
                new RetryPolicy<StorageTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff), 
                cacheEndpointInfo, 
                new RetryPolicy<CacheTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff),
                dataSerializer
            )
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableHybridBlobStorage"/> class using the specified storage account information, caching service endpoint, custom retry policies
        /// and a custom implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="storageRetryPolicy">The custom retry policy that will ensure reliable access to the underlying blob storage.</param>
        /// <param name="cacheEndpointInfo">The endpoint details for Windows Azure Caching Service.</param>
        /// <param name="cacheRetryPolicy">The custom retry policy that will ensure reliable access to the Caching Service.</param>
        /// <param name="dataSerializer">An instance of the component which performs serialization and deserialization of storage objects.</param>
        public ReliableHybridBlobStorage(StorageAccountInfo storageAccountInfo, RetryPolicy storageRetryPolicy, CachingServiceEndpointInfo cacheEndpointInfo, RetryPolicy cacheRetryPolicy, ICloudStorageEntitySerializer dataSerializer)
        {
            Guard.ArgumentNotNull(storageAccountInfo, "storageAccountInfo");
            Guard.ArgumentNotNull(storageRetryPolicy, "storageRetryPolicy");
            Guard.ArgumentNotNull(cacheEndpointInfo, "cacheEndpointInfo");
            Guard.ArgumentNotNull(cacheRetryPolicy, "cacheRetryPolicy");
            Guard.ArgumentNotNull(dataSerializer, "dataSerializer");

            this.dataSerializer = dataSerializer;
            this.storageList = new List<ICloudBlobStorage>(2);

            this.storageList.Add(this.cacheStorage = new ReliableCloudCacheStorage(cacheEndpointInfo, cacheRetryPolicy, dataSerializer));
            this.storageList.Add(this.blobStorage = new ReliableCloudBlobStorage(storageAccountInfo, storageRetryPolicy, dataSerializer));
        }
        #endregion

        #region ICloudBlobStorage implementation
        /// <summary>
        /// Creates a new blob container using specified name.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be created.</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        public bool CreateContainer(string containerName)
        {
            int count = 0;

            Parallel.ForEach<ICloudBlobStorage>(this.storageList, (x) => 
            {
                if (x.CreateContainer(containerName))
                {
                    Interlocked.Increment(ref count);
                }
            });

            return count == this.storageList.Count;
        }

        /// <summary>
        /// Deletes the specified blob container.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be deleted.</param>
        /// <returns>True if the container existed and was successfully deleted; otherwise false.</returns>
        public bool DeleteContainer(string containerName)
        {
            int count = 0;

            Parallel.ForEach<ICloudBlobStorage>(this.storageList, (x) =>
            {
                if (x.DeleteContainer(containerName))
                {
                    Interlocked.Increment(ref count);
                }
            });

            return count == this.storageList.Count;
        }

        /// <summary>
        /// Puts a blob into the underlying storage, overwrites the existing blob if the blob with the same name already exists.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        public bool Put<T>(string containerName, string blobName, T blob)
        {
            return Put<T>(containerName, blobName, blob, true);
        }

        /// <summary>
        /// Puts a blob into the underlying storage. If the blob with the same name already exists, overwrite behavior can be customized. 
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <param name="overwrite">The flag indicating whether or not overwriting the existing blob is permitted.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        public bool Put<T>(string containerName, string blobName, T blob, bool overwrite)
        {
            Guard.ArgumentNotNull(blob, "blob");

            bool success = false;
            Stream blobData = null;
            bool treatBlobAsStream = false;

            try
            {
                // Are we dealing with a stream already? If yes, just use it as is.
                if (IsStreamType(blob.GetType()))
                {
                    blobData = blob as Stream;
                    treatBlobAsStream = true;
                }
                else
                {
                    // The specified item type is something else rather than a Stream, we should perform serialization of T into a new memory stream instance.
                    blobData = new MemoryStream();

                    this.dataSerializer.Serialize(blob, blobData);
                    blobData.Seek(0, SeekOrigin.Begin);
                }

                try
                {
                    // First, make an attempt to store the blob in the distributed cache. Only use cache if blob size is optimal for this type of storage.
                    if (CloudUtility.IsOptimalCacheItemSize(blobData.Length))
                    {
                        success = this.cacheStorage.Put<Stream>(containerName, blobName, blobData, overwrite);
                    }
                }
                finally
                {
                    if (!success)
                    {
                        // The cache option was unsuccessful, fail over to the blob storage.
                        success = this.blobStorage.Put<Stream>(containerName, blobName, blobData, overwrite);
                    }
                }
            }
            finally
            {
                if (!treatBlobAsStream && blobData != null)
                {
                    // Only dispose the blob data stream if it was newly created.
                    blobData.Dispose();
                }
            }

            return success;
        }

        /// <summary>
        /// Retrieves a blob by its name from the underlying storage.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name from which the blob will be retrieved.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <returns>An instance of <typeparamref name="T"/> or default(T) if the specified blob was not found.</returns>
        public T Get<T>(string containerName, string blobName)
        {
            T blob = default(T);

            try
            {
                // First, make an attempt to retrieve the blob from the distributed cache.
                blob = this.cacheStorage.Get<T>(containerName, blobName);
            }
            finally
            {
                if (null == blob)
                {
                    // The cache option was unsuccessful, let's try to retrieve from the blob storage.
                    blob = this.blobStorage.Get<T>(containerName, blobName);
                }
            }

            return blob;
        }

        /// <summary>
        /// Deletes the specified blob from the underlying storage.
        /// </summary>
        /// <param name="containerName">The target blob container name from which the blob will be deleted.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <returns>True if the blob was deleted, otherwise false.</returns>
        public bool Delete(string containerName, string blobName)
        {
            int count = 0;

            Parallel.ForEach<ICloudBlobStorage>(this.storageList, (x) =>
            {
                if (x.Delete(containerName, blobName))
                {
                    Interlocked.Increment(ref count);
                }
            });

            return count != 0;
        }

        /// <summary>
        /// Gets the number of blobs in the specified container.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be queried.</param>
        /// <returns>The number of blobs in the container.</returns>
        public int GetCount(string containerName)
        {
            return Math.Max(this.cacheStorage.GetCount(containerName), this.blobStorage.GetCount(containerName));
        }

        /// <summary>
        /// Returns a list of all container names found in the underlying storage.
        /// </summary>
        /// <param name="options">The optional <see cref="ContainerRequestOptions"/> object to use when making a request.</param>
        /// <returns>The list containing container names.</returns>
        public IEnumerable<string> GetContainers(ContainerRequestOptions options = null)
        {
            ConcurrentQueue<string> list = new ConcurrentQueue<string>();

            Parallel.ForEach<ICloudBlobStorage>(this.storageList, (x) =>
            {
                var сontainers = x.GetContainers(options);

                if (сontainers != null)
                {
                    foreach (var item in сontainers)
                    {
                        list.Enqueue(item);
                    }
                }
            });

            return list.AsEnumerable<string>();
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Helper method to check whether the object has already been disposed.
        /// </summary>
        private void DisposedCheck()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(typeof(ReliableCloudCacheStorage).FullName);
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableHybridBlobStorage()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        /// <param name="disposing">Determines whether this was called by Dispose or by the finalizer.</param>
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.cacheStorage != null)
                    {
                        this.cacheStorage.Dispose();
                    }

                    if (this.blobStorage != null)
                    {
                        this.blobStorage.Dispose();
                    }
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private bool IsStreamType(Type type)
        {
            return type != null & (type == typeof(Stream) || typeof(Stream).IsAssignableFrom(type));
        }
        #endregion
    }
}
