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
    using System.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Logging;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    using Contoso.Cloud.Integration.Common;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using System.Xml.Linq;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    #endregion

    [TestClass]
    public class SqlAzurePersistenceQueueTest
    {
        private static string testRootFolder;
        private static string testMessageFolder;

        public SqlAzurePersistenceQueueTest()
        {
        }

        #region Additional test attributes
        [ClassInitialize()]
        public static void SqlAzurePersistenceQueueTestInit(TestContext testContext)
        {
            testRootFolder = UnitTestUtility.GetTestRoot(testContext.TestLogsDir);
            testMessageFolder = UnitTestUtility.GetTestMessagesFolder(testRootFolder);
        }
        #endregion

        [TestMethod]
        public void TestDequeueXmlData()
        {
            XPathQueryLibrary xPathLib = ApplicationConfiguration.Current.XPathQueries;

            var headerSegments = new List<string>();
            var bodySegments = new List<string>();
            var footerSegments = new List<string>();

            headerSegments.Add(xPathLib.GetXPathQuery("InventoryHeader"));
            footerSegments.Add(xPathLib.GetXPathQuery("InventorySummary"));
            footerSegments.Add(xPathLib.GetXPathQuery("InventoryIRRSegment"));
            string itemXPath = xPathLib.GetXPathQuery("InventoryItems");

            int fromItem = 1;
            int xmlBatchSize = 50;
            XDocument batch = null;
            Guid queueItemId = Guid.Parse("6DA1B27D-714D-465D-93B8-234B085CF6E4");

            using (SqlAzurePersistenceQueue dbQueue = new SqlAzurePersistenceQueue())
            {
                dbQueue.Open(WellKnownDatabaseName.PersistenceQueue);

                int toItem = fromItem + xmlBatchSize - 1;

                bodySegments.Clear();
                bodySegments.Add(String.Format(xPathLib.GetXPathQuery("InventoryItemBatchTemplate"), fromItem, toItem));

                using (XmlReader xmlReader = dbQueue.DequeueXmlData(queueItemId, headerSegments, bodySegments, footerSegments, xPathLib.Namespaces.NamespaceManager))
                {
                    if (xmlReader != null)
                    {
                        batch = XDocument.Load(xmlReader);
                    }
                }
            }
        }

        [TestMethod]
        public void TestCoreOperations()
        {
            string testFileName = Path.Combine(testMessageFolder, "InventoryReport_0.xml");
            PersistenceQueueItemInfo queueItemInfo = null;

            try
            {
                using (FileStream fileStream = new FileStream(testFileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (SqlAzurePersistenceQueue persistenceQueue = new SqlAzurePersistenceQueue())
                    {
                        persistenceQueue.Open(WellKnownDatabaseName.PersistenceQueue);

                        queueItemInfo = persistenceQueue.Enqueue(fileStream);
                    }
                }

                Assert.IsTrue(queueItemInfo.QueueItemSize > 0, "QueueItemSize is zero");
                Assert.IsTrue(!String.IsNullOrEmpty(queueItemInfo.QueueItemType), "QueueItemType is zero");

                XPathQueryLibrary xPathLib = ApplicationConfiguration.Current.GetConfigurationSection<XPathQueryLibrary>(XPathQueryLibrary.SectionName);
                string itemCountXPath = xPathLib.GetXPathQuery("InventoryItemCount");

                using (SqlAzurePersistenceQueue persistenceQueue = new SqlAzurePersistenceQueue())
                {
                    persistenceQueue.Open(WellKnownDatabaseName.PersistenceQueue);

                    using (XmlReader resultReader = persistenceQueue.QueryXmlData(queueItemInfo.QueueItemId, new string[] { itemCountXPath }, xPathLib.Namespaces.NamespaceManager))
                    {
                        int itemCount = resultReader.ReadContentAsInt();
                        
                        Assert.IsTrue(itemCount > 0, "Item count is zero");
                        Assert.AreEqual<int>(6, itemCount, "Wrong item count");
                    }
                }
            }
            finally
            {
                if (queueItemInfo != null)
                {
                    using (SqlAzurePersistenceQueue persistenceQueue = new SqlAzurePersistenceQueue())
                    {
                        persistenceQueue.Open(WellKnownDatabaseName.PersistenceQueue);
                        bool removed = persistenceQueue.Remove(queueItemInfo.QueueItemId);

                        Assert.IsTrue(removed, "Item was not removed");
                    }
                }
            }
        }
    }
}
