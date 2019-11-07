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
    using System.Diagnostics;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
    
    using Microsoft.WindowsAzure.Diagnostics;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Implementation of the Enterprise Library CustomTraceListener abstract class which writes information to the 
    /// Azure Diagnostic Monitor Trace Listener and Development Fabric Trace Listener when running in Development Fabric mode.
    /// </summary>
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public sealed class CloudDiagnosticTraceListener : CustomTraceListener
    {
        #region Private members
        private readonly TraceListener diagMonitorTraceListener;
        private readonly TraceListener devFabricTraceListener;
        #endregion

        #region Public members
        /// <summary>
        /// Returns the name of the trace listener.
        /// </summary>
        public static readonly string ListenerName = typeof(CloudDiagnosticTraceListener).Name;

        /// <summary>
        /// Returns the fully qualified type name of the trace listener.
        /// </summary>
        public static readonly string ListenerTypeName = typeof(CloudDiagnosticTraceListener).AssemblyQualifiedName;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the trace listener.
        /// </summary>
        public CloudDiagnosticTraceListener()
        {
            if (CloudEnvironment.IsAvailable)
            {
                this.diagMonitorTraceListener = new DiagnosticMonitorTraceListener();
            }
            else
            {
                this.diagMonitorTraceListener = new DefaultTraceListener();
            }

            this.devFabricTraceListener = CloudUtility.GetDevFabricTraceListener();

            Name = ListenerName;
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

        #region Public methods
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
                string message = this.Formatter != null ? this.Formatter.Format(logEntry) : logEntry.Message;

                // Format log message and write it to the trace
                this.diagMonitorTraceListener.TraceEvent(eventCache, source, eventType, id, message);

                if (this.devFabricTraceListener != null)
                {
                    this.devFabricTraceListener.WriteLine(message);
                }
            }
            else
            {
                this.diagMonitorTraceListener.TraceData(eventCache, source, eventType, id, data);

                if (this.devFabricTraceListener != null)
                {
                    this.devFabricTraceListener.TraceData(eventCache, source, eventType, id, data);
                }
            }
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
            this.diagMonitorTraceListener.TraceEvent(eventCache, source, eventType, id, format, args);

            if (this.devFabricTraceListener != null)
            {
                this.devFabricTraceListener.TraceEvent(eventCache, source, eventType, id, format, args);
            }
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
            this.diagMonitorTraceListener.TraceEvent(eventCache, source, eventType, id, message);

            if (this.devFabricTraceListener != null)
            {
                this.devFabricTraceListener.TraceEvent(eventCache, source, eventType, id, message);
            }
        }

        /// <summary>
        /// Writes the specified message to the trace.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void Write(string message)
        {
            this.diagMonitorTraceListener.Write(message);

            if (this.devFabricTraceListener != null)
            {
                this.devFabricTraceListener.Write(message);
            }
        }

        /// <summary>
        /// Writes the specified message to the trace followed by a line terminator.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void WriteLine(string message)
        {
            this.diagMonitorTraceListener.WriteLine(message);

            if (this.devFabricTraceListener != null)
            {
                this.devFabricTraceListener.WriteLine(message);
            }
        }
        #endregion
    }
}