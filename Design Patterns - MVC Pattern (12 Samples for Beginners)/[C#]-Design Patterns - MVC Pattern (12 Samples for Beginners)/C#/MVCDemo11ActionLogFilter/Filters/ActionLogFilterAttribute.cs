using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace MVCDemo11ActionLogFilter.Filters
{
    public class ActionLogFilterAttribute : ActionFilterAttribute, IActionFilter, IResultFilter
    {
        readonly string action = "action";
        readonly string render = "render";

        Stopwatch GetTimer(ControllerContext context, string name)
        {
            string key = "__timer__" + name;

            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }

            var result = new Stopwatch();
            context.HttpContext.Items[key] = result;
            return result;
        }
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Here is the place for checking the actions and take necessary actions.
            //1. Redirecting them to necessary routes.
            //2. Logging actions into the database.
            //3. Performance tracking.
            //4. Any other logics to perform before executing the requested routing.

            GetTimer(filterContext, action).Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            GetTimer(filterContext, action).Stop();
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Here is the place for checking the results and take necessary actions.
            //1. Redirecting them to necessary routes.
            //2. Logging results into the database.
            //3. Performance tracking.
            //4. Any other logics to perform before sending the response to client.

            //E.g:
            //result.JsonRequestBehavior = Behavior;

            GetTimer(filterContext, render).Start();
        }
             
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Do not show filter multiple times when using Html.RenderAction or Html.Action.
            if (filterContext.IsChildAction == true)
            {
                return;
            }
            var responseValue = String.Format(
                    "Request: {0} :: {1}, Status {2}, Result type = {3}",
                    filterContext.RouteData.Values["controller"],
                    filterContext.RouteData.Values["action"],
                    filterContext.HttpContext.Response.StatusCode,
                    filterContext.Result.GetType().FullName
                );
            
            // Trace.WriteLine(responseValue);  // View with http://technet.microsoft.com/en-us/sysinternals/bb896647.aspx
            Debug.WriteLine(responseValue);  // View in VS debug output window or DebugView
            // Use the following filter with debugView >> MSEnv*;*HR prop*;*HR orig*;*Source File*;
        }
    }
}