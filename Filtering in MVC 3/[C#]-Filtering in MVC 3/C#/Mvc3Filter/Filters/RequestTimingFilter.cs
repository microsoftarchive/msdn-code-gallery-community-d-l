using System;
using System.Diagnostics;
using System.Web.Mvc;

public class RequestTimingFilter :  IActionFilter, IResultFilter {

    readonly string action = "action";
    readonly string render = "render";
    Stopwatch GetTimer(ControllerContext context, string name) {
        string key = "__timer__" + name;
        if (context.HttpContext.Items.Contains(key)) {
            return (Stopwatch)context.HttpContext.Items[key];
        }

        var result = new Stopwatch();
        context.HttpContext.Items[key] = result;
        return result;
    }

    public void OnActionExecuting(ActionExecutingContext filterContext) {
        GetTimer(filterContext, action).Start();
    }

    public void OnActionExecuted(ActionExecutedContext filterContext) {
        GetTimer(filterContext, action).Stop();
    }

    public void OnResultExecuting(ResultExecutingContext filterContext) {
        GetTimer(filterContext, render).Start();
    }

    public void OnResultExecuted(ResultExecutedContext filterContext) {

        // Don't show filter multiple times when using Html.RenderAction or Html.Action.
        if (filterContext.IsChildAction == true)
            return;

        var renderTimer = GetTimer(filterContext, render);
        renderTimer.Stop();

        var actionTimer = GetTimer(filterContext, action);
        var response = filterContext.HttpContext.Response;

        var txt = String.Format(
                    "<hr /><h5>Action '{0} :: {1}' took {2}ms to execute and {3}ms to render.</h5>",
                    filterContext.RouteData.Values["controller"],
                    filterContext.RouteData.Values[action],
                    actionTimer.ElapsedMilliseconds,
                    renderTimer.ElapsedMilliseconds
                );

        if (response.ContentType == "text/html") 
            response.Write(txt);
        else
            Debug.WriteLine(txt);                   
    }



}