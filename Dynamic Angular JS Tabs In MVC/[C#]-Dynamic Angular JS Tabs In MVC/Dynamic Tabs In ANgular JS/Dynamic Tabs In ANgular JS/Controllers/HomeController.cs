using Dynamic_Tabs_In_ANgular_JS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dynamic_Tabs_In_ANgular_JS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult TabData()
        {
            Test t = new Test();
            var myList = t.GetData();
            return Json(myList, JsonRequestBehavior.AllowGet);
        }

    }
}
