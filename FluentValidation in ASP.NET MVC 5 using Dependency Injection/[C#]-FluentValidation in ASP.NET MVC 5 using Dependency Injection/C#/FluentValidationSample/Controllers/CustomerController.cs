using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidationSample.Models;

namespace FluentValidationSample.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult AddEditCustomer()
        {
            CustomerViewModel model = new CustomerViewModel();
            return View("AddEditCustomer", model);
        }

        [HttpPost]
        public ActionResult AddEditCustomer(CustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Operation goes here
            }
            return View("AddEditCustomer", model);
        }

    }
}