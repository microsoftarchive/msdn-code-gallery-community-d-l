using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace DynamicsCRMUnitTest.WebService
{
    public class OrganizationServiceMethods
    {
        private IOrganizationService _service;

        public OrganizationServiceMethods(IOrganizationService service)
        {
            _service = service;
        }

        public IEnumerable<Guid> RetrieveAccountIdByName(string name)
        {
            QueryByAttribute query = new QueryByAttribute("account")
            {
                ColumnSet = new ColumnSet("accountid")
            };
            query.Attributes.Add("name");
            query.Values.Add(name);

            var result = _service.RetrieveMultiple(query);

            List<Guid> ids = new List<Guid>();

            foreach (var entity in result.Entities)
            {
                ids.Add(entity.GetAttributeValue<Guid>("accountid"));
            }

            return ids;
        }
    }
}
