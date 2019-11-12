using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class PdfTextDemo : System.Web.UI.Page
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
            System.Drawing.Font sysFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFont = document.CreateFont(sysFont);
            PdfFont pdfFontEmbed = document.CreateFont(sysFont, true);

            System.Drawing.Font sysFontBold = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold,
                            System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFontBold = document.CreateFont(sysFontBold);
            PdfFont pdfFontBoldEmbed = document.CreateFont(sysFontBold, true);

            // create a standard Helvetica Type 1 font that can be used in document text
            PdfFont helveticaStdFont = document.CreateStandardFont(PdfStandardFont.Helvetica);
            helveticaStdFont.Size = 10;

            float crtYPos = 20;
            float crtXPos = 5;

            PdfLayoutInfo textLayoutInfo = null;

            string dummyText = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            #region Layout a text that expands to the right edge of the PDF page

            PdfText titleTextAtLocation = new PdfText(crtXPos, crtYPos,
                    "The text below extends from the layout position to the right edge of the PDF page:", pdfFontBoldEmbed);
            titleTextAtLocation.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextAtLocation);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            PdfText textExpandsToRightEdge = new PdfText(crtXPos + 50, crtYPos, dummyText, pdfFont);
            textExpandsToRightEdge.BackColor = System.Drawing.Color.WhiteSmoke;
            textLayoutInfo = page1.Layout(textExpandsToRightEdge);

            // draw a rectangle around the text
            PdfRectangle borderPdfRectangle = new PdfRectangle(textLayoutInfo.LastPageRectangle);
            borderPdfRectangle.LineStyle.LineWidth = 0.5f;
            page1.Layout(borderPdfRectangle);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout a text with width limit

            PdfText titleTextWithWidth = new PdfText(crtXPos, crtYPos,
                    "The text below is limited by a given width and has a free height:", pdfFontBoldEmbed);
            titleTextWithWidth.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextWithWidth);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            PdfText textWithWidthLimit = new PdfText(crtXPos + 50, crtYPos, 300, dummyText, pdfFont);
            textWithWidthLimit.BackColor = System.Drawing.Color.WhiteSmoke;
            textLayoutInfo = page1.Layout(textWithWidthLimit);

            // draw a rectangle around the text
            borderPdfRectangle = new PdfRectangle(textLayoutInfo.LastPageRectangle);
            borderPdfRectangle.LineStyle.LineWidth = 0.5f;
            page1.Layout(borderPdfRectangle);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout a text with width and height limits

            PdfText titleTextWithWidthAndHeight = new PdfText(crtXPos, crtYPos,
                    "The text below is limited by a given width and height and is trimmed:", pdfFontBoldEmbed);
            titleTextWithWidthAndHeight.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextWithWidthAndHeight);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            PdfText textWithWidthAndHeightLimit = new PdfText(crtXPos + 50, crtYPos, 300, 50, dummyText, pdfFont);
            textWithWidthAndHeightLimit.BackColor = System.Drawing.Color.WhiteSmoke;
            textLayoutInfo = page1.Layout(textWithWidthAndHeightLimit);

            // draw a rectangle around the text
            borderPdfRectangle = new PdfRectangle(textLayoutInfo.LastPageRectangle);
            borderPdfRectangle.LineStyle.LineWidth = 0.5f;
            page1.Layout(borderPdfRectangle);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout a text with standard font

            PdfText textWithStandardFont = new PdfText(crtXPos, crtYPos, "This green text is written with a Helvetica Standard Type 1 font", helveticaStdFont);
            textWithStandardFont.BackColor = System.Drawing.Color.WhiteSmoke;
            textWithStandardFont.ForeColor = System.Drawing.Color.Green;
            textLayoutInfo = page1.Layout(textWithStandardFont);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            #region Layout a rotated text

            PdfText titleRotatedText = new PdfText(crtXPos, crtYPos, "The text below is rotated:", pdfFontBoldEmbed);
            titleRotatedText.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleRotatedText);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            // create a reference Graphics used for measuring
            System.Drawing.Bitmap refBmp = new System.Drawing.Bitmap(1, 1);
            System.Drawing.Graphics refGraphics = System.Drawing.Graphics.FromImage(refBmp);
            refGraphics.PageUnit = System.Drawing.GraphicsUnit.Point;

            string counterRotatedText = "This text is rotated 45 degrees counter clockwise";

            // measure the rotated text size
            System.Drawing.SizeF counterRotatedTextSize = refGraphics.MeasureString(counterRotatedText, sysFont);

            // advance the Y position in the PDF page
            crtYPos += counterRotatedTextSize.Width / (float)Math.Sqrt(2) + 10;

            string clockwiseRotatedText = "This text is rotated 45 degrees clockwise";

            PdfText rotatedCounterClockwiseText = new PdfText(crtXPos + 100, crtYPos, counterRotatedText, pdfFontEmbed);
            rotatedCounterClockwiseText.RotationAngle = 45;
            textLayoutInfo = page1.Layout(rotatedCounterClockwiseText);

            PdfText rotatedClockwiseText = new PdfText(crtXPos + 100, crtYPos, clockwiseRotatedText, pdfFontEmbed);
            rotatedClockwiseText.RotationAngle = -45;
            textLayoutInfo = page1.Layout(rotatedClockwiseText);

            // measure the rotated text size
            System.Drawing.SizeF clockwiseRotatedTextSize = refGraphics.MeasureString(clockwiseRotatedText, sysFont);

            // advance the Y position in the PDF page
            crtYPos += clockwiseRotatedTextSize.Width / (float)Math.Sqrt(2) + 10;

            // dispose the graphics used for measuring
            refGraphics.Dispose();
            refBmp.Dispose();

            #endregion

            #region Layout an automatically paginated text

            string dummyBigText = System.IO.File.ReadAllText(Server.MapPath("~") + @"\DemoFiles\Text\DummyBigText.txt");

            PdfText titleTextPaginated = new PdfText(crtXPos, crtYPos,
                    "The text below is automatically paginated when it gets to the bottom of this page:", pdfFontBoldEmbed);
            titleTextPaginated.ForeColor = System.Drawing.Color.Navy;
            textLayoutInfo = page1.Layout(titleTextPaginated);

            // advance the Y position in the PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            PdfText paginatedText = new PdfText(crtXPos + 50, crtYPos, 300, dummyBigText, pdfFont);
            paginatedText.BackColor = System.Drawing.Color.WhiteSmoke;
            paginatedText.Cropping = false;
            textLayoutInfo = page1.Layout(paginatedText);

            // get the last page where the text was rendered
            PdfPage crtPage = document.Pages[textLayoutInfo.LastPageIndex];

            // draw a line at the bottom of the text on the second page
            System.Drawing.PointF leftPoint = new System.Drawing.PointF(textLayoutInfo.LastPageRectangle.Left, textLayoutInfo.LastPageRectangle.Bottom);
            System.Drawing.PointF rightPoint = new System.Drawing.PointF(textLayoutInfo.LastPageRectangle.Right, textLayoutInfo.LastPageRectangle.Bottom);
            PdfLine borderLine = new PdfLine(leftPoint, rightPoint);
            borderLine.LineStyle.LineWidth = 0.5f;
            crtPage.Layout(borderLine);

            // advance the Y position in the second PDF page
            crtYPos += textLayoutInfo.LastPageRectangle.Height + 10;

            #endregion

            try
            {
                // write the PDF document to a memory buffer
                byte[] pdfBuffer = document.WriteToMemory();

                // inform the browser about the binary data format
                HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");

                // let the browser know how to open the PDF document and the file name
                HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=PdfText.pdf; size={0}",
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
                Master.SelectNode("pdfText");
            }
        }
    }
}