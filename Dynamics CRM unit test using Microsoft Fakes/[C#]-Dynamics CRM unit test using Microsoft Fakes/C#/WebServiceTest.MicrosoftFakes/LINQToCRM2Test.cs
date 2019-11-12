using System;
using System.Collections.Generic;
using System.Linq;
using DynamicsCRMUnitTest.WebService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class LINQToCRM2Test
    {
        [TestMethod]
        public void RetrieveAccountsByNameTest()
        {
            //
            // Arrange
            //
            var entity1 = new Microsoft.Xrm.Sdk.Entity("account");
            entity1.Id = Guid.NewGuid();
            entity1["name"] = "abcabcabc";

            var entity2 = new Microsoft.Xrm.Sdk.Entity("account");
            entity2.Id = Guid.NewGuid();
            entity2["name"] = "123123123";

            var entity3 = new Microsoft.Xrm.Sdk.Entity("account");
            entity3.Id = Guid.NewGuid();
            entity3["name"] = "a1b2c3a1b2c3";

            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();

            service.ExecuteOrganizationRequest = r =>
            {
                List<Entity> entities = new List<Entity>
                    {
                        entity1, entity2
                    };

                var response = new RetrieveMultipleResponse
                {
                    Results = new ParameterCollection
                        {
                            { "EntityCollection", new EntityCollection(entities) }
                        }
                };

                return response;
            };

            string accountName = "abcabcabc";
            IEnumerable<Microsoft.Xrm.Sdk.Entity> actual;
            LINQToCRM2 target = new LINQToCRM2(service);

            //
            // Act
            //
            actual = target.RetrieveAccountsByName(accountName);

            //
            // Assert
            //
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(entity1, actual.ElementAt(0));
            Assert.AreEqual(entity2, actual.ElementAt(1));
        }

        [TestMethod]
        public void RetrieveAccountsByIdTest()
        {
            //
            // Arrange
            //
            Guid id = Guid.NewGuid();

            Microsoft.Xrm.Sdk.Entity expected = new Microsoft.Xrm.Sdk.Entity { Id = id };

            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();

            service.ExecuteOrganizationRequest = r =>
            {
                List<Entity> entities = new List<Entity>
                    {
                        expected
                    };

                var response = new RetrieveMultipleResponse
                {
                    Results = new ParameterCollection
                        {
                            { "EntityCollection", new EntityCollection(entities) }
                        }
                };

                return response;
            };

            Microsoft.Xrm.Sdk.Entity actual;
            LINQToCRM2 target = new LINQToCRM2(service);

            //
            // Act
            //
            actual = target.RetrieveAccountsById(id);

            //
            // Assert
            //
            Assert.AreEqual(expected, actual);
        }
    }
}
