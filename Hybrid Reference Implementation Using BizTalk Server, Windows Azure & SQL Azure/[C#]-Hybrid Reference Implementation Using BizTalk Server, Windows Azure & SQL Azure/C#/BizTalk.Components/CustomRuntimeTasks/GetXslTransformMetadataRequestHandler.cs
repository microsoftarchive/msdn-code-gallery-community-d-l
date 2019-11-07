//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains the implementations of custom BizTalk pipeline components
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Components.CustomRuntimeTasks
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Configuration;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Reflection;

    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.XLANGs.BaseTypes;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core;
    using Contoso.Cloud.Integration.BizTalk.Components.Properties;
    using Contoso.Cloud.Integration.BizTalk.Maps;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;

    using BtsTransformMetadata = Microsoft.XLANGs.RuntimeTypes.TransformMetaData;
    #endregion

    /// <summary>
    /// Implements a custom runtime task responsible for handling requests to retrieve a specific BizTalk map.
    /// </summary>
    public class GetXslTransformMetadataRequestHandler : IComponent
    {
        #region Private members
        private static readonly string DefaultMapNamespace = typeof(MetaMap).Namespace;
        private static readonly string DefaultMapTypeFullName = typeof(MetaMap).FullName;
        private static readonly string DefaultMapAssemblyQualifiedName = typeof(MetaMap).AssemblyQualifiedName;
        #endregion

        #region IComponent implementation
        /// <summary>
        /// Executes the custom runtime task component to process the input message and returns the result message.
        /// </summary>
        /// <param name="pContext">A reference to <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object that contains the current pipeline context.</param>
        /// <param name="pInMsg">A reference to <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object that contains the message to process.</param>
        /// <returns>A reference to the returned <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object which will contain the output message.</returns>
        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            Guard.ArgumentNotNull(pContext, "pContext");
            Guard.ArgumentNotNull(pInMsg, "pInMsg");

            var callToken = TraceManager.PipelineComponent.TraceIn();

            // It is OK to load the entire message into XML DOM. The size of these requests is anticipated to be very small.
            XDocument request = XDocument.Load(pInMsg.BodyPart.GetOriginalDataStream());

            string transformName = (from childNode in request.Root.Descendants() where childNode.Name.LocalName == WellKnownContractMember.MessageParameters.TransformName select childNode.Value).FirstOrDefault<string>();

            TraceManager.PipelineComponent.TraceInfo(TraceLogMessages.GetXslTransformRequest, transformName);

            IBaseMessagePart responsePart = BizTalkUtility.CreateResponsePart(pContext.GetMessageFactory(), pInMsg);
            XmlWriterSettings settings = new XmlWriterSettings();

            MemoryStream dataStream = new MemoryStream();
            pContext.ResourceTracker.AddResource(dataStream);

            settings.CloseOutput = false;
            settings.CheckCharacters = false;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;

            using (XmlWriter responseWriter = XmlWriter.Create(dataStream, settings))
            {
                responseWriter.WriteResponseStartElement("r", WellKnownContractMember.MethodNames.GetXslTransformMetadata, WellKnownNamespace.ServiceContracts.General);

                try
                {
                    Type transformType = ResolveTransformType(transformName);

                    if (transformType != null)
                    {
                        // Get the actual map from the BizTalk metadata cache.
                        BtsTransformMetadata btsTransform = BtsTransformMetadata.For(transformType);

                        if (btsTransform != null)
                        {
                            // Map existence confirmed, now it's safe to instantiate the transform type.
                            TransformBase transform = Activator.CreateInstance(transformType) as TransformBase;

                            // Is this really a valid map that implements TransformBase?
                            if (transform != null)
                            {
                                XslTransformMetadata transformMetadata = new XslTransformMetadata(transform.XmlContent, transform.XsltArgumentListContent, transform.SourceSchemas, transform.TargetSchemas);

                                DataContractSerializer dcSerializer = new DataContractSerializer(typeof(XslTransformMetadata), String.Concat(WellKnownContractMember.MethodNames.GetXslTransformMetadata, WellKnownContractMember.ResultMethodSuffix), WellKnownNamespace.ServiceContracts.General);
                                dcSerializer.WriteObject(responseWriter, transformMetadata);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log but do not pass the exception to the caller.
                    TraceManager.PipelineComponent.TraceError(ex);
                }

                responseWriter.WriteEndElement();
                responseWriter.Flush();
            }

            dataStream.Seek(0, SeekOrigin.Begin);
            responsePart.Data = dataStream;

            TraceManager.PipelineComponent.TraceOut(callToken);
            return pInMsg;
        }
        #endregion

        #region Private methods
        private Type ResolveTransformType(string transformName)
        {
            Guard.ArgumentNotNullOrEmptyString(transformName, "transformName");

            // Assume we have a fully qualified .NET type name.
            Type transformType = Type.GetType(transformName, false);
            if (transformType != null) return transformType;

            // Not a fully qualified type name, assume we have a type name with namespace, try to append the assembly name.
            string typeName = DefaultMapAssemblyQualifiedName.Replace(DefaultMapTypeFullName, transformName);
            transformType = Type.GetType(typeName, false);
            if (transformType != null) return transformType;

            // Still not found, assume we have just a type name, append both the namespace and assembly name.
            typeName = DefaultMapAssemblyQualifiedName.Replace(DefaultMapTypeFullName, String.Concat(DefaultMapNamespace, ".", transformName));
            transformType = Type.GetType(typeName, false);
            if (transformType != null) return transformType;

            // Perhaps need to perform some other form of type resolution.
            return null;
        }
        #endregion
    }
}
