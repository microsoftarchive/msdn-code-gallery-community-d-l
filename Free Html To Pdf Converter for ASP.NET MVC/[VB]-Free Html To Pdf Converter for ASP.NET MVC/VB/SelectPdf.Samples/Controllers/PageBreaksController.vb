Imports SelectPdf

Namespace Controllers
    Public Class PageBreaksController
        Inherits Controller

        ' GET: PageBreaks
        Public Function Index() As ActionResult
            ViewData.Add("PageBreaksValue", Helper.PageBreaksText())
            Return View()
        End Function

        <HttpPost>
        <ValidateInput(False)>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' read parameters
            Dim htmlString As String = collection("TxtHtmlCode")
            Dim baseUrl As String = collection("TxtBaseUrl")

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            converter.Options.MarginTop = 10
            converter.Options.MarginBottom = 10
            converter.Options.MarginLeft = 10
            converter.Options.MarginRight = 10

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertHtmlString(htmlString, baseUrl)

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