using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Drawing;
using XsPDF.Pdf;

namespace XsPDF.Demo
{
    class CreatePDFDemo
    {
        public static void CreateNewPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with XsPDF SDK";
            document.Info.Author = "sample";

            // Create an empty page in this document.
            PdfPage page1 = document.AddPage();

            // Obtain an XGraphics object to render to
            XGraphics g1 = XGraphics.FromPdfPage(page1);

            // Get the centre of the page
            double y = page1.Height / 2;

            //Draw one line in the center of page
            g1.DrawLine(XPens.Red, 0, y, page1.Width, y);

            // Create a font
            double fontHeight = 36;
            XFont font = new XFont("Times New Roman", fontHeight, XFontStyle.BoldItalic);

            // Create a rectangle to draw the text in and draw in it
            XRect rect = new XRect(0, y, page1.Width, fontHeight);
            g1.DrawString("This is the first page! ", font,
                           XBrushes.Black, rect, XStringFormats.Center);

            // Create a second page in this document.
            PdfPage page2 = document.AddPage();

            // Get an XGraphics object for drawing
            //You can customize each page content with graphics from each PDF page 
            XGraphics g2 = XGraphics.FromPdfPage(page2);

            //Draw one line in the center of page
            g2.DrawLine(XPens.Red, 0, y, page1.Width, y);

            // Add different text in another page
            g2.DrawString("This is the second page! ", font,
                           XBrushes.Black, rect, XStringFormats.Center);

            // Save and show the document
            document.Save("Sample-Document.pdf");
            Process.Start("Sample-Document.pdf");
        }

        public static void CreatePDFFromImage()
        {
            // Import a list of images from local file, support jpeg, png, tif, bmp and gif
            List<Image> images = new List<Image>();
            images.Add(Image.FromFile("Test.bmp"));
            images.Add(Image.FromFile("Test.png"));
            images.Add(Image.FromFile("Test.gif"));
            images.Add(Image.FromFile("Test.jpg"));
            images.Add(Image.FromFile("Test.tiff"));

            // Bacth convert images to pdf document, all the images will be drawn in input order.
            // Multiple pages tiff is also supported to convert to a pdf file.
            // Mix image formats (combine single page image and multi-page tiff) to PDF is supported.
            PdfDocument document = PdfDocument.ConvertToPdf(images);

            // Save and show the document
            document.Save("FromImage.pdf");
            Process.Start("FromImage.pdf");
        }
    }
}
