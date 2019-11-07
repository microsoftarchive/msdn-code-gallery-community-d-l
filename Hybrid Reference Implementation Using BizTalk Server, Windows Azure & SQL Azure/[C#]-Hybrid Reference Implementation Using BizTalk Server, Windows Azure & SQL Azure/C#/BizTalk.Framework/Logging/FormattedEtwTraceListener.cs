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
namespace Contoso.Cloud.Integration.BizTalk.Core.Logging
{
    #region Using statements
    using System;
    using System.Text;
    using System.Diagnostics;
    using System.Globalization;
    using System.Collections.Generic;

    using Microsoft.BizTalk.Diagnostics;
    using EtwTraceLevel = Microsoft.BizTalk.Tracing.TraceLevel;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

    using Contoso.Cloud.Integration.BizTalk.Core.Properties;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Provides an implementation of the Enterprise Library's <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.CustomTraceListener"/> abstract class which writes information to the ETW log.
    /// </summary>
    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public sealed class FormattedEtwTraceListener : CustomTraceListener
    {
        #region Private members
        private static readonly IDictionary<Guid, TraceProvider> traceProviderCache = new Dictionary<Guid, TraceProvider>(10);
        private static readonly object traceProviderCacheLock = new object();
        #endregion

        #region Public members
        /// <summary>
        /// Returns the name of the trace listener.
        /// </summary>
        public static readonly string ListenerName = typeof(FormattedEtwTraceListener).Name;

        /// <summary>
        /// Returns the fully qualified type name of the trace listener.
        /// </summary>
        public static readonly string ListenerTypeName = typeof(FormattedEtwTraceListener).AssemblyQualifiedName;
        #endregion

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
                string message = this.Formatter != null ? this.Formatter.Format(logEntry) : logEntry.Message;
                string providerGuid = logEntry.ExtendedProperties[InstrumentationUtility.Resources.TracingProviderGuidPropertyName] as string;

                TraceProvider etwTraceProvider = GetTraceProvider(!String.IsNullOrEmpty(providerGuid) ? Guid.Parse(providerGuid) : InstrumentationUtility.TracingProviderGuid.Default);

                switch(logEntry.Severity)
                {
                    case TraceEventType.Information:
                        TraceMessage(etwTraceProvider, EtwTraceLevel.Info, message);
                        break;
                    case TraceEventType.Warning:
                        TraceMessage(etwTraceProvider, EtwTraceLevel.Warning, message);
                        break;
                    case TraceEventType.Error:
                    case TraceEventType.Critical:
                        TraceMessage(etwTraceProvider, EtwTraceLevel.Error, message);
                        break;
                    case TraceEventType.Verbose:
                        TraceMessage(etwTraceProvider, EtwTraceLevel.Tracking | EtwTraceLevel.Error | EtwTraceLevel.Info | EtwTraceLevel.Messages | EtwTraceLevel.Warning, message);
                        break;
                    default:
                        TraceMessage(etwTraceProvider, EtwTraceLevel.Info, message);
                        break;
                }
            }

            base.TraceData(eventCache, source, eventType, id, data);
        }

        /// <summary>
        /// Writes the specified message to the trace.
        /// </summary>
        /// <param name="message">The message to write</param>
        public override void Write(string message)
        {
            //EtwTraceManager.CustomComponent.TraceInfo(message);
        }

        /// <summary>
        /// Writes the specified message to the trace followed by a line terminator.
        /// </summary>
        /// <param name="message">The message to write</param>
        public override void WriteLine(string message)
        {
            //EtwTraceManager.CustomComponent.TraceInfo(message);
        }
        
        #region Private methods
        private static TraceProvider GetTraceProvider(Guid providerGuid)
        {
            TraceProvider traceProvider = null;

            if (!traceProviderCache.TryGetValue(providerGuid, out traceProvider))
            {
                lock (traceProviderCacheLock)
                {
                    if (!traceProviderCache.TryGetValue(providerGuid, out traceProvider))
                    {
                        traceProvider = new TraceProvider(AppDomain.CurrentDomain.SetupInformation.ApplicationName, providerGuid);
                        traceProviderCache.Add(providerGuid, traceProvider);
                    }
                }
            }

            return traceProvider;
        }

        private void TraceMessage(TraceProvider etwTraceProvider, uint traceLevel, string format, params object[] parameters)
        {
            if (etwTraceProvider != null && etwTraceProvider.IsEnabled)
            {
                if (parameters == null)
                {
                    etwTraceProvider.TraceMessage(traceLevel, format);
                }
                else
                {
                    switch (parameters.Length)
                    {
                        case 0:
                            etwTraceProvider.TraceMessage(traceLevel, format);
                            return;

                        case 1:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0]);
                            return;

                        case 2:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1]);
                            return;

                        case 3:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1], parameters[2]);
                            return;

                        case 4:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1], parameters[2], parameters[3]);
                            return;

                        case 5:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                            return;

                        case 6:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                            return;

                        case 7:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6]);
                            return;

                        case 8:
                            etwTraceProvider.TraceMessage(traceLevel, format, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7]);
                            return;

                        default:
                            throw new ArgumentOutOfRangeException("parameters", parameters.Length, String.Format(CultureInfo.InvariantCulture, ExceptionMessages.ParameterListTooLong, 8));
                    }
                }
            }
        }
        #endregion
    }
}