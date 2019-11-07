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
    using System.Reflection;
    using System.Globalization;

    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Message.Interop;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    #endregion

    /// <summary>
    /// Implements a messaging runtime extension task responsible for executing external components.
    /// </summary>
    public class ExternalComponentInvokeTask : MessagingRuntimeExtenderTaskBase
    {
        #region Public properties
        /// <summary>
        /// The fully qualified type name representing an external component that needs to be executed.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// The assembly name containing the external component that needs to be executed.
        /// </summary>
        public string AssemblyName { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalComponentInvokeTask"/> object that is owned by the specified extension collection.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public ExternalComponentInvokeTask(IMessagingRuntimeExtension owner) : base(owner)
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Sets the external component type information.
        /// </summary>
        /// <param name="typeName">The fully qualified type name representing an external component that needs to be executed.</param>
        /// <param name="assemblyName">The assembly name containing the external component that needs to be executed.</param>
        public void SetComponentTypeInfo(string typeName, string assemblyName)
        {
            TypeName = typeName;
            AssemblyName = assemblyName;

            if (!String.IsNullOrEmpty(TypeName) && !String.IsNullOrEmpty(AssemblyName))
            {
                Enable();
            }
        }
        #endregion

        #region IMessagingRuntimeExtenderTask implementation
        /// <summary>
        /// Returns a flag indicating whether or not this task is enabled for execution.
        /// </summary>
        public override bool CanRun 
        {
            get { return base.CanRun && !String.IsNullOrEmpty(TypeName) && !String.IsNullOrEmpty(AssemblyName); }
        }

        /// <summary>
        /// Synchronously executes the task using the specified <see cref="RuntimeTaskExecutionContext"/> execution context object.
        /// </summary>
        /// <param name="context">The execution context.</param>
        public override void Run(RuntimeTaskExecutionContext context)
        {
            Guard.ArgumentNotNullOrEmptyString(TypeName, "TypeName");
            Guard.ArgumentNotNullOrEmptyString(AssemblyName, "AssemblyName");

            var callToken = TraceManager.CustomComponent.TraceIn();

            string typeFullName = String.Format("{0}, {1}", TypeName, AssemblyName);
            Type targetType = Type.GetType(typeFullName, false, true);

            if (targetType != null)
            {
                IComponent component = Activator.CreateInstance(targetType, true) as IComponent;

                if (component != null)
                {
                    var scopeStartExecute = TraceManager.CustomComponent.TraceStartScope(Resources.ScopeExecuteExternalComponent, callToken);

                    try
                    {
                        component.Execute(context.PipelineContext, context.Message);
                    }
                    finally
                    {
                        if (component is IDisposable)
                        {
                            (component as IDisposable).Dispose();
                        }
                    }

                    TraceManager.CustomComponent.TraceEndScope(Resources.ScopeExecuteExternalComponent, scopeStartExecute, callToken);
                }
                else
                {
                    throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.CompulsoryInterfaceNotFound, targetType.FullName, typeof(IComponent).FullName));
                }
            }
            else
            {
                throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.TypeNotFound, typeFullName));
            }

            TraceManager.CustomComponent.TraceOut(callToken);
        }
        #endregion
    }
}
