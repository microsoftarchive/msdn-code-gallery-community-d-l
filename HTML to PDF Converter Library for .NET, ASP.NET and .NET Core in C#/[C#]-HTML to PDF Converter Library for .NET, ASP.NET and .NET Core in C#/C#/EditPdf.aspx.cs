using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class EditPdf : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // the path PDF document to edit
            string pdfDocumentToEdit = Server.MapPath("~") + @"\DemoFiles\Pdf\WikiPdf.pdf";

            // load the PDF document to edit
            PdfDocument document = PdfDocument.FromFile(pdfDocumentToEdit);

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            #region Add an orange border to each page of the loaded PDF document

            // add an orange border to each PDF page in the loaded PDF document
            foreach (PdfPage pdfPage in document.Pages)
            {
                float crtPdfPageWidth = pdfPage.Size.Width;
                float crtPdfPageHeight = pdfPage.Size.Height;

                // create a PdfRectangle object
                PdfRectangle pdfRectangle = new PdfRectangle(2, 2, crtPdfPageWidth - 4, crtPdfPageHeight - 4);
                pdfRectangle.LineStyle.LineWidth = 2;
                pdfRectangle.ForeColor = System.Drawing.Color.OrangeRed;

                // layout the rectangle in PDF page
                pdfPage.Layout(pdfRectangle);
            }

            #endregion Add an orange border to each page of the loaded PDF document

            #region Layout HTML in a canvas to be repeated on each page of the loaded PDF document

            PdfPage pdfPage1 = document.Pages[0];
            float pdfPageWidth = pdfPage1.Size.Width;
            float pdfPageHeight = pdfPage1.Size.Height;

            // the width of the HTML logo in pixels
            int htmlLogoWidthPx = 400;
            // the width of the HTML logo in points
            float htmlLogoWidthPt = PdfDpiTransform.FromPixelsToPoints(htmlLogoWidthPx);
            float htmlLogoHeightPt = 100;

            // create a canvas to be repeated in the center of each PDF page
            // the canvas is a PDF container that can contain PDF objects ( HTML, text, images, etc )
            PdfRepeatCanvas repeatedCanvas = document.CreateRepeatedCanvas(new System.Drawing.RectangleF((pdfPageWidth - htmlLogoWidthPt) / 2, (pdfPageHeight - htmlLogoHeightPt) / 2,
                        htmlLogoWidthPt, htmlLogoHeightPt));

            // the HTML file giving the content to be placed in the repeated canvas
            string htmlFile = Server.MapPath("~") + @"\DemoFiles\Html\Logo.Html";

            // the HTML object to be laid out in repeated canvas
            PdfHtml htmlLogo = new PdfHtml(0, 0, repeatedCanvas.Width, repeatedCanvas.Height, htmlFile);
            // the browser width when rendering the HTML
            htmlLogo.BrowserWidth = htmlLogoWidthPx;
            // the HTML content will fit the destination hight which is the same with repeated canvas height
            htmlLogo.FitDestHeight = true;

            // layout the HTML object in the repeated canvas
            PdfLayoutInfo htmlLogLayoutInfo = repeatedCanvas.Layout(htmlLogo);

            #endregion Layout HTML in a canvas to be repeated on each page of the loaded PDF document

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=EditPdf.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                document.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                hyperLinkOpenPdf.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/WikiPdf.pdf";
                hyperLinkOpenHtml.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Html/Logo.Html";
 
                Master.SelectNode("editPdf");
            }
        }
    }
}