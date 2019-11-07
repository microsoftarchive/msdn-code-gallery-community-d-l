using System;
using DynamicsCRMUnitTest.WebService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class ContextMethods2Test
    {
        [TestMethod]
        public void CreateAccountTest()
        {
            //
            // Arrange
            //
            string accountName = "abcabcabc";
            Guid actual;
            Guid expected = Guid.Empty;

            int callCount = 0;
            Entity entity = null;

            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.ExecuteOrganizationRequest = r =>
            {
                callCount++;                

                var request = r as CreateRequest;
                entity = request.Target;
                expected = entity.Id;

                return new CreateResponse
                {
                    Results = new ParameterCollection
                        {
                            { "id", expected }
                        }
                };
            };

            ContextMethods2 target = new ContextMethods2(service);

            //
            // Act
            //
            actual = target.CreateAccount(accountName);

            //
            // Assert
            //
            Assert.AreEqual(callCount, 1); // verify OrganizationServiceContext.AddObject is called once
            Assert.IsNotNull(entity); // verify OrganizationServiceContext.AddObject is called with not null object
            Assert.AreEqual(entity.LogicalName, "account"); // verify OrganizationServiceContext.AddObject is called with entity with proper entity name
            Assert.AreEqual(entity.GetAttributeValue<string>("name"), accountName); // verify OrganizationServiceContext.AddObject is called with entity with proper value set on name attribute

            Assert.AreEqual(expected, actual);
        }
    }
}
