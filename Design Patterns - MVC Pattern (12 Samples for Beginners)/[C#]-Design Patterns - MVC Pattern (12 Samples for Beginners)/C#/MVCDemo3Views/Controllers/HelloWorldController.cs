using System.Web.Mvc;

namespace MVCDemo3Views
{
    public class HelloWorldController : Controller
    {
        public ActionResult SayHello()
        {
            return View();            

        }

        //[ChildActionOnly]
        public ActionResult SayPartialHello()
        {
            return PartialView();
        }
    }
}