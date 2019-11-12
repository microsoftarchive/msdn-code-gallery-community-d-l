//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Scalable Transform worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Configuration
{
    #region Using references
    using System;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration section which provides access to the configuration settings used by the Scalable Transform service.
    /// </summary>
    [Serializable]
    public class ScalableTransformConfigurationSettings : SerializableConfigurationSection
    {
        #region Private members
        private const string CacheStorageAccountProperty = "cacheStorageAccount";
        private const string StorageAccountsProperty = "storageAccounts";
        private const string MemoryCacheTimeToLiveProperty = "memoryCacheTimeToLive";
        private const string BlobCacheTimeToLiveProperty = "blobCacheTimeToLive";
        #endregion

        #region Public members
        /// <summary>
        /// Returns the default TTL value for the in-memory cache items.
        /// </summary>
        public const int DefaultMemoryCacheTimeToLiveSeconds = 60 * 10;

        /// <summary>
        /// Returns the default TTL value for the blob cache items.
        /// </summary>
        public const int DefaultBlobCacheTimeToLiveSeconds = 60 * 60;

        /// <summary>
        /// Returns the name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "ScalableTransformConfiguration";
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of Windows Azure storage account which used for caching transform objects.
        /// </summary>
        [ConfigurationProperty(CacheStorageAccountProperty, IsRequired = true)]
        public string CacheStorageAccount
        {
            get { return (string)base[CacheStorageAccountProperty]; }
            set { base[CacheStorageAccountProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the time value indicating how long transform objects will be kept inside non-durable in-memory cache.
        /// </summary>
        [ConfigurationProperty(MemoryCacheTimeToLiveProperty, IsRequired = false, DefaultValue = "00:10:00")]
        public TimeSpan MemoryCacheTimeToLive
        {
            get { return (TimeSpan)base[MemoryCacheTimeToLiveProperty]; }
            set { base[MemoryCacheTimeToLiveProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the time value indicating how long transform objects will be kept inside durable cache.
        /// </summary>
        [ConfigurationProperty(BlobCacheTimeToLiveProperty, IsRequired = false, DefaultValue = "01:00:00")]
        public TimeSpan BlobCacheTimeToLive
        {
            get { return (TimeSpan)base[BlobCacheTimeToLiveProperty]; }
            set { base[BlobCacheTimeToLiveProperty] = value; }
        }

        /// <summary>
        /// Returns a collection of storage accounts which will be utilized by operations in Scalable Transform service
        /// for the purposes of scalability and load balancing.
        /// </summary>
        [ConfigurationProperty(StorageAccountsProperty, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(KeyValueConfigurationElement))]
        public KeyValueConfigurationCollection StorageAccounts
        {
            get
            {
                return (KeyValueConfigurationCollection)base[StorageAccountsProperty];
            }
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a storage account by its name into the collection of storage accounts which will be utilized by Scalable Transform service.
        /// </summary>
        /// <param name="accountName">The name of the storage account definition configured in the application configuration.</param>
        public void AddStorageAccount(string accountName)
        {
            Guard.ArgumentNotNullOrEmptyString(accountName, "accountName");

            StorageAccounts.Add(accountName, String.Empty);
        }

        /// <summary>
        /// Sets the in-memory cache TTL value to the specified number of seconds.
        /// </summary>
        /// <param name="value">The number of seconds defining the cache item TTL value.</param>
        public void SetMemoryCacheTimeToLiveInSeconds(int value)
        {
            Guard.ArgumentNotZeroOrNegativeValue(value, "value");

            MemoryCacheTimeToLive = TimeSpan.FromSeconds(value);
        }

        /// <summary>
        /// Sets the blob cache TTL value to the specified number of seconds.
        /// </summary>
        /// <param name="value">The number of seconds defining the cache item TTL value.</param>
        public void SetBlobCacheTimeToLiveInSeconds(int value)
        {
            Guard.ArgumentNotZeroOrNegativeValue(value, "value");

            BlobCacheTimeToLive = TimeSpan.FromSeconds(value);
        }
        #endregion
    }
}
