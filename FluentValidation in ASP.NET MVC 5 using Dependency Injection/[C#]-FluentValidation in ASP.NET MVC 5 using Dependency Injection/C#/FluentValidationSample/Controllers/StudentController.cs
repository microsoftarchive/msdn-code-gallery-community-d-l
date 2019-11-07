using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidationSample.Models;

namespace FluentValidationSample.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddEditStudent()
        {
            StudentViewModel model = new StudentViewModel();
            return PartialView("_AddEditStudent",model);
        }

        public ActionResult AddEditStudent(StudentViewModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return RedirectToAction("index");
        }
    }
}