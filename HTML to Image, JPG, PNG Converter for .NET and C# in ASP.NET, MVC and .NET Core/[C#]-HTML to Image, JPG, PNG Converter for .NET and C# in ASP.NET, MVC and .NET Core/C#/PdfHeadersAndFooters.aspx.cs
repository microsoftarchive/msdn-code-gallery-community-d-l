using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class PdfHeadersAndFooters : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set the default header and footer of the document
            SetHeader(htmlToPdfConverter.Document);
            SetFooter(htmlToPdfConverter.Document);

            // set a handler for PageCreatingEvent where to configure the PDF document pages
            htmlToPdfConverter.PageCreatingEvent += new PdfPageCreatingDelegate(htmlToPdfConverter_PageCreatingEvent);

            try
            {
                byte[] pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(textBoxUrl.Text);

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document, attachment or inline, and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=PdfHeadersAndFooters.pdf; size={0}",
                                pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                // dettach from PageCreatingEvent event
                htmlToPdfConverter.PageCreatingEvent -= new PdfPageCreatingDelegate(htmlToPdfConverter_PageCreatingEvent);
            }
        }

        void htmlToPdfConverter_PageCreatingEvent(PdfPageCreatingParams eventParams)
        {
            PdfPage pdfPage = eventParams.PdfPage;
            int pdfPageNumber = eventParams.PdfPageNumber;

            if (pdfPageNumber == 1)
            {
                // set the header and footer visibility in first page
                pdfPage.DisplayHeader = checkBoxDisplayHeaderInFirstPage.Checked;
                pdfPage.DisplayFooter = checkBoxDisplayFooterInFirstPage.Checked;
            }
            else if (pdfPageNumber == 2)
            {
                // set the header and footer visibility in second page
                pdfPage.DisplayHeader = checkBoxDisplayHeaderInSecondPage.Checked;
                pdfPage.DisplayFooter = checkBoxDisplayFooterInSecondPage.Checked;

                if (pdfPage.DisplayHeader && checkBoxCustomizedHeaderInSecondPage.Checked)
                {
                    // override the default document header in this page
                    // with a customized header of 200 points in height
                    pdfPage.CreateHeaderCanvas(200);

                    // layout a HTML document in header
                    PdfHtml htmlInHeader = new PdfHtml("http://www.google.com");
                    htmlInHeader.FitDestHeight = true;
                    pdfPage.Header.Layout(htmlInHeader);

                    // create a border for the customized header
                    PdfRectangle borderRectangle = new PdfRectangle(0, 0, pdfPage.Header.Width - 1, pdfPage.Header.Height - 1);
                    borderRectangle.LineStyle.LineWidth = 0.5f;
                    borderRectangle.ForeColor = System.Drawing.Color.Navy;
                    pdfPage.Header.Layout(borderRectangle);
                }
            }
        }

        private void SetHeader(PdfDocumentControl htmlToPdfDocument)
        {
            // enable header display
            htmlToPdfDocument.Header.Enabled = true;

            // set header height
            htmlToPdfDocument.Header.Height = 50;

            float pdfPageWidth = htmlToPdfDocument.PageOrientation == PdfPageOrientation.Portrait ?
                                        htmlToPdfDocument.PageSize.Width : htmlToPdfDocument.PageSize.Height;

            float headerWidth = pdfPageWidth - htmlToPdfDocument.Margins.Left - htmlToPdfDocument.Margins.Right;
            float headerHeight = htmlToPdfDocument.Header.Height;

            // set header background color
            htmlToPdfDocument.Header.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            string headerImageFile = Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo.png";
            PdfImage logoHeaderImage = new PdfImage(5, 5, 40, System.Drawing.Image.FromFile(headerImageFile));
            htmlToPdfDocument.Header.Layout(logoHeaderImage);

            // layout HTML in header
            PdfHtml headerHtml = new PdfHtml(50, 5, @"<span style=""color:Navy; font-family:Times New Roman; font-style:italic"">
                            Quickly Create High Quality PDFs with </span><a href=""http://www.hiqpdf.com"">HiQPdf</a>", null);
            headerHtml.FitDestHeight = true;
            htmlToPdfDocument.Header.Layout(headerHtml);

            // create a border for header

            PdfRectangle borderRectangle = new PdfRectangle(1, 1, headerWidth - 2, headerHeight - 2);
            borderRectangle.LineStyle.LineWidth = 0.5f;
            borderRectangle.ForeColor = System.Drawing.Color.Navy;
            htmlToPdfDocument.Header.Layout(borderRectangle);
        }

        private void SetFooter(PdfDocumentControl htmlToPdfDocument)
        {
            // enable footer display
            htmlToPdfDocument.Footer.Enabled = true;

            // set footer height
            htmlToPdfDocument.Footer.Height = 50;

            // set footer background color
            htmlToPdfDocument.Footer.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            float pdfPageWidth = htmlToPdfDocument.PageOrientation == PdfPageOrientation.Portrait ?
                                        htmlToPdfDocument.PageSize.Width : htmlToPdfDocument.PageSize.Height;

            float footerWidth = pdfPageWidth - htmlToPdfDocument.Margins.Left - htmlToPdfDocument.Margins.Right;
            float footerHeight = htmlToPdfDocument.Footer.Height;

            // layout HTML in footer
            PdfHtml footerHtml = new PdfHtml(5, 5, @"<span style=""color:Navy; font-family:Times New Roman; font-style:italic"">
                            Quickly Create High Quality PDFs with </span><a href=""http://www.hiqpdf.com"">HiQPdf</a>", null);
            footerHtml.FitDestHeight = true;
            htmlToPdfDocument.Footer.Layout(footerHtml);

            if (checkBoxDisplayPageNumbersInFooter.Checked)
            {
                if (!checkBoxPageNumbersInHtml.Checked)
                {
                    // add page numbering in a text element
                    System.Drawing.Font pageNumberingFont = new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"),
                                    8, System.Drawing.GraphicsUnit.Point);
                    PdfText pageNumberingText = new PdfText(5, footerHeight - 12, "Page {CrtPage} of {PageCount}", pageNumberingFont);
                    pageNumberingText.HorizontalAlign = PdfTextHAlign.Center;
                    pageNumberingText.EmbedSystemFont = true;
                    pageNumberingText.ForeColor = System.Drawing.Color.DarkGreen;
                    htmlToPdfDocument.Footer.Layout(pageNumberingText);
                }
                else
                {
                    // add page numbers in HTML - more flexible but less efficient than text version
                    PdfHtmlWithPlaceHolders htmlWithPageNumbers = new PdfHtmlWithPlaceHolders(5, footerHeight - 20,
                        "Page <span style=\"font-size: 16px; color: blue; font-style: italic; font-weight: bold\">{CrtPage}</span> of <span style=\"font-size: 16px; color: green; font-weight: bold\">{PageCount}</span>", null);
                    htmlToPdfDocument.Footer.Layout(htmlWithPageNumbers);
                }
            }

            string footerImageFile = Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo.png";
            PdfImage logoFooterImage = new PdfImage(footerWidth - 40 - 5, 5, 40, System.Drawing.Image.FromFile(footerImageFile));
            htmlToPdfDocument.Footer.Layout(logoFooterImage);

            // create a border for footer
            PdfRectangle borderRectangle = new PdfRectangle(1, 1, footerWidth - 2, footerHeight - 2);
            borderRectangle.LineStyle.LineWidth = 0.5f;
            borderRectangle.ForeColor = System.Drawing.Color.DarkGreen;
            htmlToPdfDocument.Footer.Layout(borderRectangle);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textBoxUrl.Text = "http://www.hiqpdf.com/html/html5_introduction.html";

                Master.SelectNode("pdfHeadersAndFooters");
            }
        }
    }
}