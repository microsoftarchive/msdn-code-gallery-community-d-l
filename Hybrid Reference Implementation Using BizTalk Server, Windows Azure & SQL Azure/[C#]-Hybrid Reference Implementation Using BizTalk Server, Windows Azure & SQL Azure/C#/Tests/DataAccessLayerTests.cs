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
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    #endregion

    /// <summary>
    /// Summary description for TraceEventRecordTests
    /// </summary>
    [TestClass]
    public class DataAccessLayerTests
    {
        private static string testRootFolder;
        private static string testMessageFolder;

        public DataAccessLayerTests()
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
        public static void DataAccessLayerTestsInit(TestContext testContext)
        {
            testRootFolder = UnitTestUtility.GetTestRoot(testContext.TestLogsDir);
            testMessageFolder = UnitTestUtility.GetTestMessagesFolder(testRootFolder);
        }
        #endregion

        [TestMethod]
        public void DeserializeInventoryItems()
        {
          
        }
    }
}
