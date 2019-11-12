Imports System.Web
Imports SelectPdf

Namespace Controllers
    Public Class HttpPostRequestController
        Inherits Controller

        ' GET: HttpPostRequest
        Function Index() As ActionResult
            Dim url As String = VirtualPathUtility.ToAbsolute("~/ViewHttpPostData")
            ViewData.Add("ViewTxtUrl", (New Uri(Request.Url, url)).AbsoluteUri)
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(fields As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set the HTTP POST parameters
            converter.Options.HttpPostParameters.Add(
                fields("TxtName1"), fields("TxtValue1"))
            converter.Options.HttpPostParameters.Add(
                fields("TxtName2"), fields("TxtValue2"))
            converter.Options.HttpPostParameters.Add(
                fields("TxtName3"), fields("TxtValue3"))
            converter.Options.HttpPostParameters.Add(
                fields("TxtName4"), fields("TxtValue4"))

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