using System.Linq;
using System.Web.Mvc;

using MVCDemo13JSONAjaxRequestResponse.Models;

namespace MVCDemo13JSONAjaxRequestResponse.Controllers 
{   
    [HandleError]
    public class HomeController : Controller 
    {
        public ActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(PersonModel inputModel) 
        {
            if (ModelState.IsValid)
            {
                string message = string.Format("Response received from Server.\n Your Name '{0}' and Age '{1}'.", inputModel.Name, inputModel.Age);
                return Json(new ResulMessage { Message = message });
            }
            else 
            {
                string errorMessage = "<div class=\"validation-summary-errors\">The following errors occurred:<ul>";

                foreach (var key in ModelState.Keys) 
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null) 
                    {
                        errorMessage += "<li class=\"field-validation-error\">" + error.ErrorMessage + "</li>";
                    }
                }
                errorMessage += "</ul>";

                return Json(new ResulMessage { Message = errorMessage });
            }
        }

        [HttpGet]
        public JsonResult SayHelloMessage(int id)
        {
            //if(Request.IsAjaxRequest())
            {
                // Display the confirmation message
                var MessageObject = new ResulMessage
                {
                    Message = (id.ToString() + " Message receied from JSON Client and sending back with this text")
                };

                // Remove JsonRequestBehavior.AllowGet and see.
                //return Json(MessageObject, JsonRequestBehavior.AllowGet);
                string message = (id.ToString() + " Message receied from JSON Client and sending back with this text");
                return Json(new ResulMessage { Message = message });
            }
            //return null;
            //Need to fix few defects
            //<%: Ajax.ActionLink("JSON Request", "SayHelloMessage", new { id = 123 }, new AjaxOptions { HttpMethod = "Get", OnSuccess = "handleUpdateMethod" })%>
        }
    }
}