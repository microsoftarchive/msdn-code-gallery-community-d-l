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
namespace Contoso.Cloud.Integration.Framework.Instrumentation
{
    #region Using statements
    using System;
    using System.Threading;
    using System.Diagnostics;
    using System.Configuration;

    using Microsoft.Practices.EnterpriseLibrary.Logging;

    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Encapsulates tracing provider for a given application component.
    /// </summary>
    public class ComponentTraceEventProvider : ITraceEventProvider
    {
        #region Private members
        /// <summary>
        /// A singleton instance of the LogWriter.
        /// </summary>
        private static volatile LogWriter logWriter;

        /// <summary>
        /// A sync lock object.
        /// </summary>
        private static readonly ReaderWriterLockSlim lockObject = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        private readonly string providerName;
        private readonly Guid providerGuid;
        private readonly HighResolutionTimer highResTimer;
        private readonly TraceSource debugTraceProvider;
        private volatile TraceEventProviderState state;
        #endregion

        #region TraceEventProviderState enum
        private enum TraceEventProviderState
        {
            Initializing,
            Initialized,
            Faulty,
            Enabled,
            Disabled
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="ComponentTraceEventProvider"/> object using the specified provider name and its unique identity.
        /// </summary>
        /// <param name="providerName">The name of the tracing provider.</param>
        /// <param name="providerGuid">The unique ID of the tracing provider.</param>
        public ComponentTraceEventProvider(string providerName, Guid providerGuid)
        {
            Guard.ArgumentNotNullOrEmptyString(providerName, "providerName");
            Guard.ArgumentNotDefaultValue<Guid>(providerGuid, "providerGuid");

            this.state = TraceEventProviderState.Initializing;
            this.providerName = providerName;
            this.providerGuid = providerGuid;
            this.highResTimer = new HighResolutionTimer();

            // Configure the trace listener and default trace options.
            this.debugTraceProvider = new TraceSource(providerName, SourceLevels.All);
            this.debugTraceProvider.Switch = new SourceSwitch(providerName);
            this.debugTraceProvider.Switch.Level = SourceLevels.All;
            this.debugTraceProvider.Listeners.Add(new DefaultTraceListener());
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns a flag indicating whether or not tracing is enabled.
        /// </summary>
        public bool IsEnabled
        {
            [DebuggerStepThrough]
            get
            {
                switch(this.state)
                {
                    case TraceEventProviderState.Faulty:
                        return false;
                    
                    case TraceEventProviderState.Enabled:
                        return true;

                    default:
                        try
                        {
                            LogWriter logWriter = null;

                            // Null reference for a LogWriter indicates that the trace manager is being called recursively.
                            if ((logWriter = TraceWriter) != null)
                            {
                                return logWriter.IsTracingEnabled();
                            }
                        }
                        catch (Exception ex)
                        {
                            this.state = TraceEventProviderState.Faulty;
                            TraceEventOnFailOver(ex, TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, ex.Message);
                        }
                        finally
                        {
                            if (this.state != TraceEventProviderState.Faulty)
                            {
                                this.state = TraceEventProviderState.Initialized;
                            }
                        }
                        
                        return false;
                }
            }
        }
        #endregion

        #region Private members
        /// <summary>
        /// Gets the instance of LogWriter used by the class.
        /// </summary>
        private static LogWriter TraceWriter
        {
            get
            {
                if (logWriter == null)
                {
                    // This prevents from recursively invoking this block of code from a configuration source provider that also uses this instrumentation component.
                    if (!lockObject.IsUpgradeableReadLockHeld)
                    {
                        lockObject.EnterUpgradeableReadLock();

                        try
                        {
                            if (logWriter == null)
                            {
                                lockObject.EnterWriteLock();

                                try
                                {
                                    if (logWriter == null)
                                    {
                                        LogWriterFactory factory = new LogWriterFactory();
                                        logWriter = factory.Create();
                                    }
                                }
                                finally
                                {
                                    lockObject.ExitWriteLock();
                                }
                            }
                        }
                        finally
                        {
                            lockObject.ExitUpgradeableReadLock();
                        }
                    }
                }

                return logWriter;
            }
        }
        #endregion

        #region ITraceEventProvider implementation
        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceInfo(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Information, WellKnownTraceCategory.TraceInfo, InstrumentationUtility.SystemEventId.Info, format, parameters);
        }

