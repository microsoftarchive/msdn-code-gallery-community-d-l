using System.Web.Mvc;

namespace MVCDemo8HTMLHelper
{
    public class HelloWorldController : Controller
    {
        public ActionResult SayHello()
        {
            return View();            
        }
    }
}