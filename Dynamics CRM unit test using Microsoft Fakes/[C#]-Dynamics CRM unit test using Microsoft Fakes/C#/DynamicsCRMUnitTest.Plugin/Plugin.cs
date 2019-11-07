using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace DynamicsCRMUnitTest.Plugin
{
    public class Plugin : IPlugin
    {
        private string _unsecure, _secure;

        /// <summary>
        /// Alias of the image registered for the snapshot of the 
        /// primary entity's attributes after the core platform operation executes.
        /// The image contains the following attributes:
        /// parentcustomerid
        /// 
        /// Note: Only synchronous post-event and asynchronous registered plug-ins 
        /// have PostEntityImages populated.
        /// </summary>
        private readonly string postImageAlias = "PostCreateImage";

        public Plugin(string unsecure, string secure)
        {
            _unsecure = unsecure;
            _secure = secure;
        }

        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context service from the service provider.
            var pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (pluginExecutionContext.Stage == 40 && pluginExecutionContext.MessageName == "Create" && pluginExecutionContext.PrimaryEntityName == "contact")
            {
                // Obtain the tracing service from the service provider.
                var tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

                // Obtain the Organization Service factory service from the service provider
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

                // Use the factory to generate the Organization Service.
                var organizationService = factory.CreateOrganizationService(pluginExecutionContext.UserId);

                Entity postImageEntity = (pluginExecutionContext.PostEntityImages != null && pluginExecutionContext.PostEntityImages.Contains(this.postImageAlias)) ? pluginExecutionContext.PostEntityImages[this.postImageAlias] : null;

                // when a contact is created with parent account, increase number of employees for that account
                if (postImageEntity != null && postImageEntity.Contains("parentcustomerid"))
                {
                    EntityReference parentCustomer = postImageEntity.GetAttributeValue<EntityReference>("parentcustomerid");

                    if (parentCustomer != null && parentCustomer.LogicalName.ToLowerInvariant() == "account")
                    {
                        tracingService.Trace("Parent account id: {0}.", parentCustomer.Id);

                        Entity parentAccount = organizationService.Retrieve("account", parentCustomer.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet("numberofemployees"));

                        int numberOfEmployees = 0;
                        if (parentAccount.Contains("numberofemployees"))
                        {
                            numberOfEmployees = parentAccount.GetAttributeValue<int>("numberofemployees");
                        }

                        parentAccount["numberofemployees"] = numberOfEmployees + 1;

                        organizationService.Update(parentAccount);
                    }
                }
            }
        }
    }
}
