using System.Web.Mvc;
using SelectPdf.Samples.Models;

namespace SelectPdf.Samples.Controllers
{
    public class PageBreaksController : Controller
    {
        // GET: PageBreaks
        public ActionResult Index()
        {
            ViewData.Add("PageBreaksValue", Helper.PageBreaksText());
            
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitAction(FormCollection collection)
        {
            string htmlString = collection["TxtHtmlCode"];
            string baseUrl = collection["TxtBaseUrl"];

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.MarginTop = 10;
            converter.Options.MarginBottom = 10;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

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