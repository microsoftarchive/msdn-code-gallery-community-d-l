Imports SelectPdf

Namespace Controllers
    Public Class MediaTypesController
        Inherits Controller

        ' GET: MediaTypes
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set css media type
            converter.Options.CssMediaType =
                DirectCast([Enum].Parse(GetType(HtmlToPdfCssMediaType),
                    collection("DdlCssMediaType"), True), HtmlToPdfCssMediaType)

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