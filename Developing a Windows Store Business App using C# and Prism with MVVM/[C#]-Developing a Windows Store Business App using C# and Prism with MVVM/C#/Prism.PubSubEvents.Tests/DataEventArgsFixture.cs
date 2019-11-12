// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.Practices.Prism.PubSubEvents.Tests
{
    [TestClass]
    public class DataEventArgsFixture
    {
        [TestMethod]
        public void CanPassData()
        {
            DataEventArgs<int> e = new DataEventArgs<int>(32);
            Assert.AreEqual(32, e.Value);
        }

        [TestMethod]
        public void IsEventArgs()
        {
            DataEventArgs<string> dea = new DataEventArgs<string>("");
            EventArgs ea = dea as EventArgs;
            Assert.IsNotNull(ea);
        }
    }
}