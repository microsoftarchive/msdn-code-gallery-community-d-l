Imports SelectPdf

Namespace Controllers
    Public Class ConvertHtmlCodeToPdfController
        Inherits Controller

        ' GET: ConvertHtmlCodeToPdf
        Public Function Index() As ActionResult
            Dim stringdata As String
            stringdata = "<html>" & vbCr & vbLf & " <body>" & vbCr & vbLf &
                "  Hello World from selectpdf.com." & vbCr & vbLf & " </body>" _
                & vbCr & vbLf & "</html>" & vbCr & vbLf
            ViewData.Add("TxtHtmlCode", stringdata)
            Return View()
        End Function

        <HttpPost>
        <ValidateInput(False)>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' read parameters from the webpage
            Dim htmlString As String = collection("TxtHtmlCode")
            Dim baseUrl As String = collection("TxtBaseUrl")

            Dim pdf_page_size As String = collection("DdlPageSize")
            Dim pageSize As PdfPageSize = DirectCast([Enum].Parse(GetType(PdfPageSize),
                    pdf_page_size, True), PdfPageSize)

            Dim pdf_orientation As String = collection("DdlPageOrientation")
            Dim pdfOrientation As PdfPageOrientation =
                    DirectCast([Enum].Parse(GetType(PdfPageOrientation),
                    pdf_orientation, True), PdfPageOrientation)

            Dim webPageWidth As Integer = 1024
            Try
                webPageWidth = Convert.ToInt32(collection("TxtWidth"))
            Catch
            End Try

            Dim webPageHeight As Integer = 0
            Try
                webPageHeight = Convert.ToInt32(collection("TxtHeight"))
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set converter options
            converter.Options.PdfPageSize = pageSize
            converter.Options.PdfPageOrientation = pdfOrientation
            converter.Options.WebPageWidth = webPageWidth
            converter.Options.WebPageHeight = webPageHeight

            ' get base url
            If baseUrl = "" Then
                baseUrl = Me.ControllerContext.HttpContext.Request.
                    Url.AbsoluteUri.Substring(
                    0, Me.ControllerContext.HttpContext.Request.
                    Url.AbsoluteUri.Length - "CurrentWebPageToPdf/SubmitAction".Length - 1)
            End If

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