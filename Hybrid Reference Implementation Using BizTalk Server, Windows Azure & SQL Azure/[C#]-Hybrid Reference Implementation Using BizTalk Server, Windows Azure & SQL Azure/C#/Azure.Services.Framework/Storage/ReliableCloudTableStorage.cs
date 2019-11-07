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
    using System.Net;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data.Services.Client;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Runtime.Serialization;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;

    using RetryPolicy = Contoso.Cloud.Integration.Framework.RetryPolicy;
    #endregion

    /// <summary>
    /// Provides reliable access to the Azure table storage.
    /// </summary>
    public class ReliableCloudTableStorage : ICloudTableStorage
    {
        #region Private members
        private readonly RetryPolicy retryPolicy;
        private readonly CloudTableClient tableStorage;
        private readonly ICloudStorageEntitySerializer dataSerializer;

        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Table storage layer connected to the specified storage account.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        public ReliableCloudTableStorage(StorageAccountInfo storageAccountInfo)
            : this(storageAccountInfo, new RetryPolicy<StorageTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff))
        {
        }

        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Table storage layer connected to the specified storage account
        /// and initialized with the specified retry policy.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying table storage.</param>
        public ReliableCloudTableStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy)
            : this(storageAccountInfo, retryPolicy, new CloudStorageEntitySerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the reliable Windows Azure Table storage layer connected to the specified storage account,
        /// initialized with the specified retry policy and custom serializer.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying table storage.</param>
        /// <param name="dataSerializer">An instance of the component which performs serialization and deserialization of storage objects.</param>
        public ReliableCloudTableStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy, ICloudStorageEntitySerializer dataSerializer)
        {
            Guard.ArgumentNotNull(storageAccountInfo, "storageAccountInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");
            Guard.ArgumentNotNull(dataSerializer, "dataSerializer");

            this.retryPolicy = retryPolicy;
            this.dataSerializer = dataSerializer;

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey(storageAccountInfo.AccountName, storageAccountInfo.AccountKey), true);
            this.tableStorage = storageAccount.CreateCloudTableClient();

            // Configure the Table storage not to enforce any retry policies since this is something that we will be dealing ourselves.
            this.tableStorage.RetryPolicy = RetryPolicies.NoRetry();
        }
        #endregion

        #region ICloudTableStorage implementation
        /// <summary>
        /// Creates a new table if it does not already exist.
        /// </summary>
        /// <param name="tableName">The name of the table to be created.</param>
        /// <returns>A flag indicating whether or not the table has actually been created.</returns>
        public bool CreateTable(string tableName)
        {
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            var callToken = TraceManager.CloudStorageComponent.TraceIn(tableName);

            try
            {
                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    return this.tableStorage.CreateTableIfNotExist(tableName);
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Deletes a table if it exists.
        /// </summary>
        /// <param name="tableName">The name of the table to be deleted.</param>
        /// <returns>A flag indicating whether or not the table has actually been deleted.</returns>
        public bool DeleteTable(string tableName)
        {
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            var callToken = TraceManager.CloudStorageComponent.TraceIn(tableName);

            try
            {
                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    return this.tableStorage.DeleteTableIfExist(tableName);
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Gets a collection of entities from the specified table.
        /// </summary>
        /// <typeparam name="T">The type of the entity stored in the table.</typeparam>
        /// <param name="tableName">The name of the source table.</param>
        /// <returns>The list of entities retrieved from the specified table.</returns>
        public IEnumerable<T> Get<T>(string tableName)
        {
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            var callToken = TraceManager.CloudStorageComponent.TraceIn(tableName);

            try
            {
                return this.retryPolicy.ExecuteAction<IEnumerable<T>>(() =>
                {
                    var context = this.tableStorage.GetDataServiceContext();
                    return context.CreateQuery<T>(tableName).AsTableServiceQuery<T>();
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Adds the specified entity into the table.
        /// </summary>
        /// <typeparam name="T">The type of the table entity.</typeparam>
        /// <param name="entity">The instance of the entity to be added into the table.</param>
        /// <param name="tableName">The name of the table into which the specified entity will be added.</param>
        /// <returns>True if the entity has been successfully added, otherwise False.</returns>
        public bool Add<T>(T entity, string tableName)
        {
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            var callToken = TraceManager.CloudStorageComponent.TraceIn(tableName);

            try
            {
                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    var context = this.tableStorage.GetDataServiceContext();

                    context.AddObject(tableName, entity);
                    return IsSuccess(context.SaveChanges());
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Updates the specified entity stored in the table.
        /// </summary>
        /// <typeparam name="T">The type of the table entity.</typeparam>
        /// <param name="entity">The instance of the entity to be updated.</param>
        /// <param name="tableName">The name of the table containing the entity to be updated.</param>
        /// <returns>True if the entity has been successfully updated, otherwise False.</returns>
        public bool Update<T>(T entity, string tableName)
        {
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            var callToken = TraceManager.CloudStorageComponent.TraceIn(tableName);

            try
            {
                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    var context = this.tableStorage.GetDataServiceContext();

                    context.UpdateObject(entity);
                    return IsSuccess(context.SaveChanges());
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Deletes the specified entity stored in the table.
        /// </summary>
        /// <typeparam name="T">The type of the table entity.</typeparam>
        /// <param name="entity">The instance of the entity to be deleted.</param>
        /// <param name="tableName">The name of the table containing the entity to be deleted.</param>
        /// <returns>True if the entity has been successfully deleted, otherwise False.</returns>
        public bool Delete<T>(T entity, string tableName)
        {
            Guard.ArgumentNotNullOrEmptyString(tableName, "tableName");
            var callToken = TraceManager.CloudStorageComponent.TraceIn(tableName);

            try
            {
                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    var context = this.tableStorage.GetDataServiceContext();

                    context.DeleteObject(entity);
                    return IsSuccess(context.SaveChanges());
                });
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
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
                throw new ObjectDisposedException(typeof(ReliableCloudTableStorage).FullName);
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableCloudTableStorage()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        /// <param name="disposing">Determines whether this was called by Dispose or by the finalizer.</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
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
        private bool IsSuccess(DataServiceResponse response)
        {
            return response != null && response.BatchStatusCode >= (int)HttpStatusCode.OK && response.BatchStatusCode < (int)HttpStatusCode.Ambiguous;
        }
        #endregion
    }
}
