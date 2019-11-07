using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class PdfConverterViewerPreferencesController : Controller
    {
        // GET: PdfConverterViewerPreferences
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from the webpage
            string url = collection["TxtUrl"];

            string page_layout = collection["DdlPageLayout"];
            PdfViewerPageLayout pageLayout = (PdfViewerPageLayout)Enum.Parse(
                typeof(PdfViewerPageLayout), page_layout, true);

            string page_mode = collection["DdlPageMode"];
            PdfViewerPageMode pageMode = (PdfViewerPageMode)Enum.Parse(
                typeof(PdfViewerPageMode), page_mode, true);

            bool centerWindow = collection["ChkCenterWindow"] == "on";
            bool displayDocTitle = collection["ChkDisplayDocTitle"] == "on";
            bool fitWindow = collection["ChkFitWindow"] == "on";
            bool hideMenuBar = collection["ChkHideMenuBar"] == "on";
            bool hideToolbar = collection["ChkHideToolbar"] == "on";
            bool hideWindowUI = collection["ChkHideWindowUI"] == "on";

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.ViewerPreferences.CenterWindow = centerWindow;
            converter.Options.ViewerPreferences.DisplayDocTitle = displayDocTitle;
            converter.Options.ViewerPreferences.FitWindow = fitWindow;
            converter.Options.ViewerPreferences.HideMenuBar = hideMenuBar;
            converter.Options.ViewerPreferences.HideToolbar = hideToolbar;
            converter.Options.ViewerPreferences.HideWindowUI = hideWindowUI;

            converter.Options.ViewerPreferences.PageLayout = pageLayout;
            converter.Options.ViewerPreferences.PageMode = pageMode;
            converter.Options.ViewerPreferences.NonFullScreenPageMode =
                PdfViewerFullScreenExitMode.UseNone;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

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