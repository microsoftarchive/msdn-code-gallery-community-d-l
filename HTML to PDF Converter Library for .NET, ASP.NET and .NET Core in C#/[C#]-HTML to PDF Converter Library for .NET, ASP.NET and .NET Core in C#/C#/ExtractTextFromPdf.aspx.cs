using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class ExtractTextFromPdf : System.Web.UI.Page
    {
        protected void buttonExtractText_Click(object sender, EventArgs e)
        {
            // get the PDF file
            string pdfFile = Server.MapPath("~") + @"\DemoFiles\Pdf\InputPdf.pdf";

            // create the PDF text extractor
            PdfTextExtract pdfTextExtract = new PdfTextExtract();

            // set a demo serial number
            pdfTextExtract.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set the text extraction mode
            pdfTextExtract.TextExtractMode = GetTextExtractMode();

            int fromPdfPageNumber = int.Parse(textBoxFromPage.Text);
            int toPdfPageNumber = textBoxToPage.Text.Length > 0 ? int.Parse(textBoxToPage.Text) : 0;

            // extract the text from a range of pages of the PDF document
            string text = pdfTextExtract.ExtractText(pdfFile, fromPdfPageNumber, toPdfPageNumber);

            // get UTF-8 bytes
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);

            // the UTF-8 marker
            byte[] utf8Marker = new byte[] { 0xEF, 0xBB, 0xBF };

            // the text document bytes with UTF-8 marker followed by UTF-8 bytes
            byte[] bytes = new byte[utf8Bytes.Length + utf8Marker.Length];
            Array.Copy(utf8Marker, 0, bytes, 0, utf8Marker.Length);
            Array.Copy(utf8Bytes, 0, bytes, utf8Marker.Length, utf8Bytes.Length);

            // inform the browser about the data format
            HttpContext.Current.Response.AddHeader("Content-Type", "text/plain; charset=UTF-8");

            // let the browser know how to open the text document and the text document name
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                String.Format("{0}; filename=ExtractedText.txt; size={1}", "attachment", bytes.Length.ToString()));

            // write the text buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(bytes);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }

        private PdfTextExtractMode GetTextExtractMode()
        {
            switch (dropDownListExtractMode.SelectedItem.ToString())
            {
                case "Keep Positioning":
                    return PdfTextExtractMode.KeepPositioning;
                case "Keep Reading Order":
                    return PdfTextExtractMode.KeepReadingOrder;
                default:
                    return PdfTextExtractMode.KeepPositioning;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                hyperLinkOpenPdf.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/InputPdf.pdf";

                Master.SelectNode("extractText");
            }
        }
    }
}