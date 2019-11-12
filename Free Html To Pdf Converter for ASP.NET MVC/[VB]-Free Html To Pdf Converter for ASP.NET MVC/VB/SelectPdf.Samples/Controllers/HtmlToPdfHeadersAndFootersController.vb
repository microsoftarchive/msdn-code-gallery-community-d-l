Imports SelectPdf

Namespace Controllers
    Public Class HtmlToPdfHeadersAndFootersController
        Inherits Controller

        ' GET: HtmlToPdfHeadersAndFooters
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(fields As FormCollection) As ActionResult
            ' get parameters
            Dim headerUrl As String = Server.MapPath("~/files/header.html")
            Dim footerUrl As String = Server.MapPath("~/files/footer.html")

            Dim showHeaderOnFirstPage As Boolean = fields("ChkHeaderFirstPage") = "on"
            Dim showHeaderOnOddPages As Boolean = fields("ChkHeaderOddPages") = "on"
            Dim showHeaderOnEvenPages As Boolean = fields("ChkHeaderEvenPages") = "on"

            Dim headerHeight As Integer = 50
            Try
                headerHeight = Convert.ToInt32(fields("TxtHeaderHeight"))
            Catch
            End Try

            Dim showFooterOnFirstPage As Boolean = fields("ChkFooterFirstPage") = "on"
            Dim showFooterOnOddPages As Boolean = fields("ChkFooterOddPages") = "on"
            Dim showFooterOnEvenPages As Boolean = fields("ChkFooterEvenPages") = "on"

            Dim footerHeight As Integer = 50
            Try
                footerHeight = Convert.ToInt32(fields("TxtFooterHeight"))
            Catch
            End Try

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' header settings
            converter.Options.DisplayHeader = showHeaderOnFirstPage OrElse
                showHeaderOnOddPages OrElse showHeaderOnEvenPages
            converter.Header.DisplayOnFirstPage = showHeaderOnFirstPage
            converter.Header.DisplayOnOddPages = showHeaderOnOddPages
            converter.Header.DisplayOnEvenPages = showHeaderOnEvenPages
            converter.Header.Height = headerHeight

            Dim headerHtml As New PdfHtmlSection(headerUrl)
            headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit
            converter.Header.Add(headerHtml)

            ' footer settings
            converter.Options.DisplayFooter = showFooterOnFirstPage OrElse
                showFooterOnOddPages OrElse showFooterOnEvenPages
            converter.Footer.DisplayOnFirstPage = showFooterOnFirstPage
            converter.Footer.DisplayOnOddPages = showFooterOnOddPages
            converter.Footer.DisplayOnEvenPages = showFooterOnEvenPages
            converter.Footer.Height = footerHeight

            Dim footerHtml As New PdfHtmlSection(footerUrl)
            footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit
            converter.Footer.Add(footerHtml)

            ' add page numbering element to the footer
            If fields("ChkPageNumbering") = "on" Then
                ' page numbers can be added using a PdfTextSection object
                Dim text As New PdfTextSection(0, 10,
                                    "Page: {page_number} of {total_pages}  ",
                                    New System.Drawing.Font("Arial", 8))
                text.HorizontalAlign = PdfTextHorizontalAlign.Right
                converter.Footer.Add(text)
            End If

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