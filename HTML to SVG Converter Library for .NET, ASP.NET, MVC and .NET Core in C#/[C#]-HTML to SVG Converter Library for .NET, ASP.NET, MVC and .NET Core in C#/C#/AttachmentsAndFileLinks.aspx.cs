using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class AttachmentsAndFileLinks : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // display the attachments when the document is opened
            document.Viewer.PageMode = PdfPageMode.Attachments;

            // create a page in document
            PdfPage page1 = document.AddPage();

            // create the true type fonts that can be used in document
            System.Drawing.Font sysFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFont = document.CreateFont(sysFont);
            PdfFont pdfFontEmbed = document.CreateFont(sysFont, true);

            // create a reference Graphics used for measuring
            System.Drawing.Bitmap refBmp = new System.Drawing.Bitmap(1, 1);
            System.Drawing.Graphics refGraphics = System.Drawing.Graphics.FromImage(refBmp);
            refGraphics.PageUnit = System.Drawing.GraphicsUnit.Point;

            // create an attachment with icon from file
            string filePath1 = Server.MapPath("~") + @"\DemoFiles\Attach\TextAttach1.txt";
            PdfAttachment pdfAttachment1 = document.CreateAttachmentFromFile(page1, new System.Drawing.RectangleF(10, 30, 10, 20),
                        PdfAttachIconType.PushPin, filePath1);
            pdfAttachment1.Description = "Attachment with icon from a file";

            // write a description at the right of the icon
            PdfText pdfAttachment1Descr = new PdfText(40, 35, pdfAttachment1.Description, pdfFontEmbed);
            page1.Layout(pdfAttachment1Descr);

            // create an attachment with icon from a stream
            // The stream must remain opened until the document is saved 
            System.IO.FileStream fileStream2 = new System.IO.FileStream(filePath1, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            PdfAttachment pdfAttachment2 = document.CreateAttachmentFromStream(page1, new System.Drawing.RectangleF(10, 60, 10, 20), 
                            PdfAttachIconType.Paperclip, fileStream2, "AttachFromStream_WithIcon.txt");
            pdfAttachment2.Description = "Attachment with icon from a stream";

            // write a description at the right of the icon
            PdfText pdfAttachment2Descr = new PdfText(40, 65, pdfAttachment2.Description, pdfFontEmbed);
            page1.Layout(pdfAttachment2Descr);

            // create an attachment without icon in PDF from a file
            string filePath2 = Server.MapPath("~") + @"\DemoFiles\Attach\TextAttach2.txt";
            document.CreateAttachmentFromFile(filePath2);

            // create an attachment without icon in PDF from a stream
            // The stream must remain opened until the document is saved 
            System.IO.FileStream fileStream1 = new System.IO.FileStream(filePath2, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            document.CreateAttachmentFromStream(fileStream1, "AttachFromStream_NoIcon.txt");

            // dispose the graphics used for measuring
            refGraphics.Dispose();
            refBmp.Dispose();

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=PdfOutlines.pdf; size={0}",
                            pdfBuffer.Length.ToString()));

                // write the PDF buffer to HTTP response
                HttpContext.Current.Response.BinaryWrite(pdfBuffer);

                // call End() method of HTTP response to stop ASP.NET page processing
                HttpContext.Current.Response.End();
            }
            finally
            {
                document.Close();
                fileStream1.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.SelectNode("pdfAttachments");
            }
        }
    }
}