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

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Provides a base class for custom implementations of messaging runtime extender tasks.
    /// </summary>
    public abstract class MessagingRuntimeExtenderTaskBase : IMessagingRuntimeExtenderTask, IExtension<IMessagingRuntimeExtension>
    {
        #region Private members
        private readonly IMessagingRuntimeExtension parent;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingRuntimeExtenderTaskBase"/> object.
        /// </summary>
        private MessagingRuntimeExtenderTaskBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingRuntimeExtenderTaskBase"/> object that is owned by the specified parent extension collection.
        /// </summary>
        /// <param name="parent">The extensible owner object that aggregates this extension.</param>
        public MessagingRuntimeExtenderTaskBase(IMessagingRuntimeExtension parent)
        {
            Guard.ArgumentNotNull(parent, "parent");
            this.parent = parent;
        }
        #endregion

        #region IMessagingRuntimeExtenderTask implementation
        /// <summary>
        /// Returns a flag indicating whether or not this task is enabled for execution.
        /// </summary>
        public virtual bool CanRun
        {
            get { return this.parent.Extensions.Contains(this); }
        }

        /// <summary>
        /// Enables the task for execution.
        /// </summary>
        public virtual void Enable()
        {
            this.parent.Extensions.Add(this);
        }

        /// <summary>
        /// Disables the task from execution.
        /// </summary>
        public virtual void Disable()
        {
            if (this.parent.Extensions.Contains(this))
            {
                this.parent.Extensions.Remove(this);
            }
        }

        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public abstract void Run(RuntimeTaskExecutionContext context);

        /// <summary>
        /// Asynchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <returns>A wait object signaling when the task completes.</returns>
        public virtual WaitHandle RunAsync(RuntimeTaskExecutionContext context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IExtension<IMessagingRuntimeExtension> implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public virtual void Attach(IMessagingRuntimeExtension owner)
        {
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public virtual void Detach(IMessagingRuntimeExtension owner)
        {
        }
        #endregion
    }
}
