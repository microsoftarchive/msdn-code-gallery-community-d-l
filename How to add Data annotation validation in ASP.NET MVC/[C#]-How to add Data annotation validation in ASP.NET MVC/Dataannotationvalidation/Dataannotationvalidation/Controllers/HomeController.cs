using Dataannotationvalidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dataannotationvalidation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Profile model)
        {
            // and if You want to remove validation  for field Id then
            if (ModelState.Keys.Contains("Id"))
            {
                ModelState["Id"].Errors.Clear();
            }
            if (ModelState.IsValid) //this condition is for validation checking on server side
            {
                // Save into database
            }
            return View(model);
        }
	}
}