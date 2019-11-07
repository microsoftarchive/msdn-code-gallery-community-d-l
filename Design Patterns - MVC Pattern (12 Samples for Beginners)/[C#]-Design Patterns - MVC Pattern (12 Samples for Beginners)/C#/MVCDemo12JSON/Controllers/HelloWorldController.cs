using System.Web.Mvc;

namespace MVCDemo12JSON
{
    public class LogMessage
    {
        public string Message { get; set; }
        public int Id { get; set; }
    }
    public class HelloWorldController : Controller
    {
        public ActionResult SayHello()
        {
            return View();            
        }
                
        //public ActionResult SayHelloMessage(string _message)
        [HttpGet]
        public JsonResult SayHelloMessage(int id)
        {
            if (Request.IsAjaxRequest())
            {
                // Display the confirmation message
                var MessageObject = new LogMessage
                {
                    Message = (id.ToString() + " Message receied from JSON Client and sending back with this text")
                };

                // Remove JsonRequestBehavior.AllowGet and see.
                return Json(MessageObject, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult MakeJsonCall(int param)
        {
            string name = string.Empty;
            string Email = string.Empty;

            if (param == 1)
            {
                name = "Sai";
                Email = "Sai@Sai.com";
            }
            else if (param == 2)
            {
                name = "Sri";
                Email = "Sri@Sri.com";
            }
            else if (param == 3)
            {
                name = "SaiSri";
                Email = "SaiSri@SaiSri.com";
            }

            var datajson = new
            {
                name,
                Email
            };

            //JsonResult result = new JsonResult();
            //result.Data = ..... ;
            //result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;


            return Json(datajson, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ShowAJAXDemoView()
        {
            return View("AJAXDemoView");
        }
    }
}

// Read more about JSON hijacking here http://haacked.com/archive/2009/06/25/json-hijacking.aspx



