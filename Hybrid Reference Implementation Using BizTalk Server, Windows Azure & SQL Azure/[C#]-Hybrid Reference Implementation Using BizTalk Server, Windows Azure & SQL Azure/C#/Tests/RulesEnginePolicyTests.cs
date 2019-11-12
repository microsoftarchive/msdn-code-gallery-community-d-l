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
    using System.Runtime.Serialization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.RulesEngine;
    using Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks;
    using Contoso.Cloud.Integration.Azure.Services.Contracts.Data;
    using Contoso.Cloud.Integration.Framework;
    #endregion

    [TestClass]
    public class RulesEnginePolicyTests
    {
        private static string testRootFolder;
        private static string testMessageFolder;

        public RulesEnginePolicyTests()
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
        public static void RulesEnginePolicyTestsInit(TestContext testContext)
        {
            testRootFolder = UnitTestUtility.GetTestRoot(testContext.TestLogsDir);
            testMessageFolder = UnitTestUtility.GetTestMessagesFolder(testRootFolder);
        }
        #endregion

        [TestMethod]
        public void ValidateHandleGetConfigurationSectionRequestPolicy()
        {
            PolicyExecutionInfo policyExecInfo = new PolicyExecutionInfo("Contoso.Cloud.Integration.GenericCloudRequestHandling");

            policyExecInfo.AddParameter("http://schemas.microsoft.com/BizTalk/2003/soap-properties#MethodName", "Contoso.Cloud.Integration.ServiceContracts/IOnPremiseConfigurationService/GetConfigurationSection");

            IList<IMessagingRuntimeExtenderTask> registeredTasks = RuntimeTaskFactory.GetRegisteredTasks();
            PolicyExecutionResult policyExecResult = PolicyHelper.Execute(policyExecInfo, registeredTasks);

            IEnumerable<ExternalComponentInvokeTask> execTasks = registeredTasks.OfType<ExternalComponentInvokeTask>();

            Assert.IsTrue(policyExecResult.Success, "Policy execution was not successful");
            Assert.IsFalse(execTasks.Count() == 0, "No ExternalComponentInvokeTask was found in task collection");

            ExternalComponentInvokeTask execTask = execTasks.ElementAt<ExternalComponentInvokeTask>(0);

            Assert.IsNotNull(execTask, "execTask instance has not been found");
            Assert.IsFalse(String.IsNullOrEmpty(execTask.AssemblyName), "AssemblyName is null or empty");
            Assert.IsFalse(String.IsNullOrEmpty(execTask.TypeName), "TypeName is null or empty");
        }

        [TestMethod]
        public void DeserializeExecutePolicyRequest()
        {
            string testFileName = Path.Combine(testMessageFolder, "ExecutePolicyRequest.xml");

            DataContractSerializer serializer = new DataContractSerializer(typeof(RulesEngineRequest));

            using (FileStream fileStream = new FileStream(testFileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                XmlReaderSettings readerSettings = new XmlReaderSettings() { CheckCharacters = false, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true, ValidationType = ValidationType.None };
                XmlReader xmlFileReader = XmlReader.Create(fileStream, readerSettings);

                while (!xmlFileReader.EOF && xmlFileReader.Name != WellKnownContractMember.MessageParameters.Request && xmlFileReader.NamespaceURI != WellKnownNamespace.DataContracts.General) xmlFileReader.Read();

                Assert.IsFalse(xmlFileReader.EOF, "Unexpected end of file");

                if(!xmlFileReader.EOF)
                {
                    RulesEngineRequest request = serializer.ReadObject(xmlFileReader, false) as RulesEngineRequest;
                    
                    Assert.IsNotNull(request, "request is null");
                    Assert.IsFalse(String.IsNullOrEmpty(request.PolicyName));
                    Assert.IsNotNull(request.Facts);
                    Assert.IsTrue(request.Facts.Count() == 2);

                    PersistenceQueueItemBatchInfo batchInfo = null;
                    PersistenceQueueItemInfo queueItemInfo = null;

                    foreach (object fact in request.Facts)
                    {
                        if (fact is PersistenceQueueItemInfo)
                        {
                            queueItemInfo = fact as PersistenceQueueItemInfo;
                            
                            Assert.IsFalse(String.IsNullOrEmpty(queueItemInfo.QueueItemType));
                            Assert.IsFalse(queueItemInfo.QueueItemId == default(Guid));
                        }
                        else if (fact is PersistenceQueueItemBatchInfo)
                        {
                            batchInfo = fact as PersistenceQueueItemBatchInfo;
                        }
                    }

                    Assert.IsNotNull(batchInfo);
                    Assert.IsNotNull(queueItemInfo);
                }
            }
        }
    }
}
