using System.Web.Mvc;

namespace MVCDemo9AddingExtensionMethods
{
    public class HelloWorldController : Controller
    {
        public ActionResult SayHello()
        {
            return View();            
        }
    }
}