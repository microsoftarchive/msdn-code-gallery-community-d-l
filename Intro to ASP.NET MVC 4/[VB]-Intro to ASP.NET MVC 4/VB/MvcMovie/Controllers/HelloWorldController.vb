Namespace MvcMovie
    Public Class HelloWorldController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /HelloWorld
        Function Index() As ActionResult
            Return View()
        End Function

        '
        ' GET: /HelloWorld
        Function Welcome(ByVal name As String, Optional ByVal numTimes As Integer = 1) As ActionResult
            ViewData("Message") = "Hi " & name
            ViewData("NumTimes") = numTimes
            Return View()
        End Function

    End Class
End Namespace