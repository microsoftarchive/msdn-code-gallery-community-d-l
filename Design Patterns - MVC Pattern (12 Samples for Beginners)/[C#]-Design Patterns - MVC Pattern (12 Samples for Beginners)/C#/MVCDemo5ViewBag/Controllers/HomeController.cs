using System.Web.Mvc;

namespace MVCDemo5ViewBag
{
    public class HomeController : Controller
    { 
        public ActionResult About()
        {
            ViewData["Message"] = "Welcome!";
            Session["SampleSessionObject"] = "Hello Sai, this is from MVC Session";
            //Cache["SampleCacheObject"] = "Hello Sai, this is from MVC Cache";
            TempData["TempDataObject"] = "Hello Sai, this is from TempData";

            return View();
        }
    }
}