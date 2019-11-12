// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.Practices.Prism.PubSubEvents.Tests
{
    [TestClass]
    public class EventAggregatorFixture
    {
        [TestMethod]
        public void GetReturnsSingleInstancesOfSameEventType()
        {
            var eventAggregator = new EventAggregator();
            var instance1 = eventAggregator.GetEvent<MockEventBase>();
            var instance2 = eventAggregator.GetEvent<MockEventBase>();

            Assert.AreSame(instance2, instance1);
        }

        public class MockEventBase : EventBase { }
    }
}