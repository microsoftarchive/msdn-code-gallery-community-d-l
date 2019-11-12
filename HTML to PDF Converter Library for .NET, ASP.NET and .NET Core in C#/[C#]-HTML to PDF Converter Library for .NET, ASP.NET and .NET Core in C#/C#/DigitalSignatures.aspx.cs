using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class DigitalSignatures : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // create a page in document
            PdfPage page1 = document.AddPage();

            // create the true type fonts that can be used in document text
            Font sysFont = new Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFont = document.CreateFont(sysFont);
            PdfFont pdfFontEmbed = document.CreateFont(sysFont, true);

            float crtYPos = 20;
            float crtXPos = 5;

            // add a title to PDF document
            PdfText titleTextTransImage = new PdfText(crtXPos, crtYPos,
                    "Click the image below to open the digital signature", pdfFontEmbed);
            titleTextTransImage.ForeColor = Color.Navy;
            PdfLayoutInfo textLayoutInfo = page1.Layout(titleTextTransImage);

            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout a PNG image with alpha transparency
            PdfImage transparentPdfImage = new PdfImage(crtXPos, crtYPos, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.png");
            PdfLayoutInfo imageLayoutInfo = page1.Layout(transparentPdfImage);

            // apply a digital sgnature over the image
            PdfCertificatesCollection pdfCertificates = PdfCertificatesCollection.FromFile(Server.MapPath("~") + @"\DemoFiles\Pfx\hiqpdf.pfx", "hiqpdf");
            PdfDigitalSignature digitalSignature = new PdfDigitalSignature(pdfCertificates[0]);
            digitalSignature.SigningReason = "My signing reason";
            digitalSignature.SigningLocation = "My signing location";
            digitalSignature.SignerContactInfo = "My contact info";
            document.AddDigitalSignature(digitalSignature, imageLayoutInfo.LastPdfPage, imageLayoutInfo.LastPageRectangle);

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=DigitalSignatures.pdf; size={0}",
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
                Master.SelectNode("digitalSignatures");
            }
        }
    }
}