//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;

    using Microsoft.Practices.EnterpriseLibrary.Caching.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations;
    #endregion

    /// <summary>
    /// Wraps the Enterprise Library's Caching Application Block configuration and provides simplified operations with the underlying configuration data.
    /// </summary>
    public class CachingConfigurationView
    {
        #region Private members
        private const string DefaultCacheManagerName = "Default Cache Manager";
        private const string DefaultBackingStoreName = "NullBackingStore";
        private const int DefaultExpirationPollFrequencyInSeconds = 60 * 10;
        private const int DefaultMaximumElementsInCacheBeforeScavenging = 1000;
        private const int DefaultNumberOfItemsToRemoveWhenScavenging = 10;

        private readonly CacheManagerSettings cachingSettings;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="CachingConfigurationView"/> object based on the specified <see cref="Microsoft.Practices.EnterpriseLibrary.Caching.Configuration.CacheManagerSettings"/>.
        /// </summary>
        /// <param name="cachingSettings">The configuration data for the Caching Application Block.</param>
        public CachingConfigurationView(CacheManagerSettings cachingSettings)
        {
            Guard.ArgumentNotNull(cachingSettings, "cachingSettings");

            this.cachingSettings = cachingSettings;

            ApplyDefaultCacheManager(DefaultCacheManagerName);
            ApplyDefaultBackingStore(DefaultBackingStoreName);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Sets the name of the default cache manager instance to use when no other manager is specified.
        /// </summary>
        /// <param name="name">The name of the default cache manager.</param>
        public void SetDefaultCacheManager(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            if (this.cachingSettings.CacheManagers.Contains(name))
            {
                this.cachingSettings.DefaultCacheManager = name;
            }
        }

        /// <summary>
        /// Adds a new cache backing store into the collection of backing stores.
        /// </summary>
        /// <param name="name">The unique name under which a new cache backing store will be added to the collection.</param>
        /// <param name="cacheStorageTypeName">The fully qualified type name implementing the new cache backing store.</param>
        public void AddCacheStorage(string name, string cacheStorageTypeName)
        {
            AddCacheStorage(name, Type.GetType(cacheStorageTypeName, true));
        }

        /// <summary>
        /// Adds a new cache backing store into the collection of backing stores.
        /// </summary>
        /// <param name="name">The unique name under which a new cache backing store will be added to the collection.</param>
        /// <param name="cacheStorageType">The type implementing the new cache backing store.</param>
        public void AddCacheStorage(string name, Type cacheStorageType)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");
            Guard.ArgumentNotNull(cacheStorageType, "cacheStorageType");

            if (!this.cachingSettings.BackingStores.Contains(name))
            {
                this.cachingSettings.BackingStores.Add(new CacheStorageData(name, cacheStorageType));
            }
        }

        /// <summary>
        /// Adds a new cache definition into the collection of cache managers using specified expiration and scavenging parameters.
        /// </summary>
        /// <param name="name">The unique name under which a new cache definition will be added to the collection.</param>
        /// <param name="storageName">The name of the cache backing store that will be associated with the new cache definition.</param>
        /// <param name="isDefault">A flag indicating whether or not the new cache definition will be set as default.</param>
        /// <param name="expirationPollFrequencyInSeconds">Frequency in seconds of expiration polling cycle.</param>
        /// <param name="maximumElementsInCacheBeforeScavenging">Maximum number of items in cache before an add causes scavenging to take place.</param>
        /// <param name="numberOfItemsToRemoveWhenScavenging">Number of items to remove from cache when scavenging.</param>
        public void AddCacheManager(string name, string storageName, bool isDefault, int expirationPollFrequencyInSeconds, int maximumElementsInCacheBeforeScavenging, int numberOfItemsToRemoveWhenScavenging)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");
            Guard.ArgumentNotNullOrEmptyString(storageName, "storageName");
            Guard.ArgumentNotZeroOrNegativeValue(expirationPollFrequencyInSeconds, "expirationPollFrequencyInSeconds");
            Guard.ArgumentNotZeroOrNegativeValue(maximumElementsInCacheBeforeScavenging, "maximumElementsInCacheBeforeScavenging");
            Guard.ArgumentNotZeroOrNegativeValue(numberOfItemsToRemoveWhenScavenging, "numberOfItemsToRemoveWhenScavenging");

            if (!this.cachingSettings.CacheManagers.Contains(name))
            {
                CacheManagerData cacheManagerData = new CacheManagerData(name, expirationPollFrequencyInSeconds, maximumElementsInCacheBeforeScavenging, numberOfItemsToRemoveWhenScavenging, storageName);

                this.cachingSettings.CacheManagers.Add(cacheManagerData);

                if (isDefault)
                {
                    this.cachingSettings.DefaultCacheManager = name;
                }
            }
        }

        /// <summary>
        /// Adds a new cache definition into the collection of cache managers using default expiration and scavenging parameters.
        /// </summary>
        /// <param name="name">The unique name under which a new cache definition will be added to the collection.</param>
        /// <param name="storageName">The name of the cache backing store that will be associated with the new cache definition.</param>
        /// <param name="isDefault">A flag indicating whether or not the new cache definition will be set as default.</param>
        public void AddCacheManager(string name, string storageName, bool isDefault)
        {
            AddCacheManager(name, storageName, isDefault, DefaultExpirationPollFrequencyInSeconds, DefaultMaximumElementsInCacheBeforeScavenging, DefaultNumberOfItemsToRemoveWhenScavenging);
        }
        #endregion

        #region Private methods
        private void ApplyDefaultBackingStore(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            if (!this.cachingSettings.BackingStores.Contains(name))
            {
                this.cachingSettings.BackingStores.Add(new CacheStorageData(name, typeof(NullBackingStore)));
            }
        }

        private void ApplyDefaultCacheManager(string name)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");

            if (!this.cachingSettings.CacheManagers.Contains(name))
            {
                this.cachingSettings.CacheManagers.Add(new CacheManagerData(name, DefaultExpirationPollFrequencyInSeconds, DefaultMaximumElementsInCacheBeforeScavenging, DefaultNumberOfItemsToRemoveWhenScavenging, DefaultBackingStoreName));
            }

            if (String.IsNullOrEmpty(this.cachingSettings.DefaultCacheManager))
            {
                this.cachingSettings.DefaultCacheManager = name;
            }
        }
        #endregion
    }
}