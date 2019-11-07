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
namespace Contoso.Cloud.Integration.Framework.Configuration
{
    #region Using references
    using System;
    using System.Configuration;
    using System.Diagnostics;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

    using Contoso.Cloud.Integration.Framework;
    #endregion

    /// <summary>
    /// Implements a configuration section containing the application diagnostic settings.
    /// </summary>
    public sealed class ApplicationDiagnosticSettings : SerializableConfigurationSection
    {
        #region Private members
        private const string DiagnosticStorageAccountProperty = "diagnosticStorageAccount";
        private const string DiagnosticEnabledProperty = "diagnosticEnabled";
        private const string DefaultTransferPeriodProperty = "defaultTransferPeriod";
        private const string DefaultTransferFilterProperty = "defaultTransferFilter";
        private const string PerfCountersTransferPeriodProperty = "perfCountersTransferPeriod";
        private const string PerfCountersDataSourcesProperty = "perfCountersDataSources";
        private const string EventLogsTransferPeriodProperty = "eventLogsTransferPeriod";
        private const string EventLogsTransferFilterProperty = "eventLogsTransferFilter";
        private const string EventLogDataSourcesProperty = "eventLogDataSources";
        private const string TraceLogsTransferPeriodProperty = "traceLogsTransferPeriod";
        private const string TraceLogsTransferFilterProperty = "traceLogsTransferFilter";
        private const string FileLogsTransferPeriodProperty = "fileLogsTransferPeriod";
        private const string FileLogDirectoriesProperty = "fileLogDirectories";
        private const string DiagLogsTransferPeriodProperty = "diagLogsTransferPeriod";
        private const string DiagLogsTransferFilterProperty = "diagLogsTransferFilter";
        private const string CrashDumpCollectionEnabledProperty = "crashDumpCollectionEnabled";
        private const string HeartbeatIntervalProperty = "heartbeatInterval";
        #endregion

