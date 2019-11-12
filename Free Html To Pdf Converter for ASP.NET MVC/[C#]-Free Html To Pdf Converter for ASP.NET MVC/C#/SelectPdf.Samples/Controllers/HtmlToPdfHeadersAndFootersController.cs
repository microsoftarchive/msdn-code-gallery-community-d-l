using System;
using System.Web.Mvc;

namespace SelectPdf.Samples.Controllers
{
    public class HtmlToPdfHeadersAndFootersController : Controller
    {
        // GET: HtmlToPdfHeadersAndFooters
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAction(FormCollection collection)
        {
            // get parameters
            string headerUrl = Server.MapPath("~/files/header.html");
            string footerUrl = Server.MapPath("~/files/footer.html");

            bool showHeaderOnFirstPage = collection["ChkHeaderFirstPage"] == "on";
            bool showHeaderOnOddPages = collection["ChkHeaderOddPages"] == "on";
            bool showHeaderOnEvenPages = collection["ChkHeaderEvenPages"] == "on";

            int headerHeight = 50;
            try
            {
                headerHeight = Convert.ToInt32(collection["TxtHeaderHeight"]);
            }
            catch { }

            bool showFooterOnFirstPage = collection["ChkFooterFirstPage"] == "on";
            bool showFooterOnOddPages = collection["ChkFooterOddPages"] == "on";
            bool showFooterOnEvenPages = collection["ChkFooterEvenPages"] == "on"; 

            int footerHeight = 50;
            try
            {
                footerHeight = Convert.ToInt32(collection["TxtFooterHeight"]);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // header settings
            converter.Options.DisplayHeader = showHeaderOnFirstPage ||
                showHeaderOnOddPages || showHeaderOnEvenPages;
            converter.Header.DisplayOnFirstPage = showHeaderOnFirstPage;
            converter.Header.DisplayOnOddPages = showHeaderOnOddPages;
            converter.Header.DisplayOnEvenPages = showHeaderOnEvenPages;
            converter.Header.Height = headerHeight;

            PdfHtmlSection headerHtml = new PdfHtmlSection(headerUrl);
            headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
            converter.Header.Add(headerHtml);

            // footer settings
            converter.Options.DisplayFooter = showFooterOnFirstPage ||
                showFooterOnOddPages || showFooterOnEvenPages;
            converter.Footer.DisplayOnFirstPage = showFooterOnFirstPage;
            converter.Footer.DisplayOnOddPages = showFooterOnOddPages;
            converter.Footer.DisplayOnEvenPages = showFooterOnEvenPages;
            converter.Footer.Height = footerHeight;

            PdfHtmlSection footerHtml = new PdfHtmlSection(footerUrl);
            footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
            converter.Footer.Add(footerHtml);

            // add page numbering element to the footer
            if (collection["ChkPageNumbering"] == "on")
            {
                // page numbers can be added using a PdfTextSection object
                PdfTextSection text = new PdfTextSection(0, 10,
                    "Page: {page_number} of {total_pages}  ",
                    new System.Drawing.Font("Arial", 8));
                text.HorizontalAlign = PdfTextHorizontalAlign.Right;
                converter.Footer.Add(text);
            }

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