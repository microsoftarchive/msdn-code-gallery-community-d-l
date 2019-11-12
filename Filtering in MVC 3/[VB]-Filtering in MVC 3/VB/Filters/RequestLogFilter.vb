Imports System.Web.Mvc

#Const DEBUG = True ' #define TRACE or DEBUG to enable Tracing based on the Trace Class

Namespace Mvc3Filter.Filters

    Public Class RequestLogFilter
        Implements IResultFilter
        Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext) Implements IResultFilter.OnResultExecuting
        End Sub

        Public Sub OnResultExecuted(ByVal filterContext As ResultExecutedContext) Implements IResultFilter.OnResultExecuted

            ' Don't show filter multiple times when using Html.RenderAction or Html.Action.
            If filterContext.IsChildAction = True Then
                Return
            End If

            Dim txt = String.Format("REQUEST: {0} :: {1}, Status {2}, Result type = {3}", filterContext.RouteData.Values(DebugFilterHelper.sController), filterContext.RouteData.Values(DebugFilterHelper.sAction), filterContext.HttpContext.Response.StatusCode, filterContext.Result.GetType().FullName)
            ' ToDo use DebugFilterHelper
            ' View with http://technet.microsoft.com/en-us/sysinternals/bb896647.aspx
            Trace.WriteLine(txt) ' View in VS debug output window or DebugView
            ' Use the following filter with debugView >> MSEnv*;*HR prop*;*HR orig*;*Source File*;

        End Sub

    End Class
End Namespace






