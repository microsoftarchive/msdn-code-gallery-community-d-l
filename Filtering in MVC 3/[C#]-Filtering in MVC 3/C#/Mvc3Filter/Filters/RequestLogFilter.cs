#define DEBUG    // #define TRACE or DEBUG to enable Tracing based on the Trace Class

namespace Mvc3Filter.Filters {
    using System;
    using System.Diagnostics;
    using System.Web.Mvc;

    public class RequestLogFilter : IResultFilter {
        public void OnResultExecuting(ResultExecutingContext filterContext) {
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {

            // Don't show filter multiple times when using Html.RenderAction or Html.Action.
            if (filterContext.IsChildAction == true)
                return;

            var txt = String.Format(
                    "REQUEST: {0} :: {1}, Status {2}, Result type = {3}",
                    filterContext.RouteData.Values["controller"],
                    filterContext.RouteData.Values["action"],
                    filterContext.HttpContext.Response.StatusCode,
                    filterContext.Result.GetType().FullName
                );
          // Trace.WriteLine(txt);  // View with http://technet.microsoft.com/en-us/sysinternals/bb896647.aspx
           Debug.WriteLine(txt);  // View in VS debug output window or DebugView
            // Use the following filter with debugView >> MSEnv*;*HR prop*;*HR orig*;*Source File*;
           
        }
    }
}