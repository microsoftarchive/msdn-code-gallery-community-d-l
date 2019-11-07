// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using AzureMobile.Samples.FieldEngineer.Service.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace AzureMobile.Samples.FieldEngineer.Service.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class CustomerController : TableController<Customer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            this.DomainManager = new EntityDomainManager<Customer>(context, Request, Services);
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return this.Query();
        }

        public SingleResult<Customer> GetCustomer(string id)
        {
            return this.Lookup(id);
        }
    }
}
    