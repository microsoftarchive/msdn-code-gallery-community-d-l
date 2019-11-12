using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DynamicsCRMUnitTest.WebService
{
    public class ContextMethods
    {
        private OrganizationServiceContext _context;

        public ContextMethods(OrganizationServiceContext context)
        {
            _context = context;
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
