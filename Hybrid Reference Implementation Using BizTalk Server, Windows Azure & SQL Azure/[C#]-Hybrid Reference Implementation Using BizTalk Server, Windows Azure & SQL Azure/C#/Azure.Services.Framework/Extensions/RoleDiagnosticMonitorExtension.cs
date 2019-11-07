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
namespace Contoso.Cloud.Integration.Azure.Services.Framework.Extensions
{
    #region Using references
    using System;
    using System.ServiceModel;
    using System.Diagnostics;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Diagnostics;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Properties;
    #endregion

    #region IRoleDiagnosticMonitorExtension interface
    /// <summary>
    /// Defines a contract that must be implemented by an extension responsible for abstracting access to the Windows Azure diagnostic infrastructure.
    /// </summary>
    public interface IRoleDiagnosticMonitorExtension : ICloudServiceComponentExtension
    {
    }
    #endregion

    /// <summary>
    /// Implements the extension responsible for abstracting access to the Windows Azure diagnostic infrastructure.
    /// </summary>
    public class RoleDiagnosticMonitorExtension : IRoleDiagnosticMonitorExtension
    {
        #region Private members
        private const int DefaultScheduledTransferPeriodSeconds = 60;
        private const LogLevel DefaultScheduledTransferLogLevel = LogLevel.Error;

        private DiagnosticMonitor diagnosticMonitor;
        #endregion

        #region ICloudServiceComponentExtension implementation
        /// <summary>
        /// Notifies this extension component that it has been registered in the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Attach(IExtensibleCloudServiceComponent owner)
        {
            IRoleConfigurationSettingsExtension roleConfigExtension = owner.Extensions.Find<IRoleConfigurationSettingsExtension>();

            if (roleConfigExtension != null && CloudEnvironment.IsAvailable)
            {
                ApplicationDiagnosticSettings diagnosticSettings = roleConfigExtension.GetSection<ApplicationDiagnosticSettings>(ApplicationDiagnosticSettings.SectionName);
                StorageAccountConfigurationSettings storageSettings = roleConfigExtension.GetSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);

                if (diagnosticSettings != null)
                {
                    if (diagnosticSettings.DiagnosticEnabled)
                    {
                        DiagnosticMonitorConfiguration diagnosticConfig = DiagnosticMonitor.GetDefaultInitialConfiguration();

                        // Configure the scheduled transfer period for all logs.
                        diagnosticConfig.DiagnosticInfrastructureLogs.ScheduledTransferPeriod = diagnosticSettings.DiagnosticLogsTransferPeriod.Coalesce(diagnosticSettings.DefaultTransferPeriod);
                        diagnosticConfig.Directories.ScheduledTransferPeriod = diagnosticSettings.FileLogsTransferPeriod.Coalesce(diagnosticSettings.DefaultTransferPeriod);
                        diagnosticConfig.Logs.ScheduledTransferPeriod = diagnosticSettings.TraceLogsTransferPeriod.Coalesce(diagnosticSettings.DefaultTransferPeriod);
                        diagnosticConfig.PerformanceCounters.ScheduledTransferPeriod = diagnosticSettings.PerformanceCountersTransferPeriod.Coalesce(diagnosticSettings.DefaultTransferPeriod);
                        diagnosticConfig.WindowsEventLog.ScheduledTransferPeriod = diagnosticSettings.EventLogsTransferPeriod.Coalesce(diagnosticSettings.DefaultTransferPeriod);

                        // Configure the logs levels for scheduled transfers.
                        diagnosticConfig.DiagnosticInfrastructureLogs.ScheduledTransferLogLevelFilter = FromTraceSourceLevel(diagnosticSettings.DiagnosticLogsTransferFilter);
                        diagnosticConfig.Logs.ScheduledTransferLogLevelFilter = FromTraceSourceLevel(diagnosticSettings.TraceLogsTransferFilter);
                        diagnosticConfig.WindowsEventLog.ScheduledTransferLogLevelFilter = FromTraceSourceLevel(diagnosticSettings.EventLogsTransferFilter);

                        // Configure the Windows Event Log data sources.
                        foreach (string logName in diagnosticSettings.EventLogDataSources.AllKeys)
                        {
                            diagnosticConfig.WindowsEventLog.DataSources.Add(logName);
                        }

                        // Configure the data sources for file-based logs.
                        foreach (string containerName in diagnosticSettings.FileLogDirectories.AllKeys)
                        {
                            diagnosticConfig.Directories.DataSources.Add(new DirectoryConfiguration() { Container = containerName, Path = diagnosticSettings.FileLogDirectories[containerName].Value });
                        }

                        // Configure the data sources for performance counter data
                        foreach (string counterName in diagnosticSettings.PerformanceCountersDataSources.AllKeys)
                        {
                            diagnosticConfig.PerformanceCounters.DataSources.Add(new PerformanceCounterConfiguration() { CounterSpecifier = counterName, SampleRate = TimeSpan.Parse(diagnosticSettings.PerformanceCountersDataSources[counterName].Value) });
                        }

                        // Configure crash dumps collection.
                        if (diagnosticSettings.CrashDumpCollectionEnabled)
                        {
                            CrashDumps.EnableCollection(true);
                        }

                        // Look up for the storage account definition.
                        StorageAccountInfo storageAccountInfo = storageSettings.Accounts.Get(diagnosticSettings.DiagnosticStorageAccount);

                        if (storageAccountInfo != null)
                        {
                            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey(storageAccountInfo.AccountName, storageAccountInfo.AccountKey), true);
                            RetryPolicy retryPolicy = roleConfigExtension.StorageRetryPolicy;

                            // Start the Azure Diagnostic Monitor using a retryable scope.
                            this.diagnosticMonitor = retryPolicy.ExecuteAction<DiagnosticMonitor>(() => { return DiagnosticMonitor.Start(storageAccount, diagnosticConfig); });
                        }
                    }
                    else
                    {
                        // Do not proceed any further since diagnostic is not enabled in the application configuration.
                        return;
                    }
                }
            }

            if (null == this.diagnosticMonitor)
            {
                // Configuration extension is not available by some reasons, let try and see if DiagnosticsConnectionString property is set in the configuration.
                string diagConnectionString = CloudEnvironment.GetConfigurationSettingValue(Resources.DiagnosticsConnectionStringSettingName);

                // If DiagnosticsConnectionString is defined, start a Diagnostic Monitor using the storage account configuration specified in the setting.
                if (!String.IsNullOrEmpty(diagConnectionString))
                {
                    this.diagnosticMonitor = DiagnosticMonitor.Start(diagConnectionString, GetDiagnosticMonitorDefaultConfiguration());
                }
            }
        }

        /// <summary>
        /// Notifies this extension component that it has been unregistered from the owner's collection of extensions.
        /// </summary>
        /// <param name="owner">The extensible owner object that aggregates this extension.</param>
        public void Detach(IExtensibleCloudServiceComponent owner)
        {
            if (this.diagnosticMonitor != null)
            {
                this.diagnosticMonitor.Shutdown();
            }
        }
        #endregion

        #region Private methods
        private DiagnosticMonitorConfiguration GetDiagnosticMonitorDefaultConfiguration()
        {
            DiagnosticMonitorConfiguration diagConfig = DiagnosticMonitor.GetDefaultInitialConfiguration();

            diagConfig.DiagnosticInfrastructureLogs.ScheduledTransferLogLevelFilter = DefaultScheduledTransferLogLevel;
            diagConfig.DiagnosticInfrastructureLogs.ScheduledTransferPeriod = TimeSpan.FromSeconds(DefaultScheduledTransferPeriodSeconds);

            diagConfig.WindowsEventLog.ScheduledTransferLogLevelFilter = DefaultScheduledTransferLogLevel;
            diagConfig.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromSeconds(DefaultScheduledTransferPeriodSeconds);
            diagConfig.WindowsEventLog.DataSources.Add("Application!*");
            diagConfig.WindowsEventLog.DataSources.Add("System!*");

            diagConfig.Logs.ScheduledTransferLogLevelFilter = DefaultScheduledTransferLogLevel;
            diagConfig.Logs.ScheduledTransferPeriod = TimeSpan.FromSeconds(DefaultScheduledTransferPeriodSeconds);

            return diagConfig;
        } 

        private LogLevel FromTraceSourceLevel(SourceLevels level)
        {
            switch(level)
            {
                case SourceLevels.All:
                    return LogLevel.Undefined;
                case SourceLevels.Critical:
                    return LogLevel.Critical;
                case SourceLevels.Error:
                    return LogLevel.Error;
                case SourceLevels.Information:
                    return LogLevel.Information;
                case SourceLevels.Verbose:
                    return LogLevel.Verbose;
                case SourceLevels.Warning:
                    return LogLevel.Warning;
                default:
                    return LogLevel.Critical;
            }
        }
        #endregion
    }
}
