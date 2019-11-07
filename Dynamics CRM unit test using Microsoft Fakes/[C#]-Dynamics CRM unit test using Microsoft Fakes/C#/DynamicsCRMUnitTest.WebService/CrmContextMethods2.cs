using System;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Messages;
using Microsoft.Xrm.Sdk;

namespace DynamicsCRMUnitTest.WebService
{
    public class CrmContextMethods2
    {
        private CrmOrganizationServiceContext _crmContext;

        public CrmContextMethods2(IOrganizationService service)
        {
            _crmContext = new CrmOrganizationServiceContext(service);
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
