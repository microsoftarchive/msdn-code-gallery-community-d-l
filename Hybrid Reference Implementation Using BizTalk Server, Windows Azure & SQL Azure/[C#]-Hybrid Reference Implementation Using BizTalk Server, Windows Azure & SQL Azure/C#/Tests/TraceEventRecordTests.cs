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
    using System.Linq;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Summary description for TraceEventRecordTests
    /// </summary>
    [TestClass]
    public class TraceEventRecordTests
    {
        private static string testRootFolder;
        private static string testMessageFolder;

        public TraceEventRecordTests()
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
        [ClassInitialize()]
        public static void TraceEventRecordTestsInit(TestContext testContext)
        {
            testRootFolder = UnitTestUtility.GetTestRoot(testContext.TestLogsDir);
            testMessageFolder = UnitTestUtility.GetTestMessagesFolder(testRootFolder);
        }
        #endregion

        [TestMethod]
        public void TestSingleTraceEventRecord()
        {
            CreateTraceEventRecordFromXmlSample("TraceEventRecord1.xml");
        }

        [TestMethod]
        public void TestMultipleTraceEventRecords()
        {
            CreateTraceEventRecordFromXmlSample("MultipleTraceEventRecords.xml");
        }

        #region Private methods
        public void CreateTraceEventRecordFromXmlSample(string fileName)
        {
            string testMessageFile = Path.Combine(testMessageFolder, fileName);

            using (FileStream fileStream = new FileStream(testMessageFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                XmlReaderSettings readerSettings = new XmlReaderSettings() { CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };
                XmlReader xmlFileReader = XmlReader.Create(fileStream, readerSettings);
                XElement eventDataXml = XElement.Load(xmlFileReader);

                var traceEventRecords = eventDataXml.Descendants(XName.Get("TraceEvents", eventDataXml.Name.Namespace.NamespaceName)).Descendants(XName.Get("TraceEventRecord", WellKnownNamespace.DataContracts.General));

                foreach (var r in traceEventRecords)
                {
                    TraceEventRecord eventRecord = TraceEventRecord.Create(XmlReader.Create(r.CreateReader(), readerSettings));

                    Assert.AreNotEqual<DateTime>(default(DateTime), eventRecord.DateTime, "Unexpected DateTime value");
                    Assert.AreNotEqual<int>(default(Int32), eventRecord.EventId, "Unexpected EventId value");
                    Assert.AreNotEqual<int>(default(Int32), eventRecord.ProcessId, "Unexpected ProcessId value");
                    Assert.AreNotEqual<int>(default(Int32), eventRecord.ThreadId, "Unexpected ThreadId value");
                    Assert.AreNotEqual<long>(default(Int64), eventRecord.Timestamp, "Unexpected ThreadId value");
                    Assert.AreEqual<string>("APPFABRIC-CAT-01", eventRecord.MachineName, "Unexpected MachineName value");
                    Assert.AreEqual<string>("WaWorkerHost", eventRecord.ProcessName, "Unexpected ProcessName value");
                    Assert.AreEqual<string>("WorkerRoleComponent", eventRecord.EventSource, "Unexpected EventSource value");
                    Assert.IsFalse(String.IsNullOrEmpty(eventRecord.Message), "Message text is null or empty");
                    Assert.AreEqual<TraceEventType>(TraceEventType.Information, eventRecord.EventType, "Unexpected EventType value");
                }
            }
        }
        #endregion
    }
}
