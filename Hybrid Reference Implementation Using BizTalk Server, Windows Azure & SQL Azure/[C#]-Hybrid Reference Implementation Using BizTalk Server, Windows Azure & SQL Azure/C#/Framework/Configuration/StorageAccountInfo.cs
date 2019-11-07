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
    /// Implements a configuration element holding storage account parameters.
    /// </summary>
    public sealed class StorageAccountInfo : NamedConfigurationElement
    {
        #region Private members
        private const string AccountNameProperty = "accountName";
        private const string AccountKeyProperty = "accountKey";
        private const string RetryPolicyProperty = "retryPolicy";
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="StorageAccountInfo"/> object with default settings.
        /// </summary>
        public StorageAccountInfo() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="StorageAccountInfo"/> object with specified account name and access key.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="accountKey">The account key, as a Base64-encoded string.</param>
        public StorageAccountInfo(string accountName, string accountKey)
        {
            Guard.ArgumentNotNullOrEmptyString(accountName, "accountName");
            Guard.ArgumentNotNullOrEmptyString(accountKey, "accountKey");

            Name = accountName;
            AccountName = accountName;
            AccountKey = accountKey;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the storage account associated with the specified credentials.
        /// </summary>
        [ConfigurationProperty(AccountNameProperty, IsRequired = true)]
        public string AccountName
        {
            get { return (string)base[AccountNameProperty]; }
            set { base[AccountNameProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the key value which is part of storage account credentials for accessing the Windows Azure storage services. 
        /// </summary>
        [ConfigurationProperty(AccountKeyProperty, IsRequired = true)]
        public string AccountKey
        {
            get { return (string)base[AccountKeyProperty]; }
            set { base[AccountKeyProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the retry policy definition associated with the storage account.
        /// </summary>
        [ConfigurationProperty(RetryPolicyProperty, IsRequired = false)]
        public string RetryPolicy
        {
            get { return (string)base[RetryPolicyProperty]; }
            set { base[RetryPolicyProperty] = value; }
        }
        #endregion
    }
}
