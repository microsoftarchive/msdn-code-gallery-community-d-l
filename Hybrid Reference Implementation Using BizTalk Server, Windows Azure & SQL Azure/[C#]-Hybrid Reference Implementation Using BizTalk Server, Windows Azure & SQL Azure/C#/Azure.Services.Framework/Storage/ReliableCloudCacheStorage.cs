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
    using System.Collections.Generic;

    using Microsoft.ApplicationServer.Caching;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;

    using RetryPolicy = Contoso.Cloud.Integration.Framework.RetryPolicy;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Implements reliable generics-aware layer for Windows Azure Caching Service.
    /// </summary>
    public class ReliableCloudCacheStorage : ICloudCacheStorage, ICloudBlobStorage
    {
        #region Private members
        private readonly RetryPolicy retryPolicy;
        private readonly ICloudStorageEntitySerializer dataSerializer;
        private readonly DataCacheFactory cacheFactory;
        private readonly DataCache cache;

        private bool disposed;
        private bool? isRegionSupported;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudCacheStorage"/> class using the specified caching service endpoint details.
        /// Assumes the default use of <see cref="RetryPolicy.DefaultExponential"/> retry policy and default implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="endpointInfo">The endpoint details for Windows Azure Caching Service.</param>
        public ReliableCloudCacheStorage(CachingServiceEndpointInfo endpointInfo)
            : this(endpointInfo, new RetryPolicy<CacheTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudCacheStorage"/> class using the specified caching service endpoint details and a custom retry policy.
        /// </summary>
        /// <param name="endpointInfo">The endpoint details for Windows Azure Caching Service.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the Caching Service.</param>
        public ReliableCloudCacheStorage(CachingServiceEndpointInfo endpointInfo, RetryPolicy retryPolicy)
            : this(endpointInfo, retryPolicy, new CloudStorageEntitySerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudCacheStorage"/> class using the specified storage account information, custom retry policy
        /// and custom implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="endpointInfo">The endpoint details for Windows Azure Caching Service.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the Caching Service.</param>
        /// <param name="dataSerializer">An instance of the component which performs custom serialization and deserialization of cache items.</param>
        public ReliableCloudCacheStorage(CachingServiceEndpointInfo endpointInfo, RetryPolicy retryPolicy, ICloudStorageEntitySerializer dataSerializer)
        {
            Guard.ArgumentNotNull(endpointInfo, "endpointInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");
            Guard.ArgumentNotNull(dataSerializer, "dataSerializer");

            this.retryPolicy = retryPolicy;
            this.dataSerializer = dataSerializer;

            var cacheServers = new List<DataCacheServerEndpoint>(1);
            cacheServers.Add(new DataCacheServerEndpoint(endpointInfo.ServiceHostName, endpointInfo.CachePort));

            var cacheConfig = new DataCacheFactoryConfiguration()
            {
                Servers = cacheServers,
                MaxConnectionsToServer = 1,
                IsCompressionEnabled = false,
                SecurityProperties = new DataCacheSecurity(endpointInfo.SecureAuthenticationToken, endpointInfo.SslEnabled),
                // As per recommendations in http://blogs.msdn.com/b/akshar/archive/2011/05/01/azure-appfabric-caching-errorcode-lt-errca0017-gt-substatus-lt-es0006-gt-what-to-do.aspx
                TransportProperties = new DataCacheTransportProperties() { ReceiveTimeout = TimeSpan.FromSeconds(45) }
            };

            this.cacheFactory = new DataCacheFactory(cacheConfig);
            this.cache = this.retryPolicy.ExecuteAction<DataCache>(() => 
            {
                return this.cacheFactory.GetDefaultCache();
            });
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
        ~ReliableCloudCacheStorage()
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
                    this.cacheFactory.Dispose();
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

        #region ICloudBlobStorage implementation
        /// <summary>
        /// Creates a new container (cache region) using specified name.
        /// </summary>
        /// <param name="regionName">The name of the container (cache region) to be created.</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        public bool CreateContainer(string regionName)
        {
            Guard.ArgumentNotNullOrEmptyString(regionName, "regionName");
            
            var callToken = TraceManager.CloudStorageComponent.TraceIn(regionName);
            bool success = false;

            try
            {
                // Only execute CreateRegion action if we are sure that it is supported or when we are probing for the first time.
                if (!this.isRegionSupported.HasValue || this.isRegionSupported.Value)
                {
                    success = this.retryPolicy.ExecuteAction<bool>(() =>
                    {
                        return this.cache.CreateRegion(regionName);
                    });

                    // If we are still here, this means that a region may have been created successfully. Let's assume it's supported.
                    this.isRegionSupported = true;
                }
                else
                {
                    success = !this.isRegionSupported.Value;
                }
            }
            catch (NotSupportedException)
            {
                // Set a flag telling that we should not try creating regions any longer as these are not supported.
                this.isRegionSupported = false;
                
                // Assume this operation will be supported someday. In the meantime, return True to indicate that the operation has succeeded.
                success = true;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, success);
            }

            return success;
        }

        /// <summary>
        /// Deletes the specified container (cache region).
        /// </summary>
        /// <param name="regionName">The name of the container (cache region) to be deleted.</param>
        /// <returns>True if the container existed and was successfully deleted; otherwise false.</returns>
        public bool DeleteContainer(string regionName)
        {
            Guard.ArgumentNotNullOrEmptyString(regionName, "regionName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(regionName);
            bool success = false;

            try
            {
                // Only execute RemoveRegion action if we are sure that it is supported or when we are probing for the first time.
                if (!this.isRegionSupported.HasValue || this.isRegionSupported.Value)
                {
                    success = this.retryPolicy.ExecuteAction<bool>(() =>
                    {
                        return this.cache.RemoveRegion(regionName);
                    });

                    // If we are still here, this means that a region may have been removed successfully. Let's assume it's supported.
                    this.isRegionSupported = true;
                }
                else
                {
                    success = !this.isRegionSupported.Value;
                }
            }
            catch (NotSupportedException)
            {
                // Set a flag telling that we should not try deleting regions any longer as these are not supported.
                this.isRegionSupported = false;

                // Assume this operation will be supported someday. In the meantime, return True to indicate that the operation has succeeded.
                success = true;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, success);
            }

            return success;
        }

        /// <summary>
        /// Puts an item into the cache, overwrites the existing item if the item with the same key already exists.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the cache item.</typeparam>
        /// <param name="regionName">The target container (cache region) name into which the cache item will be stored.</param>
        /// <param name="key">The key associated with the cache item.</param>
        /// <param name="item">The cache item.</param>
        /// <returns>True if the cache item was successfully put into the specified region, otherwise false.</returns>
        public bool Put<T>(string regionName, string key, T item)
        {
            return Put<T>(regionName, key, item, true);
        }

        /// <summary>
        /// Puts an item into the cache. 
        /// If the item with the same name already exists, the older item can be overwritten depending on the behavior specified in the <paramref name="overwrite"/> parameter.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the cache item.</typeparam>
        /// <param name="regionName">The target container (cache region) name into which the cache item will be stored.</param>
        /// <param name="key">The key associated with the cache item.</param>
        /// <param name="item">The cache item.</param>
        /// <param name="overwrite">The flag indicating whether or not overwriting the existing cache item is permitted.</param>
        /// <returns>True if the cache item was successfully put into the specified region, otherwise false.</returns>
        public bool Put<T>(string regionName, string key, T item, bool overwrite)
        {
            string itemTag;
            return Put<T>(regionName, key, item, true, out itemTag);
        }

        /// <summary>
        /// Retrieves a cache item by its key.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="regionName">The target container (cache region) name from which the blob will be retrieved.</param>
        /// <param name="key">The key associated with the cache item.</param>
        /// <returns>An instance of <typeparamref name="T"/> or default(T) if the specified cache item was not found.</returns>
        public T Get<T>(string regionName, string key)
        {
            Guard.ArgumentNotNull(regionName, "regionName");
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(regionName, key);

            bool treatItemAsStream = false;

            try
            {
                treatItemAsStream = IsStreamType(typeof(T));

                object itemData = this.retryPolicy.ExecuteAction<object>(() =>
                {
                    // Only invoke the region-centric overload if region name is specified and we either explicitly know that regions are supported or we assume they are supported by default.
                    if (!String.IsNullOrEmpty(regionName) && this.isRegionSupported.GetValueOrDefault(true))
                    {
                        return this.cache.Get(key, regionName);
                    }
                    else
                    {
                        return this.cache.Get(key);
                    }
                });

                if (itemData != null)
                {
                    if (treatItemAsStream || !IsStreamType(itemData.GetType()))
                    {
                        return (T)itemData;
                    }
                    else
                    {
                        object itemObject = this.dataSerializer.Deserialize(itemData as Stream, typeof(T));
                        return (T)itemObject;
                    }
                }
                else
                {
                    return default(T);
                }
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Deletes the specified cache item.
        /// </summary>
        /// <param name="regionName">The target container (cache region) name from which the specified item will be deleted.</param>
        /// <param name="key">The key associated with the cache item.</param>
        /// <returns>True if the cache item was deleted, otherwise false.</returns>
        public bool Delete(string regionName, string key)
        {
            Guard.ArgumentNotNullOrEmptyString(regionName, "regionName");
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(regionName, key);
            bool success = false;

            try
            {
                success = this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    // Only invoke the region-centric overload if region name is specified and we either explicitly know that regions are supported or we assume they are supported by default.
                    if (!String.IsNullOrEmpty(regionName) && this.isRegionSupported.GetValueOrDefault(true))
                    {
                        return this.cache.Remove(key, regionName);
                    }
                    else
                    {
                        return this.cache.Remove(key);
                    }
                });

                return success;
            }
            catch (Exception ex)
            {
                TraceManager.CloudStorageComponent.TraceError(ex);
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, success);
            }

            return false;
        }

        /// <summary>
        /// Gets the number of cache items in the specified container (region).
        /// </summary>
        /// <param name="regionName">The target container (cache region) name to be queried.</param>
        /// <returns>The number of cache items in the container (region).</returns>
        public int GetCount(string regionName)
        {
            Guard.ArgumentNotNullOrEmptyString(regionName, "regionName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(regionName);
            int itemCount = 0;

            try
            {
                return itemCount;
            }
            catch (Exception ex)
            {
                TraceManager.CloudStorageComponent.TraceError(ex);
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, itemCount);
            }

            return 0;
        }

        /// <summary>
        /// Returns a list of all container (region) names found in the storage account.
        /// </summary>
        /// <param name="options">The <see cref="ContainerRequestOptions"/> object to use when making a request.</param>
        /// <returns>The list containing container (region) names.</returns>
        public IEnumerable<string> GetContainers(ContainerRequestOptions options = null)
        {
            var callToken = TraceManager.CloudStorageComponent.TraceIn();

            try
            {
                // Only execute CreateRegion action if we are sure that it is supported or when we are probing for the first time.
                if (!this.isRegionSupported.HasValue || this.isRegionSupported.Value)
                {
                    var regionList = this.retryPolicy.ExecuteAction<IEnumerable<string>>(() =>
                    {
                        return this.cache.GetSystemRegions();
                    });

                    // If we are still here, this means that a region may have been created successfully. Let's assume it's supported.
                    this.isRegionSupported = true;

                    return regionList;
                }
                else
                {
                    return null;
                }
            }
            catch (NotSupportedException)
            {
                // Set a flag telling that we should not try retrieving regions any longer as these are not supported.
                this.isRegionSupported = false;

                // Assume this operation will be supported someday. In the meantime, return a null reference to indicate that the operation has not succeeded.
                return null;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Puts an item into the cache and returns its globally unique auto-generated tag value.
        /// If the item with the same name already exists, the older item can be overwritten depending on the behavior specified in the <paramref name="overwrite"/> parameter.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the cache item.</typeparam>
        /// <param name="regionName">The target container (cache region) name into which the cache item will be stored.</param>
        /// <param name="key">The key associated with the cache item.</param>
        /// <param name="item">The cache item.</param>
        /// <param name="overwrite">The flag indicating whether or not overwriting the existing cache item is permitted.</param>
        /// <param name="itemTag">The output parameters holding the cache item's globally unique auto-generated tag value.</param>
        /// <returns>True if the cache item was successfully put into the specified region, otherwise false.</returns>
        private bool Put<T>(string regionName, string key, T item, bool overwrite, out string itemTag)
        {
            Guard.ArgumentNotNull(regionName, "regionName");
            Guard.ArgumentNotNullOrEmptyString(key, "key");
            Guard.ArgumentNotNull(item, "item");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(regionName, key, overwrite);

            Stream itemData = null;
            bool treatItemAsStream = false;

            try
            {
                // Are we dealing with a stream already? If yes, just use it as is.
                if (IsStreamType(item.GetType()))
                {
                    itemData = item as Stream;
                    treatItemAsStream = true;
                }
                else
                {
                    // The specified item type is something else rather than a Stream, we should perform serialization of T into a new memory stream instance.
                    itemData = new MemoryStream();

                    this.dataSerializer.Serialize(item, itemData);
                    itemData.Seek(0, SeekOrigin.Begin);
                }

                itemTag = Guid.NewGuid().ToString("N");
                var cacheItemTag = new DataCacheTag(itemTag);

                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    // Only invoke the region-centric overload if region name is specified and we either explicitly know that regions are supported or we assume they are supported by default.
                    if (!String.IsNullOrEmpty(regionName) && this.isRegionSupported.GetValueOrDefault(true))
                    {
                        this.cache.Put(key, itemData, new DataCacheTag[] { cacheItemTag }, regionName);
                    }
                    else
                    {
                        this.cache.Put(key, itemData, new DataCacheTag[] { cacheItemTag });
                    }
                    return true;
                });
            }
            finally
            {
                if (!treatItemAsStream && itemData != null)
                {
                    // Only dispose the blob data stream if it was newly created.
                    itemData.Dispose();
                }

                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }
        
        private bool IsStreamType(Type cacheItemType)
        {
            return cacheItemType != null & (cacheItemType == typeof(Stream) || typeof(Stream).IsAssignableFrom(cacheItemType));
        }
        #endregion
    }
}
