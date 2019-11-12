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
    #endregion

    /// <summary>
    /// Represents a location of a blob in the Azure storage infrastructure.
    /// </summary>
    public class CloudBlobLocation
    {
        #region Public properties
        /// <summary>
        /// Represents an unknown, non-discoverable location.
        /// </summary>
        public readonly static CloudBlobLocation Unknown = new CloudBlobLocation();

        /// <summary>
        /// The name of the storage account on which the blob is located.
        /// </summary>
        public string StorageAccount { get; private set; }

        /// <summary>
        /// The name of the container in which the blob is located.
        /// </summary>
        public string ContainerName { get; private set; }

        /// <summary>
        /// The name of the blob.
        /// </summary>
        public string BlobName { get; private set; }

        /// <summary>
        /// The optional eTag of the blob.
        /// </summary>
        public string ETag { get; private set; }

        /// <summary>
        /// Indicates whether or not the blob location is discoverable.
        /// </summary>
        public bool IsDiscoverable
        {
            get { return !String.IsNullOrEmpty(StorageAccount) && !String.IsNullOrEmpty(ContainerName) && !String.IsNullOrEmpty(BlobName); }
        } 
        #endregion

        #region Constructors
        private CloudBlobLocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref=" CloudBlobLocation"/> object using the specified location settings.
        /// </summary>
        /// <param name="storageAccount">The name of the storage account on which the blob is located.</param>
        /// <param name="containerName">The name of the container in which the blob is located.</param>
        /// <param name="blobName">The name of the blob.</param>
        public CloudBlobLocation(string storageAccount, string containerName, string blobName)
        {
            StorageAccount = storageAccount;
            BlobName = blobName;
            ContainerName = containerName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref=" CloudBlobLocation"/> object using the specified location settings.
        /// </summary>
        /// <param name="storageAccount">The name of the storage account on which the blob is located.</param>
        /// <param name="containerName">The name of the container in which the blob is located.</param>
        /// <param name="blobName">The name of the blob.</param>
        /// <param name="eTag">The known eTag of the blob.</param>
        public CloudBlobLocation(string storageAccount, string containerName, string blobName, string eTag)
            : this(storageAccount, containerName, blobName)
        {
            ETag = eTag;
        } 
        #endregion

        #region Public methods
        /// <summary>
        /// Determines whether or not the specified location is null or is considered as unknown.
        /// This method does not check if the blob is actually present in the given location.
        /// </summary>
        /// <param name="location">The location to be validated.</param>
        /// <returns>A flag indicating whether or not the specified location is null or is considered as unknown</returns>
        public static bool IsUnknown(CloudBlobLocation location)
        {
            return !(location != null && location != Unknown);
        }
        #endregion
    }
}
