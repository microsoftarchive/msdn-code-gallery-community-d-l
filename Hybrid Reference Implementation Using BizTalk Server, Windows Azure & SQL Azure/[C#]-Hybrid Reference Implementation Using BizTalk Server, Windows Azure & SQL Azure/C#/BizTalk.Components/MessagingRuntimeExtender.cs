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
namespace Contoso.Cloud.Integration.BizTalk.Components
{
    #region Using references
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;

    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Streaming;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core;
    using Contoso.Cloud.Integration.BizTalk.Core.PipelineComponents;
    using Contoso.Cloud.Integration.BizTalk.Core.RulesEngine;
    using Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks;
    using Contoso.Cloud.Integration.BizTalk.Components.Properties;
    #endregion

    /// <summary>
    /// Implements a custom pipeline component that can be used for composing and executing multiple custom message processing tasks at runtime.
    /// </summary>
    [Guid("74838B64-0669-4330-A5AA-042CE3BB22B7")]
    [BtsComponentName("MessagingRuntimeExtenderComponentName")]
    [BtsDescription("MessagingRuntimeExtenderComponentDesc")]
    [BtsComponentToolboxIcon("MessagingRuntimeExtenderComponentIcon")]
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public sealed class MessagingRuntimeExtender : CustomComponentBase
    {
        #region Component properties (configurable via BizTalk Admin console)
        /// <summary>
        /// The mandatory name of the Business Rules policy defining the composition of custom message processing tasks.
        /// </summary>
        [Browsable(true)]
        [BtsPropertyName("MessagingRuntimeExtenderPolicyNamePropName")]
        [BtsDescription("MessagingRuntimeExtenderPolicyNamePropDesc")]
        public string PolicyName { get; set; }

        /// <summary>
        /// The optional version number of the Business Rules policy defining the composition of custom message processing tasks.
        /// </summary>
        [Browsable(true)]
        [BtsPropertyName("MessagingRuntimeExtenderPolicyVersionPropName")]
        [BtsDescription("MessagingRuntimeExtenderPolicyVersionPropDesc")]
        public string PolicyVersion { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="MessagingRuntimeExtender"/> object.
        /// </summary>
        public MessagingRuntimeExtender() : base(Resources.ResourceManager)
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Executes a pipeline component to process the input message and returns the result message.
        /// </summary>
        /// <param name="pContext">A reference to <see cref="Microsoft.BizTalk.Component.Interop.IPipelineContext"/> object that contains the current pipeline context.</param>
        /// <param name="pInMsg">A reference to <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object that contains the message to process.</param>
        /// <returns>A reference to the returned <see cref="Microsoft.BizTalk.Message.Interop.IBaseMessage"/> object which will contain the output message.</returns>
        public override IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            if(pContext != null && pInMsg != null)
            {
                PolicyExecutionInfo policyExecInfo = !String.IsNullOrEmpty(PolicyVersion) ? new PolicyExecutionInfo(PolicyName, System.Version.Parse(PolicyVersion)) : new PolicyExecutionInfo(PolicyName);

                string ctxPropName, ctxPropNamespace;

                for (int i = 0; i < pInMsg.Context.CountProperties; i++)
                {
                    ctxPropName = null;
                    ctxPropNamespace = null;

                    object ctxPropValue = pInMsg.Context.ReadAt(i, out ctxPropName, out ctxPropNamespace);
                    policyExecInfo.AddParameter(String.Format("{0}{1}{2}", ctxPropNamespace, BizTalkUtility.ContextPropertyNameSeparator, ctxPropName), ctxPropValue);
#if DEBUG
                    TraceManager.PipelineComponent.TraceDetails("DETAIL: Context property added: {0}{1}{2} = {3}", ctxPropNamespace, BizTalkUtility.ContextPropertyNameSeparator, ctxPropName, ctxPropValue);
#endif
                }

                using (RuntimeTaskExecutionContext taskExecContext = new RuntimeTaskExecutionContext(pContext, pInMsg))
                {
                    IList<IMessagingRuntimeExtenderTask> registeredTasks = RuntimeTaskFactory.GetRegisteredTasks(taskExecContext);

                    try
                    {
                        PolicyExecutionResult policyExecResult = PolicyHelper.Execute(policyExecInfo, registeredTasks);

                        if (policyExecResult.Success)
                        {
                            foreach (IMessagingRuntimeExtenderTask task in taskExecContext.Extensions.FindAll<IMessagingRuntimeExtenderTask>())
                            {
                                if (task.CanRun)
                                {
                                    task.Run(taskExecContext);
                                }
                            }

                            return taskExecContext.Message;
                        }
                    }
                    finally
                    {
                        policyExecInfo.ClearParameters();

                        registeredTasks.Clear();
                        registeredTasks = null;
                    }
                }
            }
            return pInMsg;
        }
        #endregion
    }
}
