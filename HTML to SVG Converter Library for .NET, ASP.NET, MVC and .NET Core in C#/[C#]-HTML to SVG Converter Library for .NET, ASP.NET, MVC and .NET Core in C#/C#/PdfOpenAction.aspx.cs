using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class PdfOpenAction : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // create the true type fonts that can be used in document
            System.Drawing.Font ttfFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont newTimesFont = document.CreateFont(ttfFont);
            PdfFont newTimesFontEmbed = document.CreateFont(ttfFont, true);

            // create page 1
            PdfPage page1 = document.AddPage();
            // create a text object to be laid out on this page
            PdfText text1 = new PdfText(10, 10, "This is the Page 1 of the document with Open action", newTimesFontEmbed);
            // layout the text
            page1.Layout(text1);

            // create page 2
            PdfPage page2 = document.AddPage();
            // create a text object to be laid out on this page
            PdfText text2 = new PdfText(10, 10, "This is the Page 2 of the document with Open action", newTimesFontEmbed);
            // layout the text
            page2.Layout(text2);

            // create page 1
            PdfPage page3 = document.AddPage();
            // create a text object to be laid out on this page
            PdfText text3 = new PdfText(10, 10, "This is the Page 3 of the document with Open action", newTimesFontEmbed);
            // layout the text
            page3.Layout(text3);

            if (radioButtonJavaScript.Checked)
            {
                // display an alert message when the document is opened

                string alertMessage = textBoxAlertMessage.Text;
                string javaScriptCode = "app.alert({cMsg: \"" + alertMessage + "\", cTitle: \"Open Document JavaScript Action\"});";

                // create the JavaScript action to display the alert
                PdfJavaScriptAction javaScriptAction = new PdfJavaScriptAction(javaScriptCode);

                // set the document JavaScript open action
                document.SetOpenAction(javaScriptAction);
            }
            else
            {
                // go to a given page in document and set the given zoom level when the document is opened

                int pageIndex = radioButtonPage1.Checked ? 0 : (radioButtonPage2.Checked ? 1 : 2);
                int zoomLevel = int.Parse(textBoxZoomLevel.Text);

                PdfDestination openDestination = new PdfDestination(document.Pages[pageIndex], new System.Drawing.PointF(10, 10));
                openDestination.Zoom = zoomLevel;
                PdfGoToAction goToAction = new PdfGoToAction(openDestination);

                // set the document GoTo open action
                document.SetOpenAction(goToAction);
            }

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=OpenAction.pdf; size={0}",
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
                Master.SelectNode("pdfOpenAction");
            }
        }
    }
}