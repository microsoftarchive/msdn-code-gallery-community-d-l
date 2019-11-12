using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class PdfImages : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // create a page in document
            PdfPage page1 = document.AddPage();

            // set a background color for the page
            PdfRectangle backgroundRectangle = new PdfRectangle(page1.DrawableRectangle);
            backgroundRectangle.BackColor = System.Drawing.Color.WhiteSmoke;
            page1.Layout(backgroundRectangle);

            // create the true type fonts that can be used in document text
            System.Drawing.Font sysFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFont = document.CreateFont(sysFont);
            PdfFont pdfFontEmbed = document.CreateFont(sysFont, true);

            float crtYPos = 20;
            float crtXPos = 5;

            #region Layout transparent image

            PdfText titleTextTransImage = new PdfText(crtXPos, crtYPos,
                    "PNG image with alpha transparency:", pdfFontEmbed);
            titleTextTransImage.ForeColor = System.Drawing.Color.Navy;
            PdfLayoutInfo textLayoutInfo = page1.Layout(titleTextTransImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout a PNG image with alpha transparency
            PdfImage transparentPdfImage = new PdfImage(crtXPos, crtYPos, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.png");
            PdfLayoutInfo imageLayoutInfo = page1.Layout(transparentPdfImage);

            // advance the Y position in the PDF page
            crtYPos += imageLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout resized transparent image

            PdfText titleTextTransImageResized = new PdfText(crtXPos, crtYPos,
                    "The transparent PNG image below is resized:", pdfFontEmbed);
            titleTextTransImageResized.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextTransImageResized);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout a PNG image with alpha transparency
            PdfImage transparentResizedPdfImage = new PdfImage(crtXPos, crtYPos, 50, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.png");
            imageLayoutInfo = page1.Layout(transparentResizedPdfImage);

            // advance the Y position in the PDF page
            crtYPos += imageLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout rotated transparent image

            PdfText titleTextTransImageRotated = new PdfText(crtXPos, crtYPos,
                    "The transparent PNG image below is rotated 180 degrees counter clockwise:", pdfFontEmbed);
            titleTextTransImageRotated.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextTransImageRotated);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // rotate the PNG image with alpha transparency 180 degrees counter clockwise
            PdfImage transparentRotatedPdfImage = new PdfImage(0, 0, 50, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.png");
            // translate the coordinates system to image location
            transparentRotatedPdfImage.SetTranslation(crtXPos, crtYPos);
            // rotate the coordinates system counter clockwise
            transparentRotatedPdfImage.SetRotationAngle(180);
            // translate back the coordinates system
            transparentRotatedPdfImage.SetTranslation(-50, -50);

            imageLayoutInfo = page1.Layout(transparentRotatedPdfImage);

            // advance the Y position in the PDF page
            crtYPos += 50 + 10;

            #endregion

            #region Layout clipped transparent image

            PdfText titleTextTransClippedImage = new PdfText(crtXPos, crtYPos,
                    "The transparent PNG image below is clipped:", pdfFontEmbed);
            titleTextTransClippedImage.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextTransClippedImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout a clipped PNG image with alpha transparency
            PdfImage transparentClippedPdfImage = new PdfImage(crtXPos, crtYPos, 50, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.png");
            transparentClippedPdfImage.ClipRectangle = new System.Drawing.RectangleF(crtXPos, crtYPos, 50, 25);

            imageLayoutInfo = page1.Layout(transparentClippedPdfImage);

            // advance the Y position in the PDF page
            crtYPos += transparentClippedPdfImage.ClipRectangle.Height + 10;

            #endregion

            #region Layout JPEG image

            PdfText titleTextOpaqueImage = new PdfText(crtXPos, crtYPos, "The JPG image below is opaque:", pdfFontEmbed);
            titleTextOpaqueImage.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextOpaqueImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout an opaque JPG image
            PdfImage opaquePdfImage = new PdfImage(crtXPos, crtYPos, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.jpg");

            imageLayoutInfo = page1.Layout(opaquePdfImage);

            // advance the Y position in the PDF page
            crtYPos += imageLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout clipped JPEG image

            PdfText titleTextClippedImage = new PdfText(crtXPos, crtYPos, "The JPG image below is clipped:", pdfFontEmbed);
            titleTextClippedImage.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextClippedImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout a clipped image
            PdfImage clippedPdfImage = new PdfImage(crtXPos, crtYPos, 50, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_small.jpg");
            clippedPdfImage.ClipRectangle = new System.Drawing.RectangleF(crtXPos, crtYPos, 50, 25);

            imageLayoutInfo = page1.Layout(clippedPdfImage);

            // advance the Y position in the PDF page
            crtYPos += clippedPdfImage.ClipRectangle.Height + 10;

            #endregion

            #region Layout a vectorial SVG image

            PdfText titleTextSvgImage = new PdfText(crtXPos, crtYPos, "Vectorial SVG image:", pdfFontEmbed);
            titleTextSvgImage.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextSvgImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            string svgImageCode = System.IO.File.ReadAllText(Server.MapPath("~") + @"\DemoFiles\Svg\SvgImage.svg");

            PdfHtml svgImage = new PdfHtml(crtXPos, crtYPos, svgImageCode, null);
            PdfLayoutInfo svgLayoutInfo = page1.Layout(svgImage);

            // advance the Y position in the PDF page
            crtYPos += svgImage.ConversionInfo.PdfRegions[0].Rectangle.Height + 10;

            #endregion

            #region Layout JPEG image on multiple pages

            PdfText titleTexMultiPageImage = new PdfText(crtXPos, crtYPos, "The JPG image below is laid out on 2 pages:", pdfFontEmbed);
            titleTexMultiPageImage.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTexMultiPageImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // layout an opaque JPG image on 2 pages
            PdfImage paginatedPdfImage = new PdfImage(crtXPos, crtYPos, Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo_big.jpg");

            imageLayoutInfo = page1.Layout(paginatedPdfImage);

            #endregion

            // get the last page
            PdfPage crtPage = document.Pages[imageLayoutInfo.LastPageIndex];
            crtYPos = imageLayoutInfo.LastPageRectangle.Bottom + 10;

            #region Layout the screenshot of a HTML document

            PdfText titleTextHtmlImage = new PdfText(crtXPos, crtYPos, "HTML document screenshot:", pdfFontEmbed);
            titleTextHtmlImage.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = crtPage.Layout(titleTextHtmlImage);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            string htmlFile = Server.MapPath("~") + @"\DemoFiles\Html\Logo.Html";

            PdfHtmlImage htmlRasterImage = new PdfHtmlImage(crtXPos, crtYPos, htmlFile);
            htmlRasterImage.BrowserWidth = 400;
            PdfLayoutInfo htmlLayoutInfo = crtPage.Layout(htmlRasterImage);

            // advance the Y position in the PDF page
            crtYPos += htmlRasterImage.ConversionInfo.PdfRegions[0].Rectangle.Height + 10;

            #endregion

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=PdfImages.pdf; size={0}",
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
                Master.SelectNode("pdfImages");
            }
        }
    }
}