//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains core classes used by all BizTalk components and projects
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Threading;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.Serialization;

    using Microsoft.RuleEngine;
    using Microsoft.BizTalk.Message.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.BizTalk.Core.RulesEngine;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for executing a Business Rules Engine policy.
    /// </summary>
    public class ExecuteRulesEnginePolicyTask : MessagingRuntimeExtenderTaskBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecuteRulesEnginePolicyTask"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public ExecuteRulesEnginePolicyTask(IMessagingRuntimeExtension owner) : base(owner)
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the BRE policy which will be invoked.
        /// </summary>
        public string PolicyName  { get; set;  }

        /// <summary>
        /// Gets or sets the version of the BRE policy which will be invoked.
        /// </summary>
        public Version PolicyVersion { get; set; }
        #endregion

        #region IMessagingRuntimeExtenderTask implementation
        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public override void Run(RuntimeTaskExecutionContext context)
        {
            Guard.ArgumentNotNull(context, "context");
            Guard.ArgumentNotNull(context.Message, "context.Message");

            var callToken = TraceManager.PipelineComponent.TraceIn();

            Stream messageDataStream = null;
            IEnumerable<object> facts = null;
            string policyName = PolicyName, ctxPropName = null, ctxPropNamespace = null;
            Version policyVersion = PolicyVersion;
            RulesEngineRequest request = null;
            bool responseRequired = true;

            try
            {
                XmlReaderSettings readerSettings = new XmlReaderSettings() { CloseInput = false, CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };

                if (context.Message.BodyPart != null)
                {
                    messageDataStream = BizTalkUtility.EnsureSeekableStream(context.Message, context.PipelineContext);

                    if (messageDataStream != null)
                    {
                        using (XmlReader messageDataReader = XmlReader.Create(messageDataStream, readerSettings))
                        {
                            // Navigate through the XML reader until we find an element with the expected name and namespace.
                            while (!messageDataReader.EOF && messageDataReader.Name != WellKnownContractMember.MessageParameters.Request && messageDataReader.NamespaceURI != WellKnownNamespace.DataContracts.General) messageDataReader.Read();

                            // Element was found, let's perform de-serialization from XML into a RulesEngineRequest object.
                            if (!messageDataReader.EOF)
                            {
                                DataContractSerializer serializer = new DataContractSerializer(typeof(RulesEngineRequest));
                                request = serializer.ReadObject(messageDataReader, false) as RulesEngineRequest;

                                if (request != null)
                                {
                                    policyName = request.PolicyName;
                                    policyVersion = request.PolicyVersion;
                                    facts = request.Facts;
                                }
                            }
                        }
                    }
                }

                // Check if the policy name was supplied when this component was instantiated or retrieved from a request message.
                if (!String.IsNullOrEmpty(policyName))
                {
                    // If policy version is not specified, use the latest deployed version.
                    PolicyExecutionInfo policyExecInfo = policyVersion != null ? new PolicyExecutionInfo(policyName, policyVersion) : new PolicyExecutionInfo(policyName);

                    // Use all context properties as parameters when invoking a policy.
                    for (int i = 0; i < context.Message.Context.CountProperties; i++)
                    {
                        ctxPropName = null;
                        ctxPropNamespace = null;

                        object ctxPropValue = context.Message.Context.ReadAt(i, out ctxPropName, out ctxPropNamespace);
                        policyExecInfo.AddParameter(String.Format("{0}#{1}", ctxPropNamespace, ctxPropName), ctxPropValue);
                    }

                    // If we still haven't determined what facts should be passed to the policy, let's use the request message as a single fact.
                    if (null == facts)
                    {
                        if (messageDataStream != null)
                        {
                            // Unwind the data stream back to the beginning.
                            messageDataStream.Seek(0, SeekOrigin.Begin);

                            // Read the entire message into a BRE-compliant type XML document.
                            using (XmlReader messageDataReader = XmlReader.Create(messageDataStream, readerSettings))
                            {
                                facts = new object[] { new TypedXmlDocument(Resources.DefaultTypedXmlDocumentTypeName, messageDataReader) };
                                responseRequired = false;
                            }
                        }
                    }

                    // Execute a BRE policy.
                    PolicyExecutionResult policyExecResult = PolicyHelper.Execute(policyExecInfo, facts);

                    // CHeck if we need to return a response. We don't need to reply back if we are not handling ExecutePolicy request message.
                    if (responseRequired)
                    {
                        // Construct a response message.
                        RulesEngineResponse response = new RulesEngineResponse(policyExecResult.PolicyName, policyExecResult.PolicyVersion, policyExecResult.Success);

                        // Add all facts that were being used when invoking the policy.
                        response.AddFacts(facts);

                        // Create a response message.
                        IBaseMessagePart responsePart = BizTalkUtility.CreateResponsePart(context.PipelineContext.GetMessageFactory(), context.Message);
                        XmlWriterSettings settings = new XmlWriterSettings();

                        // Initialize a new stream that will hold the response message payload.
                        MemoryStream dataStream = new MemoryStream();
                        context.PipelineContext.ResourceTracker.AddResource(dataStream);

                        settings.CloseOutput = false;
                        settings.CheckCharacters = false;
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;

                        using (XmlWriter responseWriter = XmlWriter.Create(dataStream, settings))
                        {
                            responseWriter.WriteResponseStartElement("r", WellKnownContractMember.MethodNames.ExecutePolicy, WellKnownNamespace.ServiceContracts.General);

                            DataContractSerializer dcSerializer = new DataContractSerializer(typeof(RulesEngineResponse), String.Concat(WellKnownContractMember.MethodNames.ExecutePolicy, WellKnownContractMember.ResultMethodSuffix), WellKnownNamespace.ServiceContracts.General);
                            dcSerializer.WriteObject(responseWriter, response);

                            responseWriter.WriteEndElement();
                            responseWriter.Flush();
                        }

                        dataStream.Seek(0, SeekOrigin.Begin);
                        responsePart.Data = dataStream;
                    }
                    else
                    {
                        if (facts != null)
                        {
                            TypedXmlDocument xmlDoc = facts.Where((item) => { return item.GetType() == typeof(TypedXmlDocument); }).FirstOrDefault() as TypedXmlDocument;

                            if (xmlDoc != null)
                            {
                                // Initialize a new stream that will hold the response message payload.
                                MemoryStream dataStream = new MemoryStream();
                                context.PipelineContext.ResourceTracker.AddResource(dataStream);

                                XmlWriterSettings settings = new XmlWriterSettings
                                {
                                    CloseOutput = false,
                                    CheckCharacters = false,
                                    ConformanceLevel = ConformanceLevel.Fragment,
                                    NamespaceHandling = NamespaceHandling.OmitDuplicates
                                };

                                using (XmlWriter dataWriter = XmlWriter.Create(dataStream, settings))
                                {
                                    xmlDoc.Document.WriteContentTo(dataWriter);
                                    dataWriter.Flush();
                                }

                                dataStream.Seek(0, SeekOrigin.Begin);
                                context.Message.BodyPart.Data = dataStream;
                            }
                        }
                    }
                }
                else
                {
                    throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.PolicyNameNotSpecified));
                }
            }
            finally
            {
                if (messageDataStream != null && messageDataStream.CanSeek && messageDataStream.Position > 0)
                {
                    messageDataStream.Seek(0, SeekOrigin.Begin);
                }

                TraceManager.PipelineComponent.TraceOut(callToken);
            }
        }
        #endregion

        #region Public method
        /// <summary>
        /// Sets the BRE policy information for execution.
        /// </summary>
        /// <param name="policyName">The name of the Business Rules policy.</param>
        public void SetPolicyInfo(string policyName)
        {
            PolicyName = policyName;
            if (!CanRun) Enable();
        }
        #endregion
    }
}
