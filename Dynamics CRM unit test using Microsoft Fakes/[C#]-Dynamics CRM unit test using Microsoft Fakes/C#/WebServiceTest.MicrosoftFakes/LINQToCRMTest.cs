using System;
using System.Collections.Generic;
using System.Linq;
using DynamicsCRMUnitTest.WebService;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Client;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class LINQToCRMTest
    {
        [TestMethod]
        public void RetrieveAccountsByNameTest()
        {
            var connection = new CrmConnection("Crm");
            var service = new OrganizationService(connection);
            var context = new OrganizationServiceContext(service);
            using (ShimsContext.Create())
            {
                var fakeContext = new Microsoft.Xrm.Sdk.Client.Fakes.ShimOrganizationServiceContext(context);
                LINQToCRM target = new LINQToCRM(context);

                var entity1 = new Microsoft.Xrm.Sdk.Entity("account");
                entity1.Id = Guid.NewGuid();
                entity1["name"] = "abcabcabc";

                var entity2 = new Microsoft.Xrm.Sdk.Entity("account");
                entity2.Id = Guid.NewGuid();
                entity2["name"] = "123123123";

                var entity3 = new Microsoft.Xrm.Sdk.Entity("account");
                entity3.Id = Guid.NewGuid();
                entity3["name"] = "a1b2c3a1b2c3";

                fakeContext.CreateQueryString = (entityName) =>
                {
                    return new System.Linq.EnumerableQuery<Microsoft.Xrm.Sdk.Entity>(new Microsoft.Xrm.Sdk.Entity[] { entity1, entity2, entity3 });
                };

                IEnumerable<Microsoft.Xrm.Sdk.Entity> expected = new List<Microsoft.Xrm.Sdk.Entity> { entity1, entity2 };

                System.Linq.Fakes.ShimEnumerableQuery<Microsoft.Xrm.Sdk.Entity>.AllInstances.GetEnumerator = (a) =>
                {
                    return expected.GetEnumerator();
                };

                string accountName = "abcabcabc";
                IEnumerable<Microsoft.Xrm.Sdk.Entity> actual;
                actual = target.RetrieveAccountsByName(accountName);

                Assert.AreEqual(expected.Count(), actual.Count());
                Assert.AreEqual(expected.ElementAt(0), actual.ElementAt(0));
                Assert.AreEqual(expected.ElementAt(1), actual.ElementAt(1));
            }
        }

        [TestMethod]
        public void RetrieveAccountsByIdTest()
        {
            var connection = new CrmConnection("Crm");
            var service = new OrganizationService(connection);
            var context = new OrganizationServiceContext(service);
            using (ShimsContext.Create())
            {
                var fakeContext = new Microsoft.Xrm.Sdk.Client.Fakes.ShimOrganizationServiceContext(context);
                LINQToCRM target = new LINQToCRM(context);

                fakeContext.CreateQueryString = (entityName) =>
                {
                    return new System.Linq.EnumerableQuery<Microsoft.Xrm.Sdk.Entity>(new Microsoft.Xrm.Sdk.Entity[] { });
                };

                Guid id = Guid.NewGuid();

                Microsoft.Xrm.Sdk.Entity expected = new Microsoft.Xrm.Sdk.Entity();

                System.Linq.Fakes.ShimQueryable.FirstOrDefaultOf1IQueryableOfM0<Microsoft.Xrm.Sdk.Entity>((a) =>
                {
                    expected.Id = id;
                    return expected;
                });

                Microsoft.Xrm.Sdk.Entity actual;

                actual = target.RetrieveAccountsById(id);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
