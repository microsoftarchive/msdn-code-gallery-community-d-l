Imports System.Web.Mvc

Namespace Mvc3Filter.Filters
	Public NotInheritable Class DebugFilterHelper
		Private Sub New()
		End Sub
		Public Shared Sub DebugFilter(ByVal context As ControllerContext, ByVal sFilterMethod As String, ByVal FilterType As String)

			sFilterMethod = removePrependedSubstring(sFilterMethod, "System.Web.Mvc.")
			FilterType = removePrependedSubstring(FilterType, "Mvc3Filter.Controllers.")
			FilterType = removePrependedSubstring(FilterType, "Mvc3Filter.Filters.")

				   Dim txt = String.Format("FilterMethod: {0} Controller: {1}  ActionName: {2}  FilterType: {3}", sFilterMethod, context.RouteData.Values(sController), context.RouteData.Values(sAction), FilterType)

			 Trace.WriteLine(txt)

			' By the time OnResultExecuting runs, it's too late to write to the IIS trace provider.
			If Not sFilterMethod.Contains("ResultExecuting") Then
				'context.HttpContext.Trace.Write(txt);
			context.HttpContext.Trace.Warn(txt)
			End If
			' Trace.WriteLine(txt);  // View with http://technet.microsoft.com/en-us/sysinternals/bb896647.aspx
		End Sub
		Public Shared ReadOnly sAction As String = "action"
		Public Shared ReadOnly sController As String = "controller"


		Public Shared Function removePrependedSubstring(ByVal fullString As String, ByVal subString As String) As String

			If Not fullString.Contains(subString) Then
				Return fullString
			End If

			Return fullString.Remove(0, subString.Length)

		End Function
	End Class


End Namespace