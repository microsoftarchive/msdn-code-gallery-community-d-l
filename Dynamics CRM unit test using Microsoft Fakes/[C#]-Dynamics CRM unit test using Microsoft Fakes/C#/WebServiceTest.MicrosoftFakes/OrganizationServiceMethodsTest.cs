using System;
using System.Collections.Generic;
using DynamicsCRMUnitTest.WebService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System.Linq;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class OrganizationServiceMethodsTest
    {
        [TestMethod]
        public void RetrieveAccountIdByNameTest()
        {
            //
            // Arrange
            //
            IEnumerable<Guid> actual;
            IEnumerable<Guid> expected = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            int callCount = 0;

            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.RetrieveMultipleQueryBase = (query) =>
            {
                callCount++;

                var results = new EntityCollection();

                results.Entities.AddRange(
                    new Entity("account") { Attributes = { { "accountid", expected.ElementAt(0) } } },
                    new Entity("account") { Attributes = { { "accountid", expected.ElementAt(1) } } });

                return results;
            };

            OrganizationServiceMethods target = new OrganizationServiceMethods(service);

            //
            // Act
            //
            actual = target.RetrieveAccountIdByName("TestName");

            //
            // Assert
            //
            Assert.AreEqual(callCount, 1); // verify OrganizationServiceContext.RetrieveVersion is called once

            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(expected.ElementAt(0), actual.ElementAt(0));
            Assert.AreEqual(expected.ElementAt(1), actual.ElementAt(1));
        }
    }
}
