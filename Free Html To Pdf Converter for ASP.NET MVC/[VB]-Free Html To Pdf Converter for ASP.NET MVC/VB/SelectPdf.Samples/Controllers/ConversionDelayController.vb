Imports SelectPdf

Namespace Controllers
    Public Class ConversionDelayController
        Inherits Controller

        ' GET: ConversionDelay
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' read parameters from webpage
            Dim delay As Integer = 0
            Try
                delay = Convert.ToInt32(collection("TxtDelay").ToString())
            Catch
            End Try

            Dim timeout As Integer = 0
            Try
                timeout = Convert.ToInt32(collection("TxtTimeout").ToString())
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' specify the number of seconds the conversion is delayed
            converter.Options.MinPageLoadTime = delay

            ' set the page timeout
            converter.Options.MaxPageLoadTime = timeout

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