using System;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using POCWCFService;


namespace POCPlugin
{
    public class UpdateSalesOrderDetailsPlugin : IPlugin
    {
        /// <summary>
        /// A plugin that update sales order details when WCF Service returns some values
        /// 
        /// </summary>
        /// <remarks>Register this plug-in on the Update message, salesorderdetail entity,
        /// and postoperation-event stage.
        /// </remarks>

        public void Execute(IServiceProvider serviceProvider)
        {

            //Extract the tracing service for use in debugging sandboxed plug-ins.
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.
            Microsoft.Xrm.Sdk.IPluginExecutionContext context = (Microsoft.Xrm.Sdk.IPluginExecutionContext)
                serviceProvider.GetService(typeof(Microsoft.Xrm.Sdk.IPluginExecutionContext));

            // Obtaining the organization service reference.
            IOrganizationService orgService = null;
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            orgService = serviceFactory.CreateOrganizationService(context.UserId);

            // The InputParameters collection contains all the data passed in the message request.
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parmameters.
                Entity entity = (Entity)context.InputParameters["Target"];

                try
                {
                    // Verify the target entity.
                    switch (entity.LogicalName)
                    {
                        case "account":
                            //Implementation of opportunity logic
                            break;
                        case "contact":
                            //Implementation of opportunity logic
                            break;
                        case "opportunity":
                            //Implementation of opportunity logic
                            break;
                        case "quote":
                            //Implementation of quote logic
                            break;
                        case "quotedetail":
                            //Implementation of quote detail logic
                            break;
                        case "salesorder":
                            //Implementation of sales order logic
                            break;
                        case "salesorderdetail":
                            //Implementation of sales order logic
                            break;
                    }
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in the UpdateSalesOrderDetails plug-in.", ex);
                }
                catch (Exception ex)
                {

                    tracingService.Trace("UpdateSalesOrderDetailsPlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }

        private void UpdateSalesOrderDetails(ITracingService tracingService, Microsoft.Xrm.Sdk.IPluginExecutionContext context, IOrganizationService orgService)
        {
            OrderEntity objOrder = new OrderEntity();
            decimal unitPrice = 0M;

            #region Calling WCF Service

            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.Name = "BasicHttpBinding_IPOCService";
            myBinding.Security.Mode = BasicHttpSecurityMode.None;
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            myBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
            myBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            //EndpointAddress endPointAddress = new EndpointAddress("http://amarprakash.ignify.net/POCService/POCService.svc");
            EndpointAddress endPointAddress = new EndpointAddress("http://igndevcrm2011.office.ignifi.com:81/POCService/POCService.svc");
            ChannelFactory<IPOCService> factory = new ChannelFactory<IPOCService>(myBinding, endPointAddress);
            IPOCService channel = factory.CreateChannel();
            objOrder = channel.GetCalculatedTaxValue(unitPrice);
            factory.Close();

            #endregion

            //Setting up tax value
            SalesOrderDetail entity = new SalesOrderDetail();
            entity.Tax = new Money(objOrder.TaxAmount);

            // Update the sales order details in Microsoft Dynamics CRM.
            tracingService.Trace("UpdateSalesOrderDetailsPlugin: Updating the sales order details.");
            //Update Sales Order Entity
            if (context.Depth == 1)
                orgService.Update(entity);
        }
    }
}
