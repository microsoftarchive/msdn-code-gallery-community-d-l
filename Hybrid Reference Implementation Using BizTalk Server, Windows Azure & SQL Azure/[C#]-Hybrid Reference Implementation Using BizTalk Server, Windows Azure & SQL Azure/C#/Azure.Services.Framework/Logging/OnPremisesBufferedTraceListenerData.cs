//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// This library contains framework components used by all Azure-hosted services.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Logging
{
    #region Using statements
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq.Expressions;

    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;

    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    /// <summary>
    /// Implements a configuration data provider for the custom trace listener that relays trace events to an on-premises hosted service.
    /// </summary>
    [ResourceDescription(typeof(Resources), "OnPremisesBufferedTraceListenerDataDescription")]
    [ResourceDisplayName(typeof(Resources), "OnPremisesBufferedTraceListenerDataDisplayName")]
    public sealed class OnPremisesBufferedTraceListenerData : TraceListenerData, IConfigurableConfigurationElement
    {
        #region Private members
        private const int DefaultInMemoryQueueCapacity = 100000;
        private const int DefaultInMemoryQueueListenerSleepTimeoutMs = 1000;
        private const int DefaultDiagnosticQueueEventBatchSize = 50;
        private const int DefaultDiagnosticQueueListenerSleepTimeoutMs = 1000;

        private const string DiagnosticServiceEndpointProperty = "diagnosticServiceEndpoint";
        private const string DiagnosticStorageAccountProperty = "diagnosticStorageAccount";
        private const string InMemoryQueueCapacityProperty = "inMemoryQueueCapacity";
        private const string InMemoryQueueListenerSleepTimeoutProperty = "inMemoryQueueListenerSleepTimeout";
        private const string DiagnosticQueueEventBatchSizeProperty = "diagnosticQueueEventBatchSize";
        private const string DiagnosticQueueListenerSleepTimeoutProperty = "diagnosticQueueListenerSleepTimeout";
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the trace listener configuration data provider.
        /// </summary>
        public OnPremisesBufferedTraceListenerData()
            : base(typeof(OnPremisesBufferedTraceListener))
        {
            ListenerDataType = typeof(OnPremisesBufferedTraceListenerData);
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the name of the Service Bus endpoint definition that corresponds to the on-premises hosted diagnostic service.
        /// </summary>
        [ConfigurationProperty(DiagnosticServiceEndpointProperty, IsRequired = true)]
        [ResourceDescription(typeof(Resources), "DiagnosticServiceEndpointPropertyDescription")]
        [ResourceDisplayName(typeof(Resources), "DiagnosticServiceEndpointPropertyDisplayName")]
        public string DiagnosticServiceEndpoint
        {
            get { return (string)base[DiagnosticServiceEndpointProperty]; }
            set { base[DiagnosticServiceEndpointProperty] = value; }
        }

        /// <summary>
        /// Gets the name of the storage account in which diagnostic data will be queued before relayed to the on-premises hosted diagnostic service.
        /// </summary>
        [ConfigurationProperty(DiagnosticStorageAccountProperty, IsRequired = false)]
        [ResourceDescription(typeof(Resources), "DiagnosticStorageAccountPropertyDescription")]
        [ResourceDisplayName(typeof(Resources), "DiagnosticStorageAccountPropertyDisplayName")]
        public string DiagnosticStorageAccount
        {
            get { return (string)base[DiagnosticStorageAccountProperty]; }
            set { base[DiagnosticStorageAccountProperty] = value; }
        }

        /// <summary>
        /// Gets the maximum capacity of the non-durable in-memory queue in which trace events are being stored before they are persisted into an Azure queue.
        /// </summary>
        [ConfigurationProperty(InMemoryQueueCapacityProperty, DefaultValue = DefaultInMemoryQueueCapacity)]
        [ResourceDescription(typeof(Resources), "InMemoryQueueCapacityPropertyDescription")]
        [ResourceDisplayName(typeof(Resources), "InMemoryQueueCapacityPropertyDisplayName")]
        public int InMemoryQueueCapacity
        {
            get { return (int)base[InMemoryQueueCapacityProperty]; }
            set { base[InMemoryQueueCapacityProperty] = value; }
        }

        /// <summary>
        /// Gets the interval in milliseconds during which a dequeue thread is waiting for new events in the in-memory queue.
        /// </summary>
        [ConfigurationProperty(InMemoryQueueListenerSleepTimeoutProperty, DefaultValue = DefaultInMemoryQueueListenerSleepTimeoutMs)]
        [ResourceDescription(typeof(Resources), "InMemoryQueueListenerSleepTimeoutDescription")]
        [ResourceDisplayName(typeof(Resources), "InMemoryQueueListenerSleepTimeoutDisplayName")]
        public int InMemoryQueueListenerSleepTimeout
        {
            get { return (int)base[InMemoryQueueListenerSleepTimeoutProperty]; }
            set { base[InMemoryQueueListenerSleepTimeoutProperty] = value; }
        }

        /// <summary>
        /// Gets the maximum number of trace events in a batch that is submitted to the on-premises hosted diagnostic service.
        /// </summary>
        [ConfigurationProperty(DiagnosticQueueEventBatchSizeProperty, DefaultValue = DefaultDiagnosticQueueEventBatchSize)]
        [ResourceDescription(typeof(Resources), "DiagnosticQueueEventBatchSizePropertyDescription")]
        [ResourceDisplayName(typeof(Resources), "DiagnosticQueueEventBatchSizePropertyDisplayName")]
        public int DiagnosticQueueEventBatchSize
        {
            get { return (int)base[DiagnosticQueueEventBatchSizeProperty]; }
            set { base[DiagnosticQueueEventBatchSizeProperty] = value; }
        }

        /// <summary>
        /// Gets the interval in milliseconds during which a dequeue thread is waiting for new events to be deposited into the Azure queue.
        /// </summary>
        [ConfigurationProperty(DiagnosticQueueListenerSleepTimeoutProperty, DefaultValue = DefaultDiagnosticQueueListenerSleepTimeoutMs)]
        [ResourceDescription(typeof(Resources), "DiagnosticQueueListenerSleepTimeoutPropertyDescription")]
        [ResourceDisplayName(typeof(Resources), "DiagnosticQueueListenerSleepTimeoutPropertyDisplayName")]
        public int DiagnosticQueueListenerSleepTimeout
        {
            get { return (int)base[DiagnosticQueueListenerSleepTimeoutProperty]; }
            set { base[DiagnosticQueueListenerSleepTimeoutProperty] = value; }
        }
        #endregion

        /// <summary>
        /// Returns a lambda expression that represents the creation of the trace listener described by this
        /// configuration object.
        /// </summary>
        /// <returns>A lambda expression to create a trace listener.</returns>
        protected override Expression<Func<TraceListener>> GetCreationExpression()
        {
            return () => new OnPremisesBufferedTraceListener(this.DiagnosticServiceEndpoint, this.DiagnosticStorageAccount, this.InMemoryQueueCapacity, this.InMemoryQueueListenerSleepTimeout, this.DiagnosticQueueEventBatchSize, this.DiagnosticQueueListenerSleepTimeout);
        }

        #region IConfigurableConfigurationElement implementation
        /// <summary>
        /// Changes the current value of the specified configuration property to a new value.
        /// </summary>
        /// <param name="name">The name of the configuration property.</param>
        /// <param name="value">The new value that will be set on the specified configuration property.</param>
        public void SetPropertyValue(string name, object value)
        {
            ConfigurationProperty configProperty = null;

            if (this.Properties.Contains(name))
            {
                configProperty = this.Properties[name];

                if (configProperty != null)
                {
                    SetPropertyValue(configProperty, value, true);
                }
            }
        }
        #endregion
    }
}
