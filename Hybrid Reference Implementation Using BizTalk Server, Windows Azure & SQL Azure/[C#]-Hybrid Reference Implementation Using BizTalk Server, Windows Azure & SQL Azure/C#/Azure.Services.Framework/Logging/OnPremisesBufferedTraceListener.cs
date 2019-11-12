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
    using System.Linq;
    using System.Diagnostics;
    using System.Threading;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Configuration;

    using Microsoft.ServiceBus;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

    using LogEntry = Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    #endregion

    /// <summary>
    /// Implementation of the Enterprise Library CustomTraceListener abstract class which writes information to 
    /// a remote trace listener hosted on premises.
    /// </summary>
    [ConfigurationElementType(typeof(OnPremisesBufferedTraceListenerData))]
    public sealed class OnPremisesBufferedTraceListener : CustomTraceListener, IDisposable 
    {
        #region Private members
        private const int DefaultRetryCount = 10;

        private readonly RetryPolicy sbRetryPolicy;
        private readonly RetryPolicy queueRetryPolicy;
        private readonly ConcurrentQueue<TraceEventRecord> inMemoryQueue;
        private readonly ICloudQueueStorage diagQueueStorage;
        private readonly ReliableServiceBusClient<IDiagnosticLoggingServiceChannel> diagnosticService;
        private readonly ManualResetEvent diagQueueReaderDone;
        private readonly ManualResetEvent diagQueueWriterDone;
        private readonly TraceListener backupTraceListener;
        private readonly TraceEventCache traceEventCache = new TraceEventCache();
        private readonly int inMemoryQueueCapacity;
        private readonly int inMemoryQueueListenerSleepTimeout;
        private readonly int diagQueueEventBatchSize;
        private readonly int diagQueueListenerSleepTimeout;
        private readonly string diagQueueName;

        /// <summary>
        /// Holds a value to indicate whether the instance has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Holds a value that determines whether the RealTimeBufferedTraceListener is running.
        /// </summary>
        private volatile bool isRunning;
        #endregion

        #region Public members
        /// <summary>
        /// Returns the name of the trace listener.
        /// </summary>
        public static readonly string ListenerName = typeof(OnPremisesBufferedTraceListener).Name;

        /// <summary>
        /// Returns the fully qualified type name of the trace listener.
        /// </summary>
        public static readonly string ListenerTypeName = typeof(OnPremisesBufferedTraceListener).AssemblyQualifiedName;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the trace listener using the specified configuration settings.
        /// </summary>
        /// <param name="diagnosticServiceEndpoint">The name of the Service Bus endpoint definition that corresponds to the on-premises hosted diagnostic service.</param>
        /// <param name="diagnosticStorageAccount">The name of the storage account in which diagnostic data will be queued before relayed to the on-premises hosted diagnostic service.</param>
        /// <param name="inMemoryQueueCapacity">The maximum capacity of the non-durable in-memory queue in which trace events are being stored before they are persisted into an Azure queue.</param>
        /// <param name="inMemoryQueueListenerSleepTimeout">The interval in milliseconds during which a dequeue thread is waiting for new events in the in-memory queue.</param>
        /// <param name="diagQueueEventBatchSize">The maximum number of trace events in a batch that is submitted to the on-premises hosted diagnostic service.</param>
        /// <param name="diagQueueListenerSleepTimeout">The interval in milliseconds during which a dequeue thread is waiting for new events to be deposited into the Azure queue.</param>
        public OnPremisesBufferedTraceListener(string diagnosticServiceEndpoint, string diagnosticStorageAccount, int inMemoryQueueCapacity, int inMemoryQueueListenerSleepTimeout, int diagQueueEventBatchSize, int diagQueueListenerSleepTimeout)
        {
            Guard.ArgumentNotNullOrEmptyString(diagnosticServiceEndpoint, "diagnosticServiceEndpoint");
            Guard.ArgumentNotZeroOrNegativeValue(inMemoryQueueCapacity, "inMemoryQueueCapacity");
            Guard.ArgumentNotZeroOrNegativeValue(inMemoryQueueListenerSleepTimeout, "inMemoryQueueListenerSleepTimeout");
            Guard.ArgumentNotZeroOrNegativeValue(diagQueueEventBatchSize, "diagQueueEventBatchSize");
            Guard.ArgumentNotZeroOrNegativeValue(diagQueueListenerSleepTimeout, "diagQueueListenerSleepTimeout");

            // Configure the general properties of the trace listener.
            Name = ListenerName;
            NeedIndent = false;

            // Configure the in-memory queue and its parameters, set up a backup trace listener.
            this.inMemoryQueue = new ConcurrentQueue<TraceEventRecord>();
            this.inMemoryQueueCapacity = inMemoryQueueCapacity;
            this.inMemoryQueueListenerSleepTimeout = inMemoryQueueListenerSleepTimeout;
            this.diagQueueEventBatchSize = diagQueueEventBatchSize;
            this.diagQueueListenerSleepTimeout = diagQueueListenerSleepTimeout;
            this.diagQueueName = GetServiceBusQueueName(CloudEnvironment.CurrentRoleInstanceId);
            this.backupTraceListener = new CloudDiagnosticTraceListener();

            // Configure Service Bus endpoint for the Diagnostic Service.
            ServiceBusEndpointInfo diagServiceEndpointInfo = ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[diagnosticServiceEndpoint];

            // Validate Service Bus endpoints.
            if (null == diagServiceEndpointInfo)
            {
                throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.SpecifiedServiceBusEndpointNotFound, diagnosticServiceEndpoint, ServiceBusConfigurationSettings.SectionName));
            }

            // Retrieve the storage account settings from application configuration.
            StorageAccountConfigurationSettings storageSettings = ApplicationConfiguration.Current.GetConfigurationSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

            // Validate the presence of storage account settings.
            if (null == storageSettings)
            {
                throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, StorageAccountConfigurationSettings.SectionName));
            }

            // Determine the storage account for storing tracing data. By default, assume that storage account is defined in the trace listener configuration.
            string diagStorageAccountName = diagnosticStorageAccount;

            // If storage account is not defined in the trace listener configuration, switch to the storage account specified in the Application Diagnostic Settings section.
            if (String.IsNullOrEmpty(diagStorageAccountName))
            {
                // Retrieve the diagnostic settings from application configuration.
                ApplicationDiagnosticSettings diagSettings = ApplicationConfiguration.Current.GetConfigurationSection<ApplicationDiagnosticSettings>(ApplicationDiagnosticSettings.SectionName);

                // Validate the presence of diagnostic settings.
                if (null == diagSettings)
                {
                    throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.ConfigSectionNotFoundInConfigSource, ApplicationDiagnosticSettings.SectionName));
                }

                diagStorageAccountName = diagSettings.DiagnosticStorageAccount;
            }

            // Resolve the storage account details based on the account name defined in the diagnostic settings .
            StorageAccountInfo diagStorageAccount = storageSettings.Accounts.Get(diagStorageAccountName);

            // Validate storage account details.
            if (null == diagStorageAccount)
            {
                throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.StorageAccountNotFoundInConfigSource, diagStorageAccountName));
            }

            // Configure retry policies.
            this.sbRetryPolicy = new RetryPolicy<ServiceBusTransientErrorDetectionStrategy>(DefaultRetryCount);
            this.queueRetryPolicy = new RetryPolicy<StorageTransientErrorDetectionStrategy>(DefaultRetryCount);
            this.sbRetryPolicy.RetryOccurred += HandleServiceBusEndpointRetryState;
            this.queueRetryPolicy.RetryOccurred += HandleCloudQueueRetryState;

            // Configure Service Bus and Message Queue clients.
            this.diagnosticService = new ReliableServiceBusClient<IDiagnosticLoggingServiceChannel>(diagServiceEndpointInfo, this.sbRetryPolicy);
            this.diagQueueStorage = new ReliableCloudQueueStorage(diagStorageAccount, this.queueRetryPolicy);
            this.diagQueueReaderDone = new ManualResetEvent(false);
            this.diagQueueWriterDone = new ManualResetEvent(false);

            // Ensure that destination cloud queue exists, create if necessary.
            this.diagQueueStorage.CreateQueue(this.diagQueueName);

            // Enable background listeners to run.
            this.isRunning = true;

            StartInMemoryQueueListener();
            StartServiceBusQueueListener();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets a value indicating whether the trace listener is thread safe.
        /// </summary>
        public override bool IsThreadSafe
        {
            get { return true; }
        }
        #endregion

        #region Private properties
        private ConcurrentQueue<TraceEventRecord> InMemoryQueue
        {
            get { return this.inMemoryQueue; }
        }

        private bool IsRunning
        {
            get { return this.isRunning; }
        }

        private ICloudQueueStorage QueueStorage
        {
            get { return this.diagQueueStorage; }
        }

        private IDiagnosticLoggingServiceChannel DiagnosticServiceClient
        {
            get { return this.diagnosticService.Client; }
        }

        private ManualResetEvent QueueReaderDone
        {
            get { return this.diagQueueReaderDone; }
        }

        private int QueueReaderSleepTimeout
        {
            get { return this.diagQueueListenerSleepTimeout; }
        }

        private ManualResetEvent QueueWriterDone
        {
            get { return this.diagQueueWriterDone; }
        }

        private int QueueWriterSleepTimeout
        {
            get { return this.inMemoryQueueListenerSleepTimeout; }
        }

        private RetryPolicy ServiceBusRetryPolicy
        {
            get { return this.sbRetryPolicy; }
        }
        
        private RetryPolicy QueueRetryPolicy
        {
            get { return this.queueRetryPolicy; }
        }

        private int QueueEventBatchSize
        {
            get { return this.diagQueueEventBatchSize; }
        }

        private string QueueName
        {
            get { return this.diagQueueName; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Writes the specified message to the trace.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void Write(string message)
        {
            TraceEvent(TraceEventRecord.Create(ListenerName, TraceEventType.Information, InstrumentationUtility.SystemEventId.Info, message));
        }

        /// <summary>
        /// Writes the specified message to the trace followed by a line terminator.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void WriteLine(string message)
        {
            Write(message);
        }

        /// <summary>
        /// Writes trace and event information to the listener specific output.
        /// </summary>
        /// <param name="eventCache">A TraceEventCache object that contains the current process ID, thread ID, and stack trace information.</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
        /// <param name="eventType">One of the TraceEventType values specifying the type of event that has caused the trace.</param>
        /// <param name="id">A numeric identifier for the event.</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            TraceEvent(eventCache, source, eventType, id, null);
        }

        /// <summary>
        /// Writes trace information, a message, and event information to the listener specific output.
        /// </summary>
        /// <param name="eventCache">A TraceEventCache object that contains the current process ID, thread ID, and stack trace information.</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
        /// <param name="eventType">One of the TraceEventType values specifying the type of event that has caused the trace.</param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="message">A message to write.</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            TraceEvent(TraceEventRecord.Create(eventCache, source, eventType, id, message));
        }

        /// <summary>
        /// Writes trace information, a formatted array of objects and event information to the listener specific output.
        /// </summary>
        /// <param name="eventCache">A TraceEventCache object that contains the current process ID, thread ID, and stack trace information.</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
        /// <param name="eventType">One of the TraceEventType values specifying the type of event that has caused the trace.</param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="format">A format string that contains zero or more format items, which correspond to objects in the args array.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            TraceEvent(eventCache, source, eventType, id, String.Format(CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        /// Writes trace information, a data object and event information to the listener specific output. 
        /// </summary>
        /// <param name="eventCache">A TraceEventCache object that contains the current process ID, thread ID, and stack trace information.</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
        /// <param name="eventType">One of the TraceEventType values specifying the type of event that has caused the trace.</param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="data">The trace data to emit.</param>
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            // Extract log entry from data parameter
            LogEntry logEntry = data as LogEntry;

            if (logEntry != null)
            {
                TraceEvent(TraceEventRecord.Create(logEntry));
            }
            else
            {
                base.TraceData(eventCache, source, eventType, id, data);
            }
        }

        /// <summary>
        /// Closes the output stream so it no longer receives tracing or debugging output.
        /// </summary>
        public override void Close()
        {
            DisposedCheck();
            Dispose();
        }
        #endregion

        #region Private methods
        private void TraceEvent(TraceEventRecord traceEvent)
        {
            TraceEventRecord skippedEvent;

            // Continue accepting events only if the component is running and has not been asked to terminate.
            if (this.isRunning)
            {
                // Should prevent the in-memory queue from overflowing and consuming too much memory.
                while (this.inMemoryQueue.Count >= this.inMemoryQueueCapacity)
                {
                    this.inMemoryQueue.TryDequeue(out skippedEvent);
                }

                this.inMemoryQueue.Enqueue(traceEvent);
            }
        }

        private void StartInMemoryQueueListener()
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                OnPremisesBufferedTraceListener parent = state as OnPremisesBufferedTraceListener;
                IList<TraceEventRecord> traceEvents = new List<TraceEventRecord>(parent.QueueEventBatchSize);
                TraceEventRecord traceEvent;
                bool canRun = parent.IsRunning;

                try
                {
                    while (canRun)
                    {
                        try
                        {
                            while (!parent.InMemoryQueue.IsEmpty && traceEvents.Count < parent.QueueEventBatchSize)
                            {
                                if (parent.InMemoryQueue.TryDequeue(out traceEvent))
                                {
                                    traceEvents.Add(traceEvent);
                                }
                            }

                            if (traceEvents.Count > 0)
                            {
                                parent.QueueStorage.Put<TraceEventRecord[]>(parent.QueueName, traceEvents.ToArray<TraceEventRecord>());
                                traceEvents.Clear();
                            }
                            else
                            {
                                // Time to check if we are still allowed to run. We should run until the in-memory queue is completely flushed or 
                                // as long as the parent is running.
                                canRun = !parent.InMemoryQueue.IsEmpty || parent.IsRunning;

                                // No messages were dequeued, let's sleep for the defined interval.
                                if (canRun && parent.QueueWriterSleepTimeout > 0)
                                {
                                    Thread.Sleep(parent.QueueWriterSleepTimeout);
                                }
                            }
                        }
                        catch (ThreadAbortException threadEx)
                        {
                            HandleException(threadEx);
                            return;
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);

                            // Enforce a sleep interval whenever an exception is encountered.
                            if (parent.QueueWriterSleepTimeout > 0)
                            {
                                Thread.Sleep(parent.QueueWriterSleepTimeout);
                            }
                        }
                    }
                }
                finally
                {
                    parent.QueueWriterDone.Set();
                }

            }, this);
        }

        private void StartServiceBusQueueListener()
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                OnPremisesBufferedTraceListener parent = state as OnPremisesBufferedTraceListener;
                bool canRun = parent.IsRunning;

                try
                {
                    while (canRun)
                    {
                        try
                        {
                            var traceEventBatch = parent.QueueStorage.Get<TraceEventRecord[]>(parent.QueueName, parent.QueueEventBatchSize);

                            if (traceEventBatch != null && traceEventBatch.Count() > 0)
                            {
                                var traceEvents = (from batch in traceEventBatch select batch.AsEnumerable()).Aggregate((i, j) => i.Concat(j));

                                parent.ServiceBusRetryPolicy.ExecuteAction(() =>
                                {
                                    parent.DiagnosticServiceClient.TraceEvent(traceEvents.ToArray<TraceEventRecord>());
                                });

                                foreach (var item in traceEventBatch)
                                {
                                    parent.QueueStorage.Delete<TraceEventRecord[]>(item);
                                }
                            }
                            else
                            {
                                // Time to check if we are still allowed to run. We should run until the in-memory queue is completely flushed or 
                                // as long as the parent is running.
                                canRun = !parent.InMemoryQueue.IsEmpty || parent.IsRunning;

                                // No messages were dequeued, let's sleep for the defined interval.
                                if (canRun && parent.QueueReaderSleepTimeout > 0)
                                {
                                    Thread.Sleep(parent.QueueReaderSleepTimeout);
                                }
                            }
                        }
                        catch (ThreadAbortException threadEx)
                        {
                            HandleException(threadEx);
                            return;
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);

                            // Enforce a sleep interval whenever an exception is encountered.
                            if (parent.QueueReaderSleepTimeout > 0)
                            {
                                Thread.Sleep(parent.QueueReaderSleepTimeout);
                            }
                        }
                    }
                }
                finally
                {
                    parent.QueueReaderDone.Set();
                }

            }, this);
        }

        private void HandleServiceBusEndpointRetryState(int currentRetryCount, Exception lastException, TimeSpan delay)
        {
            // Only report on errors if the first retry failed to recover the system to normal state.
            if (currentRetryCount > 1)
            {
                this.backupTraceListener.TraceEvent(this.traceEventCache, Name, TraceEventType.Warning, InstrumentationUtility.SystemEventId.Warning, String.Format(CultureInfo.CurrentCulture, TraceLogMessages.ServiceBusEndpointRetryConditionWarning, lastException.Message, currentRetryCount));
                HandleException(lastException);
            }
        }

        private void HandleCloudQueueRetryState(int currentRetryCount, Exception lastException, TimeSpan delay)
        {
            // Only report on errors if the first retry failed to recover the system to normal state.
            if (currentRetryCount > 1)
            {
                this.backupTraceListener.TraceEvent(this.traceEventCache, Name, TraceEventType.Warning, InstrumentationUtility.SystemEventId.Warning, String.Format(CultureInfo.CurrentCulture, TraceLogMessages.AzureQueueRetryConditionWarning, lastException.Message, currentRetryCount));
                HandleException(lastException);
            }
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        private void HandleException(Exception ex)
        {
            this.backupTraceListener.TraceEvent(this.traceEventCache, !String.IsNullOrEmpty(ex.Source) ? ex.Source : Name, TraceEventType.Error, InstrumentationUtility.SystemEventId.Error, ExceptionTextFormatter.Format(ex));
        }

        /// <summary>
        /// Constructs and returns a queue name that is unique for the specified instance ID and is safe to be used as a name for the Windows Azure Service Bus Message Buffer.
        /// </summary>
        /// <param name="instanceId">A string that uniquely and reliably identifies the process in which the OnPremisesBufferedTraceListener trace listener is running.</param>
        /// <returns>The constructed queue name.</returns>
        private static string GetServiceBusQueueName(string instanceId)
        {
            Guard.ArgumentNotNullOrEmptyString(instanceId, "instanceId");

            return CloudUtility.CleanupContainerName(String.Concat(Resources.OnPremisesBufferedTraceListenerQueueName, "-", FrameworkUtility.GetHashedValue(instanceId)).ToLowerInvariant());
        }
        #endregion

        #region IDisposable implementation
         /// <summary>
        /// Helper method to check whether the object has already been disposed.
        /// </summary>
        private void DisposedCheck()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(typeof(OnPremisesBufferedTraceListener).FullName);
            }
        }

        /// <summary>
        /// Finalises the object instance.
        /// </summary>
        ~OnPremisesBufferedTraceListener()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        /// <param name="disposing">Determines whether this was called by Dispose or by the finaliser.</param>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // We can safely dispose of .NET resources.
                    this.isRunning = false;

                    QueueReaderDone.WaitOne();
                    QueueWriterDone.WaitOne();

                    this.diagQueueStorage.DeleteQueue(this.diagQueueName);
                    this.diagQueueStorage.Dispose();

                    diagnosticService.Dispose();
                }

                this.disposed = true;
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        public new void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            
            base.Dispose();
        }
        #endregion
    }
}