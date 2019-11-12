using System;
using System.Web.Mvc;
using System.Diagnostics;

namespace Mvc3Filter.Filters {
    public class TraceActionFilterAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var txt = getResponseString(filterContext.ActionDescriptor, "OnActionExecuting");
            WriteResponse(txt, filterContext);
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            var txt = getResponseString(filterContext.ActionDescriptor, "OnActionExecuted");
            WriteResponse(txt, filterContext);
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext) {

            var txt = getResponseString(filterContext, "OnResultExecuting");
            WriteResponse(txt, filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext) {
            // Don't show filter multiple times when using Html.RenderAction or Html.Action.
            if (filterContext.IsChildAction == true)
                return;
            var txt = getResponseString(filterContext, "OnResultExecuted");
            WriteResponse(txt, filterContext);
        }

        string getResponseString(ControllerContext filterContext, string onAct) {
            var txt = String.Format(
                   "<hr /><h5>TraceActionFilterAttribute {0} : Action '{1} :: {2}'</h5>",
                   onAct,
                  filterContext.RouteData.Values["controller"],
                   filterContext.RouteData.Values["action"]
               );

            return txt;
        }
        string getResponseString(ActionDescriptor ad, string onAct) {
            var txt = String.Format(
                   "<hr /><h5>TraceActionFilterAttribute {0} : Action '{1} :: {2}'</h5>",
                   onAct,
                   ad.ControllerDescriptor.ControllerName,
                   ad.ActionName
               );

            return txt;
        }

        void WriteDbg( string txt) {
            Debug.WriteLine(txt);
        }

        void WriteResponse(string txt, ControllerContext filterContext) {
            var response = filterContext.HttpContext.Response;
            if (response.ContentType == "text/html")
                response.Write(txt);
            else
                Debug.WriteLine(txt);
        }
    }

}