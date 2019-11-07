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
    using System.Linq;
    using System.Xml;
    using System.Xml.Xsl;
    using System.Xml.Linq;
    using System.ServiceModel;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Extensions;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Azure.Services.ScalableTransform.Properties;
    #endregion

    #region IXslTransformProviderExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for providing XSLT-based
    /// transformation objects to their consumers.
    /// </summary>
    public interface IXslTransformProviderExtension : ICloudServiceComponentExtension
    {
        /// <summary>
        /// Returns an object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation object.</param>
        /// <returns>An instance of the object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments, or null if the specified transform was not found.</returns>
        XslTransformSet GetXslTransform(string transformName);
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for providing XSLT-based transformation objects to their consumers.
    /// </summary>
    public class XslTransformProviderExtension : IXslTransformProviderExtension
    {
        #region Private members
        private IExtensibleCloudServiceComponent owner;
        private IXslTransformMetadataProviderExtension metadataProvider;
        #endregion

        #region IXslTransformProviderExtension implementation
        /// <summary>
        /// Returns an object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments.
        /// </summary>
        /// <param name="transformName">Either partial or fully qualified name of the transformation object.</param>
        /// <returns>An instance of the object carrying the XSLT transformation metadata, XSLT transformation engine and its arguments, or null if the specified transform was not found.</returns>
        public XslTransformSet GetXslTransform(string transformName)
        {
            var callToken = TraceManager.WorkerRoleComponent.TraceIn(transformName);

            try
            {
                ICollection<IXslTransformCacheExtension> transformCacheCollection = this.owner.Extensions.FindAll<IXslTransformCacheExtension>();
                XslTransformSet transformSet = null;

                // If cache is enabled, try to get from the cache first.
                if(transformCacheCollection != null)
                {
                    // Find a cached transform instance in all registered cache extensions, break at the first match.
                    foreach (var transformCache in transformCacheCollection)
                    {
                        if ((transformSet = transformCache.Get(transformName)) != null) break;
                    }
                }

                // Reason 1: cache miss or no caching functionality is provided via extensions.
                // Reason 2: transform set doesn't have the XSLT transform engine instance.
                // Reason 3: XSLT transform engine in the transform set doesn't have a loaded template.
                if (null == transformSet || null == transformSet.Transform || null == transformSet.Transform.OutputSettings)
                {
                    // Try to re-use the transform metadata (if available), otherwise 
                    XslTransformMetadata metadata = transformSet != null && transformSet.Metadata != null ? transformSet.Metadata : this.metadataProvider.GetXslTransformMetadata(transformName);

                    if(metadata != null)
                    {
                        XslCompiledTransform transform = new XslCompiledTransform();
                        XsltArgumentList arguments = new XsltArgumentList();
                        XsltSettings xsltSettings = new XsltSettings() { EnableDocumentFunction = true, EnableScript = true };
                        XmlReaderSettings readerSettings = new XmlReaderSettings() { CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };

                        // Read the XSLT template from the metadata and load it into XSLT transformation engine.
                        using(StringReader rawDataReader = new StringReader(metadata.XsltContentRaw))
                        using(XmlReader xsltReader = XmlReader.Create(rawDataReader, readerSettings))
                        {
                            transform.Load(xsltReader, xsltSettings, null);
                        }

                        // Check if XSLT arguments are provided.
                        if (!String.IsNullOrEmpty(metadata.XsltArgumentsRaw))
                        {
                            // Read the XSLT argument list from the metadata and load it into a XsltArgumentList collection.
                            using(StringReader argDataReader = new StringReader(metadata.XsltArgumentsRaw))
                            using(XmlReader argContentReader = XmlReader.Create(argDataReader, readerSettings))
                            {
                                XDocument xsltArgs = XDocument.Load(argContentReader);

                                var extObjects = (from x in xsltArgs.Root.Descendants()
                                                  select new
                                                  {
                                                      Namespace = x.Attribute(Resources.ExtensionObjectNamespaceAttributeName).Value,
                                                      AssemblyName = x.Attribute(Resources.ExtensionObjectAssemblyAttributeName).Value,
                                                      ClassName = x.Attribute(Resources.ExtensionObjectClassAttributeName).Value
                                                  });

                                foreach (var extObjectInfo in extObjects)
                                {
                                    Type extObjectType = Type.GetType(String.Concat(extObjectInfo.ClassName, ", ", extObjectInfo.AssemblyName), false);
                                    object extObject = null;

                                    if (extObjectType != null && (extObject = Activator.CreateInstance(extObjectType)) != null)
                                    {
                                        arguments.AddExtensionObject(extObjectInfo.Namespace, extObject);
                                    }
                                }
                            }
                        }

                        transformSet = new XslTransformSet(metadata, transform, arguments);

                        // If cache is enabled, place the transform instance and its metadata to the cache.
                        if (transformCacheCollection != null)
                        {
                            foreach (var transformCache in transformCacheCollection)
                            {
                                transformCache.Put(transformName, transformSet);
                            }
                        }
                    }
                }
                
                return transformSet;
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
            this.owner = owner;
            this.owner.Extensions.Demand<IXslTransformMetadataProviderExtension>();
            this.metadataProvider = owner.Extensions.Find<IXslTransformMetadataProviderExtension>();
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