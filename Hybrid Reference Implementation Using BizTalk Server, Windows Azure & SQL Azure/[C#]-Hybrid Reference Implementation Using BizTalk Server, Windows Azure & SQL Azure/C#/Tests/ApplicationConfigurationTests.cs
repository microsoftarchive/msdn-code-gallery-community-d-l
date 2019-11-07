//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The test library contains a set of general unit tests.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Tests
{
    #region Using statements
    using System;
    using System.Xml;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.Configuration;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Data;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Common;
    using Contoso.Cloud.Integration.BizTalk.Core.Configuration;
    using Contoso.Cloud.Integration.BizTalk.Core;
    using Contoso.Cloud.Integration.BizTalk.Core.Logging;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Logging;
    using Contoso.Cloud.Integration.Azure.Services.WorkItemScheduler.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    #endregion

    /// <summary>
    /// Summary description for ApplicationConfigurationTests
    /// </summary>
    [TestClass]
    public class ApplicationConfigurationTests
    {
        public ApplicationConfigurationTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ValidateDatabaseSettings()
        {
            ApplicationConfiguration appConfig = ApplicationConfiguration.Current;

            Assert.IsTrue(ApplicationConfiguration.IsLoaded);

            RulesEngineConfigurationSource rulesConfigStore = ApplicationConfiguration.Current.Source as RulesEngineConfigurationSource;

            Assert.IsNotNull(rulesConfigStore, "Config store is not RulesEngineConfigurationSource");
            Assert.IsFalse(String.IsNullOrEmpty(rulesConfigStore.PolicyName), "PolicyName is not specified");

            Assert.IsFalse(String.IsNullOrEmpty(ApplicationConfiguration.Current.Databases.DefaultDatabase), "Default database is not specified");
            Assert.AreEqual("GCOM_Partition_Metadata", ApplicationConfiguration.Current.Databases.DefaultDatabase, "Wrong name of default database");

            Assert.IsFalse(String.IsNullOrEmpty(ApplicationConfiguration.Current.Databases.ConnectionStrings[WellKnownDatabaseName.PartitionMetadata]), "PartitionMetadata database connection string is not specified");
            Assert.IsFalse(String.IsNullOrEmpty(ApplicationConfiguration.Current.Databases.ConnectionStrings[WellKnownDatabaseName.PersistenceQueue]), "PersistenceQueue database connection string is not specified");
        }

        [TestMethod]
        public void ValidateServiceBusSettings()
        {
            ApplicationConfiguration appConfig = ApplicationConfiguration.Current;

            Assert.IsTrue(ApplicationConfiguration.IsLoaded);

            ServiceBusConfigurationSettings sbSettings = appConfig.GetConfigurationSection<ServiceBusConfigurationSettings>(ServiceBusConfigurationSettings.SectionName);

            Assert.IsNotNull(sbSettings, "No ServiceBusSettings section was found");
            Assert.IsFalse(String.IsNullOrEmpty(sbSettings.DefaultEndpoint), "DefaultEndpoint not specified");
            Assert.IsFalse(String.IsNullOrEmpty(sbSettings.DefaultIssuerName), "DefaultIssuerName not specified");
            Assert.IsFalse(String.IsNullOrEmpty(sbSettings.DefaultIssuerSecret), "DefaultIssuerSecret not specified");
            Assert.IsTrue(sbSettings.Endpoints != null && sbSettings.Endpoints.Count > 0, "Endpoints collection is empty");

            ServiceBusEndpointInfo firstEndpoint = sbSettings.Endpoints.Get(0);

            Assert.IsNotNull(firstEndpoint, "First endpoint is null");
            Assert.IsFalse(String.IsNullOrEmpty(firstEndpoint.Name), "Element name not specified");
            Assert.IsFalse(String.IsNullOrEmpty(firstEndpoint.ServiceNamespace), "ServiceNamespace not specified");
            Assert.IsFalse(String.IsNullOrEmpty(firstEndpoint.ServicePath), "ServicePath not specified");
            Assert.IsFalse(String.IsNullOrEmpty(firstEndpoint.IssuerName), "IssuerName not specified");
            Assert.IsFalse(String.IsNullOrEmpty(firstEndpoint.IssuerSecret), "IssuerSecret not specified");

            ServiceBusEndpointInfo secondEndpoint = sbSettings.Endpoints.Get(1);

            Assert.IsNotNull(secondEndpoint, "First endpoint is null");
            Assert.IsFalse(String.IsNullOrEmpty(secondEndpoint.Name), "Element name not specified");
            Assert.IsFalse(String.IsNullOrEmpty(secondEndpoint.ServiceNamespace), "ServiceNamespace not specified");
            Assert.IsFalse(String.IsNullOrEmpty(secondEndpoint.ServicePath), "ServicePath not specified");
            // Assert.IsFalse(String.IsNullOrEmpty(secondEndpoint.IssuerName), "IssuerName not specified");
            // Assert.IsFalse(String.IsNullOrEmpty(secondEndpoint.IssuerSecret), "IssuerSecret not specified");
        }

        [TestMethod]
        public void ValidateApplicationDiagnosticSettings()
        {
            ApplicationConfiguration appConfig = ApplicationConfiguration.Current;

            Assert.IsTrue(ApplicationConfiguration.IsLoaded);

            ApplicationDiagnosticSettings loggingSettings = appConfig.GetConfigurationSection<ApplicationDiagnosticSettings>(ApplicationDiagnosticSettings.SectionName);

            //loggingSettings.AddEventLogDataSource("Application!*");
            //loggingSettings.AddEventLogDataSource("System!*");
            //loggingSettings.AddFileLogDirectory("blob1", @"C:\Program Files\");
            //loggingSettings.AddFileLogDirectory("blob2", @"C:\Windows\Logs\");
            //loggingSettings.AddPerformanceCounter(@"\Processor(*)\% Processor Time", TimeSpan.FromSeconds(30));
            //loggingSettings.AddPerformanceCounter(@"\Memory\Available Mbytes", TimeSpan.FromSeconds(120));

            Assert.IsNotNull(loggingSettings, "No ApplicationDiagnosticSettings section was found");

            StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            loggingSettings.WriteXml(xmlWriter);

            string configSectionText = sw.GetStringBuilder().ToString();

            Assert.IsTrue(configSectionText.Length > 0);
        }

        [TestMethod]
        public void TestLoggingConfigurationView()
        {
            LoggingSettings loggingSettings = new LoggingSettings();
            LoggingConfigurationView loggingConfigView = new LoggingConfigurationView(loggingSettings);

            loggingConfigView.ConfigureEventLogTraceListener("VALERYM-BTS2010", "MyLog", "MySource");
            loggingConfigView.ConfigureRollingFlatFileTraceListener("MyLog.log", 5, 1000000);
            loggingConfigView.ConfigureEmailTraceListenerSmtpServer("exchangebox", 50, "smtpuser", "smtpsecret", false);
            loggingConfigView.ConfigureEmailTraceListener("from@domain.com", "recepient@domain.com");
            loggingConfigView.ConfigureDatabaseTraceListener("MyLoggingDB");
            loggingConfigView.AddTraceListener(typeof(FormattedEtwTraceListener));

            loggingConfigView.EnableListenerForEventCategory(LoggingConfigurationView.FormattedDebugTraceListenerName, "ApplicationError", SourceLevels.All);

            StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            loggingSettings.WriteXml(xmlWriter);

            string configSectionText = sw.GetStringBuilder().ToString();

            Assert.IsTrue(configSectionText.Length > 0);

            /*
            IConfigurationSource configSource = ConfigurationSourceFactory.Create();
            LoggingSettings loggingConfig = configSource.GetSection(LoggingSettings.SectionName) as LoggingSettings;

            LoggingConfigurationView loggingConfigView = new LoggingConfigurationView(loggingConfig);

            loggingConfigView.ConfigureEventLogTraceListener(".", "Application", ConfigurationManager.AppSettings["EvtSource"]);
            loggingConfigView.ConfigureRollingFlatFileTraceListener(ConfigurationManager.AppSettings["LogFileName"], 5, 1000000);
            loggingConfigView.AddTraceListener("EtwTraceListener", typeof(FormattedEtwTraceListener));

            loggingConfigView.EnableListenerForEventCategory("EtwTraceListener", "ApplicationErrors", SourceLevels.All);
             * */
        }

        [TestMethod]
        public void TestLoadLoggingConfiguration()
        {
            ApplicationConfiguration appConfig = ApplicationConfiguration.Current;
            Assert.IsTrue(ApplicationConfiguration.IsLoaded);

            LoggingSettings loggingSettings = appConfig.GetConfigurationSection<LoggingSettings>(LoggingSettings.SectionName);
            Assert.IsNotNull(loggingSettings, "No LoggingSettings section was found");
            Assert.IsTrue(loggingSettings.TraceListeners.Count > 0, "TraceListeners collection is empty");
            Assert.IsTrue(loggingSettings.Formatters.Count > 0, "Formatters collection is empty");
            Assert.IsTrue(loggingSettings.TraceSources.Count > 0, "Formatters collection is empty");

            StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            loggingSettings.WriteXml(xmlWriter);

            string configSectionText = sw.GetStringBuilder().ToString();
            Assert.IsTrue(configSectionText.Length > 0);
        }

        [TestMethod]
        public void TestRetryPolicyConfigurationSettings()
        {
            ApplicationConfiguration appConfig = ApplicationConfiguration.Current;
            Assert.IsTrue(ApplicationConfiguration.IsLoaded);

            RetryPolicyConfigurationSettings retryPolicySettings = appConfig.GetConfigurationSection<RetryPolicyConfigurationSettings>(RetryPolicyConfigurationSettings.SectionName);
            Assert.IsNotNull(retryPolicySettings, "No LoggingSettings section was found");
            Assert.IsTrue(retryPolicySettings.Policies.Count > 0, "Policies collection is empty");
            Assert.IsFalse(String.IsNullOrEmpty(retryPolicySettings.DefaultPolicy), "DefaultPolicy is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(retryPolicySettings.DefaultSqlConnectionPolicy), "DefaultSqlConnectionPolicy is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(retryPolicySettings.DefaultSqlCommandPolicy), "DefaultSqlCommandPolicy is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(retryPolicySettings.DefaultStoragePolicy), "DefaultStoragePolicy is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(retryPolicySettings.DefaultCommunicationPolicy), "DefaultCommunicationPolicy is null or empty");

            RetryPolicy defaultPolicy = retryPolicySettings.GetRetryPolicy<SqlAzureTransientErrorDetectionStrategy>(retryPolicySettings.DefaultPolicy);

            Assert.IsNotNull(defaultPolicy, "No default retry policy was found");
            Assert.IsTrue(retryPolicySettings.Policies.Get(retryPolicySettings.DefaultPolicy).MaxRetryCount > 0, "Policies collection is empty");
        }

        [TestMethod]
        public void TestConfigureTraceListenerProperty()
        {
            LoggingSettings loggingSettings = new LoggingSettings();
            LoggingConfigurationView loggingConfigView = new LoggingConfigurationView(loggingSettings);

            string propName1 = "diagnosticServiceEndpoint";
            string propValue1 = "diagnosticServiceEndpointValue";
            string propName2 = "diagnosticStorageAccount";
            string propValue2 = "diagnosticStorageAccountValue";

            loggingConfigView.AddTraceListener(OnPremisesBufferedTraceListener.ListenerName, OnPremisesBufferedTraceListener.ListenerTypeName);
            loggingConfigView.ConfigureTraceListenerProperty(OnPremisesBufferedTraceListener.ListenerName, propName1, propValue1);
            loggingConfigView.ConfigureTraceListenerProperty(OnPremisesBufferedTraceListener.ListenerName, propName2, propValue2);

            OnPremisesBufferedTraceListenerData listenerData = loggingSettings.TraceListeners.Get(OnPremisesBufferedTraceListener.ListenerName) as OnPremisesBufferedTraceListenerData;
            Assert.IsNotNull(listenerData);
            
            Assert.AreEqual(propValue1, listenerData.DiagnosticServiceEndpoint);
            Assert.AreEqual(propValue2, listenerData.DiagnosticStorageAccount);
        }

        [TestMethod]
        public void LoadWorkItemSchedulerConfigurationSettings()
        {
            ApplicationConfigurationSettings settings = ApplicationConfiguration.Current.GetConfigurationSection<ApplicationConfigurationSettings>(WorkItemSchedulerConfigurationSettings.SectionName);
            Assert.IsNotNull(settings, "No WorkItemSchedulerConfigurationSettings section was found");

            WorkItemSchedulerConfigurationSettings customSettings = new WorkItemSchedulerConfigurationSettings(settings);

            Assert.IsFalse(String.IsNullOrEmpty(customSettings.HandlingPolicyName), "HandlingPolicyName is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(customSettings.CloudStorageAccount), "CloudStorageAccount is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(customSettings.DestinationQueue), "DestinationQueue is null or empty");
            Assert.IsFalse(customSettings.XmlBatchSize == 0, "XmlBatchSize is zero");
        }

        [TestMethod]
        public void LoadStorageAccountConfigurationSettings()
        {
            StorageAccountConfigurationSettings storageSettings = ApplicationConfiguration.Current.GetConfigurationSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);
            
            Assert.IsNotNull(storageSettings, "No StorageAccountConfigurationSettings section was found");
            Assert.IsFalse(storageSettings.Accounts.Count == 0, "Accounts collection is empty");
            Assert.IsFalse(String.IsNullOrEmpty(storageSettings.Accounts.Get(0).Name), "Name property is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(storageSettings.Accounts.Get(0).AccountName), "AccountName property is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(storageSettings.Accounts.Get(0).AccountKey), "AccountKey property is null or empty");

            using (MemoryStream memoryBuffer = new MemoryStream())
            {
                XmlWriterSettings writerRettings = new XmlWriterSettings();

                writerRettings.CloseOutput = false;
                writerRettings.CheckCharacters = false;
                writerRettings.ConformanceLevel = ConformanceLevel.Fragment;
                writerRettings.NamespaceHandling = NamespaceHandling.OmitDuplicates;

                using (XmlWriter writer = XmlWriter.Create(memoryBuffer, writerRettings))
                {
                    storageSettings.WriteXml(writer);
                    writer.Flush();
                }

                memoryBuffer.Seek(0, SeekOrigin.Begin);

                StreamReader sr = new StreamReader(memoryBuffer);
                string sectionXml = sr.ReadToEnd();

                Assert.IsNotNull(sectionXml, "sectionXml is null");
            }
        }

        [TestMethod]
        public void ValidateConfigurationSectionFactory()
        {
            ConfigurationSection configSection = ConfigurationSectionFactory.GetSection(StorageAccountConfigurationSettings.SectionName);

            Assert.IsNotNull(configSection, "Config section is null");
            Assert.AreEqual<Type>(typeof(StorageAccountConfigurationSettings), configSection.GetType(), "Config section is of a wrong type");

            configSection = ConfigurationSectionFactory.GetSection(typeof(RetryPolicyConfigurationSettings).FullName);

            Assert.IsNotNull(configSection, "Config section is null");
            Assert.AreEqual<Type>(typeof(RetryPolicyConfigurationSettings), configSection.GetType(), "Config section is of a wrong type");

            configSection = ConfigurationSectionFactory.GetSection(typeof(ApplicationDiagnosticSettings).AssemblyQualifiedName);

            Assert.IsNotNull(configSection, "Config section is null");
            Assert.AreEqual<Type>(typeof(ApplicationDiagnosticSettings), configSection.GetType(), "Config section is of a wrong type");
        }
    }
}
