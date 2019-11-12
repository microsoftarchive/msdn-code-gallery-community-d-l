using System;
using System.Diagnostics;
using DynamicsCRMUnitTest.Plugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;

namespace PluginTest.MicrosoftFakes
{
    [TestClass]
    public class PluginTest
    {
        /// <summary>
        ///A test for Execute
        ///</summary>
        [TestMethod()]
        public void ExecuteTest()
        {
            //
            // Arrange
            //
            string unsecure = "unsecure";
            string secure = "secure";
            Plugin target = new Plugin(unsecure, secure);

            var accountId = Guid.NewGuid();
            var previousNumber = 3;
            var expected = 4;
            var actual = 0;

            // IOrganizationService
            var service = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationService();
            service.RetrieveStringGuidColumnSet = (entityName, id, columns) =>
                {
                    return new Microsoft.Xrm.Sdk.Entity("account")
                                            {
                                                Id = accountId,
                                                Attributes = { { "numberofemployees", previousNumber } }
                                            };
                };
            service.UpdateEntity = (entity) =>
                {
                    actual = entity.GetAttributeValue<int>("numberofemployees");
                };

            // IPluginExecutionContext
            var pluginExecutionContext = new Microsoft.Xrm.Sdk.Fakes.StubIPluginExecutionContext();
            pluginExecutionContext.StageGet = () => { return 40; };
            pluginExecutionContext.MessageNameGet = () => { return "Create"; };
            pluginExecutionContext.PrimaryEntityNameGet = () => { return "contact"; };
            pluginExecutionContext.PostEntityImagesGet = () =>
            {
                return new EntityImageCollection
                { 
                    { "PostCreateImage", new Microsoft.Xrm.Sdk.Entity("contact") 
                                            {
                                                Attributes = { { "parentcustomerid", new EntityReference("account", accountId) } }
                                            }
                    }
                };
            };

            // ITracingService
            var tracingService = new Microsoft.Xrm.Sdk.Fakes.StubITracingService();
            tracingService.TraceStringObjectArray = (f, o) =>
                {
                    Debug.WriteLine(f, o);
                };

            // IOrganizationServiceFactory
            var factory = new Microsoft.Xrm.Sdk.Fakes.StubIOrganizationServiceFactory();
            factory.CreateOrganizationServiceNullableOfGuid = id =>
                {
                    return service;
                };

            // IServiceProvider
            var serviceProvider = new System.Fakes.StubIServiceProvider();
            serviceProvider.GetServiceType = t =>
                {
                    if (t == typeof(IPluginExecutionContext))
                    {
                        return pluginExecutionContext;
                    }
                    else if (t == typeof(ITracingService))
                    {
                        return tracingService;
                    }
                    else if (t == typeof(IOrganizationServiceFactory))
                    {
                        return factory;
                    }

                    return null;
                };

            //
            // Act
            //
            target.Execute(serviceProvider);

            //
            // Assert
            //
            Assert.AreEqual(expected, actual);
        }
    }
}
