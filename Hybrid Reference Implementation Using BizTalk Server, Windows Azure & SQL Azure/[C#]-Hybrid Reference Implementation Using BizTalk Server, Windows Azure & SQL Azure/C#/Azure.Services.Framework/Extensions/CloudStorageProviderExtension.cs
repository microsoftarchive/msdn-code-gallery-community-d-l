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
    using System.Globalization;
    using System.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    #endregion

    #region ICloudStorageProviderExtension interface
    /// <summary>
    /// Defines a contract that must be supported by an extension acting as a factory for specific Windows Azure storage service implementations.
    /// </summary>
    public interface ICloudStorageProviderExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns the Windows Azure blob storage specified in the application configuration as default.
        /// </summary>
        ICloudBlobStorage DefaultBlobStorage { get; }

        /// <summary>
        /// Returns the Windows Azure queue storage specified in the application configuration as default.
        /// </summary>
        ICloudQueueStorage DefaultQueueStorage { get; }

        /// <summary>
        /// Returns the Windows Azure queue storage specified in the application configuration as default.
        /// </summary>
        ICloudTableStorage DefaultTableStorage { get; }

        /// <summary>
        /// Returns the Windows Azure blob storage from the specified storage account.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>An instance of the object supporting storage operations against Windows Azure blobs.</returns>
        ICloudBlobStorage GetBlobStorage(string accountName);

        /// <summary>
        /// Returns the Windows Azure queue storage from the specified storage account.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>An instance of the object supporting storage operations against Windows Azure queues.</returns>
        ICloudQueueStorage GetQueueStorage(string accountName);

        /// <summary>
        /// Returns the Windows Azure table storage from the specified storage account.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>An instance of the object supporting storage operations against Windows Azure tables.</returns>
        ICloudTableStorage GetTableStorage(string accountName);
    }
    #endregion

    /// <summary>
    /// Implements the extension acting as a factory for specific Windows Azure storage service implementations.
    /// </summary>
    public class CloudStorageProviderExtension : ICloudStorageProviderExtension
    {
        #region Private members
        private IRoleConfigurationSettingsExtension roleConfigExtension;
        private ICloudBlobStorage defaultBlobStorage;
        private ICloudQueueStorage defaultQueueStorage;
        private ICloudTableStorage defaultTableStorage;
        private readonly object syncRoot = new object();
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<IRoleConfigurationSettingsExtension>();

            this.roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            if (this.defaultBlobStorage != null)
            {
                lock (this.syncRoot)
                {
                    if (this.defaultBlobStorage != null)
                    {
                        this.defaultBlobStorage.Dispose();
                        this.defaultBlobStorage = null;
                    }
                }
            }

            if (this.defaultQueueStorage != null)
            {
                lock (this.syncRoot)
                {
                    if (this.defaultQueueStorage != null)
                    {
                        this.defaultQueueStorage.Dispose();
                        this.defaultQueueStorage = null;
                    }
                }
            }

            if (this.defaultTableStorage != null)
            {
                lock (this.syncRoot)
                {
                    if (this.defaultTableStorage != null)
                    {
                        this.defaultTableStorage.Dispose();
                        this.defaultTableStorage = null;
                    }
                }
            }
        }
        #endregion

        #region ICloudStorageProviderExtension implementation
        /// <summary>
        /// Returns the Windows Azure blob storage specified in the application configuration as default.
        /// </summary>
        public ICloudBlobStorage DefaultBlobStorage 
        { 
            get
            {
                if (null == this.defaultBlobStorage)
                {
                    lock (this.syncRoot)
                    {
                        if (null == this.defaultBlobStorage)
                        {
                            StorageAccountConfigurationSettings storageSettings = this.roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                            if (storageSettings != null)
                            {
                                this.defaultBlobStorage = GetBlobStorage(storageSettings.DefaultBlobStorage);
                            }
                            else
                            {
                                throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
                            }
                        }
                    }
                }

                return this.defaultBlobStorage;
            }
        }

        /// <summary>
        /// Returns the Windows Azure queue storage specified in the application configuration as default.
        /// </summary>
        public ICloudQueueStorage DefaultQueueStorage 
        { 
            get
            {
                if (null == this.defaultQueueStorage)
                {
                    lock (this.syncRoot)
                    {
                        if (null == this.defaultQueueStorage)
                        {
                            StorageAccountConfigurationSettings storageSettings = this.roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                            if (storageSettings != null)
                            {
                                this.defaultQueueStorage = GetQueueStorage(storageSettings.DefaultQueueStorage);
                            }
                            else
                            {
                                throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
                            }
                        }
                    }
                }

                return this.defaultQueueStorage;
            }
        }

        /// <summary>
        /// Returns the Windows Azure queue storage specified in the application configuration as default.
        /// </summary>
        public ICloudTableStorage DefaultTableStorage
        {
            get
            {
                if (null == this.defaultTableStorage)
                {
                    lock (this.syncRoot)
                    {
                        if (null == this.defaultTableStorage)
                        {
                            StorageAccountConfigurationSettings storageSettings = this.roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                            if (storageSettings != null)
                            {
                                this.defaultTableStorage = GetTableStorage(storageSettings.DefaultTableStorage);
                            }
                            else
                            {
                                throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
                            }
                        }
                    }
                }

                return this.defaultTableStorage;
            }
        }

        /// <summary>
        /// Returns the Windows Azure blob storage from the specified storage account.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>An instance of the object supporting storage operations against Windows Azure blobs.</returns>
        public ICloudBlobStorage GetBlobStorage(string accountName)
        {
            Guard.ArgumentNotNull(accountName, "accountName");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(accountName);

            try
            {
                StorageAccountConfigurationSettings storageSettings = this.roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                if (storageSettings != null)
                {
                    StorageAccountInfo storageAccount = storageSettings.Accounts.Get(accountName);

                    if (storageAccount != null)
                    {
                        return new ReliableCloudBlobStorage(storageAccount, GetStorageAccountRetryPolicy(storageAccount));
                    }
                    else
                    {
                        throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.StorageAccountNotFoundInConfigSource, accountName));
                    }
                }
                else
                {
                    throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Returns the Windows Azure queue storage from the specified storage account.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>An instance of the object supporting storage operations against Windows Azure queues.</returns>
        public ICloudQueueStorage GetQueueStorage(string accountName)
        {
            Guard.ArgumentNotNull(accountName, "accountName");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(accountName);

            try
            {
                StorageAccountConfigurationSettings storageSettings = this.roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                if (storageSettings != null)
                {
                    StorageAccountInfo storageAccount = storageSettings.Accounts.Get(accountName);

                    if (storageAccount != null)
                    {
                        return new ReliableCloudQueueStorage(storageAccount, GetStorageAccountRetryPolicy(storageAccount));
                    }
                    else
                    {
                        throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.StorageAccountNotFoundInConfigSource, accountName));
                    }
                }
                else
                {
                    throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Returns the Windows Azure table storage from the specified storage account.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>An instance of the object supporting storage operations against Windows Azure tables.</returns>
        public ICloudTableStorage GetTableStorage(string accountName)
        {
            Guard.ArgumentNotNull(accountName, "accountName");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(accountName);

            try
            {
                StorageAccountConfigurationSettings storageSettings = this.roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                if (storageSettings != null)
                {
                    StorageAccountInfo storageAccount = storageSettings.Accounts.Get(accountName);

                    if (storageAccount != null)
                    {
                        return new ReliableCloudTableStorage(storageAccount, GetStorageAccountRetryPolicy(storageAccount));
                    }
                    else
                    {
                        throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.StorageAccountNotFoundInConfigSource, accountName));
                    }
                }
                else
                {
                    throw new ConfigurationErrorsException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region Private members
        private RetryPolicy GetStorageAccountRetryPolicy(StorageAccountInfo storageAccount)
        {
            Guard.ArgumentNotNull(storageAccount, "storageAccount");

            if (!String.IsNullOrEmpty(storageAccount.RetryPolicy))
            {
                return RetryPolicyFactory.GetRetryPolicy<StorageTransientErrorDetectionStrategy>(storageAccount.RetryPolicy);
            }
            else
            {
                return this.roleConfigExtension.StorageRetryPolicy;
            }
        }
        #endregion
    }
}