        #region Public members
        /// <summary>
        /// The name of the configuration section represented by this type.
        /// </summary>
        public const string SectionName = "ApplicationDiagnosticConfiguration"; 
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="ApplicationDiagnosticSettings"/> object with default settings.
        /// </summary>
        public ApplicationDiagnosticSettings()
        {
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the name of the Windows Azure storage account in which diagnostic data will be queued for processing.
        /// </summary>
        [ConfigurationProperty(DiagnosticStorageAccountProperty, IsRequired = true)]
        public string DiagnosticStorageAccount
        {
            get { return (string)base[DiagnosticStorageAccountProperty]; }
            set { base[DiagnosticStorageAccountProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating whether or not collection of diagnostic data is enabled for a given application.
        /// </summary>
        [ConfigurationProperty(DiagnosticEnabledProperty, IsRequired = true, DefaultValue = true)]
        public bool DiagnosticEnabled
        {
            get { return (bool)base[DiagnosticEnabledProperty]; }
            set { base[DiagnosticEnabledProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the value indicating whether or not the collection of application crash dumps (mini dumps or full dumps) is enabled.
        /// </summary>
        [ConfigurationProperty(CrashDumpCollectionEnabledProperty, IsRequired = true, DefaultValue = false)]
        public bool CrashDumpCollectionEnabled
        {
            get { return (bool)base[CrashDumpCollectionEnabledProperty]; }
            set { base[CrashDumpCollectionEnabledProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the default time interval between scheduled transfers of diagnostic data.
        /// </summary>
        [ConfigurationProperty(DefaultTransferPeriodProperty, IsRequired = true, DefaultValue = "01:00:00")]
        public TimeSpan DefaultTransferPeriod
        {
            get { return (TimeSpan)base[DefaultTransferPeriodProperty]; }
            set { base[DefaultTransferPeriodProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the default level of trace messages by which to filter records when performing a scheduled transfer.
        /// </summary>
        [ConfigurationProperty(DefaultTransferFilterProperty, IsRequired = true, DefaultValue = SourceLevels.Error)]
        public SourceLevels DefaultTransferFilter
        {
            get 
            { 
                return (SourceLevels)base[DefaultTransferFilterProperty]; 
            }
            set 
            { 
                base[DefaultTransferFilterProperty] = value;

                // Update the transfer filter for all log types.
                EventLogsTransferFilter = value;
                TraceLogsTransferFilter = value;
                DiagnosticLogsTransferFilter = value;
            }
        }

        /// <summary>
        /// Gets or sets the interval between scheduled transfers of performance counters.
        /// </summary>
        [ConfigurationProperty(PerfCountersTransferPeriodProperty, IsRequired = false)]
        public TimeSpan PerformanceCountersTransferPeriod
        {
            get { return (TimeSpan)base[PerfCountersTransferPeriodProperty]; }
            set { base[PerfCountersTransferPeriodProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the interval between scheduled transfers of event log entries.
        /// </summary>
        [ConfigurationProperty(EventLogsTransferPeriodProperty, IsRequired = false)]
        public TimeSpan EventLogsTransferPeriod
        {
            get { return (TimeSpan)base[EventLogsTransferPeriodProperty]; }
            set { base[EventLogsTransferPeriodProperty] = value; }
        }

        /// <summary>
        /// Gets or sets a logging level by which to filter records when performing a scheduled transfer of event log entries.
        /// </summary>
        [ConfigurationProperty(EventLogsTransferFilterProperty, IsRequired = false)]
        public SourceLevels EventLogsTransferFilter
        {
            get { return (SourceLevels)base[EventLogsTransferFilterProperty]; }
            set { base[EventLogsTransferFilterProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the interval between scheduled transfers of trace logs.
        /// </summary>
        [ConfigurationProperty(TraceLogsTransferPeriodProperty, IsRequired = false)]
        public TimeSpan TraceLogsTransferPeriod
        {
            get { return (TimeSpan)base[TraceLogsTransferPeriodProperty]; }
            set { base[TraceLogsTransferPeriodProperty] = value; }
        }

        /// <summary>
        /// Gets or sets a logging level by which to filter records when performing a scheduled transfer of trace logs.
        /// </summary>
        [ConfigurationProperty(TraceLogsTransferFilterProperty, IsRequired = false)]
        public SourceLevels TraceLogsTransferFilter
        {
            get { return (SourceLevels)base[TraceLogsTransferFilterProperty]; }
            set { base[TraceLogsTransferFilterProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the interval between scheduled transfers of file-based logs defined by the developer.
        /// </summary>
        [ConfigurationProperty(FileLogsTransferPeriodProperty, IsRequired = false)]
        public TimeSpan FileLogsTransferPeriod
        {
            get { return (TimeSpan)base[FileLogsTransferPeriodProperty]; }
            set { base[FileLogsTransferPeriodProperty] = value; }
        }

        /// <summary>
        /// Gets or sets the interval between scheduled transfers of the logs generated by the underlying
        /// diagnostics infrastructure. The diagnostic infrastructure logs are useful for troubleshooting 
        /// the diagnostics system itself.
        /// </summary>
        [ConfigurationProperty(DiagLogsTransferPeriodProperty, IsRequired = false)]
        public TimeSpan DiagnosticLogsTransferPeriod
        {
            get { return (TimeSpan)base[DiagLogsTransferPeriodProperty]; }
            set { base[DiagLogsTransferPeriodProperty] = value; }
        }

        /// <summary>
        /// Gets or sets a logging level by which to filter records when performing a scheduled transfer of
        /// the logs generated by the underlying diagnostics infrastructure.
        /// </summary>
        [ConfigurationProperty(DiagLogsTransferFilterProperty, IsRequired = false)]
        public SourceLevels DiagnosticLogsTransferFilter
        {
            get { return (SourceLevels)base[DiagLogsTransferFilterProperty]; }
            set { base[DiagLogsTransferFilterProperty] = value; }
        }

        /// <summary>
        /// Gets a list of configured data sources for Windows event logs.
        /// </summary>
        [ConfigurationProperty(EventLogDataSourcesProperty, IsRequired = true)]
        public NameValueConfigurationCollection EventLogDataSources
        {
            get { return (NameValueConfigurationCollection)base[EventLogDataSourcesProperty]; }
        }

        /// <summary>
        /// Gets a list of configured directories for file-based logs.
        /// </summary>
        [ConfigurationProperty(FileLogDirectoriesProperty, IsRequired = true)]
        public NameValueConfigurationCollection FileLogDirectories
        {
            get { return (NameValueConfigurationCollection)base[FileLogDirectoriesProperty]; }
        }

        /// <summary>
        /// Gets a list of configurations for performance counters that are being collected.
        /// </summary>
        [ConfigurationProperty(PerfCountersDataSourcesProperty, IsRequired = true)]
        public NameValueConfigurationCollection PerformanceCountersDataSources
        {
            get { return (NameValueConfigurationCollection)base[PerfCountersDataSourcesProperty]; }
        }

        /// <summary>
        /// Gets or sets the time interval for heartbeats emitted by worker role instances.
        /// </summary>
        [ConfigurationProperty(HeartbeatIntervalProperty, IsRequired = false)]
        public TimeSpan HeartbeatInterval
        {
            get { return (TimeSpan)base[HeartbeatIntervalProperty]; }
            set { base[HeartbeatIntervalProperty] = value; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Enables the collection of diagnostic data for this application.
        /// </summary>
        public void EnableDiagnostic()
        {
            DiagnosticEnabled = true;
        }

        /// <summary>
        /// Disables the collection of diagnostic data for this application.
        /// </summary>
        public void DisableDiagnostic()
        {
            DiagnosticEnabled = false;
        }

        /// <summary>
        /// Enables the collection of application crash dumps (mini dumps or full dumps) for this application.
        /// </summary>
        public void EnableCrashDumpCollection()
        {
            CrashDumpCollectionEnabled = true;
        }

        /// <summary>
        /// Disables the collection of application crash dumps (mini dumps or full dumps) for this application.
        /// </summary>
        public void DisableCrashDumpCollection()
        {
            CrashDumpCollectionEnabled = false;
        }

        /// <summary>
        /// Sets the default time interval between scheduled transfers of diagnostic data for the specified number of seconds.
        /// </summary>
        /// <param name="value">The number of seconds between scheduled transfers.</param>
        public void SetDefaultTransferPeriodInSeconds(int value)
        {
            Guard.ArgumentNotZeroOrNegativeValue(value, "value");

            DefaultTransferPeriod = TimeSpan.FromSeconds(value);
        }

        /// <summary>
        /// Sets the default time interval between scheduled transfers of diagnostic data for the specified number of minutes.
        /// </summary>
        /// <param name="value">The number of minutes between scheduled transfers.</param>
        public void SetDefaultTransferPeriodInMinutes(int value)
        {
            Guard.ArgumentNotZeroOrNegativeValue(value, "value");

            DefaultTransferPeriod = TimeSpan.FromMinutes(value);
        }

        /// <summary>
        /// Sets the default time interval between scheduled transfers of diagnostic data for the specified number of hours.
        /// </summary>
        /// <param name="value">The number of hours between scheduled transfers.</param>
        public void SetDefaultTransferPeriodInHours(int value)
        {
            Guard.ArgumentNotZeroOrNegativeValue(value, "value");

            DefaultTransferPeriod = TimeSpan.FromHours(value);
        }

        /// <summary>
        /// Sets the time interval for heartbeats emitted by worker role instances for the specified number of seconds.
        /// </summary>
        /// <param name="value">The heartbeat interval expressed in seconds.</param>
        public void SetDefaultHeartbeatIntervalInSeconds(int value)
        {
            Guard.ArgumentNotZeroOrNegativeValue(value, "value");

            HeartbeatInterval = TimeSpan.FromSeconds(value);
        }

        /// <summary>
        /// Adds a new source into the list of configured data sources for Windows event log data transfers.
        /// </summary>
        /// <param name="logName">The event log source to be included into scheduled transfers.</param>
        public void AddEventLogDataSource(string logName)
        {
            Guard.ArgumentNotNullOrEmptyString(logName, "logName");

            EventLogDataSources.Add(new NameValueConfigurationElement(logName, String.Empty));
        }

        /// <summary>
        /// Adds a new path into the list of configured directories for file-based log data transfers.
        /// </summary>
        /// <param name="containerName">The name of a container defined in a storage account where the contents of file-based logs are to be transferred.</param>
        /// <param name="path">The absolute path for the local directory to which file-based logs are being written.</param>
        public void AddFileLogDirectory(string containerName, string path)
        {
            Guard.ArgumentNotNullOrEmptyString(path, "path");
            Guard.ArgumentNotNullOrEmptyString(containerName, "containerName");

            FileLogDirectories.Add(new NameValueConfigurationElement(containerName, path));
        }

        /// <summary>
        /// Adds a new performance counter into the list of configurations for performance counters that are being collected.
        /// </summary>
        /// <param name="counterName">The performance counter specifier using standard Windows counter syntax.</param>
        /// <param name="sampleRate">The rate at which to sample the performance counter, rounded up to the nearest second.</param>
        public void AddPerformanceCounter(string counterName, TimeSpan sampleRate)
        {
            Guard.ArgumentNotNullOrEmptyString(counterName, "counterName");

            PerformanceCountersDataSources.Add(new NameValueConfigurationElement(counterName, sampleRate.ToString()));
        }
        #endregion
    }
}