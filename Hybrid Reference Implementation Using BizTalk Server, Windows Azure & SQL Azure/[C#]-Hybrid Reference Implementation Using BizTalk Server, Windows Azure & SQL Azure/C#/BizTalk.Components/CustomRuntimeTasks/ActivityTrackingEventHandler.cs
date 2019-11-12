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
    using System.Linq;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;

    using Microsoft.BizTalk.Streaming;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.XLANGs.BaseTypes;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Core;
    using Contoso.Cloud.Integration.BizTalk.Core.ActivityTracking;
    using Contoso.Cloud.Integration.BizTalk.Components.Properties;
    #endregion

    /// <summary>
    /// Implements a custom runtime task responsible for handling BAM activity tracking updates received through a receive port.
    /// </summary>
    public class ActivityTrackingEventHandler : IComponent
    {
        #region Private members
        private static MessageContextPropertyBase SoapMethodProperty = new SOAP.MethodName();
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

            if (pInMsg.BodyPart != null)
            {
                Stream messageDataStream = BizTalkUtility.EnsureSeekableStream(pInMsg, pContext);

                if (messageDataStream != null)
                {
                    try
                    {
                        XmlReaderSettings readerSettings = new XmlReaderSettings() { CloseInput = false, CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };

                        using (XmlReader messageDataReader = XmlReader.Create(messageDataStream, readerSettings))
                        {
                            ActivityBase genericActivity = ActivityBase.Create(messageDataReader);

                            if (genericActivity != null)
                            {
                                using (IActivityTrackingEventStream eventStream = ActivityTrackingEventStreamFactory.CreateEventStream(pContext))
                                {
                                    string methodName = pInMsg.Context.Read(SoapMethodProperty.Name.Name, SoapMethodProperty.Name.Namespace) as string;

                                    if (!String.IsNullOrEmpty(methodName))
                                    {
                                        if (methodName.EndsWith(Resources.BeginActivityMethodName))
                                        {
                                            eventStream.BeginActivity(genericActivity);
                                        }
                                        else if (methodName.EndsWith(Resources.UpdateActivityMethodName))
                                        {
                                            eventStream.UpdateActivity(genericActivity);
                                        }
                                        else if (methodName.EndsWith(Resources.CompleteActivityMethodName))
                                        {
                                            eventStream.CompleteActivity(genericActivity);
                                        }
                                    }
                                    else
                                    {
                                        TraceManager.PipelineComponent.TraceWarning(TraceLogMessages.CannotDetermineSoapAction, this.GetType().Name, SoapMethodProperty.Name.Name, SoapMethodProperty.Name.Namespace);
                                    }
                                }
                            }
                            else
                            {
                                TraceManager.PipelineComponent.TraceWarning(TraceLogMessages.CannotDeserializeActivityMessage, this.GetType().Name, typeof(ActivityBase).FullName);
                            }
                        }
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

            TraceManager.PipelineComponent.TraceOut(callToken);
            return pInMsg;
        }
        #endregion
    }
}
