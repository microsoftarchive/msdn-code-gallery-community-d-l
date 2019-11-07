using System;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Client.Messages;
using Microsoft.Crm.Sdk.Messages;
using CrmOrganizationServiceContextExtensions;

namespace DynamicsCRMUnitTest.WebService
{
    public class CrmContextMethods
    {
        private ICrmOrganizationServiceContext _crmContext;

        public CrmContextMethods(ICrmOrganizationServiceContext crmContext)
        {
            _crmContext = crmContext;
        }

        public string RetrieveVersion()
        {
            var version = _crmContext.RetrieveVersion();

            return version;
        }

        public Guid CreateAccount(string name)
        {
            var entity = new Entity("account")
            {
                Attributes = new Microsoft.Xrm.Sdk.AttributeCollection
                {
                    { "name", name }
                }
            };

            var id = _crmContext.Create(entity);

            return id;
        }
    }
}
