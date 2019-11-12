using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class MediaTypesController : Controller
    {
        // GET: MediaTypes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set css media type
            converter.Options.CssMediaType = (HtmlToPdfCssMediaType)Enum.Parse(
                typeof(HtmlToPdfCssMediaType), collection["DdlCssMediaType"], true);

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