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
    using System.ServiceModel;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Configuration;
    using Contoso.Cloud.Integration.Framework.Instrumentation;
    using Contoso.Cloud.Integration.Azure.Services.Framework;
    using Contoso.Cloud.Integration.Azure.Services.Framework.Logging;
    using Contoso.Cloud.Integration.Azure.Services.Contracts;
    #endregion

    [TestClass]
    public class OnPremisesBufferedTraceListenerTests
    {
        private string diagnosticServiceEndpointName = "DiagnosticLoggingService";
        private string diagnosticEventQueue = "DiagnosticEventQueue";
        private ServiceHost diagServiceHost;

        public OnPremisesBufferedTraceListenerTests()
        {
        }

        #region Additional test attributes
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

        [ClassInitialize()]
        public static void OnPremisesBufferedTraceListenerTestsInit(TestContext testContext)
        {
        }
        #endregion

        [TestMethod]
        public void TraceSingleEvent()
        {
            TraceTestEvent(1);
        }

        [TestMethod]
        public void TraceSmallNumberOfEvents()
        {
            TraceTestEvent(100);
        }

        [TestMethod]
        public void TraceMediumNumberOfEvents()
        {
            TraceTestEvent(1000);
        }

        [TestMethod]
        public void TraceLargeNumberOfEvents()
        {
            TraceTestEvent(100000);
        }

        [TestMethod]
        public void TestMessageBufferSend()
        {
            int eventCount = 0;
            ServiceBusEndpointInfo diagEndpointInfo = ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[diagnosticEventQueue];

            Assert.IsNotNull(diagEndpointInfo, "{0} service bus endpoint definition has not been found", diagnosticEventQueue);

            try
            {
                string randomQueueName = Guid.NewGuid().ToString();

                using (ReliableServiceBusQueue<TraceEventRecord> sbQueue = new ReliableServiceBusQueue<TraceEventRecord>(randomQueueName, diagEndpointInfo))
                {

                    for (int i = 0; i < 100; i++)
                    {
                        sbQueue.Send(TraceEventRecord.Create(this.GetType().Name, TraceEventType.Information, 0, String.Format("Test event #{0}", i)));
                        eventCount++;
                    }
                }
            }
            finally
            {
                Trace.WriteLine(String.Format("Event count = {0}", eventCount));
            }
        }

        private void TraceTestEvent(int count)
        {
            OnPremisesBufferedTraceListenerData listenerData = new OnPremisesBufferedTraceListenerData();
            var reqs = listenerData.GetRegistrations();

            listenerData.DiagnosticQueueEventBatchSize = 10;

            var reg = (from r in reqs where r.ImplementationType == typeof(OnPremisesBufferedTraceListener) select r).FirstOrDefault();

            try
            {
                StartDiagnosticLoggingMockService();

                using (OnPremisesBufferedTraceListener listener = new OnPremisesBufferedTraceListener(diagnosticServiceEndpointName, null, listenerData.InMemoryQueueCapacity, listenerData.InMemoryQueueListenerSleepTimeout, listenerData.DiagnosticQueueEventBatchSize, listenerData.DiagnosticQueueListenerSleepTimeout))
                {
                    for (int i = 0; i < count; i++)
                    {
                        listener.Write(String.Format("Test event #{0}", i));
                    }
                }

                DiagnosticLoggingMockService mockService = this.diagServiceHost.SingletonInstance as DiagnosticLoggingMockService;
                Assert.AreEqual(count, mockService.EventCount, "Number of received events doesn't match");
            }
            finally
            {
                StopDiagnosticLoggingMockService();
            }
        }

        private void StartDiagnosticLoggingMockService()
        {
            ServiceBusEndpointInfo diagEndpointInfo = ApplicationConfiguration.Current.ServiceBusSettings.Endpoints[diagnosticServiceEndpointName];

            Assert.IsNotNull(diagEndpointInfo, "{0} service bus endpoint definition has not been found", diagnosticServiceEndpointName);

            this.diagServiceHost = ServiceBusHostFactory.CreateServiceBusEventRelayHost<DiagnosticLoggingMockService>(diagEndpointInfo);
            this.diagServiceHost.Open();
        }

        private void StopDiagnosticLoggingMockService()
        {
            if (this.diagServiceHost != null)
            {
                this.diagServiceHost.Close();
                this.diagServiceHost = null;
            }
        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DiagnosticLoggingMockService : IDiagnosticLoggingServiceContract
    {
        public int EventCount { get; set; }

        #region IDiagnosticLoggingServiceContract implementation
        public void TraceEvent(TraceEventRecord[] traceEvents)
        {
            Assert.IsNotNull(traceEvents, "traceEvents is null");
            Assert.IsTrue(traceEvents.Length > 0, "traceEvents is empty");
            Assert.IsTrue(traceEvents[0].Message.StartsWith("Test event"), "traceEvents contains an invalid message text");

            EventCount += traceEvents != null ? traceEvents.Length : 0;
        }
        #endregion
    }
}
