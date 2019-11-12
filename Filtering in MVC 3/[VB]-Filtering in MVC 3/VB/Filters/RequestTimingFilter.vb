Imports System.Web.Mvc
Imports Mvc3Filter.Filters

Public Class RequestTimingFilter
	Implements IActionFilter, IResultFilter

	Private ReadOnly render As String = "render"
	Private Function GetTimer(ByVal context As ControllerContext, ByVal name As String) As Stopwatch
		Dim key As String = "__timer__" & name
		If context.HttpContext.Items.Contains(key) Then
			Return CType(context.HttpContext.Items(key), Stopwatch)
		End If

		Dim result = New Stopwatch()
		context.HttpContext.Items(key) = result
		Return result
	End Function

    Public Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext) Implements IActionFilter.OnActionExecuting
        GetTimer(filterContext, DebugFilterHelper.sAction).Start()
        DebugInfo(filterContext, filterContext.GetType().FullName)
    End Sub

    Public Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext) Implements IActionFilter.OnActionExecuted
        DebugInfo(filterContext, filterContext.GetType().FullName)
        GetTimer(filterContext, DebugFilterHelper.sAction).Stop()
    End Sub

    Public Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext) Implements IResultFilter.OnResultExecuting
        GetTimer(filterContext, render).Start()
        DebugInfo(filterContext, filterContext.GetType().FullName)
    End Sub

    Public Sub OnResultExecuted(ByVal filterContext As ResultExecutedContext) Implements IResultFilter.OnResultExecuted

        ' Don't show filter multiple times when using Html.RenderAction or Html.Action.
        If filterContext.IsChildAction = True Then
            Return
        End If

        Dim renderTimer = GetTimer(filterContext, render)
        renderTimer.Stop()
        DebugInfo(filterContext, filterContext.GetType().FullName)

        Dim actionTimer = GetTimer(filterContext, DebugFilterHelper.sAction)
        Dim response = filterContext.HttpContext.Response

        Dim txt = String.Format("<hr /><h5>Action '{0} :: {1}' took {2}ms to execute and {3}ms to render.</h5>", filterContext.RouteData.Values(DebugFilterHelper.sController), filterContext.RouteData.Values(DebugFilterHelper.sAction), actionTimer.ElapsedMilliseconds, renderTimer.ElapsedMilliseconds)

        If response.ContentType = "text/html" Then
            response.Write(txt)
        Else
            Trace.WriteLine(txt)
        End If
    End Sub

	Private Sub DebugInfo(ByVal context As ControllerContext, ByVal sFilterMethod As String)
#If DbgRequestTimingFilter Then
		DebugFilterHelper.DebugFilter(context, sFilterMethod, Me.ToString())
#End If
	End Sub



End Class