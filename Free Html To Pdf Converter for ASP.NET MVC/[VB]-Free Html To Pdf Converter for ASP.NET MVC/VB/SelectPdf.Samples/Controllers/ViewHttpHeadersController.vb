Namespace Controllers
    Public Class ViewHttpHeadersController
        Inherits Controller

        ' GET: ViewHttpHeaders
        Public Function Index() As ActionResult
            Dim headers As String = String.Empty
            For Each name As String In Request.Headers
                Dim value As String = Request.Headers(name)
                headers += "<br/>" & name & ": " & value
            Next

            ViewData.Add("HeadersValue", headers)

            Return View()
        End Function
    End Class
End Namespace