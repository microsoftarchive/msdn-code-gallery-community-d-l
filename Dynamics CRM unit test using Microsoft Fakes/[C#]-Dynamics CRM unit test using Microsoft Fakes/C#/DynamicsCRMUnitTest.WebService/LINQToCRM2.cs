﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DynamicsCRMUnitTest.WebService
{
    public class LINQToCRM2
    {
        private OrganizationServiceContext _context;

        public LINQToCRM2(IOrganizationService service)
        {
            _context = new OrganizationServiceContext(service);
        }

        public IEnumerable<Entity> RetrieveAccountsByName(string name)
        {
            var query = from account in _context.CreateQuery("account")
                        where account.GetAttributeValue<string>("name") == name
                        select account;

            var accountList = new List<Entity>();

            foreach (var entity in query)
            {
                accountList.Add(entity);
            }

            //We can simply call query.ToList()
            //foreach loop here is to demonstrate item Enumeration

            return accountList;
        }

        public Entity RetrieveAccountsById(Guid id)
        {
            var query = from account in _context.CreateQuery("account")
                        where account.GetAttributeValue<Guid>("accountid") == id
                        select account;

            var accountEntity = query.FirstOrDefault();

            return accountEntity;
        }
    }
}
