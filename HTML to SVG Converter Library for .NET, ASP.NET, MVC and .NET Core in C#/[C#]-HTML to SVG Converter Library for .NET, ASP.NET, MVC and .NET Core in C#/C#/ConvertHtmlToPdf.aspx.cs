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
    public partial class ConvertHtmlToPdf : System.Web.UI.Page
    {
        protected void buttonConvertToPdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set browser width
            htmlToPdfConverter.BrowserWidth = int.Parse(textBoxBrowserWidth.Text);

            // set browser height if specified, otherwise use the default
            if (textBoxBrowserHeight.Text.Length > 0)
                htmlToPdfConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

            // set HTML Load timeout
            htmlToPdfConverter.HtmlLoadedTimeout = int.Parse(textBoxLoadHtmlTimeout.Text);

            // set PDF page size and orientation
            htmlToPdfConverter.Document.PageSize = GetSelectedPageSize();
            htmlToPdfConverter.Document.PageOrientation = GetSelectedPageOrientation();

            // set the PDF standard used by the document
            htmlToPdfConverter.Document.PdfStandard = checkBoxPdfA.Checked ? PdfStandard.PdfA : PdfStandard.Pdf;

            // set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(5);

            // set whether to embed the true type font in PDF
            htmlToPdfConverter.Document.FontEmbedding = checkBoxFontEmbedding.Checked;

            // set triggering mode; for WaitTime mode set the wait time before convert
            switch (dropDownListTriggeringMode.SelectedValue)
            {
                case "Auto":
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
                case "WaitTime":
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.WaitTime;
                    htmlToPdfConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);
                    break;
                case "Manual":
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Manual;
                    break;
                default:
                    htmlToPdfConverter.TriggerMode = ConversionTriggerMode.Auto;
                    break;
            }

            // set header and footer
            SetHeader(htmlToPdfConverter.Document);
            SetFooter(htmlToPdfConverter.Document);

            // set the document security
            htmlToPdfConverter.Document.Security.OpenPassword = textBoxOpenPassword.Text;
            htmlToPdfConverter.Document.Security.AllowPrinting = checkBoxAllowPrinting.Checked;

            // set the permissions password too if an open password was set
            if (htmlToPdfConverter.Document.Security.OpenPassword != null && htmlToPdfConverter.Document.Security.OpenPassword != String.Empty)
                htmlToPdfConverter.Document.Security.PermissionsPassword = htmlToPdfConverter.Document.Security.OpenPassword + "_admin";

            // convert HTML to PDF
            byte[] pdfBuffer = null;

            if (radioButtonConvertUrl.Checked)
            {
                // convert URL to a PDF memory buffer
                string url = textBoxUrl.Text;

                pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url);
            }
            else
            {
                // convert HTML code
                string htmlCode = textBoxHtmlCode.Text;
                string baseUrl = textBoxBaseUrl.Text;

                // convert HTML code to a PDF memory buffer
                pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, baseUrl);
            }

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("{0}; filename=HtmlToPdf.pdf; size={1}",
                checkBoxOpenInline.Checked ? "inline" : "attachment", pdfBuffer.Length.ToString()));

            // write the PDF buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(pdfBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }

        private void SetHeader(PdfDocumentControl htmlToPdfDocument)
        {
            // enable header display
            htmlToPdfDocument.Header.Enabled = checkBoxAddHeader.Checked;

            if (!htmlToPdfDocument.Header.Enabled)
                return;

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
            headerHtml.FontEmbedding = checkBoxFontEmbedding.Checked;
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
            htmlToPdfDocument.Footer.Enabled = checkBoxAddFooter.Checked;

            if (!htmlToPdfDocument.Footer.Enabled)
                return;

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
            footerHtml.FontEmbedding = checkBoxFontEmbedding.Checked;
            htmlToPdfDocument.Footer.Layout(footerHtml);

            // add page numbering
            System.Drawing.Font pageNumberingFont = new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"),
                                        8, System.Drawing.GraphicsUnit.Point);
            PdfText pageNumberingText = new PdfText(5, footerHeight - 12, "Page {CrtPage} of {PageCount}", pageNumberingFont);
            pageNumberingText.HorizontalAlign = PdfTextHAlign.Center;
            pageNumberingText.EmbedSystemFont = true;
            pageNumberingText.ForeColor = System.Drawing.Color.DarkGreen;
            htmlToPdfDocument.Footer.Layout(pageNumberingText);

            string footerImageFile = Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo.png";
            PdfImage logoFooterImage = new PdfImage(footerWidth - 40 - 5, 5, 40, System.Drawing.Image.FromFile(footerImageFile));
            htmlToPdfDocument.Footer.Layout(logoFooterImage);

            // create a border for footer
            PdfRectangle borderRectangle = new PdfRectangle(1, 1, footerWidth - 2, footerHeight - 2);
            borderRectangle.LineStyle.LineWidth = 0.5f;
            borderRectangle.ForeColor = System.Drawing.Color.DarkGreen;
            htmlToPdfDocument.Footer.Layout(borderRectangle);
        }

        private PdfPageSize GetSelectedPageSize()
        {
            switch (dropDownListPageSizes.SelectedValue)
            {
                case "A0":
                    return PdfPageSize.A0;
                case "A1":
                    return PdfPageSize.A1;
                case "A10":
                    return PdfPageSize.A10;
                case "A2":
                    return PdfPageSize.A2;
                case "A3":
                    return PdfPageSize.A3;
                case "A4":
                    return PdfPageSize.A4;
                case "A5":
                    return PdfPageSize.A5;
                case "A6":
                    return PdfPageSize.A6;
                case "A7":
                    return PdfPageSize.A7;
                case "A8":
                    return PdfPageSize.A8;
                case "A9":
                    return PdfPageSize.A9;
                case "ArchA":
                    return PdfPageSize.ArchA;
                case "ArchB":
                    return PdfPageSize.ArchB;
                case "ArchC":
                    return PdfPageSize.ArchC;
                case "ArchD":
                    return PdfPageSize.ArchD;
                case "ArchE":
                    return PdfPageSize.ArchE;
                case "B0":
                    return PdfPageSize.B0;
                case "B1":
                    return PdfPageSize.B1;
                case "B2":
                    return PdfPageSize.B2;
                case "B3":
                    return PdfPageSize.B3;
                case "B4":
                    return PdfPageSize.B4;
                case "B5":
                    return PdfPageSize.B5;
                case "Flsa":
                    return PdfPageSize.Flsa;
                case "HalfLetter":
                    return PdfPageSize.HalfLetter;
                case "Ledger":
                    return PdfPageSize.Ledger;
                case "Legal":
                    return PdfPageSize.Legal;
                case "Letter":
                    return PdfPageSize.Letter;
                case "Letter11x17":
                    return PdfPageSize.Letter11x17;
                case "Note":
                    return PdfPageSize.Note;
                default:
                    return PdfPageSize.A4;
            }
        }

        private PdfPageOrientation GetSelectedPageOrientation()
        {
            return (dropDownListPageOrientations.SelectedValue == "Portrait") ?
                PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;
        }

        protected void radioButtonConvertUrl_CheckedChanged(object sender, EventArgs e)
        {
            panelUrl.Visible = radioButtonConvertUrl.Checked;
            panelHtmlCode.Visible = !radioButtonConvertUrl.Checked;
        }

        protected void radioButtonConvertHtmlCode_CheckedChanged(object sender, EventArgs e)
        {
            panelUrl.Visible = !radioButtonConvertHtmlCode.Checked;
            panelHtmlCode.Visible = radioButtonConvertHtmlCode.Checked;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDownListPageSizes.SelectedValue = "A4";
                dropDownListPageOrientations.SelectedValue = "Portrait";

                dropDownListTriggeringMode.SelectedValue = "WaitTime";
                panelWaitTime.Visible = true;

                Master.SelectNode("htmlToPdf");
            }
        }

        protected void dropDownListTriggeringMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelWaitTime.Visible = dropDownListTriggeringMode.SelectedValue == "WaitTime";
        }
    }
}
