using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class AutomaticBookmarksController : Controller
    {
        // GET: AutomaticBookmarks
        public ActionResult Index()
        {
            string url = System.Web.VirtualPathUtility.ToAbsolute("~/files/document.html");
            ViewData.Add("ViewTxtUrl", (new Uri(Request.Url, url)).AbsoluteUri);
           
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set the css selectors for the automatic bookmarks
            converter.Options.PdfBookmarkOptions.CssSelectors =
                collection["TxtElements"].Split(new char[] { ',' });

            // display the bookmarks when the document is opened in a viewer
            converter.Options.ViewerPreferences.PageMode = PdfViewerPageMode.UseOutlines;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(collection["TxtUrl"]);

            // save pdf document
            byte[] pdf = doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
        }
    }
}