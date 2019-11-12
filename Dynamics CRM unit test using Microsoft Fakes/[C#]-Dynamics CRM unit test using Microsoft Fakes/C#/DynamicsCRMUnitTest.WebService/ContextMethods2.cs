using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DynamicsCRMUnitTest.WebService
{
    public class ContextMethods2
    {
        private OrganizationServiceContext _context;

        public ContextMethods2(IOrganizationService service)
        {
            _context = new OrganizationServiceContext(service);
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

            _context.AddObject(entity);

            var results = _context.SaveChanges();

            return entity.Id;
        }
    }
}
