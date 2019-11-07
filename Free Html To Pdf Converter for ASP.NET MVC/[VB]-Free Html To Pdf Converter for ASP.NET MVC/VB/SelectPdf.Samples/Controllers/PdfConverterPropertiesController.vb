Imports SelectPdf

Namespace Controllers
    Public Class PdfConverterPropertiesController
        Inherits Controller

        ' GET: /PdfConverterProperties/
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost> _
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(collection("TxtUrl"))

            ' get conversion result (contains document info from the web page)
            Dim result As HtmlToPdfResult = converter.ConversionResult

            ' set the document properties
            doc.DocumentInformation.Title = result.WebPageInformation.Title
            doc.DocumentInformation.Subject = result.WebPageInformation.Description
            doc.DocumentInformation.Keywords = result.WebPageInformation.Keywords

            doc.DocumentInformation.Author = "SelectPdf Samples"
            doc.DocumentInformation.CreationDate = DateTime.Now

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