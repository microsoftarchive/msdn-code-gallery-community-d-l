using System;
using DynamicsCRMUnitTest.WebService;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class CrmContextMethodsTest
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

            var context = new CrmOrganizationServiceContextExtensions.Fakes.StubICrmOrganizationServiceContext();
            context.CreateEntity = e =>
            {
                callCount++;
                entity = e;
                return expected;
            };

            CrmContextMethods target = new CrmContextMethods(context);

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

            var context = new CrmOrganizationServiceContextExtensions.Fakes.StubICrmOrganizationServiceContext();
            context.RetrieveVersion = () =>
            {
                callCount++;
                return expected;
            };

            CrmContextMethods target = new CrmContextMethods(context);

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
