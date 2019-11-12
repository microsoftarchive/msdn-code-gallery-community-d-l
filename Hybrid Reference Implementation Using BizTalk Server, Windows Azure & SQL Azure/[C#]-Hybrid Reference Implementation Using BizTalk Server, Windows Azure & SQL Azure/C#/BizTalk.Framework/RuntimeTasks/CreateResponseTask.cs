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
    using System.Threading;

    using Microsoft.XLANGs.BaseTypes;
    using Microsoft.BizTalk.Message.Interop;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for generating a response message that can be routed back on request-response messaging ports.
    /// </summary>
    public class CreateResponseTask : MessagingRuntimeExtenderTaskBase
    {
        #region Private members
        private static MessageContextPropertyBase EpmRRCorrelationToken = new BTS.EpmRRCorrelationToken();
        private static MessageContextPropertyBase RouteDirectToTP = new BTS.RouteDirectToTP();
        private static MessageContextPropertyBase CorrelationToken = new BTS.CorrelationToken();
        private static MessageContextPropertyBase ReqRespTransmitPipelineID = new BTS.ReqRespTransmitPipelineID();
        private static MessageContextPropertyBase ReceivePipelineResponseConfig = new BTS.ReceivePipelineResponseConfig();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateResponseTask"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public CreateResponseTask(IMessagingRuntimeExtension owner) : base(owner)
        {
        }
        #endregion

        #region IMessagingRuntimeExtenderTask implementation
        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public override void Run(RuntimeTaskExecutionContext context)
        {
            var callToken = TraceManager.CustomComponent.TraceIn();

            IBaseMessageFactory msgFactory = context.PipelineContext.GetMessageFactory();
            IBaseMessage responseMsg = msgFactory.CreateMessage();
            IBaseMessageContext responseMsgCtx = msgFactory.CreateMessageContext();
            IBaseMessageContext requestMsgCtx = context.Message.Context;

            responseMsg.Context = responseMsgCtx;

            if (BizTalkUtility.ContainsResponsePart(context.Message))
            {
                IBaseMessagePart responsePart = BizTalkUtility.GetResponsePart(context.Message);
                responseMsg.AddPart(context.Message.BodyPartName, responsePart, true);
            }
            else
            {
                responseMsg.AddPart(context.Message.BodyPartName, context.Message.BodyPart, true);
            }

            responseMsgCtx.Promote(EpmRRCorrelationToken.Name.Name, EpmRRCorrelationToken.Name.Namespace, requestMsgCtx.Read(EpmRRCorrelationToken.Name.Name, EpmRRCorrelationToken.Name.Namespace));
            responseMsgCtx.Promote(RouteDirectToTP.Name.Name, RouteDirectToTP.Name.Namespace, true);
            responseMsgCtx.Promote(CorrelationToken.Name.Name, CorrelationToken.Name.Namespace, requestMsgCtx.Read(CorrelationToken.Name.Name, CorrelationToken.Name.Namespace));
            responseMsgCtx.Promote(ReqRespTransmitPipelineID.Name.Name, ReqRespTransmitPipelineID.Name.Namespace, requestMsgCtx.Read(ReqRespTransmitPipelineID.Name.Name, ReqRespTransmitPipelineID.Name.Namespace));
            responseMsgCtx.Write(ReceivePipelineResponseConfig.Name.Name, ReceivePipelineResponseConfig.Name.Namespace, requestMsgCtx.Read(ReceivePipelineResponseConfig.Name.Name, ReceivePipelineResponseConfig.Name.Namespace));

            context.Message = responseMsg;

            TraceManager.CustomComponent.TraceOut(callToken);
        }
        #endregion
    }
}
