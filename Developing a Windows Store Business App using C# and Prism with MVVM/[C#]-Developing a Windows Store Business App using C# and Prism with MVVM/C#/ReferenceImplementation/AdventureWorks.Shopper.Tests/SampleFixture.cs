// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace AdventureWorks.Shopper.Tests
{
    [TestClass]
    public class SampleFixture
    {
        [TestMethod]
        public void ShopperTestRunnerCheck()
        {
            //This is a simple test to validate that the test runner can execute unit tests
            //against the Shopper assembly.
            Assert.IsTrue(true);
        }
    }
}
