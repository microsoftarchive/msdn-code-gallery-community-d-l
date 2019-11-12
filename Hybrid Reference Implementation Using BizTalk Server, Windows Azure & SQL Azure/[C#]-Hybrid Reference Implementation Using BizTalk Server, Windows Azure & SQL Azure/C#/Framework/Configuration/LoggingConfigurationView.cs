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
    using System.IO;
    using System.Diagnostics;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Database.Configuration;

    using Contoso.Cloud.Integration.Framework.Properties;
    using Contoso.Cloud.Integration.Framework.Logging;
    #endregion

    /// <summary>
    /// Wraps the Enterprise Library's Logging Application Block configuration and provides simplified operations with the underlying configuration data.
    /// </summary>
    public class LoggingConfigurationView
    {
        #region Private members
        private readonly LoggingSettings loggingSettings;
        private readonly object formatterLock = new object();
        private readonly object listenerLock = new object();
        private readonly object traceSourceLock = new object();
        #endregion

        #region Public members
        /// <summary>
        /// Returns the default name of the formatting database trace listener.
        /// </summary>
        public readonly static string FormattedDatabaseTraceListenerName = Resources.FormattedDatabaseTraceListenerName;

        /// <summary>
        /// Returns the default name of the formatting debugging trace listener.
        /// </summary>
        public readonly static string FormattedDebugTraceListenerName = Resources.FormattedDebugTraceListenerName;

        /// <summary>
        /// Returns the default name of the rolling flat file trace listener.
        /// </summary>
        public readonly static string RollingFlatFileTraceListenerName = Resources.RollingFlatFileTraceListenerName;

        /// <summary>
        /// Returns the default name of the trace log-based trace listener.
        /// </summary>
        public readonly static string TraceLogTraceListenerName = Resources.TraceLogTraceListenerName;

        /// <summary>
        /// Returns the default name of the event log-based trace listener.
        /// </summary>
        public readonly static string EventLogTraceListenerName = Resources.EventLogTraceListenerName;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="LoggingConfigurationView"/> object based on the specified <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings"/>.
        /// </summary>
        /// <param name="loggingSettings">The configuration data for the Logging Application Block.</param>
        public LoggingConfigurationView(LoggingSettings loggingSettings)
        {
            Guard.ArgumentNotNull(loggingSettings, "loggingSettings");

            this.loggingSettings = loggingSettings;

            ApplyDefaultGlobalSettings();
            ApplyDefaultFormatters();
            ApplyDefaultTraceListener();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns the <see cref="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings"/> object
        /// wrapped by this instance.
        /// </summary>
        public LoggingSettings Settings
        {
            get { return this.loggingSettings; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds a new trace listener associated with an unique name and a type containing the implementation.
        /// </summary>
        /// <param name="name">The unique name under which a new trace listener will be added to the collection.</param>
        /// <param name="listenerTypeName">The fully qualified type name implementing the new trace listener.</param>
        public void AddTraceListener(string name, string listenerTypeName)
        {
            AddTraceListener(name, Type.GetType(listenerTypeName, true));
        }

        /// <summary>
        /// Adds a new trace listener associated with a type containing the implementation. The fully qualified type name will be
        /// used for assigning the unique name for the new trace listener.
        /// </summary>
        /// <param name="listenerType">The type implementing the new trace listener.</param>
        public void AddTraceListener(Type listenerType)
        {
            AddTraceListener(listenerType.Name, listenerType);
        }

        /// <summary>
        /// Adds a new trace listener associated with an unique name and a type containing the implementation.
        /// </summary>
        /// <param name="name">The unique name under which a new trace listener will be added to the collection.</param>
        /// <param name="listenerType">The type implementing the new trace listener.</param>
        public void AddTraceListener(string name, Type listenerType)
        {
            Guard.ArgumentNotNullOrEmptyString(name, "name");
            Guard.ArgumentNotNull(listenerType, "listenerType");

            ConfigurationElementTypeAttribute configElementTypeAttr = FrameworkUtility.GetDeclarativeAttribute<ConfigurationElementTypeAttribute>(listenerType);

            if (configElementTypeAttr != null)
            {
                TraceListenerData listenerData = Activator.CreateInstance(configElementTypeAttr.ConfigurationType) as TraceListenerData;

                if (listenerData != null)
                {
                    listenerData.ListenerDataType = configElementTypeAttr.ConfigurationType;
                    listenerData.Name = name;
                    listenerData.Type = listenerType;

                    this.loggingSettings.TraceListeners.Add(listenerData);
                }
            }
        }

        /// <summary>
        /// Configures the Event Log trace listener with the specified machine name, log name and log source.
        /// </summary>
        /// <param name="machineName">The machine name.</param>
        /// <param name="logName">The event log name.</param>
        /// <param name="logSource">The event log source name.</param>
        public void ConfigureEventLogTraceListener(string machineName, string logName, string logSource)
        {
            if (this.loggingSettings.TraceListeners.Contains(Resources.EventLogTraceListenerName))
            {
                FormattedEventLogTraceListenerData eventLogData = this.loggingSettings.TraceListeners.Get(Resources.EventLogTraceListenerName) as FormattedEventLogTraceListenerData;

                if (eventLogData != null)
                {
                    if (!String.IsNullOrEmpty(machineName))
                    {
                        eventLogData.MachineName = machineName;
                    }

                    if (!String.IsNullOrEmpty(logName))
                    {
                        eventLogData.Log = logName;
                    }

                    if (!String.IsNullOrEmpty(logSource))
                    {
                        eventLogData.Source = logSource;
                    }
                }
            }
        }

        /// <summary>
        /// Configures the Rolling Flat File trace listener with the specified file name and parameters.
        /// </summary>
        /// <param name="fileName">The log file name.</param>
        /// <param name="maxArchivedFiles">The maximum number of archived files to keep.</param>
        /// <param name="rollSizeKB">The maximum file size (KB) before rolling.</param>
        public void ConfigureRollingFlatFileTraceListener(string fileName, int maxArchivedFiles, int rollSizeKB)
        {
            if (this.loggingSettings.TraceListeners.Contains(Resources.RollingFlatFileTraceListenerName))
            {
                RollingFlatFileTraceListenerData listenerData = this.loggingSettings.TraceListeners.Get(Resources.RollingFlatFileTraceListenerName) as RollingFlatFileTraceListenerData;

                if (listenerData != null)
                {
                    if (!String.IsNullOrEmpty(fileName))
                    {
                        string filePath = Path.GetDirectoryName(fileName);

                        if (String.IsNullOrEmpty(filePath))
                        {
                            filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                        }

                        listenerData.FileName = Path.Combine(filePath, Path.GetFileName(fileName));
                    }

                    if (maxArchivedFiles > 0)
                    {
                        listenerData.MaxArchivedFiles = maxArchivedFiles;
                    }

                    if (rollSizeKB > 0)
                    {
                        listenerData.RollSizeKB = rollSizeKB;
                    }
                }
            }
        }

        /// <summary>
        /// Configures the email-based trace listener with custom SMTP server configuration.
        /// </summary>
        /// <param name="serverName">The SMTP server to use to send messages.</param>
        /// <param name="serverPort">The SMTP port.</param>
        /// <param name="userName">User name when authenticating with user name and password.</param>
        /// <param name="password">Password when authenticating with user name and password.</param>
        /// <param name="useSsl">A flag indicating whether or not it is required to use SSL when connecting to the SMTP server.</param>
        public void ConfigureEmailTraceListenerSmtpServer(string serverName, int serverPort, string userName, string password, bool useSsl)
        {
            if (this.loggingSettings.TraceListeners.Contains(Resources.EmailTraceListenerName))
            {
                EmailTraceListenerData listenerData = this.loggingSettings.TraceListeners.Get(Resources.EmailTraceListenerName) as EmailTraceListenerData;

                if (listenerData != null)
                {
                    listenerData.SmtpServer = serverName;
                    listenerData.SmtpPort = 25;
                    listenerData.UserName = userName;
                    listenerData.Password = password;
                    listenerData.UseSSL = useSsl;
                }
            }
        }

        /// <summary>
        /// Configures the email-based trace listener with custom address information.
        /// </summary>
        /// <param name="fromAddress">Email address that messages will be sent from.</param>
        /// <param name="toAddress">One or more email semicolon separated addresses.</param>
        public void ConfigureEmailTraceListener(string fromAddress, string toAddress)
        {
            if (this.loggingSettings.TraceListeners.Contains(Resources.EmailTraceListenerName))
            {
                EmailTraceListenerData listenerData = this.loggingSettings.TraceListeners.Get(Resources.EmailTraceListenerName) as EmailTraceListenerData;

                if (listenerData != null)
                {
                    listenerData.FromAddress = fromAddress;
                    listenerData.ToAddress = toAddress;
                }
            }
        }

        /// <summary>
        /// Configures the database trace listener with custom database instance information.
        /// </summary>
        /// <param name="databaseInstanceName">The database instance name.</param>
        public void ConfigureDatabaseTraceListener(string databaseInstanceName)
        {
            if (this.loggingSettings.TraceListeners.Contains(Resources.FormattedDatabaseTraceListenerName))
            {
                FormattedDatabaseTraceListenerData listenerData = this.loggingSettings.TraceListeners.Get(Resources.FormattedDatabaseTraceListenerName) as FormattedDatabaseTraceListenerData;

                if (listenerData != null)
                {
                    listenerData.DatabaseInstanceName = databaseInstanceName;
                }
            }
        }

        /// <summary>
        /// Configures the specified trace listener and assigns a new value to its configuration property. In order to support this generic configuration facility,
        /// the trace listener type must implement the <see cref="IConfigurableConfigurationElement"/> interface.
        /// </summary>
        /// <param name="listenerName">The name under which a trace listener is registered in the collection.</param>
        /// <param name="propertyName">The name of the configuration property.</param>
        /// <param name="propertyValue">The new value that will be set on the specified configuration property.</param>
        public void ConfigureTraceListenerProperty(string listenerName, string propertyName, object propertyValue)
        {
            IConfigurableConfigurationElement configurableElement = this.loggingSettings.TraceListeners.Get(listenerName) as IConfigurableConfigurationElement;

            if (configurableElement != null)
            {
                configurableElement.SetPropertyValue(propertyName, propertyValue);
            }
        }

        /// <summary>
        /// Enables the specified trace listener for a given log source and its associated trace level.
        /// </summary>
        /// <param name="listenerName">The name under which a trace listener is registered in the collection.</param>
        /// <param name="categoryName">The name for the represented log source.</param>
        /// <param name="traceLevel">The trace level for the represented log source.</param>
        public void EnableListenerForEventCategory(string listenerName, string categoryName, SourceLevels traceLevel)
        {
            TraceSourceData traceSource = null;

            if (this.loggingSettings.TraceSources.Contains(categoryName))
            {
                traceSource = this.loggingSettings.TraceSources.Get(categoryName);
            }
            else 
            {
                lock (this.traceSourceLock)
                {
                    if (!this.loggingSettings.TraceSources.Contains(categoryName))
                    {
                        traceSource = new TraceSourceData(categoryName, traceLevel, false);
                        this.loggingSettings.TraceSources.Add(traceSource);
                    }
                }
            }

            traceSource.TraceListeners.Add(new TraceListenerReferenceData(listenerName));
        }
        #endregion

        #region Private methods
        private void ApplyDefaultFormatters()
        {
            AddFormatter(Resources.TraceLogTextFormatterName, Resources.TraceLogTextFormatterTemplate);
            AddFormatter(Resources.EventLogTextFormatterName, Resources.EventLogTextFormatterTemplate);
        }

        private void AddFormatter(string formatterName, string templateName)
        {
            if (!this.loggingSettings.Formatters.Contains(formatterName))
            {
                lock (this.formatterLock)
                {
                    if (!this.loggingSettings.Formatters.Contains(formatterName))
                    {
                        TextFormatterData textTextFormatter = new TextFormatterData();

                        textTextFormatter.Name = formatterName;
                        textTextFormatter.Template = templateName;

                        this.loggingSettings.Formatters.Add(textTextFormatter);
                    }
                }
            }
        }

        private void ApplyDefaultTraceListener()
        {
            if (!this.loggingSettings.TraceListeners.Contains(Resources.FormattedDebugTraceListenerName))
            {
                lock (this.listenerLock)
                {
                    if (!this.loggingSettings.TraceListeners.Contains(Resources.FormattedDebugTraceListenerName))
                    {
                        CustomTraceListenerData listenerData = new CustomTraceListenerData();

                        listenerData.Formatter = Resources.TraceLogTextFormatterName;
                        listenerData.Type = typeof(FormattedDebugTraceListener);
                        listenerData.Name = Resources.FormattedDebugTraceListenerName;
                        listenerData.TraceOutputOptions = TraceOptions.None;
                        listenerData.Filter = SourceLevels.All;

                        this.loggingSettings.TraceListeners.Add(listenerData);
                    }
                }
            }

            if (!this.loggingSettings.TraceListeners.Contains(Resources.TraceLogTraceListenerName))
            {
                lock (this.listenerLock)
                {
                    if (!this.loggingSettings.TraceListeners.Contains(Resources.TraceLogTraceListenerName))
                    {
                        CustomTraceListenerData listenerData = new CustomTraceListenerData();

                        listenerData.Formatter = Resources.TraceLogTextFormatterName;
                        listenerData.Type = typeof(FormattedTextWriterTraceListener);
                        listenerData.Name = Resources.TraceLogTraceListenerName;
                        listenerData.TraceOutputOptions = TraceOptions.None;
                        listenerData.Filter = SourceLevels.All;

                        this.loggingSettings.TraceListeners.Add(listenerData);
                    }
                }
            }

            if (!this.loggingSettings.TraceListeners.Contains(Resources.EventLogTraceListenerName))
            {
                lock (this.listenerLock)
                {
                    if (!this.loggingSettings.TraceListeners.Contains(Resources.EventLogTraceListenerName))
                    {
                        FormattedEventLogTraceListenerData listenerData = new FormattedEventLogTraceListenerData();

                        listenerData.Formatter = Resources.EventLogTextFormatterName;
                        listenerData.Type = typeof(FormattedEventLogTraceListener);
                        listenerData.Name = Resources.EventLogTraceListenerName;
                        listenerData.MachineName = ".";
                        listenerData.Source = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
                        listenerData.Log = Resources.DefaultEventLogTraceListenerLogName;

                        this.loggingSettings.TraceListeners.Add(listenerData);
                    }
                }
            }

            if (!this.loggingSettings.TraceListeners.Contains(Resources.RollingFlatFileTraceListenerName))
            {
                lock (this.listenerLock)
                {
                    if (!this.loggingSettings.TraceListeners.Contains(Resources.RollingFlatFileTraceListenerName))
                    {
                        RollingFlatFileTraceListenerData listenerData = new RollingFlatFileTraceListenerData();

                        listenerData.Name = Resources.RollingFlatFileTraceListenerName;
                        listenerData.Formatter = Resources.TraceLogTextFormatterName;
                        listenerData.FileName = Path.ChangeExtension(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, ".log");
                        listenerData.Footer = String.Empty;
                        listenerData.Header = String.Empty;
                        listenerData.TimeStampPattern = Resources.RollingFlatFileTraceListenerTimeStampPattern;
                        listenerData.MaxArchivedFiles = 10;
                        listenerData.RollFileExistsBehavior = RollFileExistsBehavior.Increment;
                        listenerData.RollSizeKB = 10240;
                        
                        this.loggingSettings.TraceListeners.Add(listenerData);
                    }
                }
            }

            if (!this.loggingSettings.TraceListeners.Contains(Resources.EmailTraceListenerName))
            {
                lock (this.listenerLock)
                {
                    if (!this.loggingSettings.TraceListeners.Contains(Resources.EmailTraceListenerName))
                    {
                        EmailTraceListenerData listenerData = new EmailTraceListenerData();

                        listenerData.Name = Resources.EmailTraceListenerName;
                        listenerData.AuthenticationMode = EmailAuthenticationMode.UserNameAndPassword;
                        listenerData.Formatter = Resources.EventLogTextFormatterName;
                        listenerData.SmtpPort = 25;

                        this.loggingSettings.TraceListeners.Add(listenerData);
                    }
                }
            }

            if (!this.loggingSettings.TraceListeners.Contains(Resources.FormattedDatabaseTraceListenerName))
            {
                lock (this.listenerLock)
                {
                    if (!this.loggingSettings.TraceListeners.Contains(Resources.FormattedDatabaseTraceListenerName))
                    {
                        FormattedDatabaseTraceListenerData listenerData = new FormattedDatabaseTraceListenerData();

                        listenerData.Name = Resources.FormattedDatabaseTraceListenerName;
                        listenerData.AddCategoryStoredProcName = SqlCommandResources.AddCategoryStoredProcName;
                        listenerData.WriteLogStoredProcName = SqlCommandResources.WriteLogStoredProcName;

                        this.loggingSettings.TraceListeners.Add(listenerData);
                    }
                }
            }
        }

        private void ApplyDefaultGlobalSettings()
        {
            this.loggingSettings.DefaultCategory = Resources.DefaultLoggingCategory;
            this.loggingSettings.TracingEnabled = true;
            this.loggingSettings.LogWarningWhenNoCategoriesMatch = true;

            EnableListenerForEventCategory(FormattedDebugTraceListenerName, Resources.DefaultLoggingCategory, SourceLevels.All);
        }
        #endregion
    }
}
