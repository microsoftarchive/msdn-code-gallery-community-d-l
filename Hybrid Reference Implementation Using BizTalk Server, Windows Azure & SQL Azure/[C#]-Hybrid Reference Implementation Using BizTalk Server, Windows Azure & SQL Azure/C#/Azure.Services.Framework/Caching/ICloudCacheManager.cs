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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Caching
{
    #region Using references
    using System;
    #endregion

    /// <summary>
    /// Defines the contract that must be implemented by all cache managers.
    /// </summary>
    public interface ICloudCacheManager
    {
        /// <summary>
        /// Adds new cache item to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added. 
        /// Items added with this method will not expire, and will have a Normal priority.
        /// </summary>
        /// <param name="key">A key of the item to be put to the cache.</param>
        /// <param name="value">Value to be stored in the cache. It may be null.</param>
        void Put(string key, object value);

        /// <summary>
        /// Adds new cache item to cache. If another item already exists with the same key, that item is removed before
        /// the new item is added. If any failure occurs during this process, the cache will not contain the item being added. 
        /// Items added with this method will not expire, and will have a Normal priority.
        /// </summary>
        /// <param name="key">A key of the item to be put to the cache.</param>
        /// <param name="value">Value to be stored in the cache. It may be null.</param>
        /// <param name="options">The options <see cref="CachePutOptions"/> to use when making a request.</param>
        void Put(string key, object value, CachePutOptions options);

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">A key of the item to return from cache.</param>
        /// <returns>The value stored in the cache.</returns>
        object Get(string key);

        /// <summary>
        /// Returns the value associated with the given key.
        /// </summary>
        /// <param name="key">A key of the item to return from cache.</param>
        /// <param name="options">The options <see cref="CacheGetOptions"/> to use when making a request.</param>
        /// <returns>The value stored in the cache.</returns>
        object Get(string key, CacheGetOptions options);

        /// <summary>
        /// Returns the value associated with the given key or adds an item to the cache it doesn't exist.
        /// </summary>
        /// <param name="key">A key of the item to return from cache.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <returns>The value stored in the cache.</returns>
        object GetOrPut(string key, Func<object> valueFactory);

        /// <summary>
        /// Removes the given item from the cache. If no item exists with specified key, this method does nothing.
        /// </summary>
        /// <param name="key">A key of the item to remove from the cache.</param>
        void Remove(string key);

        /// <summary>
        /// Returns the number of items currently in the cache.
        /// </summary>
        int Count { get; }
    }
}
