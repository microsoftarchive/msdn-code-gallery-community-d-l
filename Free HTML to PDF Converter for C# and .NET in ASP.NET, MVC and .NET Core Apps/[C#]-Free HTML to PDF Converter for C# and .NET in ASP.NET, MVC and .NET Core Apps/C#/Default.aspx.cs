using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void buttonConvertToPdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

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

            // set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(0);

            // set a wait time before starting the conversion
            htmlToPdfConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);

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

                Master.SelectNode("htmlToPdf");
            }
        }
    }
}