using System;
using DynamicsCRMUnitTest.WebService;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class CrmContextMethods2Test
    {
        [TestMethod]
        public void CreateAccountTest()
        {
            //
            // Arrange
            //
            string accountName = "abcabcabc";
            Guid actual;
            Guid expected = Guid.NewGuid();

            int callCount = 0;
            Entity entity = null;

            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.CreateEntity = e =>
            {
                callCount++;
                entity = e;
                return expected;
            };

            CrmContextMethods2 target = new CrmContextMethods2(service);

            //
            // Act
            //
            actual = target.CreateAccount(accountName);

            //
            // Assert
            //
            Assert.AreEqual(callCount, 1); // verify OrganizationServiceContext.Create is called once
            Assert.IsNotNull(entity); // verify OrganizationServiceContext.Create is called with not null object
            Assert.AreEqual(entity.LogicalName, "account"); // verify OrganizationServiceContext.Create is called with entity with proper entity name
            Assert.AreEqual(entity.GetAttributeValue<string>("name"), accountName); // verify OrganizationServiceContext.Create is called with entity with proper value set on name attribute

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrieveVersionTest()
        {
            //
            // Arrange
            //
            string actual;
            string expected = "5.0.9690.2243";

            int callCount = 0;

            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.ExecuteOrganizationRequest = r =>
                {
                    callCount++;

                    return new RetrieveVersionResponse
                    {
                        Results = new ParameterCollection
                        {
                            { "Version", expected }
                        }
                    };
                };

            CrmContextMethods2 target = new CrmContextMethods2(service);

            //
            // Act
            //
            actual = target.RetrieveVersion();

            //
            // Assert
            //
            Assert.AreEqual(callCount, 1); // verify OrganizationServiceContext.RetrieveVersion is called once

            Assert.AreEqual(expected, actual);
        }

    }
}
