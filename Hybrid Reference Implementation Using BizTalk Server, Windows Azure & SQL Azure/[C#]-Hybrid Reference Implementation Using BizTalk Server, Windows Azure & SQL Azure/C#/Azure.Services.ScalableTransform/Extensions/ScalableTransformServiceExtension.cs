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
    using System.ServiceModel;
    using System.Globalization;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Properties;
    #endregion

    #region IScalableTransformServiceExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension that supports all Scalable Transformation service operations.
    /// </summary>
    public interface IScalableTransformServiceExtension : ICloudServiceComponentExtension, IScalableTransformationServiceContract
    {
    }
    #endregion

    /// <summary>
    /// Implements the extension that supports the Scalable Transformation service operations.
    /// </summary>
    public class ScalableTransformServiceExtension : IScalableTransformServiceExtension
    {
        #region Private methods
        private ICloudStorageProviderExtension cloudStorageProvider;
        private ICloudStorageLoadBalancingExtension cloudStorageLoadBalancer;
        private IXslTransformProviderExtension transformProvider;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            owner.Extensions.Demand<ICloudStorageProviderExtension>();
            owner.Extensions.Demand<ICloudStorageLoadBalancingExtension>();
            owner.Extensions.Demand<IXslTransformProviderExtension>();

            this.cloudStorageProvider = owner.Extensions.Find<ICloudStorageProviderExtension>();
            this.cloudStorageLoadBalancer = owner.Extensions.Find<ICloudStorageLoadBalancingExtension>();
            this.transformProvider = owner.Extensions.Find<IXslTransformProviderExtension>();
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
        }
        #endregion

        #region IScalableTransformationServiceContract implementation
        /// <summary>
        /// Prepares the specified source document for transformation.
        /// </summary>
        /// <param name="data">The stream of data containing the source document that needs to be transformed.</param>
        /// <returns>An instance of the object used by the Scalable Transformation Service to track state transitions when performing transformations.</returns>
        public XslTransformState PrepareTransform(Stream data)
        {
            try
            {
                return PersistInputDocument(data);
            }
            catch (Exception ex)
            {
                throw new CloudApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.PrepareTransformOperationFailed, ex.Message), ex);
            }
        }

        /// <summary>
        /// Applies the specified transformation map name against the source document described by the given transformation state object.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation map.</param>
        /// <param name="state">An instance of the state object carrying the information related to the source document that will be transformed.</param>
        /// <returns>An instance of the object used by the Scalable Transformation Service to track state transitions when performing transformations.</returns>
        public XslTransformState ApplyTransform(string transformName, XslTransformState state)
        {
            try
            {
                Guard.ArgumentNotNullOrEmptyString(transformName, "transformName");
                Guard.ArgumentNotNull(state, "state");
                Guard.ArgumentNotNullOrEmptyString(state.StorageAccount, "state.StorageAccount");
                Guard.ArgumentNotNullOrEmptyString(state.ContainerName, "state.ContainerName");
                Guard.ArgumentNotNullOrEmptyString(state.InputDocumentRef, "state.InputDocumentRef");

                XslTransformSet transformSet = this.transformProvider.GetXslTransform(transformName);

                if (transformSet != null)
                {
                    using (ICloudBlobStorage blobStorage = this.cloudStorageProvider.GetBlobStorage(state.StorageAccount))
                    using (Stream blobData = blobStorage.Get<Stream>(state.ContainerName, state.InputDocumentRef))
                    {
                        if (blobData != null)
                        {
                            using (MemoryStream outputDoc = new MemoryStream())
                            using (XmlReader inputDocReader = XmlReader.Create(blobData))
                            {
                                transformSet.Transform.Transform(inputDocReader, transformSet.Arguments, outputDoc);

                                outputDoc.Seek(0, SeekOrigin.Begin);

                                XslTransformState newState = PersistInputDocument(outputDoc);
                                return new XslTransformState(newState, state);
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ApplyTransformOperationFailureInputDocNotFound, state.StorageAccount, state.ContainerName, state.InputDocumentRef));
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ApplyTransformOperationFailureTransformNotFound, transformName));
                }
            }
            catch (Exception ex)
            {
                throw new CloudApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ApplyTransformOperationFailed, ex.Message), ex);
            }
        }

        /// <summary>
        /// Retrieves the transformed version of the source document described by the given transformation state object.
        /// </summary>
        /// <param name="state">An instance of the state object carrying the information related to the source document that will be transformed.</param>
        /// <returns>The stream of data containing the results from transformation.</returns>
        public Stream CompleteTransform(XslTransformState state)
        {
            try
            {
                Guard.ArgumentNotNull(state, "state");
                Guard.ArgumentNotNullOrEmptyString(state.StorageAccount, "state.StorageAccount");
                Guard.ArgumentNotNullOrEmptyString(state.ContainerName, "state.ContainerName");
                Guard.ArgumentNotNullOrEmptyString(state.InputDocumentRef, "state.InputDocumentRef");

                Stream blobData = null;

                using (ICloudBlobStorage blobStorage = this.cloudStorageProvider.GetBlobStorage(state.StorageAccount))
                {
                    blobData = blobStorage.Get<Stream>(state.ContainerName, state.InputDocumentRef);
                }

                foreach (var knownState in state.GetTransitions())
                {
                    try
                    {
                        using (ICloudBlobStorage blobStorage = this.cloudStorageProvider.GetBlobStorage(knownState.StorageAccount))
                        {
                            blobStorage.Delete(knownState.ContainerName, knownState.InputDocumentRef);
                        }
                    }
                    catch (Exception ex)
                    {
                        // We must ensure that all blobs are deleted. An exception should not cause a stop condition.
                        TraceManager.TransformComponent.TraceError(ex);
                    }
                }

                if(null == blobData)
                {
                    throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.CompleteTransformFailureFinalDocNotFound, state.StorageAccount, state.ContainerName, state.InputDocumentRef));
                }

                return blobData;
            }
            catch (Exception ex)
            {
                throw new CloudApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.CompleteTransformOperationFailed, ex.Message), ex);
            }
        }
        #endregion

        #region Private methods
        private XslTransformState PersistInputDocument(Stream data)
        {
            CloudBlobLocation location = this.cloudStorageLoadBalancer.FindBlobLocation();

            if (!CloudBlobLocation.IsUnknown(location))
            {
                using (ICloudBlobStorage blobStorage = this.cloudStorageLoadBalancer.GetBlobStorage(location))
                {
                    string blobName = Guid.NewGuid().ToString("N");

                    if (blobStorage.Put<Stream>(location.ContainerName, blobName, data, true))
                    {
                        return new XslTransformState(location.StorageAccount, location.ContainerName, blobName);
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.PrepareTransformOperationFailureStreamPersistence);
                    }
                }
            }
            else
            {
                // TODO: Auto-create missing blob container.
                throw new InvalidOperationException(ExceptionMessages.FindBlobLocationFailed);
            }
        }
        #endregion
    }
}
