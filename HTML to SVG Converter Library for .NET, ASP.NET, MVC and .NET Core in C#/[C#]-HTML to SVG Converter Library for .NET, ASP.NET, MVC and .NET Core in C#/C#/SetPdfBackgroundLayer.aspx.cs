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
    public partial class SetPdfBackgroundLayer : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // attach to PageLayoutingEvent event raised right before layouting the HTML content in a PDF page
            htmlToPdfConverter.PageLayoutingEvent += new PdfPageLayoutingDelegate(htmlToPdfConverter_PageLayoutingEvent);

            // set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(
                                        int.Parse(textBoxLeftMargin.Text), int.Parse(textBoxRightMargin.Text),
                                        int.Parse(textBoxTopMargin.Text), int.Parse(textBoxBottomMargin.Text));
            
            try
            {
                byte[] pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(textBoxUrl.Text);

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document, attachment or inline, and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=SetPdfBackground.pdf; size={0}",
                                pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                // dettach from PageLayoutingEvent event
                htmlToPdfConverter.PageLayoutingEvent -= new PdfPageLayoutingDelegate(htmlToPdfConverter_PageLayoutingEvent);
            }
        }

        /// <summary>
        /// The PageLayoutingEvent event handler called before each PDF page is rendered by the converter
        /// </summary>
        /// <param name="eventParams">The event handler parameter giving information about the PDF page being rendered 
        /// and the rectangle in page that will be rendered</param>
        void htmlToPdfConverter_PageLayoutingEvent(PdfPageLayoutingParams eventParams)
        {
            // The PDF page being rendered
            PdfPage crtPage = eventParams.PdfPage;

            // draw a colored rectangle in the background of the PDF page
            PdfRectangle backColorRect = new PdfRectangle(0, 0, crtPage.DrawableRectangle.Width, crtPage.DrawableRectangle.Height);
            backColorRect.BackColor = System.Drawing.Color.FromArgb(255, int.Parse(textBoxR.Text), int.Parse(textBoxG.Text), int.Parse(textBoxB.Text));
            crtPage.Layout(backColorRect);

            // draw a 2 points orange line under the rendered content in page
            System.Drawing.PointF leftBottom = new System.Drawing.PointF(eventParams.LayoutingBounds.Left, eventParams.LayoutingBounds.Bottom + 1);
            System.Drawing.PointF rightBottom = new System.Drawing.PointF(eventParams.LayoutingBounds.Right, eventParams.LayoutingBounds.Bottom + 1);
            PdfLine bottomLine = new PdfLine(leftBottom, rightBottom);
            bottomLine.LineStyle.LineWidth = 2.0f;
            bottomLine.ForeColor = System.Drawing.Color.OrangeRed;
            crtPage.Layout(bottomLine);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.SelectNode("setPdfBackgroundLayer");
            }
        }
    }
}
