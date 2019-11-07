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
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Defines a generics-aware abstraction layer for Windows Azure Blob storage.
    /// </summary>
    public interface ICloudBlobStorage : IDisposable
    {
        /// <summary>
        /// Creates a new blob container using specified name.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be created.</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        bool CreateContainer(string containerName);

        /// <summary>
        /// Deletes the specified blob container.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be deleted.</param>
        /// <returns>True if the container existed and was successfully deleted; otherwise false.</returns>
        bool DeleteContainer(string containerName);

        /// <summary>
        /// Puts a blob into the underlying storage, overwrites if the blob with the same name already exists.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        bool Put<T>(string containerName, string blobName, T blob);

        /// <summary>
        /// Puts a blob into the underlying storage. If the blob with the same name already exists, overwrite behavior can be applied. 
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name into which a blob will be stored.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <param name="blob">The blob's payload.</param>
        /// <param name="overwrite">The flag indicating whether or not overwriting the existing blob is permitted.</param>
        /// <returns>True if the blob was successfully put into the specified container, otherwise false.</returns>
        bool Put<T>(string containerName, string blobName, T blob, bool overwrite);

        /// <summary>
        /// Retrieves a blob by its name from the underlying storage.
        /// </summary>
        /// <typeparam name="T">The type of the payload associated with the blob.</typeparam>
        /// <param name="containerName">The target blob container name from which the blob will be retrieved.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <returns>An instance of <typeparamref name="T"/> or default(T) if the specified blob was not found.</returns>
        T Get<T>(string containerName, string blobName);

        /// <summary>
        /// Deletes the specified blob.
        /// </summary>
        /// <param name="containerName">The target blob container name from which the blob will be deleted.</param>
        /// <param name="blobName">The custom name associated with the blob.</param>
        /// <returns>True if the blob was deleted, otherwise false.</returns>
        bool Delete(string containerName, string blobName);

        /// <summary>
        /// Gets the number of blobs in the specified container.
        /// </summary>
        /// <param name="containerName">The name of the blob container to be queried.</param>
        /// <returns>The number of blobs in the container.</returns>
        int GetCount(string containerName);

        /// <summary>
        /// Returns a list of all container names found in the storage account.
        /// </summary>
        /// <param name="options">The optional <see cref="ContainerRequestOptions"/> object to use when making a request.</param>
        /// <returns>The list containing container names.</returns>
        IEnumerable<string> GetContainers(ContainerRequestOptions options = null);
    }
}
