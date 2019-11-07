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
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Implements a configuration section containing Windows Azure storage configuration settings.
    /// </summary>
    [Serializable]
    public sealed class StorageAccountConfigurationSettings : SerializableConfigurationSection
    {
        #region Private members
        private const string DefaultTableStorageProperty = "defaultTableStorage";
        private const string DefaultBlobStorageProperty = "defaultBlobStorage";
        private const string DefaultQueueStorageProperty = "defaultQueueStorage";
        #endregion

        #region Public members
        /// <summary>
        /// The name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "StorageAccountConfiguration"; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="StorageAccountConfigurationSettings"/> object with default settings.
        /// </summary>
        public StorageAccountConfigurationSettings()
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the Windows Azure storage account intended to be used as default for holding the Azure tables.
        /// </summary>
        [ConfigurationProperty(DefaultTableStorageProperty, IsRequired = false)]
        public string DefaultTableStorage
        {
            get { return (string)base[DefaultTableStorageProperty]; }
            set { base[DefaultTableStorageProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the Windows Azure storage account intended to be used as default for holding the Azure blobs.
        /// </summary>
        [ConfigurationProperty(DefaultBlobStorageProperty, IsRequired = false)]
        public string DefaultBlobStorage
        {
            get { return (string)base[DefaultBlobStorageProperty]; }
            set { base[DefaultBlobStorageProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the name of the Windows Azure storage account intended to be used as default for holding the Azure queues.
        /// </summary>
        [ConfigurationProperty(DefaultQueueStorageProperty, IsRequired = false)]
        public string DefaultQueueStorage
        {
            get { return (string)base[DefaultQueueStorageProperty]; }
            set { base[DefaultQueueStorageProperty] = value; }
        }

        /// <summary>
        /// Returns a collection of Windows Azure storage account definitions configured for the application. 
        /// </summary>
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(StorageAccountInfo))]
        public NamedElementCollection<StorageAccountInfo> Accounts
        {
            get { return (NamedElementCollection<StorageAccountInfo>)base[String.Empty]; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds details of a new storage account into the collection of storage account definitions.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="accountKey">The account key, as a Base64-encoded string.</param>
        public void AddAccount(string accountName, string accountKey)
        {
            Guard.ArgumentNotNullOrEmptyString(accountName, "accountName");
            Guard.ArgumentNotNullOrEmptyString(accountKey, "accountKey");

            Accounts.Add(new StorageAccountInfo(accountName, accountKey));
        }

        /// <summary>
        /// Adds details of a new storage account into the collection of storage account definitions and overrides the storage retry policy with the specified retry policy name.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="accountKey">The account key, as a Base64-encoded string.</param>
        /// <param name="retryPolicyName">The name of the retry policy definition specified in the application configuration.</param>
        public void AddAccount(string accountName, string accountKey, string retryPolicyName)
        {
            Guard.ArgumentNotNullOrEmptyString(accountName, "accountName");
            Guard.ArgumentNotNullOrEmptyString(accountKey, "accountKey");
            Guard.ArgumentNotNullOrEmptyString(retryPolicyName, "retryPolicyName");

            Accounts.Add(new StorageAccountInfo(accountName, accountKey) { RetryPolicy = retryPolicyName });
        }

        /// <summary>
        /// Associates the specified storage account definition with a retry policy.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="retryPolicyName">The name of the retry policy definition specified in the application configuration.</param>
        public void AssignRetryPolicy(string accountName, string retryPolicyName)
        {
            Guard.ArgumentNotNullOrEmptyString(accountName, "accountName");
            Guard.ArgumentNotNullOrEmptyString(retryPolicyName, "retryPolicyName");

            StorageAccountInfo accountInfo = Accounts.Get(accountName);

            if (accountInfo != null)
            {
                accountInfo.RetryPolicy = retryPolicyName;
            }
        }
        #endregion
    }
}
