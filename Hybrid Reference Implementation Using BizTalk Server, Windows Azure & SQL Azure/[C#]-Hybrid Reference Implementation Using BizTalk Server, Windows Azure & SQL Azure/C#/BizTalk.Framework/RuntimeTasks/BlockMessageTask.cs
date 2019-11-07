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
    using System.Threading;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for blocking a message passing through the messaging pipeline.
    /// </summary>
    public class BlockMessageTask : MessagingRuntimeExtenderTaskBase
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockMessageTask"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public BlockMessageTask(IMessagingRuntimeExtension owner) : base(owner)
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

            context.Message = null;

            TraceManager.CustomComponent.TraceOut(callToken);
        }
        #endregion
    }
}
