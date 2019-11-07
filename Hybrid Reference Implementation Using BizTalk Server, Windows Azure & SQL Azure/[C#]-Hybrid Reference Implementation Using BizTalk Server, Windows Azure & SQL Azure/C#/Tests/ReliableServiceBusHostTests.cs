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
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.BizTalk.Core.RulesEngine;
    using Contoso.Cloud.Integration.BizTalk.Core.RuntimeTasks;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Storage;
    using Contoso.Cloud.Integration.Azure.Services.Common;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    #endregion

    [TestClass]
    public class ReliableServiceBusHostTests
    {
        public ReliableServiceBusHostTests()
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
        public static void ReliableServiceBusHostTestsInit(TestContext testContext)
        {
        }

        [ClassCleanup()]
        public static void ReliableServiceBusHostTestsCleanup()
        {
        }
        #endregion

        [TestMethod]
        public void SimulateServiceHostFaultedState()
        {
            string endpointName = "InterRoleCommunication";
            
            ServiceBusEndpointInfo testEndpointInfo = ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[endpointName];
            
            Assert.IsNotNull(testEndpointInfo, "{0} service bus endpoint definition has not been found", endpointName);

            ReliableServiceBusHost<InterRoleCommunicationService> serviceHost = new ReliableServiceBusHost<InterRoleCommunicationService>(testEndpointInfo);
            serviceHost.Open();

            bool faultEncountered = false;
            serviceHost.Faulted += (sender, e) =>
            {
                faultEncountered = true;
            };

            Thread.Sleep(60 * 1000);

            Assert.IsTrue(faultEncountered);
        }
    }
}
