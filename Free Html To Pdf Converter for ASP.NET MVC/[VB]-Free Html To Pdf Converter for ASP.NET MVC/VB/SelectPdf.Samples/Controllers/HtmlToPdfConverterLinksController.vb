Imports SelectPdf

Namespace Controllers
    Public Class HtmlToPdfConverterLinksController
        Inherits Controller

        ' GET: HtmlToPdfConverterLinks
        Public Function Index() As ActionResult
            Dim url As String =
                System.Web.VirtualPathUtility.ToAbsolute("~/files/document.html")
            ViewData.Add("ViewTxtUrl", (New Uri(Request.Url, url)).AbsoluteUri)
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set links options
            converter.Options.InternalLinksEnabled = collection("ChkInternalLinks") = "on"
            converter.Options.ExternalLinksEnabled = collection("ChkExternalLinks") = "on"

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(collection("TxtUrl"))

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