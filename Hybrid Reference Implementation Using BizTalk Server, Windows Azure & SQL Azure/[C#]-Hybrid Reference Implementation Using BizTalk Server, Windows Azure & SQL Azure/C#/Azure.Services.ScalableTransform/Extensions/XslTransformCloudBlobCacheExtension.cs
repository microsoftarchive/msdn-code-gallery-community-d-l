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
namespace Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Extensions
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;
    using System.Xml.Linq;
    using System.ServiceModel;
    using System.Collections.Concurrent;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Internal;
    #endregion

    /// <summary>
    /// Implements the extension responsible for caching XSLT-based transform objects in the Windows Azure blob storage.
    /// </summary>
    public class XslTransformCloudBlobCacheExtension : IXslTransformCacheExtension
    {
        #region Private members
        private const string DefaultContainerName = "XslTransformCloudBlobCache";

        private readonly StorageAccountInfo storageAccount;
        private ICloudStorageProviderExtension cloudStorageProvider;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="XslTransformCloudBlobCacheExtension"/> object using the specified storage account.
        /// The storage account will provide a dedicated blob storage container which will be used as a cache.
        /// </summary>
        /// <param name="storageAccount">The name of the storage account on which the caching blob storage container will be located.</param>
        public XslTransformCloudBlobCacheExtension(StorageAccountInfo storageAccount)
        {
            Guard.ArgumentNotNull(storageAccount, "storageAccount");
            Guard.ArgumentNotNullOrEmptyString(storageAccount.AccountName, "storageAccount.AccountName");

            this.storageAccount = storageAccount;
            this.ContainerName = DefaultContainerName;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the blob storage container that will be used as a cache.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets the time value indicating how long transform objects will be kept inside the cache.
        /// </summary>
        public TimeSpan CacheTimeToLive { get; set; }
        #endregion

        #region IXslTransformCacheExtension implementation
        /// <summary>
        /// Looks up for a transform object in the cache and returns its metadata if the specified transform was found.
        /// </summary>
        /// <param name="transformName">The unique name of the transform object that is being used as a cache key.</param>
        /// <returns>An instance of the object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments, or null if the specified transform was not found.</returns>
        public XslTransformSet Get(string transformName)
        {
            Guard.ArgumentNotNullOrEmptyString(transformName, "transformName");
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(transformName);

            try
            {
                XslTransformSet transformSet = null;

                using (ICloudBlobStorage blobStorage = this.cloudStorageProvider.GetBlobStorage(this.storageAccount.AccountName))
                {
                    XslTransformCacheItemInfo cacheItemInfo = blobStorage.Get<XslTransformCacheItemInfo>(ContainerName, transformName);

                    if (cacheItemInfo != null && !cacheItemInfo.IsExpired)
                    {
                        transformSet = cacheItemInfo.TransformSet;
                    }
                }

                return transformSet;
            }
            catch (Exception ex)
            {
                TraceManager.WorkerRoleComponent.TraceError(ex);
                return null;
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }

        /// <summary>
        /// Puts the specified transform object and its metadata into the underlying cache.
        /// </summary>
        /// <param name="transformName">The unique name of the transform object that will be used as a cache key.</param>
        /// <param name="transformSet">The object carrying the XSLT transformation metadata, XSLT transformation object and its arguments.</param>
        public void Put(string transformName, XslTransformSet transformSet)
        {
            Guard.ArgumentNotNullOrEmptyString(transformName, "transformName");
            Guard.ArgumentNotNull(transformSet, "transformSet");

            var callToken = TraceManager.WorkerRoleComponent.TraceIn(transformName);

            try
            {
                using (ICloudBlobStorage blobStorage = this.cloudStorageProvider.GetBlobStorage(this.storageAccount.AccountName))
                {
                    XslTransformCacheItemInfo cacheItemInfo = new XslTransformCacheItemInfo(transformSet, CacheTimeToLive);

                    blobStorage.CreateContainer(ContainerName);
                    blobStorage.Put<XslTransformCacheItemInfo>(ContainerName, transformName, cacheItemInfo);
                }
            }
            finally
            {
                TraceManager.WorkerRoleComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<CloudStorageProviderExtension>();
            this.cloudStorageProvider = owner.Extensions.Find<ICloudStorageProviderExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion
    }
}