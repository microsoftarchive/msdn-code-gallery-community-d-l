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
namespace Contoso.Cloud.Integration.BizTalk.Core
{
    #region Using references
    using System;
    using System.IO;

    using Microsoft.BizTalk.Streaming;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Provides common utility methods facilitating various operations with BizTalk runtime objects.
    /// </summary>
    public static class BizTalkUtility
    {
        #region Public members
        /// <summary>
        /// Returns the default buffer size for virtual streams.
        /// </summary>
        public const int VirtualStreamBufferSize = 10240; // 10 KB

        /// <summary>
        /// Returns the default threshold value upon which a virtual stream will overflow into a file-based stream.
        /// </summary>
        public const int VirtualStreamThresholdSize = 1048576; // 1 MB

        /// <summary>
        /// Returns the default character that is used for separating context property name and its namespace.
        /// </summary>
        public const char ContextPropertyNameSeparator = '#';
        #endregion

        /// <summary>
        /// Adds a new message part to the specified request message which is intended to be used as a response part.
        /// </summary>
        /// <param name="msgFactory">The <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessageFactory"/> factory object providing message part creation capabilities.</param>
        /// <param name="requestMsg">The request message represented by the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object.</param>
        /// <returns>A new message part represented by the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessagePart"/> object.</returns>
        public static IBaseMessagePart CreateResponsePart(IBaseMessageFactory msgFactory, IBaseMessage requestMsg)
        {
            Guard.ArgumentNotNull(msgFactory, "msgFactory");
            Guard.ArgumentNotNull(requestMsg, "requestMsg");

            IBaseMessagePart responsePart = msgFactory.CreateMessagePart();
            requestMsg.AddPart(Resources.ResponseBodyPartName, responsePart, false);

            return responsePart;
        }

        /// <summary>
        /// Verifies whether or not the specified message contains a response message part.
        /// </summary>
        /// <param name="msg">The message instance represented by the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object.</param>
        /// <returns>True if response message part was found, otherwise false.</returns>
        public static bool ContainsResponsePart(IBaseMessage msg)
        {
            Guard.ArgumentNotNull(msg, "msg");

            return msg.GetPart(Resources.ResponseBodyPartName) != null;
        }

        /// <summary>
        /// Returns a response message part from the specified message.
        /// </summary>
        /// <param name="msg">The message instance represented by the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object.</param>
        /// <returns>The response message part represented by the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessagePart"/> object.</returns>
        public static IBaseMessagePart GetResponsePart(IBaseMessage msg)
        {
            return ContainsResponsePart(msg) ? msg.GetPart(Resources.ResponseBodyPartName) : null;
        }

        /// <summary>
        /// Checks seekability of the data stream in the body part of specified message and returns a new <see cref="Microsoft.BizTalk.Streaming.ReadOnlySeekableStream"/> 
        /// stream should the original stream fail to support the Seek operation.
        /// </summary>
        /// <param name="msg">The message instance represented by the <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object.</param>
        /// <param name="pContext">A reference to <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object that contains the current pipeline context.</param>
        /// <returns>Either the original data stream or a new stream wrapping the original stream and providing support for the Seek operation, or a null reference if the specified message doesn't contain a body part.</returns>
        public static Stream EnsureSeekableStream(IBaseMessage msg, IPipelineContext pContext)
        {
            if (msg != null && msg.BodyPart != null)
            {
                Stream messageDataStream = msg.BodyPart.GetOriginalDataStream();

                if (!messageDataStream.CanSeek)
                {
                    Stream virtualStream = new VirtualStream(VirtualStreamBufferSize, VirtualStreamThresholdSize);
                    pContext.ResourceTracker.AddResource(virtualStream);

                    Stream seekableStream = new ReadOnlySeekableStream(messageDataStream, virtualStream, VirtualStreamBufferSize);
                    msg.BodyPart.Data = seekableStream;

                    return seekableStream;
                }
                else
                {
                    return messageDataStream;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
