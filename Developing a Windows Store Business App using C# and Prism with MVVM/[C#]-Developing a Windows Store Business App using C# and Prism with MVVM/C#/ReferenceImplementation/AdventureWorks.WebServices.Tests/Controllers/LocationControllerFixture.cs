// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Linq;
using AdventureWorks.WebServices.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventureWorks.WebServices.Tests.Controllers
{
    [TestClass]
    public class LocationControllerFixture
    {
        [TestMethod]
        public void Get_All_States()
        {
            var controller = new LocationController();
            var result = controller.GetStates();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }
    }
}
