Imports SelectPdf

Namespace Controllers
    Public Class PdfConverterViewerPreferencesController
        Inherits Controller

        ' GET: PdfConverterViewerPreferences
        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost> _
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' read parameters from the webpage
            Dim url As String = collection("TxtUrl")

            Dim page_layout As String = collection("DdlPageLayout")
            Dim pageLayout As PdfViewerPageLayout = DirectCast(
                [Enum].Parse(GetType(PdfViewerPageLayout), page_layout, True),
                PdfViewerPageLayout)

            Dim page_mode As String = collection("DdlPageMode")
            Dim pageMode As PdfViewerPageMode = DirectCast(
                [Enum].Parse(GetType(PdfViewerPageMode), page_mode, True),
                PdfViewerPageMode)

            Dim centerWindow As Boolean = collection("ChkCenterWindow") = "on"
            Dim displayDocTitle As Boolean = collection("ChkDisplayDocTitle") = "on"
            Dim fitWindow As Boolean = collection("ChkFitWindow") = "on"
            Dim hideMenuBar As Boolean = collection("ChkHideMenuBar") = "on"
            Dim hideToolbar As Boolean = collection("ChkHideToolbar") = "on"
            Dim hideWindowUI As Boolean = collection("ChkHideWindowUI") = "on"

            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set converter options
            converter.Options.ViewerPreferences.CenterWindow = centerWindow
            converter.Options.ViewerPreferences.DisplayDocTitle = displayDocTitle
            converter.Options.ViewerPreferences.FitWindow = fitWindow
            converter.Options.ViewerPreferences.HideMenuBar = hideMenuBar
            converter.Options.ViewerPreferences.HideToolbar = hideToolbar
            converter.Options.ViewerPreferences.HideWindowUI = hideWindowUI

            converter.Options.ViewerPreferences.PageLayout = pageLayout
            converter.Options.ViewerPreferences.PageMode = pageMode
            converter.Options.ViewerPreferences.NonFullScreenPageMode =
                PdfViewerFullScreenExitMode.UseNone

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