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
    using System.IO;
    using System.Xml;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Framework.ActivityTracking;
    #endregion

    /// <summary>
    /// Summary description for TraceEventRecordTests
    /// </summary>
    [TestClass]
    public class ActivityTrackingTests
    {
        private static string testRootFolder;
        private static string testMessageFolder;

        public ActivityTrackingTests()
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
        public static void ActivityTrackingTestsInit(TestContext testContext)
        {
            testRootFolder = UnitTestUtility.GetTestRoot(testContext.TestLogsDir);
            testMessageFolder = UnitTestUtility.GetTestMessagesFolder(testRootFolder);
        }
        #endregion

        [TestMethod]
        public void CreateActivityInstanceFromXmlSample()
        {
            string testMessageFile = Path.Combine(testMessageFolder, "GenericNamedActivity.xml");

            using (FileStream fileStream = new FileStream(testMessageFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                XmlReaderSettings readerSettings = new XmlReaderSettings() { CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };
                XmlReader xmlFileReader = XmlReader.Create(fileStream, readerSettings);

                ActivityBase activity = ActivityBase.Create(xmlFileReader);

                Assert.AreEqual<string>("InventoryDataTrackingActivity", activity.ActivityName, "Unexpected ActivityName value");
                Assert.AreEqual<string>("9190e3b5-d8c8-4902-9b5f-4796af42efcb", activity.ActivityID, "Unexpected ActivityID value");
                Assert.AreEqual<string>("9C0F681B-AC8D-4C9F-B375-FC1D35437C04", activity.ContinuationToken, "Unexpected ContinuationToken value");
                Assert.AreEqual<int>(1, activity.ActivityData.Count, "Unexpected number of items on property bag");
                Assert.AreEqual<DateTime>(DateTime.Parse("2010-08-06T22:33:58.7954004Z").ToUniversalTime(), ((DateTime)activity.ActivityData["DataSubscribersNotified"]).ToUniversalTime(), "Unexpected value in DataSubscribersNotified property");
            }
        }
    }
}
