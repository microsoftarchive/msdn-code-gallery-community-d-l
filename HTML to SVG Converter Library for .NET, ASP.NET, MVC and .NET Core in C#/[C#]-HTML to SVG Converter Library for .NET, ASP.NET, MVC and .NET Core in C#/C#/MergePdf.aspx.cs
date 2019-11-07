using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class MergePdf : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create an empty document which will become the final document after merge
            PdfDocument resultDocument = new PdfDocument();

            // set a demo serial number
            resultDocument.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // load the first document to be merged from a file
            string pdfFile1 = Server.MapPath("~") + @"\DemoFiles\Pdf\WikiHtml.pdf";
            PdfDocument document1 = PdfDocument.FromFile(pdfFile1);

            // load the second document to be merged from a FileStream to exemplify the PDF loading from a stream
            // The stream must remain open until the result document is saved. The stream is closed when the document2 
            // will be closed
            string pdfFile2 = Server.MapPath("~") + @"\DemoFiles\Pdf\WikiPdf.pdf";
            System.IO.FileStream pdfStream = new System.IO.FileStream(pdfFile2, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            PdfDocument document2 = PdfDocument.FromStream(pdfStream);

            // add the two documents to the result document
            resultDocument.AddDocument(document1);
            resultDocument.AddDocument(document2);

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = resultDocument.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=MergePdf.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                // close the result document
                resultDocument.Close();
                // close the merged documents
                // this will also close the pdfStream from which document 2 was loaded 
                document1.Close();
                document2.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pageUri = HttpContext.Current.Request.Url.AbsoluteUri;
                hyperLinkOpenPdf1.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/WikiHtml.pdf";
                hyperLinkOpenPdf2.NavigateUrl = pageUri.Substring(0, pageUri.LastIndexOf('/')) + @"/DemoFiles/Pdf/WikiPdf.pdf";

                Master.SelectNode("mergePdf");
            }
        }
    }
}