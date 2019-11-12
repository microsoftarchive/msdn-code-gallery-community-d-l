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
    public partial class AutoOutlinesAndLinks : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set a demo serial number
            htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            if (checkBoxHierarchical.Checked)
            {
                // automatically outline the H1 to H6 tags in a hierarchy
                htmlToPdfConverter.Document.Outlines.OutlineHeadingTags = true;
            }
            else
            {
                // create outlines for each chapter and for table of contents
                // the CSS selectors mean all the H1 and H2 elements with the CSS class name 'pdf_outlines'
                htmlToPdfConverter.Document.Outlines.OutlinedElements = new string[] { "H1[class=\"pdf_outlines\"]", "H2[class=\"pdf_outlines\"]" };
            }

            // make the outlines visible in viewer
            htmlToPdfConverter.Document.Viewer.PageMode = PdfPageMode.Outlines;

            // convert the HTML code to PDF
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(textBoxHtmlCode.Text, null);

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=AutoOutlines.pdf; size={0}",
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
                Master.SelectNode("autoOutlinesAndLinks");
            }
        }
    }
}
