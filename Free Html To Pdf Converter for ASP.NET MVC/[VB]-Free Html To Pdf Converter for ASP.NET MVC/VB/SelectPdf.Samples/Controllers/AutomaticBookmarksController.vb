Imports SelectPdf

Namespace Controllers
    Public Class AutomaticBookmarksController
        Inherits Controller

        ' GET: AutomaticBookmarks
        Public Function Index() As ActionResult
            Dim url As String = System.Web.VirtualPathUtility _
                .ToAbsolute("~/files/document.html")
            ViewData.Add("ViewTxtUrl", (New Uri(Request.Url, url)).AbsoluteUri)
            Return View()
        End Function

        <HttpPost>
        Public Function SubmitAction(collection As FormCollection) As ActionResult
            ' instantiate a html to pdf converter object
            Dim converter As New HtmlToPdf()

            ' set the css selectors for the automatic bookmarks
            converter.Options.PdfBookmarkOptions.CssSelectors =
                collection("TxtElements").Split(New Char() {","c})

            ' display the bookmarks when the document is opened in a viewer
            converter.Options.ViewerPreferences.PageMode = PdfViewerPageMode.UseOutlines

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