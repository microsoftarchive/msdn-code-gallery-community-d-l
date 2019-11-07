Imports SelectPdf

Namespace Controllers
    Public Class HttpHeadersController
        Inherits Controller

        ' GET: HttpHeaders
        Public Function Index() As ActionResult
            Dim url As String =
                System.Web.VirtualPathUtility.ToAbsolute("~/ViewHttpHeaders")
            ViewData.Add("ViewTxtUrl", (New Uri(Request.Url, url)).AbsoluteUri)
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(fields As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set the HTTP headers
            converter.Options.HttpHeaders.Add(fields("TxtName1"), fields("TxtValue1"))
            converter.Options.HttpHeaders.Add(fields("TxtName2"), fields("TxtValue2"))
            converter.Options.HttpHeaders.Add(fields("TxtName3"), fields("TxtValue3"))
            converter.Options.HttpHeaders.Add(fields("TxtName4"), fields("TxtValue4"))

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(fields("TxtUrl"))

            ' save pdf document
            Dim pdf As Byte() = doc.Save()

            ' close pdf document
            doc.Close()

            ' return resulted pdf document
            Dim fileResult As FileResult = New FileContentResult(pdf, "application/pdf")
            fileResult.FileDownloadName = "Document.pdf"
            Return fileResult
        End Function
    End Class
End Namespace