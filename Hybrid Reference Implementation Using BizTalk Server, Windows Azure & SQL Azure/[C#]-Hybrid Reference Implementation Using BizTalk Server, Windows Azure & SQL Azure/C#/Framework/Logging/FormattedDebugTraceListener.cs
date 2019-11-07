//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Framework library is a set of common components shared across multiple
// projects in the Contoso Cloud Integration solution.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Framework.Logging
{
    #region Using statements
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
    
    using Contoso.Cloud.Integration.Framework.Configuration;
    #endregion

    /// <summary>
    /// Provides an implementation of the Enterprise Library's <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.CustomTraceListener"/> abstract class 
    /// which writes tracing information to the default trace listener.
    /// </summary>
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public sealed class FormattedDebugTraceListener : CustomTraceListener
    {
        #region Private members
        private readonly TraceListener debugTraceListener;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="FormattedDebugTraceListener"/> object configured with default settings.
        /// </summary>
        public FormattedDebugTraceListener()
        {
            Name = LoggingConfigurationView.FormattedDebugTraceListenerName;

            this.debugTraceListener = new DefaultTraceListener();
            this.debugTraceListener.Filter = this.Filter;
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
            // Extract log entry from data parameter.
            LogEntry logEntry = data as LogEntry;
            if (logEntry != null)
            {
                if (this.Formatter != null)
                {
                    // Format log message and write it to the trace.
                    this.Write(this.Formatter.Format(logEntry));
                }
                else
                {
                    this.Write(logEntry.Message);
                }
                return;
            }

            base.TraceData(eventCache, source, eventType, id, data);
        }

        /// <summary>
        /// Writes trace information, a formatted array of objects and event information to the listener specific output.
        /// </summary>
        /// <param name="eventCache">A TraceEventCache object that contains the current process ID, thread ID, and stack trace information.</param>
        /// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
        /// <param name="eventType">One of the TraceEventType values specifying the type of event that has caused the trace.</param>
        /// <param name="id">A numeric identifier for the event.</param>
        /// <param name="format">A format string that contains zero or more format items, which correspond to objects in the arguments array.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            this.debugTraceListener.TraceEvent(eventCache, source, eventType, id, format, args);
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
            this.debugTraceListener.TraceEvent(eventCache, source, eventType, id, message);
        }

        /// <summary>
        /// Writes the specified message to the trace.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void Write(string message)
        {
            this.debugTraceListener.Write(message);
        }

        /// <summary>
        /// Writes the specified message to the trace followed by a line terminator.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void WriteLine(string message)
        {
            this.debugTraceListener.WriteLine(message);
        } 
        #endregion
    }
}