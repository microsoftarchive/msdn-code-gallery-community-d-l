using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.IO;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class ConvertHtmlPreservingState : System.Web.UI.Page
    {
        // a flag to indicate to Render method if the current page
        // will be converted to PDF
        bool convertCrtPageToPdf = false;


        protected void Page_Load(object sender, EventArgs e)
        {
            panelSessionVariableValue.Visible = false;

            if (!IsPostBack)
            {
                Master.SelectNode("convertHtmlPreservingState");
            }
        }

        protected void buttonConvertCrtPage_Click(object sender, EventArgs e)
        {
            // indicate to Render method that the current page
            // will be converted to PDF
            convertCrtPageToPdf = true;

            // save custom value in ASP.NET session variable
            Session["SessionVariable"] = textBoxCrtSessionVariable.Text;

            // show session variable value
            panelSessionVariableValue.Visible = true;
            litSessionVariableValue.Text = Session["SessionVariable"].ToString();
        }

        // override the Render method of the ASP.NET page
        protected override void Render(HtmlTextWriter writer)
        {
            if (convertCrtPageToPdf)
            {
                // setup a TextWriter to capture the current page HTML code
                TextWriter tw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(tw);

                // render the HTML markup into the TextWriter
                base.Render(htw);

                // get the current page HTML code
                string htmlCode = tw.ToString();

                // convert the HTML code to PDF

                // create the HTML to PDF converter
                HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

                // set a demo serial number
                htmlToPdfConverter.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

                // hide the HTML buttons
                htmlToPdfConverter.HiddenHtmlElements = new string[] { "#convertCrtPageDiv", "#convertAnotherPageDiv" };

                // the base URL used to resolve images, CSS and script files
                string currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri;

                // convert HTML code to a PDF memory buffer
                byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, currentPageUrl);

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document, attachment or inline, and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition",
                    String.Format("attachment; filename=ConvertThisHtmlWithState.pdf; size={0}", pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            else
            {
                base.Render(writer);
            }
        }

        protected void buttonConvertAnotherPage_Click(object sender, EventArgs e)
        {
            // save custom value in ASP.NET session variable
            Session["SessionVariable"] = textBoxAnotherSessionVariable.Text;

            // setup a TextWriter to capture the HTML code of the page to convert
            TextWriter tw = new StringWriter();

            // execute the 'AnotherPageInThisApplication.aspx' page in the same application and capture the HTML code
            Server.Execute("AnotherPageInThisApplication.aspx", tw);

            // get the HTML code from writer
            string htmlCode = tw.ToString();

            // convert the HTML code to PDF

            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // the base URL used to resolve images, CSS and script files
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            // convert HTML code to a PDF memory buffer
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, baseUrl);

            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition",
                String.Format("attachment; filename=ConvertAnotherHtmlWithState.pdf; size={0}", pdfBuffer.Length.ToString()));

            // write the PDF buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(pdfBuffer);

            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }
    }
}