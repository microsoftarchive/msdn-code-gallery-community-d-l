using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class ReplaceHtmlElements : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            htmlToPdfConverter.SelectedHtmlElements = new string[] { textBoxImageSelector.Text };
            htmlToPdfConverter.HiddenHtmlElements = new string[] { textBoxImageSelector.Text };

            PdfDocument document = null;
            try
            {
                document = htmlToPdfConverter.ConvertUrlToPdfDocument(textBoxUrl.Text);

                foreach (HtmlElementInfo htmlImageInfo in htmlToPdfConverter.ConversionInfo.SelectedHtmlElementsInfo)
                {
                    PdfPageRegion imagePdfRegion = htmlImageInfo.PdfRegions[0];
                    PdfPage imagePdfPage = document.Pages[imagePdfRegion.PageIndex];

                    // create the image element
                    PdfImage pdfImage = new PdfImage(imagePdfRegion.Rectangle, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_Modified.png");
                    pdfImage.ClipRectangle = imagePdfRegion.Rectangle;

                    imagePdfPage.Layout(pdfImage);
                }

                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=ReplaceHtmlElements.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();

            }
            finally
            {
                if (document != null)
                    document.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                textBoxUrl.Text = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Html/ReplaceImage.htm";

                Master.SelectNode("replaceHtmlElements");
            }
        }
    }
}
