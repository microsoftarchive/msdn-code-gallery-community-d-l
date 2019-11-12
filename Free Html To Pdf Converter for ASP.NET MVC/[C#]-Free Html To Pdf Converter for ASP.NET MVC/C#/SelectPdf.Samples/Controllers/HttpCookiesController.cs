using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class HttpCookiesController : Controller
    {
        // GET: HttpCookies
        public ActionResult Index()
        {
            string url = System.Web.VirtualPathUtility.ToAbsolute("~/ViewHttpCookies");
            ViewData.Add("ViewTxtUrl", (new Uri(Request.Url, url)).AbsoluteUri);
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection fields)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set the HTTP cookies
            converter.Options.HttpCookies.Add(fields["TxtName1"], fields["TxtValue1"]);
            converter.Options.HttpCookies.Add(fields["TxtName2"], fields["TxtValue2"]);
            converter.Options.HttpCookies.Add(fields["TxtName3"], fields["TxtValue3"]);
            converter.Options.HttpCookies.Add(fields["TxtName4"], fields["TxtValue4"]);

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(fields["TxtUrl"]);

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