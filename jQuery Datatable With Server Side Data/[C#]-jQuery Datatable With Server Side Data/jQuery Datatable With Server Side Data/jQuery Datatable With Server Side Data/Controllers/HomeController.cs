using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jQuery_Datatable_With_Server_Side_Data.Models;
namespace jQuery_Datatable_With_Server_Side_Data.Controllers
{
    public class HomeController : Controller
    {
        TrialsDBEntities tdb;
        Sales sa = new Sales();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetGata()
        {
            try
            {
                using (tdb = new TrialsDBEntities())
                {
                    var myList = sa.GetSales(tdb);                    
                    return Json(myList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
