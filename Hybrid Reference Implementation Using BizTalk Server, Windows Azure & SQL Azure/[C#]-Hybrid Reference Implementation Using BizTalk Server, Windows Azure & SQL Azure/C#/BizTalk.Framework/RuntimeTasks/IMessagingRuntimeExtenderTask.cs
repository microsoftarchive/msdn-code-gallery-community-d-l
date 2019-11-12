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
    using System.ServiceModel;
    #endregion

    /// <summary>
    /// Defines an interface which must be implemented by a task participating in messaging runtime extensibility model.
    /// </summary>
    public interface IMessagingRuntimeExtenderTask : IExtension<IMessagingRuntimeExtension>
    {
        /// <summary>
        /// Returns a flag indicating whether or not this task is enabled for execution.
        /// </summary>
        bool CanRun { get; }

        /// <summary>
        /// Enables the task for execution.
        /// </summary>
        void Enable();

        /// <summary>
        /// Disables the task from execution.
        /// </summary>
        void Disable();

        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        void Run(RuntimeTaskExecutionContext context);

        /// <summary>
        /// Asynchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <returns>A wait object signaling when the task completes.</returns>
        WaitHandle RunAsync(RuntimeTaskExecutionContext context);
    }
}
