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

    using Microsoft.Practices.EnterpriseLibrary.Caching;
    using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
    #endregion

    /// <summary>
    /// Defines a set of options that apply when writing data to a cache.
    /// </summary>
    public sealed class CachePutOptions
    {
        #region Public members
        /// <summary>
        /// Gets the default sliding expiration time in seconds for cache items.
        /// </summary>
        public const int DefaultSlidingTimeExpirationSeconds = 60 * 60;

        /// <summary>
        /// Gets the default options that apply when writing data to a cache.
        /// </summary>
        public static readonly CachePutOptions Default = new CachePutOptions()
        {
            Priority = CacheItemPriority.Normal,
            ExpirationPolicy = new SlidingTime(TimeSpan.FromSeconds(DefaultSlidingTimeExpirationSeconds))
        }; 
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the relative priority of items stored in the cache.
        /// </summary>
        public CacheItemPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the instance of the cache policy that define how soon cached items expire. 
        /// </summary>
        public ICacheItemExpiration ExpirationPolicy { get; set; }

        /// <summary>
        /// Gets or sets the instance of an object that can be used to refresh an expired item from the cache. The implementing class must be serializable. 
        /// </summary>
        public ICacheItemRefreshAction RefreshAction { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating that cache write operation must be completed asynchronously.
        /// </summary>
        public bool EnableAsyncPut { get; set; } 
        #endregion
    }
}
