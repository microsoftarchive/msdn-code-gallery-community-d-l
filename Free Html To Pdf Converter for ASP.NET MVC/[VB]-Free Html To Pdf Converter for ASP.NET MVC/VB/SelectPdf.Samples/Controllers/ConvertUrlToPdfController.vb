Imports SelectPdf

Namespace Controllers
    Public Class ConvertUrlToPdfController
        Inherits Controller

        ' GET: /ConvertUrlToPdf/
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' read parameters from the webpage
            Dim url As String = collection("TxtUrl")

            Dim pdf_page_size As String = collection("DdlPageSize")
            Dim pageSize As PdfPageSize = DirectCast([Enum].Parse(GetType(PdfPageSize),
                pdf_page_size, True), PdfPageSize)

            Dim pdf_orientation As String = collection("DdlPageOrientation")
            Dim pdfOrientation As PdfPageOrientation = DirectCast(
                [Enum].Parse(GetType(PdfPageOrientation),
                pdf_orientation, True), PdfPageOrientation)

            Dim webPageWidth As Integer = 1024
            Try
                webPageWidth = System.Convert.ToInt32(collection("TxtWidth"))
            Catch
            End Try

            Dim webPageHeight As Integer = 0
            Try
                webPageHeight = System.Convert.ToInt32(collection("TxtHeight"))
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set converter options
            converter.Options.PdfPageSize = pageSize
            converter.Options.PdfPageOrientation = pdfOrientation
            converter.Options.WebPageWidth = webPageWidth
            converter.Options.WebPageHeight = webPageHeight

            ' create a new pdf document converting an url
            Dim doc As PdfDocument = converter.ConvertUrl(url)

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