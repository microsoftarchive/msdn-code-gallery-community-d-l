Imports System.Web.Mvc
Imports System.Web.UI
Imports Mvc3Filter.Filters

Namespace Mvc3Filter.Controllers
	' Review. No way to make TraceActionFilter run before controller overloads (filters)
	' Set the order so TraceActionFilter runs after RequestTimingFilter
   ' [TraceActionFilter(Order=1)]   // trace all action methods in this controller
	<TraceActionFilter, OutputCache(Location := OutputCacheLocation.None, NoStore := True)>
	Public Class SimpleController ' trace all action methods in this controller
		Inherits Controller

		Private Shared OnAuthRedirect As String
		Private rnd As New Random()

		Protected Overrides Sub OnAuthorization(ByVal filterContext As AuthorizationContext)

			MyBase.OnAuthorization(filterContext)
			' /Simple/About and /Home/About share the same view ( Shared/About )
			' The ViewBag.AuthorizeFilterMessage is displayed in the Shared/About
			' when /Simple/About is invoked.
			ViewBag.AuthorizeFilterMessage = "From Controller: " & filterContext.ActionDescriptor.ControllerDescriptor.ControllerName

			' Return for all requests except About with Cancel route data

			If (Not filterContext.ActionDescriptor.ActionName.Contains("About")) OrElse (Not filterContext.RouteData.Values.ContainsValue("Cancel")) Then
				Return
			End If

			' Simple/About?Cancel was requested, so redirect and view debug output

			filterContext.Result = New RedirectResult("~/Home/Details")
			OnAuthRedirect = "Redirected by OnAuthorization"
		End Sub

		Private Sub dumpData(ByVal context As ControllerContext, ByVal FilterType As String, Optional ByVal actionName As String = "Test1")

#If DbgSimpleController Then
			DebugFilterHelper.DebugFilter(context, FilterType, Me.ToString())
#End If
			' Only write out data when Test1 is called (or the specificed action) 
			If Not context.RouteData.Values(DebugFilterHelper.sAction).ToString().Contains(actionName) Then
				Return
			End If

			Dim response = context.HttpContext.Response
			Dim txt = String.Format("<hr /><h5>Action '{0} :: {1} From {2}'.</h5>", context.RouteData.Values(DebugFilterHelper.sController), context.RouteData.Values(DebugFilterHelper.sAction), FilterType)

			If response.ContentType = "text/html" Then
				response.Write(txt)
			Else
				Trace.WriteLine(txt)
			End If
		End Sub

		' Review:
		Protected Overrides Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext)

			MyBase.OnActionExecuted(filterContext)
			dumpData(filterContext, filterContext.GetType().FullName)

		End Sub

		Protected Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
			MyBase.OnActionExecuting(filterContext)
			dumpData(filterContext, filterContext.GetType().FullName)
		End Sub

		Private Function mytest(ByVal filterContext As ActionExecutingContext) As Boolean
			If filterContext.RouteData.Values.ContainsValue("Cancel") Then
				Return True
			End If
			Return False
		End Function

		Protected Overrides Sub OnResultExecuted(ByVal filterContext As ResultExecutedContext)
			MyBase.OnResultExecuted(filterContext)
			dumpData(filterContext, filterContext.GetType().FullName)
		End Sub

		Protected Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
			MyBase.OnResultExecuting(filterContext)
			dumpData(filterContext, filterContext.GetType().FullName)
		End Sub

		Protected Overrides Sub OnException(ByVal filterContext As ExceptionContext)
			MyBase.OnException(filterContext)
			dumpData(filterContext, "OnException", "e")
		End Sub

		'
		' GET: /Simple/

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function About() As ViewResult
			' this.HttpContext.Trace.IsEnabled = true;
			Return View()
		End Function

		Public Function Test1() As ViewResult
			Return View()
		End Function

		Public Function Details() As ViewResult


			Dim s As String = Me.Request.RawUrl

			ViewBag.wasRedirected = OnAuthRedirect
			OnAuthRedirect = ""
			Return View()

		End Function

		Public Function ShowHandleErrorAttribute() As ViewResult
'             See Web.config file which requires customErrors element  as shown below
'              <customErrors mode="On" defaultRedirect="Error" /> 
'             * 
'INSTANT VB TODO TASK: There is no equivalent to #pragma directives in VB:
'#pragma warning disable 0162
			Throw New NotImplementedException()
			Return View()
		End Function
	End Class
End Namespace
