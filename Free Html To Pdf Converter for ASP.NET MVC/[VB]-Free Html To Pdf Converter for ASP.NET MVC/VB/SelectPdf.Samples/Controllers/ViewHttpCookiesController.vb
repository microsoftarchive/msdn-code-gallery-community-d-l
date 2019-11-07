Namespace Controllers
    Public Class ViewHttpCookiesController
        Inherits Controller

        ' GET: ViewHttpCookies
        Public Function Index() As ActionResult
            Dim cookies As String = String.Empty
            For Each key As String In Request.Cookies
                Dim cookie As HttpCookie = Request.Cookies(key)
                cookies += "<br/>" + cookie.Name + ": " + cookie.Value
            Next

            ViewData.Add("cookiesValue", cookies)

            Return View()
        End Function
    End Class
End Namespace