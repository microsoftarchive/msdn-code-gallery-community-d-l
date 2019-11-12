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
    public partial class PdfPageBreaksControl : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // set browser width
            htmlToPdfConverter.BrowserWidth = int.Parse(textBoxBrowserWidth.Text);

            // convert HTML to PDF
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(textBoxHtmlCode.Text, textBoxBaseUrl.Text);

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=PageBreaksControl.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

            // write the PDF buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(pdfBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textBoxBaseUrl.Text = HttpContext.Current.Request.Url.AbsoluteUri;

                Master.SelectNode("pdfPageBreaksControl");
            }
        }
    }
}
