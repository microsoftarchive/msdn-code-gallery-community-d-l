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
    using System.Xml.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.RulesEngine;
    using Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    #endregion

    [TestClass]
    public class ReliableCloudQueueStorageTests
    {
        private static Random randGenerator = new Random();
        private static string testQueueName;
        private static string testRootFolder;
        private static string testMessageFolder;

        public ReliableCloudQueueStorageTests()
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
        public static void ReliableCloudQueueStorageTestsInit(TestContext testContext)
        {
            testQueueName = "TestQueue-" + Guid.NewGuid().ToString("N");
            testRootFolder = UnitTestUtility.GetTestRoot(testContext.TestLogsDir);
            testMessageFolder = UnitTestUtility.GetTestMessagesFolder(testRootFolder);
        }

        [ClassCleanup()]
        public static void ReliableCloudQueueStorageTestsCleanup()
        {
            using (ICloudQueueStorage queueStorage = GetCloudQueueStorage())
            {
                queueStorage.DeleteQueue(testQueueName);
            }
        }
        #endregion

        [TestMethod]
        public void PutLargeXmlMessage()
        {
            string testFileName = Path.Combine(testMessageFolder, "InventoryReport_2.xml");

            using (ICloudBlobStorage blobStorage = GetCloudBlobStorage())
            using (ICloudQueueStorage queueStorage = GetCloudQueueStorage())
            {
                LargeQueueMessageInfo largeMsgInfo = LargeQueueMessageInfo.Create(testQueueName);
                XDocument testMessage = XDocument.Load(testFileName);

                queueStorage.Clear(testQueueName);
                queueStorage.Put<XDocument>(testQueueName, testMessage);

                int blobCount = blobStorage.GetCount(largeMsgInfo.ContainerName);
                XDocument msgFromQueue = queueStorage.Get<XDocument>(testQueueName);

                Assert.IsNotNull(msgFromQueue, "Unable to find message on the queue");
                Assert.IsTrue(String.Compare(testMessage.ToString(), msgFromQueue.ToString(), false) == 0, "Message content is different");
                Assert.IsTrue(blobCount == 1, "Blob storage must contain the message data");

                bool deleted = queueStorage.Delete<XDocument>(msgFromQueue);
                int queueLength = queueStorage.GetCount(testQueueName);

                Assert.IsTrue(deleted, "Message has not been deleted by some reasons");
                Assert.IsTrue(queueLength == 0, "Queue is not empty by some reasons");

                blobCount = blobStorage.GetCount(largeMsgInfo.ContainerName);
                Assert.IsTrue(blobCount == 0, "Blob storage is not empty by some reasons");
            }
        }

        [TestMethod]
        public void PutLargeBinaryMessage()
        {
            int largeMessageSize = 2 * 1024 * 1024;
            var largeMessage = new byte[largeMessageSize];

            randGenerator.NextBytes(largeMessage);

            using (ICloudBlobStorage blobStorage = GetCloudBlobStorage())
            using (ICloudQueueStorage queueStorage = GetCloudQueueStorage())
            {
                LargeQueueMessageInfo largeMsgInfo = LargeQueueMessageInfo.Create(testQueueName);

                queueStorage.Clear(testQueueName);
                queueStorage.Put<byte[]>(testQueueName, largeMessage);

                int blobCount = blobStorage.GetCount(largeMsgInfo.ContainerName);
                byte[] msgFromQueue = queueStorage.Get<byte[]>(testQueueName);

                Assert.IsNotNull(msgFromQueue, "Unable to find message on the queue");

                var matchedBytes = msgFromQueue.Where((value, index) =>
                {
                    return largeMessage[index] == value;
                });

                Assert.IsTrue(matchedBytes.Count() == largeMessageSize, "Message content is different");
                Assert.IsTrue(blobCount == 1, "Blob storage must contain the message data");

                bool deleted = queueStorage.Delete<byte[]>(msgFromQueue);
                int queueLength = queueStorage.GetCount(testQueueName);

                Assert.IsTrue(deleted, "Message has not been deleted by some reasons");
                Assert.IsTrue(queueLength == 0, "Queue is not empty by some reasons");

                blobCount = blobStorage.GetCount(largeMsgInfo.ContainerName);
                Assert.IsTrue(blobCount == 0, "Blob storage is not empty by some reasons");
            }
        }

        #region Private methods
        private static ICloudQueueStorage GetCloudQueueStorage()
        {
            StorageAccountConfigurationSettings storageSettings = ApplicationConfiguration.Current.GetConfigurationSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);
            return new ReliableCloudQueueStorage(storageSettings.Accounts.Get(storageSettings.DefaultQueueStorage));
        }

        private static ICloudBlobStorage GetCloudBlobStorage()
        {
            StorageAccountConfigurationSettings storageSettings = ApplicationConfiguration.Current.GetConfigurationSection<StorageAccountConfigurationSettings>(StorageAccountConfigurationSettings.SectionName);
            return new ReliableCloudBlobStorage(storageSettings.Accounts.Get(storageSettings.DefaultQueueStorage));
        } 
        #endregion
    }
}
