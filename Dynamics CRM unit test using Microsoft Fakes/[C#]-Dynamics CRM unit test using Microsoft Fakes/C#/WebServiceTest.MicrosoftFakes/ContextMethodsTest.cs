using System;
using DynamicsCRMUnitTest.WebService;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System.Reflection;
using System.Linq;

namespace WebServiceTest.MicrosoftFakes
{
    [TestClass]
    public class ContextMethodsTest
    {
        [TestMethod]
        public void CreateAccountTest()
        {
            //
            // Arrange
            //
            var connection = new CrmConnection("Crm");
            var service = new OrganizationService(connection);
            var context = new OrganizationServiceContext(service);
            using (ShimsContext.Create())
            {
                string accountName = "abcabcabc";
                Guid actual;
                Guid expected = Guid.NewGuid();

                int callCount = 0;
                Entity entity = null;

                var fakeContext = new Microsoft.Xrm.Sdk.Client.Fakes.ShimOrganizationServiceContext(context);                

                fakeContext.AddObjectEntity = e =>
                {
                    callCount++;
                    entity = e;
                };

                fakeContext.SaveChanges = () =>
                {
                    entity.Id = expected;
                    
                    // SaveChangesResultCollection only has one internal constructor
                    // so we can not create a instance outside of Microsoft.Xrm.Sdk assembly
                    // we will use reflection to create instances of SaveChangesResultCollection and SaveChangesResult
                    var results = CreateSaveChangesResultCollection(SaveChangesOptions.None);

                    var request = new OrganizationRequest();
                    var response = new OrganizationResponse();

                    results.Add(CreateSaveChangesResult(request, response));

                    return results;
                };

                ContextMethods target = new ContextMethods(context);                

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

        private SaveChangesResultCollection CreateSaveChangesResultCollection(SaveChangesOptions option)
        {
            var con = typeof(SaveChangesResultCollection).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var results = con.Invoke(new object[] { option }) as SaveChangesResultCollection;
            return results;
        }

        private SaveChangesResult CreateSaveChangesResult(OrganizationRequest request, OrganizationResponse response)
        {
            var con = typeof(SaveChangesResult).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var result = con.Invoke(new object[] { request, response }) as SaveChangesResult;
            return result;
        }

        private SaveChangesResult CreateSaveChangesResult(OrganizationRequest request, Exception error)
        {
            var con = typeof(SaveChangesResult).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var result = con.Invoke(new object[] { request, error }) as SaveChangesResult;
            return result;
        }
    }
}
