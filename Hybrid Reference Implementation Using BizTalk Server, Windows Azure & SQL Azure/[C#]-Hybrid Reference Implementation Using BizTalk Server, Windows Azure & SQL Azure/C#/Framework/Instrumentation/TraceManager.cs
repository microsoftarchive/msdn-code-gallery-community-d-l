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
namespace Contoso.Cloud.Integration.Framework.Instrumentation
{
    #region Using references
    using System;
    using System.Threading;
    using System.Reflection;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// The main tracing component which is intended to be invoked from user code.
    /// </summary>
    public static class TraceManager
    {
        #region Private members
        private const int InitialCacheSize = 10;

        private static readonly ITraceEventProvider pipelineComponentTracer;
        private static readonly ITraceEventProvider workflowComponentTracer;
        private static readonly ITraceEventProvider dataAccessComponentTracer;
        private static readonly ITraceEventProvider transformComponentTracer;
        private static readonly ITraceEventProvider serviceComponentTracer;
        private static readonly ITraceEventProvider customComponentTracer;
        private static readonly ITraceEventProvider rulesComponentTracer;
        private static readonly ITraceEventProvider trackingComponentTracer;
        private static readonly ITraceEventProvider workerRoleComponentTracer;
        private static readonly ITraceEventProvider debugComponentTracer;
        private static readonly ITraceEventProvider cloudStorageComponent;

        private static readonly IDictionary<Guid, ITraceEventProvider> traceProviderCache = new Dictionary<Guid, ITraceEventProvider>(InitialCacheSize);
        private static readonly IDictionary<string, Guid> traceProviderGuidToSourceMap = new Dictionary<string, Guid>(InitialCacheSize);
        private static readonly object traceProviderCacheLock = new object();
        #endregion

        #region Constructor
        static TraceManager()
        {
            customComponentTracer = Create("CustomComponent", InstrumentationUtility.TracingProviderGuid.Default);
            pipelineComponentTracer = Create("PipelineComponent", InstrumentationUtility.TracingProviderGuid.PipelineComponent);
            workflowComponentTracer = Create("WorkflowComponent", InstrumentationUtility.TracingProviderGuid.WorkflowComponent);
            dataAccessComponentTracer = Create("DataAccessComponent", InstrumentationUtility.TracingProviderGuid.DataAccessComponent);
            transformComponentTracer = Create("TransformComponent", InstrumentationUtility.TracingProviderGuid.TransformComponent);
            serviceComponentTracer = Create("ServiceComponent", InstrumentationUtility.TracingProviderGuid.ServiceComponent);
            rulesComponentTracer = Create("RulesComponent", InstrumentationUtility.TracingProviderGuid.RulesComponent);
            trackingComponentTracer = Create("TrackingComponent", InstrumentationUtility.TracingProviderGuid.TrackingComponent);
            workerRoleComponentTracer = Create("WorkerRoleComponent", InstrumentationUtility.TracingProviderGuid.WorkerRoleComponent);
            cloudStorageComponent = Create("CloudStorageComponent", InstrumentationUtility.TracingProviderGuid.CloudStorageComponent);
            debugComponentTracer = new DebugTraceEventProvider();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// The trace provider for user code in the custom pipeline components.
        /// </summary>
        public static ITraceEventProvider PipelineComponent
        {
            get { return pipelineComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in workflows (such as expression shapes in the BizTalk orchestrations).
        /// </summary>
        public static ITraceEventProvider WorkflowComponent
        {
            get { return workflowComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the custom components responsible for data access operations.
        /// </summary>
        public static ITraceEventProvider DataAccessComponent
        {
            get { return dataAccessComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the transformation components (such as scripting functoids in the BizTalk maps).
        /// </summary>
        public static ITraceEventProvider TransformComponent
        {
            get { return transformComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the service components (such as Web Service, WCF Service or service proxy components).
        /// </summary>
        public static ITraceEventProvider ServiceComponent
        {
            get { return serviceComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the Business Rules components (such as custom fact retrievers, policy executors).
        /// </summary>
        public static ITraceEventProvider RulesComponent
        {
            get { return rulesComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the business activity tracking components (such as BAM activities).
        /// </summary>
        public static ITraceEventProvider TrackingComponent
        {
            get { return trackingComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in any other custom components which don't fall into any of the standard categories such as Pipeline, Workflow, DataAccess, Transform.
        /// </summary>
        public static ITraceEventProvider CustomComponent
        {
            get { return customComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the Azure worker roles.
        /// </summary>
        public static ITraceEventProvider WorkerRoleComponent
        {
            get { return workerRoleComponentTracer; }
        }

        /// <summary>
        /// The trace provider reserved for the Azure components responsible for storage-related operations.
        /// </summary>
        public static ITraceEventProvider CloudStorageComponent
        {
            get { return cloudStorageComponent; }
        }

        /// <summary>
        /// The trace provider reserved for DEBUG mode.
        /// </summary>
        public static ITraceEventProvider DebugComponent
        {
            get { return debugComponentTracer; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns an instance of a trace provider for the specified type. This requires that the type supplies its GUID which will be used
        /// for registering it with the ETW infrastructure.
        /// </summary>
        /// <param name="componentType">The type which must be decorated with a <see cref="System.Runtime.InteropServices.GuidAttribute"/> attribute.</param>
        /// <returns>An instance of the trace provider implementing the <see cref="ITraceEventProvider"/> interface.</returns>
        public static ITraceEventProvider Create(Type componentType)
        {
            GuidAttribute guidAttribute = FrameworkUtility.GetDeclarativeAttribute<GuidAttribute>(componentType);

            if (guidAttribute != default(GuidAttribute))
            {
                return Create(componentType.FullName, new Guid(guidAttribute.Value));
            }
            else
            {
                throw new MissingMemberException(componentType.FullName, typeof(GuidAttribute).FullName);
            }
        }

        /// <summary>
        /// Returns an instance of a trace provider initialized with the specified name and provider GUID.
        /// </summary>
        /// <param name="providerName">The name of the trace provider.</param>
        /// <param name="providerGuid">The value uniquely identifying the trace provider.</param>
        /// <returns>An instance of the trace provider implementing the <see cref="ITraceEventProvider"/> interface.</returns>
        public static ITraceEventProvider Create(string providerName, Guid providerGuid)
        {
            Guard.ArgumentNotNullOrEmptyString(providerName, "providerName");

            ITraceEventProvider traceProvider = null;

            if (!traceProviderCache.TryGetValue(providerGuid, out traceProvider))
            {
                lock (traceProviderCacheLock)
                {
                    if (!traceProviderCache.TryGetValue(providerGuid, out traceProvider))
                    {
                        traceProvider = new ComponentTraceEventProvider(providerName, providerGuid);

                        traceProviderCache.Add(providerGuid, traceProvider);
                        traceProviderGuidToSourceMap.Add(providerName, providerGuid);
                    }
                }
            }

            return traceProvider;
        }

        /// <summary>
        /// Returns an instance of a trace provider registered under the specified GUID value.
        /// </summary>
        /// <param name="providerGuid">The value uniquely identifying the trace provider.</param>
        /// <returns>An instance of the trace provider implementing the <see cref="ITraceEventProvider"/> interface, of a null reference if no providers were found with matching GUID value.</returns>
        public static ITraceEventProvider Create(Guid providerGuid)
        {
            ITraceEventProvider traceProvider = null;
            traceProviderCache.TryGetValue(providerGuid, out traceProvider);

            return traceProvider;
        }

        /// <summary>
        /// Returns an instance of a trace provider registered under the specified name.
        /// </summary>
        /// <param name="providerName">The name of the trace provider.</param>
        /// <returns>An instance of the trace provider implementing the <see cref="ITraceEventProvider"/> interface, of a null reference if no providers were found with matching name.</returns>
        public static ITraceEventProvider Create(string providerName)
        {
            Guard.ArgumentNotNullOrEmptyString(providerName, "providerName");

            ITraceEventProvider traceProvider = null;
            Guid providerGuid = default(Guid);

            if (traceProviderGuidToSourceMap.TryGetValue(providerName, out providerGuid))
            {
                traceProviderCache.TryGetValue(providerGuid, out traceProvider);
            }

            return traceProvider;
        }
        #endregion
    }
}