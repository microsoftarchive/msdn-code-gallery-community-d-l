using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3Filter.Filters;
using System.Diagnostics;

namespace Mvc3Filter.Controllers {
    [TraceActionFilter]   // trace all action methods in this controller
    public class SimpleController : Controller {

        readonly string action = "action";
        static string OnAuthRedirect;
        Random rnd = new Random();

        protected override void OnAuthorization(AuthorizationContext filterContext) {

            base.OnAuthorization(filterContext);
            // /Simple/About and /Home/About share the same view ( Shared/About )
            // The ViewBag.AuthorizeFilterMessage is displayed in the Shared/About
            // when /Simple/About is invoked.
            ViewBag.AuthorizeFilterMessage = "From Controller: " +
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (!filterContext.ActionDescriptor.ActionName.Contains("About"))
                return;

            // Randomly redirect request to "/Simple/About" to "/Simple/Details"
            // A more useful sample might redirect to a login method.
            if (rnd.Next() % 2 == 0) {
                filterContext.Result = new RedirectResult("/Simple/Details");
                OnAuthRedirect = "Redirected by OnAuthorization";
            }
        }

        void dumpData(ControllerContext context, string filter, string actionName = "Test1" ) {

            // Only write out data when Test1 is called (or the specifice action) 
            if (!context.RouteData.Values[action].ToString().Contains(actionName))
                return;

            var response = context.HttpContext.Response;
            var txt = String.Format(
                     "<hr /><h5>Action '{0} :: {1} From {2}'.</h5>",
                     context.RouteData.Values["controller"],
                     context.RouteData.Values[action],
                     filter
                 );

            if (response.ContentType == "text/html")
                response.Write(txt);
            else
                Debug.WriteLine(txt);  
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext) {

            base.OnActionExecuted(filterContext);
            string s = filterContext.ToString();
            dumpData(filterContext, "OnActionExecuted");
               
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);
            dumpData(filterContext, "OnActionExecuting");
            if (mytest(filterContext) == true) {
                filterContext.Result = new RedirectResult("/Home/Index");
                Debug.WriteLine(" Redirecting from Simple filter to /Home/Index");
            }

        }

        private bool mytest(ActionExecutingContext filterContext) {
            return (rnd.Next() % 3 == 0);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext) {
            base.OnResultExecuted(filterContext);
            dumpData(filterContext, "OnResultExecuted");
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext) {
            base.OnResultExecuting(filterContext);
            dumpData(filterContext, "OnResultExecuting");
        }

        protected override void OnException(ExceptionContext filterContext) {
            base.OnException(filterContext);
            dumpData(filterContext, "OnException", "e");
        }

        //
        // GET: /Simple/

        public ActionResult Index() {
            return View();
        }

        public ViewResult About() {
            return View();
        }

        public ViewResult Test1() {
            return View();
        }

        public ViewResult Details() {
            string s = this.Request.RawUrl;

            ViewBag.wasRedirected = OnAuthRedirect;
            OnAuthRedirect = "";
            return View();

        }

        public ViewResult ShowHandleErrorAttribute() {
            /* See Web.config file which requires customErrors element  as shown below
              <customErrors mode="On" defaultRedirect="Error" /> 
             * */
#pragma warning disable 0162
            throw new NotImplementedException();
            return View();
        }
    }
}
