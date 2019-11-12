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
    using System.ServiceModel;
    using System.Threading.Tasks;

    using Microsoft.Practices.EnterpriseLibrary.Caching;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Caching;
    #endregion

    #region ICloudCacheProviderExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for caching user objects.
    /// </summary>
    public interface ICloudCacheProviderExtension : ICloudCacheManager, ICloudServiceComponentExtension
    {
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for caching user objects.
    /// </summary>
    public class CloudCacheProviderExtension : ICloudCacheProviderExtension
    {
        #region Private members
        private readonly ICacheManager cacheManager;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a cache provider extension object initialized with the default cache manager that is defined in the caching configuration.
        /// </summary>
        public CloudCacheProviderExtension()
        {
            this.cacheManager = CacheFactory.GetCacheManager();
        }

        /// <summary>
        /// Initializes a new instance of a cache provider extension object initialized with the specified cache manager.
        /// </summary>
        /// <param name="name">The name defined in configuration for the cache manager to instantiate.</param>
        public CloudCacheProviderExtension(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            this.cacheManager = CacheFactory.GetCacheManager(name);
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region ICloudCacheManager implementation
        /// <summary>
        /// Adds new cache item to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added. 
        /// Items added with this method will not expire, and will have a Normal priority.
        /// </summary>
        /// <param name="key">A key of the item to be put to the cache.</param>
        /// <param name="value">Value to be stored in the cache. It may be null.</param>
        public void Put(string key, object value)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            this.cacheManager.Add(key, value);
        }

        /// <summary>
        /// Adds new cache item to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added. 
        /// Items added with this method will not expire, and will have a Normal priority.
        /// </summary>
        /// <param name="key">A key of the item to be put to the cache.</param>
        /// <param name="value">Value to be stored in the cache. It may be null.</param>
        /// <param name="options">The options <see cref="CachePutOptions"/> to use when making a request.</param>
        public void Put(string key, object value, CachePutOptions options)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");
            Guard.ArgumentNotNull(options, "options");

            if (options.EnableAsyncPut)
            {
                Task.Factory.StartNew(() =>
                {
                    this.cacheManager.Add(key, value, options.Priority, options.RefreshAction, options.ExpirationPolicy);
                });
            }
            else
            {
                this.cacheManager.Add(key, value, options.Priority, options.RefreshAction, options.ExpirationPolicy);
            }
        }

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">A key of the item to return from cache.</param>
        /// <returns>The value stored in the cache.</returns>
        public object Get(string key)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            return this.cacheManager.GetData(key);
        }

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">A key of the item to return from cache.</param>
        /// <param name="options">The options <see cref="CacheGetOptions"/> to use when making a request.</param>
        /// <returns>The value stored in the cache.</returns>
        public object Get(string key, CacheGetOptions options)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");
            Guard.ArgumentNotNull(options, "options");

            object value = this.cacheManager.GetData(key);

            if (options.AutoRemove)
            {
                Remove(key);
            }

            return value;
        }

        /// <summary>
        /// Returns the value associated with the given key or adds an item to the cache it doesn't exist.
        /// </summary>
        /// <param name="key">A key of the item to return from cache.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <returns>The value stored in the cache.</returns>
        public object GetOrPut(string key, Func<object> valueFactory)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            object value = this.cacheManager.GetData(key);

            if (null == value)
            {
                Put(key, value = valueFactory());
            }
            
            return value;
        }

        /// <summary>
        /// Removes the given item from the cache. If no item exists with specified key, this method does nothing.
        /// </summary>
        /// <param name="key">A key of the item to remove from the cache.</param>
        public void Remove(string key)
        {
            Guard.ArgumentNotNullOrEmptyString(key, "key");

            this.cacheManager.Remove(key);
        }

        /// <summary>
        /// Returns the number of items currently in the cache.
        /// </summary>
        public int Count
        {
            get { return this.cacheManager.Count; }
        }
        #endregion
    }
}