        /// <summary>
        /// Writes an information message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        [DebuggerStepThrough]
        public void TraceInfo(string message)
        {
            TraceEvent(TraceEventType.Information, WellKnownTraceCategory.TraceInfo, InstrumentationUtility.SystemEventId.Info, InstrumentationUtility.Resources.FormatStringTraceInfo, message);
        }

        /// <summary>
        /// Writes an information message to the trace. This method is intended to be used when the data that needs to be
        /// written to the trace is expensive to be fetched. The method represented by the Func(T) delegate will only be invoked if
        /// tracing is enabled.
        /// </summary>
        /// <param name="expensiveDataProvider">A method that has no parameters and returns a value that needs to be traced.</param>
        [DebuggerStepThrough]
        public void TraceInfo(Func<string> expensiveDataProvider)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Information, WellKnownTraceCategory.TraceInfo, InstrumentationUtility.SystemEventId.Info, InstrumentationUtility.Resources.FormatStringTraceInfo, expensiveDataProvider());
            }
        }

        /// <summary>
        /// Writes a message to the trace. This method can be used to trace detailed information
        /// which is only required in particular cases.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceDetails(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceDetails, InstrumentationUtility.SystemEventId.DetailedInfo, format, parameters);
        }

        /// <summary>
        /// Writes a message to the trace. This method can be used to trace detailed information
        /// which is only required in particular cases. The method represented by the Func(T) 
        /// delegate will only be invoked if tracing is enabled.
        /// </summary>
        /// <param name="expensiveDataProvider">A method that has no parameters and returns a value that needs to be traced.</param>
        [DebuggerStepThrough]
        public void TraceDetails(Func<string> expensiveDataProvider)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceDetails, InstrumentationUtility.SystemEventId.DetailedInfo, InstrumentationUtility.Resources.FormatStringTraceDetails, expensiveDataProvider());
            }
        }

        /// <summary>
        /// Writes a warning message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceWarning(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Warning, WellKnownTraceCategory.TraceWarning, InstrumentationUtility.SystemEventId.Warning, format, parameters);
        }

        /// <summary>
        /// Writes a warning message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        [DebuggerStepThrough]
        public void TraceWarning(string message)
        {
            TraceEvent(TraceEventType.Warning, WellKnownTraceCategory.TraceWarning, InstrumentationUtility.SystemEventId.Warning, InstrumentationUtility.Resources.FormatStringTraceWarning, message);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceError(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, format, parameters);
        }

        /// <summary>
        /// Writes an error message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the error message to be traced.</param>
        [DebuggerStepThrough]
        public void TraceError(string message)
        {
            TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, InstrumentationUtility.Resources.FormatStringTraceErrorNoToken, message);
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex)
        {
            TraceError(ex, true);
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceError calls.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex, Guid callToken)
        {
            TraceError(ex, true, callToken);
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex, bool includeStackTrace)
        {
            if (IsEnabled)
            {
                ExceptionTextFormatter exceptionFormatter = new ExceptionTextFormatter(this.providerName);
                TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, InstrumentationUtility.Resources.FormatStringTraceErrorNoToken, exceptionFormatter.FormatException(ex, includeStackTrace));
            }
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceError calls.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex, bool includeStackTrace, Guid callToken)
        {
            if (IsEnabled)
            {
                ExceptionTextFormatter exceptionFormatter = new ExceptionTextFormatter(this.providerName);
                TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, InstrumentationUtility.Resources.FormatStringTraceError, exceptionFormatter.FormatException(ex, includeStackTrace), callToken);
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="parameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        /// <returns>An unique value which can be used as a correlation token to correlate TraceIn and TraceOut calls.</returns>
        [DebuggerStepThrough]
        public Guid TraceIn(params object[] parameters)
        {
            Guid callToken = Guid.NewGuid();

            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceIn, InstrumentationUtility.SystemEventId.MethodEntry, InstrumentationUtility.Resources.FormatStringTraceIn, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), InstrumentationUtility.GetParameterList(parameters), callToken);
            }

            return callToken;
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// This method is provided to ensure optimal performance when no parameters are required to be traced.
        /// </summary>
        /// <returns>An unique value which can be used as a correlation token to correlate TraceIn and TraceOut calls.</returns>
        [DebuggerStepThrough]
        public Guid TraceIn()
        {
            Guid callToken = Guid.NewGuid();

            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceIn, InstrumentationUtility.SystemEventId.MethodEntry, InstrumentationUtility.Resources.FormatStringTraceIn, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), null, callToken);
            }

            return callToken;
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// This overload should be used when correlation token (callToken) is defined by the calling code.
        /// </summary>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceOut calls.</param>
        [DebuggerStepThrough]
        public void TraceIn(Guid callToken)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceIn, InstrumentationUtility.SystemEventId.MethodEntry, InstrumentationUtility.Resources.FormatStringTraceIn, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), null, callToken);
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceOut method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// </summary>
        /// <param name="outParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        [DebuggerStepThrough]
        public void TraceOut(params object[] outParameters)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceOut, InstrumentationUtility.SystemEventId.MethodExit, InstrumentationUtility.Resources.FormatStringTraceOutNoToken, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), outParameters != null & outParameters.Length > 0 ? InstrumentationUtility.GetParameterList(outParameters) : InstrumentationUtility.Resources.NoReturnValue);
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceOut method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// This method is provided to ensure optimal performance when no parameters are required to be traced.
        /// </summary>
        [DebuggerStepThrough]
        public void TraceOut()
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceOut, InstrumentationUtility.SystemEventId.MethodExit, InstrumentationUtility.Resources.FormatStringTraceOutNoTokenAndParams, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()));
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceOut method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// </summary>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceOut calls.</param>
        /// <param name="outParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        [DebuggerStepThrough]
        public void TraceOut(Guid callToken, params object[] outParameters)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceOut, InstrumentationUtility.SystemEventId.MethodExit, InstrumentationUtility.Resources.FormatStringTraceOut, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), outParameters != null & outParameters.Length > 0 ? InstrumentationUtility.GetParameterList(outParameters) : InstrumentationUtility.Resources.NoReturnValue, callToken);
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating a start of a scope for which duration will be measured.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="parameters">A list containing zero or more data items to be included into scope details.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        [DebuggerStepThrough]
        public long TraceStartScope(string scope, params object[] parameters)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Start, WellKnownTraceCategory.TraceStartScope, InstrumentationUtility.SystemEventId.StartScope, InstrumentationUtility.Resources.FormatStringTraceScopeStart, scope, InstrumentationUtility.GetParameterList(parameters));
                return this.highResTimer.TickCount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating the start of a scope for which duration will be measured.
        /// This method is provided in order to ensure optimal performance when no parameters are available for tracing.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        [DebuggerStepThrough]
        public long TraceStartScope(string scope)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Start, WellKnownTraceCategory.TraceStartScope, InstrumentationUtility.SystemEventId.StartScope, InstrumentationUtility.Resources.FormatStringTraceScopeStartNoParams, scope);
                return this.highResTimer.TickCount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating the start of a scope for which duration will be measured.
        /// This method is provided in order to ensure optimal performance when only 1 parameter of type Guid is available for tracing.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceStartScope and TraceEndScope calls.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        [DebuggerStepThrough]
        public long TraceStartScope(string scope, Guid callToken)
        {
            if (IsEnabled)
            {
                TraceEvent(TraceEventType.Start, WellKnownTraceCategory.TraceStartScope, InstrumentationUtility.SystemEventId.StartScope, InstrumentationUtility.Resources.FormatStringTraceScopeStart, scope, callToken);
                return this.highResTimer.TickCount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating the end of a scope for which duration will be measured.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="startTicks">The number of ticks that represent the date and time when the code entered the scope.</param>
        /// <returns>The calculated duration.</returns>
        [DebuggerStepThrough]
        public long TraceEndScope(string scope, long startTicks)
        {
            if (IsEnabled)
            {
                long duration = this.highResTimer.GetElapsedMilliseconds(startTicks);
                TraceEvent(TraceEventType.Stop, WellKnownTraceCategory.TraceEndScope, InstrumentationUtility.SystemEventId.EndScope, InstrumentationUtility.Resources.FormatStringTraceScopeEndNoParams, scope, duration);

                return duration;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating the end of a scope for which duration will be measured.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="startTicks">The number of ticks that represent the date and time when the code entered the scope.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceStartScope and TraceEndScope calls.</param>
        /// <returns>The calculated duration.</returns>
        [DebuggerStepThrough]
        public long TraceEndScope(string scope, long startTicks, Guid callToken)
        {
            if (IsEnabled)
            {
                long duration = this.highResTimer.GetElapsedMilliseconds(startTicks);
                TraceEvent(TraceEventType.Stop, WellKnownTraceCategory.TraceEndScope, InstrumentationUtility.SystemEventId.EndScope, InstrumentationUtility.Resources.FormatStringTraceScopeEnd, scope, callToken, duration);

                return duration;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Writes a trace log entry containing the specified trace event record.
        /// </summary>
        /// <param name="eventRecord">The trace record which will be written to a trace log.</param>
        [DebuggerStepThrough]
        public void TraceEvent(TraceEventRecord eventRecord)
        {
            if (IsEnabled)
            {
                LogEntry logEntry = new LogEntry()
                {
                    TimeStamp = eventRecord.DateTime,
                    ProcessId = eventRecord.ProcessId.ToString(),
                    Win32ThreadId = eventRecord.ThreadId.ToString(),
                    MachineName = eventRecord.MachineName,
                    ProcessName = eventRecord.ProcessName,
                    EventId = eventRecord.EventId,
                    Message = eventRecord.Message,
                    Severity = eventRecord.EventType,
                    Title = eventRecord.EventSource
                };

                logEntry.Categories.Add(WellKnownTraceCategory.CreateFrom(eventRecord));
                logEntry.ExtendedProperties[InstrumentationUtility.Resources.TracingProviderGuidPropertyName] = this.providerGuid;

                if (TraceWriter.ShouldLog(logEntry))
                {
                    TraceWriter.Write(logEntry);
                }
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Writes a trace log entry of the specified type, category and event ID.
        /// </summary>
        /// <param name="eventType">The type of event.</param>
        /// <param name="eventCategory">The category of event.</param>
        /// <param name="eventId">The ID of the trace event.</param>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to be included into scope details.</param>
        protected virtual void TraceEvent(TraceEventType eventType, string eventCategory, int eventId, string format, params object[] parameters)
        {
            try
            {
                if (IsEnabled)
                {
                    LogEntry logEntry = new LogEntry();

                    logEntry.Categories.Add(eventCategory);
                    logEntry.Severity = eventType;

                    if (TraceWriter.ShouldLog(logEntry))
                    {
                        logEntry.Message = parameters != null && parameters.Length > 0 ? String.Format(format, parameters) : format;
                        logEntry.EventId = eventId;
                        logEntry.Title = this.providerName;
                        logEntry.ExtendedProperties[InstrumentationUtility.Resources.TracingProviderGuidPropertyName] = this.providerGuid;

                        TraceWriter.Write(logEntry);
                    }
                }
            }
            catch (Exception ex)
            {
                // Tracing component should not generate any exceptions. We need to to fail over to a debug trace listener should logging via Enterprise Library fails.
                TraceEventOnFailOver(ex, eventType, eventCategory, eventId, format, parameters);
            }
        }

        private void TraceEventOnFailOver(Exception ex, TraceEventType eventType, string eventCategory, int eventId, string format, params object[] args)
        {
            if (this.debugTraceProvider.Switch.ShouldTrace(eventType))
            {
                if (args != null && args.Length > 0)
                {
                    this.debugTraceProvider.TraceEvent(eventType, eventId, format, args);
                }
                else
                {
                    this.debugTraceProvider.TraceEvent(eventType, eventId, format);
                }
            }

            if (ex != null)
            {
                this.debugTraceProvider.TraceEvent(TraceEventType.Error, InstrumentationUtility.SystemEventId.Error, ExceptionTextFormatter.Format(ex));
            }
        }
        #endregion
    }
}