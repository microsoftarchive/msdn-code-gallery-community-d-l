using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class ConvertHtmlCodeToPdfController : Controller
    {
        // GET: ConvertHtmlCodeToPdf
        public ActionResult Index()
        {
            string stringdata = "";
            
            stringdata = @"<html>
    <body>
        Hello World from selectpdf.com.
    </body>
</html>
";
            ViewData.Add("TxtHtmlCode", stringdata);
            return View();
        }
        
        [HttpPost]        
        [ValidateInput(false)]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // read parameters from the webpage
            string htmlString = collection["TxtHtmlCode"];
            string baseUrl = collection["TxtBaseUrl"];

            string pdf_page_size = collection["DdlPageSize"];
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = collection["DdlPageOrientation"];
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(collection["TxtWidth"]);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(collection["TxtHeight"]);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            byte[] pdf =doc.Save();

            // close pdf document
            doc.Close();

            // return resulted pdf document
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;

        }
    }
}