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
    using System.Collections.Generic;

    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.XPath;
    using Microsoft.BizTalk.Streaming;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for promoting properties into message context.
    /// </summary>
    public class PromoteContextPropertyTask : MessagingRuntimeExtenderTaskBase
    {
        #region Private members
        private readonly IDictionary<string, object> propertyToValueMap = new Dictionary<string, object>();
        private readonly IDictionary<string, string> propertyToXPathMap = new Dictionary<string, string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PromoteContextPropertyTask"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public PromoteContextPropertyTask(IMessagingRuntimeExtension owner) : base(owner)
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Promotes the specified property with its specified value into the message context.
        /// </summary>
        /// <param name="propertyName">The full name of the promoted property including its namespace. The namespace and property name must be separated by a hash (#) symbol.</param>
        /// <param name="value">The value that will be promoted into message context.</param>
        public void Promote(string propertyName, object value)
        {
            Guard.ArgumentNotNullOrEmptyString(propertyName, "propertyName");

            var callToken = TraceManager.CustomComponent.TraceIn(propertyName, value);

            this.propertyToValueMap.Add(propertyName, value);
            if (!CanRun) Enable();

            TraceManager.CustomComponent.TraceOut(callToken);
        }

        /// <summary>
        /// Promotes the specified property with its value taken from the XML message payload by applying the specified XPath expression.
        /// </summary>
        /// <param name="propertyName">The full name of the promoted property including its namespace. The namespace and property name must be separated by a # symbol.</param>
        /// <param name="xPathItemRef">The XPath expression to be applied against the input message.</param>
        public void PromoteWithXPath(string propertyName, string xPathItemRef)
        {
            Guard.ArgumentNotNullOrEmptyString(propertyName, "propertyName");
            Guard.ArgumentNotNullOrEmptyString(xPathItemRef, "xPathItemRef");

            var callToken = TraceManager.CustomComponent.TraceIn(propertyName, xPathItemRef);

            this.propertyToXPathMap.Add(propertyName, xPathItemRef);
            if (!CanRun) Enable();

            TraceManager.CustomComponent.TraceOut(callToken);
        }
        #endregion

        #region IMessagingRuntimeExtenderTask implementation
        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public override void Run(RuntimeTaskExecutionContext context)
        {
            string propName, propNamespace;

            // Check if there are any properties with values to be promoted.
            if (this.propertyToValueMap.Count > 0)
            {
                foreach (var property in this.propertyToValueMap)
                {
                    if (TryParsePropertyName(property.Key, out propName, out propNamespace))
                    {
#if DEBUG
                        TraceManager.CustomComponent.TraceDetails("DETAIL: Context property promoted: {0}{1}{2} = {3}", propNamespace, BizTalkUtility.ContextPropertyNameSeparator, propName, property.Value);
#endif
                        context.Message.Context.Promote(propName, propNamespace, property.Value);
                    }
                }
            }

            // Check if there are any properties to be promoted by inspecting the incoming message and capturing property values using XPath.
            if (this.propertyToXPathMap.Count > 0)
            {
                Stream messageDataStream = BizTalkUtility.EnsureSeekableStream(context.Message, context.PipelineContext);

                if (messageDataStream != null)
                {
                    byte[] buffer = new byte[BizTalkUtility.VirtualStreamBufferSize];
                    string[] propValues = new string[this.propertyToXPathMap.Count];
                    int arrIndex = 0, matchFound = 0;

                    XPathCollection xc = new XPathCollection();
                    XPathQueryLibrary xPathLib = ApplicationConfiguration.Current.XPathQueries;

                    foreach (var property in this.propertyToXPathMap)
                    {
                        propValues[arrIndex++] = property.Key;
                        xc.Add(xPathLib.GetXPathQuery(property.Value));
                    }

                    try
                    {
                        XPathMutatorStream mutator = new XPathMutatorStream(messageDataStream, xc,
                            delegate(int matchIdx, XPathExpression expr, string origValue, ref string finalValue)
                            {
                                if (matchIdx >= 0 && matchIdx < propValues.Length)
                                {
                                    if (TryParsePropertyName(propValues[matchIdx], out propName, out propNamespace))
                                    {
#if DEBUG
                                        TraceManager.CustomComponent.TraceDetails("DETAIL: Context property promoted: {0}{1}{2} = {3}", propNamespace, BizTalkUtility.ContextPropertyNameSeparator, propName, origValue);
#endif
                                        context.Message.Context.Promote(propName, propNamespace, origValue);
                                    }

                                    matchFound++;
                                }
                            });

                        while (mutator.Read(buffer, 0, buffer.Length) > 0 && matchFound < propValues.Length);
                    }
                    finally
                    {
                        if (messageDataStream.CanSeek)
                        {
                            messageDataStream.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }
            }
        }
        #endregion

        #region Private methods
        private bool TryParsePropertyName(string propertyName, out string name, out string ns)
        {
            ns = null;
            name = null;

            if (!String.IsNullOrEmpty(propertyName))
            {
                int separatorPos = propertyName.IndexOf(BizTalkUtility.ContextPropertyNameSeparator);

                if (separatorPos > 0)
                {
                    ns = propertyName.Split(BizTalkUtility.ContextPropertyNameSeparator)[0];
                    name = propertyName.Split(BizTalkUtility.ContextPropertyNameSeparator)[1];
                }
                else
                {
                    ns = String.Empty;
                    name = propertyName;
                }
            }

            return !String.IsNullOrEmpty(name);
        }
        #endregion
    }
}
