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
    using System.Reflection;

    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core;
    using Contoso.Cloud.Integration.BizTalk.Components.Properties;
    #endregion

    /// <summary>
    /// Implements a custom runtime task responsible for handling requests to retrieve a specific configuration section from the application configuration.
    /// </summary>
    public class GetConfigurationSectionRequestHandler : IComponent
    {
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

            string sectionName = (from childNode in request.Root.Descendants() where childNode.Name.LocalName == WellKnownContractMember.MessageParameters.SectionName select childNode.Value).FirstOrDefault<string>();
            string applicationName = (from childNode in request.Root.Descendants() where childNode.Name.LocalName == WellKnownContractMember.MessageParameters.ApplicationName select childNode.Value).FirstOrDefault<string>();
            string machineName = (from childNode in request.Root.Descendants() where childNode.Name.LocalName == WellKnownContractMember.MessageParameters.MachineName select childNode.Value).FirstOrDefault<string>();

            TraceManager.PipelineComponent.TraceInfo(TraceLogMessages.GetConfigSectionRequest, sectionName, applicationName, machineName);

            IConfigurationSource configSource = ApplicationConfiguration.Current.Source;
            IApplicationConfigurationSource appConfigSource = configSource as IApplicationConfigurationSource;
            ConfigurationSection configSection = appConfigSource != null ? appConfigSource.GetSection(sectionName, applicationName, machineName) : configSource.GetSection(sectionName);

            if (configSection != null)
            {
                IBaseMessagePart responsePart = BizTalkUtility.CreateResponsePart(pContext.GetMessageFactory(), pInMsg);
                XmlWriterSettings settings = new XmlWriterSettings();

                MemoryStream dataStream = new MemoryStream();
                pContext.ResourceTracker.AddResource(dataStream);

                settings.CloseOutput = false;
                settings.CheckCharacters = false;
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;

                using (XmlWriter configDataWriter = XmlWriter.Create(dataStream, settings))
                {
                    configDataWriter.WriteResponseStartElement("r", WellKnownContractMember.MethodNames.GetConfigurationSection, WellKnownNamespace.ServiceContracts.General);
                    configDataWriter.WriteResultStartElement("r", WellKnownContractMember.MethodNames.GetConfigurationSection, WellKnownNamespace.ServiceContracts.General);

                    SerializableConfigurationSection serializableSection = configSection as SerializableConfigurationSection;

                    if (serializableSection != null)
                    {
                        serializableSection.WriteXml(configDataWriter);
                    }
                    else
                    {
                        MethodInfo info = configSection.GetType().GetMethod(WellKnownContractMember.MethodNames.SerializeSection, BindingFlags.NonPublic | BindingFlags.Instance);
                        string serialized = (string)info.Invoke(configSection, new object[] { configSection, sectionName, ConfigurationSaveMode.Full });

                        configDataWriter.WriteRaw(serialized);
                    }

                    configDataWriter.WriteEndElement();
                    configDataWriter.WriteEndElement();
                    configDataWriter.Flush();
                }

                dataStream.Seek(0, SeekOrigin.Begin);
                responsePart.Data = dataStream;
            }
            else
            {
                throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ConfigurationSectionNotFound, sectionName, ApplicationConfiguration.Current.Source.GetType().FullName));
            }

            TraceManager.PipelineComponent.TraceOut(callToken);
            return pInMsg;
        }
        #endregion
    }
}
