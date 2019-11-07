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
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;

    using RetryPolicy = Contoso.Cloud.Integration.Framework.RetryPolicy;
    #endregion

    /// <summary>
    /// Implements reliable generics-aware layer for Windows Azure Blob storage.
    /// </summary>
    public class ReliableCloudBlobStorage : ICloudBlobStorage
    {
        #region Private members
        private readonly RetryPolicy retryPolicy;
        private readonly CloudBlobClient blobStorage;
        private readonly ICloudStorageEntitySerializer dataSerializer;

        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudBlobStorage"/> class using the specified storage account information.
        /// Assumes the default use of <see cref="RetryPolicy.DefaultExponential"/> retry policy and default implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        public ReliableCloudBlobStorage(StorageAccountInfo storageAccountInfo)
            : this(storageAccountInfo, new RetryPolicy<StorageTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudBlobStorage"/> class using the specified storage account information and retry policy.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying blob storage.</param>
        public ReliableCloudBlobStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy)
            : this(storageAccountInfo, retryPolicy, new CloudStorageEntitySerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReliableCloudBlobStorage"/> class using the specified storage account information, custom retry policy
        /// and custom implementation of <see cref="ICloudStorageEntitySerializer"/> interface.
        /// </summary>
        /// <param name="storageAccountInfo">The access credentials for Windows Azure storage account.</param>
        /// <param name="retryPolicy">The custom retry policy that will ensure reliable access to the underlying storage.</param>
        /// <param name="dataSerializer">An instance of the component which performs serialization and deserialization of storage objects.</param>
        public ReliableCloudBlobStorage(StorageAccountInfo storageAccountInfo, RetryPolicy retryPolicy, ICloudStorageEntitySerializer dataSerializer)
        {
            Guard.ArgumentNotNull(storageAccountInfo, "storageAccountInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");
            Guard.ArgumentNotNull(dataSerializer, "dataSerializer");

            this.retryPolicy = retryPolicy;
            this.dataSerializer = dataSerializer;

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey(storageAccountInfo.AccountName, storageAccountInfo.AccountKey), true);
            this.blobStorage = storageAccount.CreateCloudBlobClient();

            // Configure the Blob storage not to enforce any retry policies since this is something that we will be dealing ourselves.
            this.blobStorage.RetryPolicy = RetryPolicies.NoRetry();

            // Disable parallelism in blob upload operations to reduce the impact of multiple concurrent threads on parallel upload feature.
            this.blobStorage.ParallelOperationThreadCount = 1;
        }
        #endregion

        #region ICloudBlobStorage implementation
        /// <summary>
        /// Creates a new blob container using specified name.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be created.</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        public bool CreateContainer(string containerName)
        {
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(containerName);

            try
            {
                var container = this.blobStorage.GetContainerReference(CloudUtility.GetSafeContainerName(containerName));

                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    return container.CreateIfNotExist();
                });
            }
            catch (StorageClientException ex)
            {
                if (ex.ErrorCode == StorageErrorCode.ContainerAlreadyExists || ex.ErrorCode == StorageErrorCode.ResourceAlreadyExists)
                {
                    return false;
                }

                throw;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Deletes the specified blob container.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be deleted.</param>
        /// <returns>True if the container existed and was successfully deleted; otherwise false.</returns>
        public bool DeleteContainer(string containerName)
        {
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(containerName);

            try
            {
                var container = this.blobStorage.GetContainerReference(CloudUtility.GetSafeContainerName(containerName));

                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    container.Delete();
                    return true;
                });
            }
            catch (StorageClientException ex)
            {
                if (ex.ErrorCode == StorageErrorCode.ContainerNotFound || ex.ErrorCode == StorageErrorCode.ResourceNotFound)
                {
                    return false;
                }

                throw;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Puts a blob into the underlying storage, overwrites the existing blob if the blob with the same name already exists.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        public bool Put<T>(string containerName, string blobName, T blob)
        {
            return Put<T>(containerName, blobName, blob, true);
        }

        /// <summary>
        /// Puts a blob into the underlying storage. If the blob with the same name already exists, overwrite behavior can be customized. 
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <param name="overwrite">The flag indicating whether or not overwriting the existing blob is permitted.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        public bool Put<T>(string containerName, string blobName, T blob, bool overwrite)
        {
            string eTag;
            return Put<T>(containerName, blobName, blob, true, null, out eTag);
        }

        /// <summary>
        /// Retrieves a blob by its name from the underlying storage.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name from which the blob will be retrieved.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <returns>An instance of <typeparamref name="T"/> or default(T) if the specified blob was not found.</returns>
        public T Get<T>(string containerName, string blobName)
        {
            return GetBlob<T>(containerName, blobName).Value;
        }

        /// <summary>
        /// Deletes the specified blob.
        /// </summary>
        /// <param name="containerName">The target blob container name from which the blob will be deleted.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <returns>True if the blob was deleted, otherwise false.</returns>
        public bool Delete(string containerName, string blobName)
        {
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");
            Guard.ArgumentNotNullOrEmptyString(blobName, "blobName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(containerName, blobName);

            try
            {
                var container = this.blobStorage.GetContainerReference(CloudUtility.GetSafeContainerName(containerName));
                var cloudBlob = container.GetBlobReference(blobName);

                return this.retryPolicy.ExecuteAction<bool>(() =>
                {
                    return cloudBlob.DeleteIfExists();
                });
            }
            catch (StorageClientException ex)
            {
                // If blob doesn't exist, do not re-throw the exception, simply return a null reference.
                if (!(ex.ErrorCode == StorageErrorCode.ContainerNotFound || ex.ErrorCode == StorageErrorCode.BlobNotFound || ex.ErrorCode == StorageErrorCode.ResourceNotFound))
                {
                    throw;
                }
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }

            return false;
        }

        /// <summary>
        /// Gets the number of blobs in the specified container.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be queried.</param>
        /// <returns>The number of blobs in the container.</returns>
        public int GetCount(string containerName)
        {
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(containerName);
            int blobCount = 0;

            try
            {
                var container = this.blobStorage.GetContainerReference(CloudUtility.GetSafeContainerName(containerName));

                blobCount = this.retryPolicy.ExecuteAction<int>(() =>
                {
                    var blobList = container.ListBlobs(new BlobRequestOptions() { BlobListingDetails = BlobListingDetails.None, RetryPolicy = RetryPolicies.NoRetry(), UseFlatBlobListing = true });
                    return blobList != null ? blobList.Count() : 0;
                });

                return blobCount;
            }
            catch (StorageClientException ex)
            {
                // If blob doesn't exist, do not re-throw the exception, simply return a null reference.
                if (!(ex.ErrorCode == StorageErrorCode.ContainerNotFound || ex.ErrorCode == StorageErrorCode.BlobNotFound || ex.ErrorCode == StorageErrorCode.ResourceNotFound))
                {
                    throw;
                }
                return 0;
            }
            finally
            {
                TraceManager.CloudStorageComponent.TraceOut(callToken, blobCount);
            }
        }

        /// <summary>
        /// Returns a list of all container names found in the storage account.
        /// </summary>
        /// <param name="options">The optional <see cref="ContainerRequestOptions"/> object to use when making a request.</param>
        /// <returns>The list containing container names.</returns>
        public IEnumerable<string> GetContainers(ContainerRequestOptions options = null)
        {
            var callToken = TraceManager.CloudStorageComponent.TraceIn();

            try
            {
                IEnumerable<CloudBlobContainer> blobContainers = this.retryPolicy.ExecuteAction<IEnumerable<CloudBlobContainer>>(() =>
                {
                    if (options != null && (!String.IsNullOrEmpty(options.NamePrefix) || options.ListingDetails != ContainerListingDetails.None))
                    {
                        return this.blobStorage.ListContainers(options.NamePrefix, options.ListingDetails);
                    }
                    else
                    {
                        return this.blobStorage.ListContainers();
                    }
                });

                return (from c in blobContainers select c.Name);
            }
            catch (StorageClientException ex)
            {
                TraceManager.CloudStorageComponent.TraceError(ex);

                // If a storage exception is encountered, do not re-throw the exception, simply return a null reference.
                return null;
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
                throw new ObjectDisposedException(typeof(ReliableCloudBlobStorage).FullName);
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~ReliableCloudBlobStorage()
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
                    // We can safely dispose of .NET resources.
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
        /// <summary>
        /// Puts a blob into the underlying storage and returns its eTag value. 
        /// If the blob with the same name already exists, overwrite behavior can be applied. 
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <param name="overwrite">The flag indicating whether or not overwriting the existing blob is permitted.</param>
        /// <param name="expectedEtag">The parameters holding the blob's expected eTag value.</param>
        /// <param name="actualEtag">The output parameters holding the blob's actual eTag value.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        private bool Put<T>(string containerName, string blobName, T blob, bool overwrite, string expectedEtag, out string actualEtag)
        {
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");
            Guard.ArgumentNotNullOrEmptyString(blobName, "blobName");
            Guard.ArgumentNotNull(blob, "blob");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(containerName, blobName, overwrite, expectedEtag);

            // Verify whether or not the specified blob is already of type Stream.
            Stream blobStream = IsStreamType(blob.GetType()) ? blob as Stream : null;
            Stream blobData = null;
            actualEtag = null;

            try
            {
                // Are we dealing with a stream already? If yes, just use it as is.
                if (blobStream != null)
                {
                    blobData = blobStream;
                }
                else
                {
                    // The specified blob is something else rather than a Stream, we perform serialization of T into a new stream instance.
                    blobData = new MemoryStream();
                    this.dataSerializer.Serialize(blob, blobData);
                }

                var container = this.blobStorage.GetContainerReference(CloudUtility.GetSafeContainerName(containerName));
                StorageErrorCode lastErrorCode = StorageErrorCode.None;

                Func<string> uploadAction = () =>
                {
                    var cloudBlob = container.GetBlobReference(blobName);
                    return UploadBlob(cloudBlob, blobData, overwrite, expectedEtag);
                };

                try
                {
                    // First attempt - perform upload and let the UploadBlob method handle any retry conditions.
                    string eTag = uploadAction();

                    if (!String.IsNullOrEmpty(eTag))
                    {
                        actualEtag = eTag;
                        return true;
                    }
                }
                catch (StorageClientException ex)
                {
                    lastErrorCode = ex.ErrorCode;

                    if (!(lastErrorCode == StorageErrorCode.ContainerNotFound || lastErrorCode == StorageErrorCode.ResourceNotFound || lastErrorCode == StorageErrorCode.BlobAlreadyExists))
                    {
                        // Anything other than "not found" or "already exists" conditions will be considered as a runtime error.
                        throw;
                    }
                }

                if (lastErrorCode == StorageErrorCode.ContainerNotFound)
                {
                    // Failover action #1: create the target container and try again. This time, use a retry policy to wrap calls to the UploadBlob method.
                    string eTag = this.retryPolicy.ExecuteAction<string>(() =>
                    {
                        CreateContainer(containerName);
                        return uploadAction();
                    });

                    return !String.IsNullOrEmpty(actualEtag = eTag);
                }

                if (lastErrorCode == StorageErrorCode.BlobAlreadyExists && overwrite)
                {
                    // Failover action #2: Overwrite was requested but BlobAlreadyExists has still been returned. Delete the original blob and try to upload again.
                    string eTag = this.retryPolicy.ExecuteAction<string>(() =>
                    {
                        var cloudBlob = container.GetBlobReference(blobName);
                        cloudBlob.DeleteIfExists();

                        return uploadAction();
                    });

                    return !String.IsNullOrEmpty(actualEtag = eTag);
                }
            }
            finally
            {
                // Only dispose the blob data stream if it was newly created.
                if (blobData != null && null == blobStream)
                {
                    blobData.Dispose();
                }

                TraceManager.CloudStorageComponent.TraceOut(callToken, actualEtag);
            }

            return false;
        }

        private string UploadBlob(CloudBlob blob, Stream data, bool overwrite)
        {
            return UploadBlob(blob, data, overwrite, null);
        }
        
        private string UploadBlob(CloudBlob blob, Stream data, bool overwrite, string eTag)
        {
            BlobRequestOptions options;

            if (overwrite)
            {
                options = String.IsNullOrEmpty(eTag) ? new BlobRequestOptions { AccessCondition = AccessCondition.None } : new BlobRequestOptions { AccessCondition = AccessCondition.IfMatch(eTag) };
            }
            else
            {
                options = new BlobRequestOptions { AccessCondition = AccessCondition.IfNotModifiedSince(DateTime.MinValue) };
            }

            try
            {
                if (data.CanSeek)
                {
                    this.retryPolicy.ExecuteAction(() =>
                    {
                        data.Seek(0, SeekOrigin.Begin);
                        blob.UploadFromStream(data, options);
                    });
                }
                else
                {
                    // Stream is not seekable, cannot use retry logic as data consistency cannot be guaranteed.
                    blob.UploadFromStream(data, options);
                }

                return blob.Properties.ETag;
            }
            catch (StorageClientException ex)
            {
                if (ex.ErrorCode != StorageErrorCode.ConditionFailed)
                {
                    throw;
                }
            }

            return null;
        }

        private KeyValuePair<BlobProperties, T> GetBlob<T>(string containerName, string blobName)
        {
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");
            Guard.ArgumentNotNullOrEmptyString(blobName, "blobName");

            var callToken = TraceManager.CloudStorageComponent.TraceIn(containerName, blobName);
            
            MemoryStream blobData = null;
            object blobObject = null;
            bool isBlobAsStream = IsStreamType(typeof(T));

            try
            {
                var container = this.blobStorage.GetContainerReference(CloudUtility.GetSafeContainerName(containerName));
                var cloudBlob = container.GetBlobReference(blobName);

                blobData = new MemoryStream();

                this.retryPolicy.ExecuteAction(() =>
                {
                    blobData.Seek(0, SeekOrigin.Begin);
                    cloudBlob.DownloadToStream(blobData);
                });

                blobData.Seek(0, SeekOrigin.Begin);

                // If blob type is a stream, just return the memory stream.
                if (isBlobAsStream)
                {
                    blobObject = blobData;
                }
                else
                {
                    // Otherwise, deserialize the underlying object from the blob data.
                    blobObject = this.dataSerializer.Deserialize(blobData, typeof(T));
                }

                return new KeyValuePair<BlobProperties, T>(cloudBlob.Properties, (T)blobObject);
            }
            catch (StorageClientException ex)
            {
                // If blob doesn't exist, do not re-throw the exception, simply return a null reference.
                if (!(ex.ErrorCode == StorageErrorCode.ContainerNotFound || ex.ErrorCode == StorageErrorCode.BlobNotFound || ex.ErrorCode == StorageErrorCode.ResourceNotFound))
                {
                    throw;
                }
            }
            finally
            {
                // Should dispose the working stream unless it must be returned to the caller.
                if (blobData != null && !isBlobAsStream)
                {
                    blobData.Dispose();
                }

                TraceManager.CloudStorageComponent.TraceOut(callToken);
            }

            // Always return a non-null name/value pair, however do return a null reference to both the blob and its properties.
            return new KeyValuePair<BlobProperties, T>();
        }

        private bool IsStreamType(Type blobType)
        {
            return blobType != null & (blobType == typeof(Stream) || typeof(Stream).IsAssignableFrom(blobType));
        }
        #endregion
    }
}
