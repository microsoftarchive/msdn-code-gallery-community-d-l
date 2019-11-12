using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class SearchTextInPdf : System.Web.UI.Page
    {
        protected void buttonSearchText_Click(object sender, EventArgs e)
        {
            // get the PDF file
            string pdfFile = Server.MapPath("~") + @"\DemoFiles\Pdf\InputPdf.pdf";

            // get the text to search
            string textToSearch = textBoxTextToSearch.Text;

            // create the PDF text extractor
            PdfTextExtract pdfTextExtract = new PdfTextExtract();

            // set a demo serial number
            pdfTextExtract.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            int fromPdfPageNumber = int.Parse(textBoxFromPage.Text);
            int toPdfPageNumber = textBoxToPage.Text.Length > 0 ? int.Parse(textBoxToPage.Text) : 0;

            // search the text in PDF document
            PdfTextSearchItem[] searchTextInstances = pdfTextExtract.SearchText(pdfFile, textToSearch,
                        fromPdfPageNumber, toPdfPageNumber, checkBoxMatchCase.Checked, checkBoxMatchWholeWord.Checked);

            // load the PDF file to highlight the searched text
            PdfDocument pdfDocument = PdfDocument.FromFile(pdfFile);

            // set a demo serial number
            pdfDocument.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // highlight the searched text in PDF document
            foreach (PdfTextSearchItem searchTextInstance in searchTextInstances)
            {
                PdfRectangle pdfRectangle = new PdfRectangle(searchTextInstance.BoundingRectangle);

                // set rectangle color and opacity
                pdfRectangle.BackColor = Color.Yellow;
                pdfRectangle.Opacity = 30;

                // highlight the text
                pdfDocument.Pages[searchTextInstance.PdfPageNumber - 1].Layout(pdfRectangle);
            }

            // write the modified PDF document
            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = pdfDocument.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=SearchText.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                pdfDocument.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                hyperLinkOpenPdf.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/InputPdf.pdf";

                Master.SelectNode("searchText");
            }
        }
    }
}