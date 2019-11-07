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
    #region Using references
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime.Serialization;
    using System.Diagnostics;
    using System.Threading;
    using System.Globalization;

    using Microsoft.Practices.EnterpriseLibrary.Logging;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Properties;
    #endregion

    /// <summary>
    /// Describes a single record in the trace log and provides factory classes for instantiating the trace records from different sources.
    /// </summary>
    [DataContract(Name = "TraceEventRecord", Namespace = WellKnownNamespace.DataContracts.General)]
    public sealed class TraceEventRecord
    {
        #region Private members
        private const string DateTimePropertyName = "DateTime";
        private const string ProcessIdPropertyName = "ProcessId";
        private const string ProcessNamePropertyName = "ProcessName";
        private const string ThreadIdPropertyName = "ThreadId";
        private const string MachineNamePropertyName = "MachineName";
        private const string EventIdPropertyName = "EventId";
        private const string TimestampPropertyName = "Timestamp";
        private const string EventSourcePropertyName = "EventSource";
        private const string EventSourceIdPropertyName = "EventSourceId";
        private const string EventCategoryPropertyName = "EventCategory";
        private const string MessagePropertyName = "Message";
        private const string EventTypePropertyName = "EventType";
        #endregion

        #region Public properties
        /// <summary>
        /// Gets the date and time at which the event trace occurred.
        /// </summary>
        [DataMember(Name = DateTimePropertyName)]
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the current process.
        /// </summary>
        [DataMember(Name = ProcessIdPropertyName)]
        public int ProcessId { get; private set; }

        /// <summary>
        /// Gets the name of the current process.
        /// </summary>
        [DataMember(Name = ProcessNamePropertyName)]
        public string ProcessName { get; private set; }

        /// <summary>
        /// Gets a unique identifier for the current managed thread.
        /// </summary>
        [DataMember(Name = ThreadIdPropertyName)]
        public int ThreadId { get; private set; }

        /// <summary>
        /// Gets the machine name originating this event.
        /// </summary>
        [DataMember(Name = MachineNamePropertyName)]
        public string MachineName { get; private set; }

        /// <summary>
        /// Gets the ID of the trace event.
        /// </summary>
        [DataMember(Name = EventIdPropertyName)]
        public int EventId { get; private set; }

        /// <summary>
        /// Gets the current number of ticks in the timer mechanism.
        /// </summary>
        [DataMember(Name = TimestampPropertyName)]
        public long Timestamp { get; private set; }

        /// <summary>
        /// Gets the name of the source generated this event.
        /// </summary>
        [DataMember(Name = EventSourcePropertyName)]
        public string EventSource { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the source generated this event.
        /// Depending on usage scenario, this identifier could represent an ETW provider's GUID.
        /// </summary>
        [DataMember(Name = EventSourceIdPropertyName)]
        public Guid EventSourceId { get; private set; }

        /// <summary>
        /// Gets the name of the event category that describes this event.
        /// </summary>
        [DataMember(Name = EventCategoryPropertyName)]
        public string EventCategory { get; private set; }

        /// <summary>
        /// One of the System.Diagnostics.TraceEventType values specifying the type of event that has caused the trace.
        /// </summary>
        [DataMember(Name = EventTypePropertyName)]
        public TraceEventType EventType { get; private set; }

        /// <summary>
        /// Gets the text of the trace message.
        /// </summary>
        [DataMember(Name = MessagePropertyName)]
        public string Message { get; private set; } 
        #endregion

        #region Public methods
        /// <summary>
        /// Returns an instance of a <see cref="TraceEventRecord"/> object initialized with the given parameters.
        /// </summary>
        /// <param name="eventCache">Provides trace event data specific to a thread and a process.</param>
        /// <param name="eventSource">The name of the source generated the event.</param>
        /// <param name="eventType">One of the <see cref="System.Diagnostics.TraceEventType"/> values specifying the type of event that has caused the trace.</param>
        /// <param name="eventId">The ID of the trace event.</param>
        /// <param name="message">The text of the trace message.</param>
        /// <returns>The initialized instance of a <see cref="TraceEventRecord"/> object containing trace event details.</returns>
        public static TraceEventRecord Create(TraceEventCache eventCache, string eventSource, TraceEventType eventType, int eventId, string message)
        {
            Guard.ArgumentNotNull(eventCache, "eventCache");
            Guard.ArgumentNotNullOrEmptyString(eventSource, "eventSource");

            TraceEventRecord eventRecord = new TraceEventRecord
            {
                DateTime = DateTime.UtcNow,
                ProcessId = eventCache.ProcessId,
                ThreadId = Convert.ToInt32(eventCache.ThreadId),
                MachineName = Environment.MachineName,
                ProcessName = Process.GetCurrentProcess().ProcessName,
                Timestamp = eventCache.Timestamp,
                EventId = eventId,
                EventSource = eventSource,
                EventType = eventType,
                Message = message
            };

            return eventRecord;
        }

        /// <summary>
        /// Returns an instance of a <see cref="TraceEventRecord"/> object initialized with the given parameters.
        /// </summary>
        /// <param name="eventCache">Provides trace event data specific to a thread and a process.</param>
        /// <param name="eventSource">The name of the source generated the event.</param>
        /// <param name="eventSourceId">The unique identifier of the source generated this event.</param>
        /// <param name="eventType">One of the <see cref="System.Diagnostics.TraceEventType"/> values specifying the type of event that has caused the trace.</param>
        /// <param name="eventId">The ID of the trace event.</param>
        /// <param name="message">The text of the trace message.</param>
        /// <returns>The initialized instance of a <see cref="TraceEventRecord"/> object containing trace event details.</returns>
        public static TraceEventRecord Create(TraceEventCache eventCache, string eventSource, Guid eventSourceId, TraceEventType eventType, int eventId, string message)
        {
            TraceEventRecord eventRecord = Create(eventCache, eventSource, eventType, eventId, message);
            eventRecord.EventSourceId = eventSourceId;

            return eventRecord;
        }

        /// <summary>
        /// Returns an instance of a <see cref="TraceEventRecord"/> object initialized with the given parameters.
        /// </summary>
        /// <param name="eventSource">The name of the source generated the event.</param>
        /// <param name="eventType">One of the <see cref="System.Diagnostics.TraceEventType"/> values specifying the type of event that has caused the trace.</param>
        /// <param name="eventId">The ID of the trace event.</param>
        /// <param name="message">The text of the trace message.</param>
        /// <returns>The initialized instance of a <see cref="TraceEventRecord"/> object containing trace event details.</returns>
        public static TraceEventRecord Create(string eventSource, TraceEventType eventType, int eventId, string message)
        {
            Guard.ArgumentNotNullOrEmptyString(eventSource, "eventSource");

            Process currentProcess = Process.GetCurrentProcess();

            TraceEventRecord eventRecord = new TraceEventRecord
            {
                DateTime = DateTime.UtcNow,
                ProcessId = currentProcess.Id,
                ThreadId = Thread.CurrentThread.ManagedThreadId,
                MachineName = Environment.MachineName,
                ProcessName = currentProcess.ProcessName,
                Timestamp = HighResolutionTimer.CurrentTickCount,
                EventId = eventId,
                EventSource = eventSource,
                EventType = eventType,
                Message = message
            };

            return eventRecord;
        }

        /// <summary>
        /// Returns an instance of a <see cref="TraceEventRecord"/> object initialized with the given parameters.
        /// </summary>
        /// <param name="eventSource">The name of the source generated the event.</param>
        /// <param name="eventSourceId">The unique identifier of the source generated this event.</param>
        /// <param name="eventType">One of the <see cref="System.Diagnostics.TraceEventType"/> values specifying the type of event that has caused the trace.</param>
        /// <param name="eventId">The ID of the trace event.</param>
        /// <param name="message">The text of the trace message.</param>
        /// <returns>The initialized instance of a <see cref="TraceEventRecord"/> object containing trace event details.</returns>
        public static TraceEventRecord Create(string eventSource, Guid eventSourceId, TraceEventType eventType, int eventId, string message)
        {
            TraceEventRecord eventRecord = Create(eventSource, eventType, eventId, message);
            eventRecord.EventSourceId = eventSourceId;

            return eventRecord;
        }

        /// <summary>
        /// Reconstructs an instance of a <see cref="TraceEventRecord"/> object from its XML representation generated by <see cref="System.Runtime.Serialization.DataContractSerializer"/>.
        /// </summary>
        /// <param name="reader">The XML reader supplying the serialized representation of a <see cref="TraceEventRecord"/> object.</param>
        /// <returns>The initialized instance of a <see cref="TraceEventRecord"/> object containing trace event details.</returns>
        public static TraceEventRecord Create(XmlReader reader)
        {
            Guard.ArgumentNotNull(reader, "reader");

            DataContractAttribute dataContractAttr = FrameworkUtility.GetDeclarativeAttribute<DataContractAttribute>(typeof(TraceEventRecord));

            if (dataContractAttr != null)
            {
                XElement eventRecordXml = XElement.Load(reader, LoadOptions.None);

                if (eventRecordXml.Name.LocalName == dataContractAttr.Name && eventRecordXml.Name.Namespace == dataContractAttr.Namespace)
                {
                    XElement childElement;
                    
                    TraceEventRecord eventRecord = new TraceEventRecord
                    {
                        DateTime = (childElement = (from child in eventRecordXml.Descendants(XName.Get(DateTimePropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? DateTime.Parse(childElement.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) : default(DateTime),
                        ProcessId = (childElement = (from child in eventRecordXml.Descendants(XName.Get(ProcessIdPropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? Int32.Parse(childElement.Value, CultureInfo.InvariantCulture) : 0,
                        ThreadId = (childElement = (from child in eventRecordXml.Descendants(XName.Get(ThreadIdPropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? Int32.Parse(childElement.Value, CultureInfo.InvariantCulture) : 0,
                        MachineName = (childElement = (from child in eventRecordXml.Descendants(XName.Get(MachineNamePropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? childElement.Value : null,
                        ProcessName = (childElement = (from child in eventRecordXml.Descendants(XName.Get(ProcessNamePropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? childElement.Value : null,
                        Timestamp = (childElement = (from child in eventRecordXml.Descendants(XName.Get(TimestampPropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? Int64.Parse(childElement.Value, CultureInfo.InvariantCulture) : 0,
                        EventId = (childElement = (from child in eventRecordXml.Descendants(XName.Get(EventIdPropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? Int32.Parse(childElement.Value, CultureInfo.InvariantCulture) : 0,
                        EventSource = (childElement = (from child in eventRecordXml.Descendants(XName.Get(EventSourcePropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? childElement.Value : null,
                        EventSourceId = (childElement = (from child in eventRecordXml.Descendants(XName.Get(EventSourceIdPropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? Guid.Parse(childElement.Value) : Guid.Empty,
                        EventType = (childElement = (from child in eventRecordXml.Descendants(XName.Get(EventTypePropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? (TraceEventType)Enum.Parse(typeof(TraceEventType), childElement.Value, true) : default(TraceEventType),
                        Message = (childElement = (from child in eventRecordXml.Descendants(XName.Get(MessagePropertyName, dataContractAttr.Namespace)) select child).FirstOrDefault()) != null ? childElement.Value : null
                    };

                    return eventRecord;
                }
                else
                {
                    throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, ExceptionMessages.CannotCreateInstanceFromXmlReader, typeof(TraceEventRecord).Name, dataContractAttr.Namespace, eventRecordXml.Name.LocalName, eventRecordXml.Name.Namespace), "reader");
                }
            }
            else
            {
                throw new ArgumentNullException(typeof(DataContractAttribute).FullName);
            }
        }

        /// <summary>
        /// Reconstructs an instance of a <see cref="TraceEventRecord"/> object based on its <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry"/> counterpart from Enterprise Library.
        /// </summary>
        /// <param name="logEntry">A log entry used by the Logging Application Block in Enterprise Library.</param>
        /// <returns>The initialized instance of a <see cref="TraceEventRecord"/> object containing trace event details.</returns>
        public static TraceEventRecord Create(LogEntry logEntry)
        {
            Guard.ArgumentNotNull(logEntry, "logEntry");

            TraceEventRecord eventRecord = new TraceEventRecord
            {
                DateTime = logEntry.TimeStamp,
                ProcessId = Convert.ToInt32(logEntry.ProcessId),
                ThreadId = Convert.ToInt32(logEntry.Win32ThreadId),
                MachineName = logEntry.MachineName,
                ProcessName = logEntry.ProcessName,
                Timestamp = logEntry.TimeStamp.Ticks,
                EventId = logEntry.EventId,
                EventSource = logEntry.Title,
                EventType = logEntry.Severity,
                Message = logEntry.Message
            };

            // Ensure that provider GUID is copied from the extended property collection.
            object propValue = logEntry.ExtendedProperties[InstrumentationUtility.Resources.TracingProviderGuidPropertyName];
            
            if (propValue != null)
            {
                Guid guidValue;

                if(Guid.TryParse(Convert.ToString(propValue), out guidValue))
                {
                    eventRecord.EventSourceId = guidValue;
                }
            }

            return eventRecord;
        }
        #endregion
    }
}
