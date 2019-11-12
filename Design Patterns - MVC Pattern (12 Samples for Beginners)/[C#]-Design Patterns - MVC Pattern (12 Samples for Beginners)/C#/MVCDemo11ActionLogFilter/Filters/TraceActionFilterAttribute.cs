using System;
using System.Web.Mvc;
using System.Diagnostics;

namespace MVCDemo11ActionLogFilter.Filters 
{
    public class TraceActionFilterAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            var responseValue = GetResponseString(filterContext.ActionDescriptor, "OnActionExecuting");
            WriteResponse(responseValue, filterContext);
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) 
        {
            var responseValue = GetResponseString(filterContext.ActionDescriptor, "OnActionExecuted");
            WriteResponse(responseValue, filterContext);
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext) 
        {
            var responseValue = GetResponseString(filterContext, "OnResultExecuting");
            WriteResponse(responseValue, filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext) 
        {
            // Don't show filter multiple times when using Html.RenderAction or Html.Action.
            if (filterContext.IsChildAction == true)
                return;

            var responseValue = GetResponseString(filterContext, "OnResultExecuted");

            WriteResponse(responseValue, filterContext);
        }

        string GetResponseString(ControllerContext filterContext, string onAction) 
        {
            return String.Format("<hr /><h5>TraceActionFilterAttribute {0} : Action '{1} :: {2}'</h5>",onAction,filterContext.RouteData.Values["controller"],filterContext.RouteData.Values["action"]);
        }

        string GetResponseString(ActionDescriptor actionDescriptor, string onAction) 
        {
            return String.Format("<hr /><h5>TraceActionFilterAttribute {0} : Action '{1} :: {2}'</h5>",onAction,actionDescriptor.ControllerDescriptor.ControllerName,actionDescriptor.ActionName);
        }

        void WriteResponse(string responseValue, ControllerContext filterContext) 
        {
            var response = filterContext.HttpContext.Response;

            if (response.ContentType == "text/html")
                response.Write(responseValue);
            else
                Debug.WriteLine(responseValue);
        }
    }
}