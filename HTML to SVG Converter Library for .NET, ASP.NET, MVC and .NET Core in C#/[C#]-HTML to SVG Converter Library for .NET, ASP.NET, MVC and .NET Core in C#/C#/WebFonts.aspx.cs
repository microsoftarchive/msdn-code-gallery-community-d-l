using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class WebFonts : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            htmlToPdfConverter.TriggerMode = ConversionTriggerMode.WaitTime;
            htmlToPdfConverter.WaitBeforeConvert = 3;

            byte[] pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(textBoxUrl.Text);

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=WebFonts.pdf; size={0}",
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
                textBoxUrl.Text = "http://www.hiqpdf.com/html/webfonts.html";

                Master.SelectNode("convertWebFonts");
            }
        }
    }
}