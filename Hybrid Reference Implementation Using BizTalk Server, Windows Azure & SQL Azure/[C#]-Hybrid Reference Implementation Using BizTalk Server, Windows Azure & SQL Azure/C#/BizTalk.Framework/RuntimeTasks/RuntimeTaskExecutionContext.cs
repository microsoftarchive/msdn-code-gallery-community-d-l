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
    using System.ServiceModel;

    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;
    #endregion

    /// <summary>
    /// Provides a mechanism for sharing state information between messaging runtime extension tasks.
    /// </summary>
    public sealed class RuntimeTaskExecutionContext : IMessagingRuntimeExtension, IDisposable
    {
        #region Private members
        private IExtensionCollection<IMessagingRuntimeExtension> extensions;
        private readonly object extensionsLock = new object();
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the messaging pipeline context object.
        /// </summary>
        public IPipelineContext PipelineContext { get; private set; }

        /// <summary>
        /// Gets or sets the current message that is being processed by messaging runtime extension tasks.
        /// </summary>
        public IBaseMessage Message { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not messaging runtime extension tasks can be executed asynchronously.
        /// </summary>
        public bool Async { get; set; } 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="RuntimeTaskExecutionContext"/> object for a given pipeline context and input message.
        /// </summary>
        /// <param name="context">The messaging pipeline context object.</param>
        /// <param name="msg">The input message that will be made available to all messaging runtime extension tasks.</param>
        public RuntimeTaskExecutionContext(IPipelineContext context, IBaseMessage msg)
        {
            PipelineContext = context;
            Message = msg;
        } 
        #endregion

        #region IExtensibleObject implementation
        /// <summary>
        /// Gets a collection of extension objects for this extensible object.
        /// </summary>
        public IExtensionCollection<IMessagingRuntimeExtension> Extensions 
        {
            get
            {
                if (null == this.extensions)
                {
                    lock (this.extensionsLock)
                    {
                        if (null == this.extensions)
                        {
                            this.extensions = new ExtensionCollection<IMessagingRuntimeExtension>(this, this.extensionsLock);
                        }
                    }
                }
                return this.extensions;
            }
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~RuntimeTaskExecutionContext()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.extensions.Clear();
            }
        }  
        #endregion
    }
}
