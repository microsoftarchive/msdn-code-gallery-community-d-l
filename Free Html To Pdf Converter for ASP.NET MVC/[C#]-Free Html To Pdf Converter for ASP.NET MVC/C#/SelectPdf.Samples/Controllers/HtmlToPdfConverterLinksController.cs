using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class HtmlToPdfConverterLinksController : Controller
    {
        // GET: HtmlToPdfConverterLinks
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

            // set links options
            converter.Options.InternalLinksEnabled = 
                collection["ChkInternalLinks"] == "on";
            converter.Options.ExternalLinksEnabled = 
                collection["ChkExternalLinks"] == "on";

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