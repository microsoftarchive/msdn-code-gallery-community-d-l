Imports System.Web.Mvc

Namespace Mvc3Filter.Filters
	Public Class TraceActionFilterAttribute
		Inherits ActionFilterAttribute

		Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
			Dim sFilterMethod As String = filterContext.GetType().FullName
			Dim txt = getResponseString(filterContext.ActionDescriptor, sFilterMethod)
			DebugInfo(filterContext, sFilterMethod)
			WriteResponse(txt, filterContext)
			MyBase.OnActionExecuting(filterContext)

			If filterContext.RouteData.Values.ContainsValue("Cancel") Then
				filterContext.Result = New RedirectResult("~/Home/Index")
				Trace.WriteLine(" Redirecting from Simple filter to /Home/Index")
			End If

		End Sub

		Private Sub DebugInfo(ByVal context As ControllerContext, ByVal sFilterMethod As String)
#If DbgTraceActionFilterAttribute Then
			DebugFilterHelper.DebugFilter(context, sFilterMethod, Me.ToString())
#End If
		End Sub

		Public Overrides Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext)

			Dim sFilterMethod As String = filterContext.GetType().FullName
			DebugInfo(filterContext, sFilterMethod)
			Dim txt = getResponseString(filterContext.ActionDescriptor, sFilterMethod)

			WriteResponse(txt, filterContext)
			MyBase.OnActionExecuted(filterContext)
		End Sub

		Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
			Dim sFilterMethod As String = filterContext.GetType().FullName
			DebugInfo(filterContext, sFilterMethod)
			Dim txt = getResponseString(filterContext, sFilterMethod)
			WriteResponse(txt, filterContext)
		End Sub

		Public Overrides Sub OnResultExecuted(ByVal filterContext As ResultExecutedContext)
			' Don't show filter multiple times when using Html.RenderAction or Html.Action.
			If filterContext.IsChildAction = True Then
				Return
			End If
			Dim sFilterMethod As String = filterContext.GetType().FullName
			DebugInfo(filterContext, sFilterMethod)

			Dim txt = getResponseString(filterContext, sFilterMethod)
			WriteResponse(txt, filterContext)
		End Sub

		Private Function getResponseString(ByVal filterContext As ControllerContext, ByVal onAct As String) As String
			Dim txt = String.Format("<hr /><h5>TraceActionFilterAttribute {0} : Action '{1} :: {2}'</h5>", onAct, filterContext.RouteData.Values(DebugFilterHelper.sController), filterContext.RouteData.Values(DebugFilterHelper.sAction))

			Return txt
		End Function
		Private Function getResponseString(ByVal ad As ActionDescriptor, ByVal onAct As String) As String
			Dim txt = String.Format("<hr /><h5>TraceActionFilterAttribute {0} : Action '{1} :: {2}'</h5>", onAct, ad.ControllerDescriptor.ControllerName, ad.ActionName)

			Return txt
		End Function

		Private Sub WriteDbg(ByVal txt As String)
			Trace.WriteLine(txt)
		End Sub

		Private Sub WriteResponse(ByVal txt As String, ByVal filterContext As ControllerContext)
			Dim response = filterContext.HttpContext.Response
			If response.ContentType = "text/html" Then
				response.Write(txt)
			Else
				Trace.WriteLine(txt)
			End If
		End Sub
	End Class

End Namespace