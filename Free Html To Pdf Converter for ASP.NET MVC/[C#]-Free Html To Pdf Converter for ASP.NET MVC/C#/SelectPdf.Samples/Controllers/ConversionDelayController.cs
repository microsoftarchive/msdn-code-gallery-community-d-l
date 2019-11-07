using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class ConversionDelayController : Controller
    {
        // GET: ConversionDelay
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from webpage
            int delay = 0;
            try
            {
                delay =  Convert.ToInt32(collection["TxtDelay"].ToString());
            }
            catch { }

            int timeout = 0;
            try
            {
                timeout = Convert.ToInt32(collection["TxtTimeout"].ToString());
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // specify the number of seconds the conversion is delayed
            converter.Options.MinPageLoadTime = delay;

            // set the page timeout
            converter.Options.MaxPageLoadTime = timeout;

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