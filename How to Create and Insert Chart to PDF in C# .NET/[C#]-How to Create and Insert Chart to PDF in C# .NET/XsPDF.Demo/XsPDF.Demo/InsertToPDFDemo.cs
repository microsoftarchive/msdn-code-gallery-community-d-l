using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Drawing;
using XsPDF.Drawing.Layout;
using XsPDF.Pdf;
using XsPDF.Pdf.Annotations;

namespace XsPDF.Demo
{
    class InsertToPDFDemo
    {
        public static void AddImageToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create an empty page in this document.
            PdfPage page = document.AddPage();

            // Obtain an XGraphics object to render to
            XGraphics g = XGraphics.FromPdfPage(page);

            // Load a local image file
            XImage importImg = XImage.FromFile("image.jpg");

            // Insert an image to pdf page, position and size can be modified
            g.DrawImage(importImg, 50, 50, 200, 200);

            // Save and show the document
            document.Save("AddImage.pdf");
            Process.Start("AddImage.pdf");
        }

        public static void AddShortTextToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create an empty page in this document.
            PdfPage page = document.AddPage();

            // Obtain an XGraphics object to render to
            XGraphics g = XGraphics.FromPdfPage(page);

            // Set the font style
            XFont font = new XFont("Times New Roman", 36, XFontStyle.BoldItalic);

            // Set a short text, no wider than the page width
            string text = "XsPDF title!";

            // Create a rectangle to draw the text in and draw in it
            XRect rect = new XRect(0, 50, page.Width, 36);
            g.DrawString(text, font,
                           XBrushes.Black, rect, XStringFormats.Center);

            // Save and show the document
            document.Save("ShortText.pdf");
            Process.Start("ShortText.pdf");
        }

        public static void CreateLongParagraphToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create an empty page in this document.
            PdfPage page = document.AddPage();

            // Obtain an XGraphics object to render to
            XGraphics g = XGraphics.FromPdfPage(page);

            // Set the font style
            XFont font = new XFont("Times New Roman", 16, XFontStyle.BoldItalic);

            // Set a long long text
            string text = "This is the 1st sentence! This is the 2nd sentence! " +
            "This is the 3rd sentence! This is the 4th sentence! This is the 5th sentence!";

            // Create a rectangle to render the long sentence in.
            // You only need to set the rectangle x, y and width, the height 
            // will be measured by XTextFormatter object automatically. 
            // So you can input any value of height, here we set to 0.
            XRect rect = new XRect(50, 50, page.Width - 50 * 2, 0);

            // Create a text formatter object
            XTextFormatter tf = new XTextFormatter(g);

            // Add the long sentence to the page. And this api will 
            // returen the actual height used by the formatter 
            double neededHeight = tf.DrawString(text, font, XBrushes.Black, rect);

            //Draw a rectangle to show the real space this long text used
            rect = new XRect(50, 50, page.Width - 50 * 2, neededHeight);
            g.DrawRectangle(XPens.Red, rect);

            // Save and show the document
            document.Save("LongText.pdf");
            Process.Start("LongText.pdf");
        }

        public static void CreatePDFBookmarks()
        {
            // Create a new PDF document.
            var document = new PdfDocument();

            // Create the first page.
            var page = document.AddPage();

            int pageIndex = 1;
            string text = "Page " + pageIndex++.ToString();

            // Create a font.
            var font = new XFont("Times New Roman", 16);

            // Get graphics of current page
            var g = XGraphics.FromPdfPage(page);
            g.DrawString(text, font, XBrushes.Black, 100, 100, XStringFormats.Center);

            // Create the root bookmark. You can set the style and the color.
            PdfOutline outline = document.Outlines.Add("Level 1", page, true, PdfOutlineStyle.Bold, XColors.Red);

            // Create some more pages and bookmarks
            for (int i = 1; i < 4; i++)
            {
                page = document.AddPage();
                g = XGraphics.FromPdfPage(page);

                text = "Page " + pageIndex++.ToString();
                g.DrawString(text, font, XBrushes.Black, 100, 100, XStringFormats.Center);

                string bookmarkTitle = "Level 2-" + i.ToString();
                // Create a sub bookmark.
                outline.Outlines.Add(bookmarkTitle, page, true);
            }

            // Save and show the document           
            document.Save("Bookmarks.pdf");
            Process.Start("Bookmarks.pdf");
        }

        public static void AddAnnotationToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get current page graphics
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a PDF text annotation.
            PdfTextAnnotation textAnnot = new PdfTextAnnotation();
            textAnnot.Title = "Title sample";
            textAnnot.Subject = "Subject sample";
            textAnnot.Contents = "This is the first line of annotation.\rThis is the 2nd line.";
            textAnnot.Icon = PdfTextAnnotationIcon.Comment;

            // Convert rectangle from world space to page space(visual to graphics drawing). This is necessary because 
            // the annotation is placed relative to the bottom left corner of the page with units measured in point.
            XRect rect = g.Transformer.WorldToDefaultPage(new XRect(new XPoint(100, 60), new XSize(50, 50)));
            textAnnot.Rectangle = new PdfRectangle(rect);

            // Add the annotation to the page
            page.Annotations.Add(textAnnot);


            // Create a PDF rubber stamp annotation.
            PdfRubberStampAnnotation rsAnnot = new PdfRubberStampAnnotation();
            rsAnnot.Icon = PdfRubberStampAnnotationIcon.Approved;

            rect = g.Transformer.WorldToDefaultPage(new XRect(new XPoint(100, 200), new XSize(300, 150)));
            rsAnnot.Rectangle = new PdfRectangle(rect);

            // Add the rubber stamp annotation to the page.
            page.Annotations.Add(rsAnnot);


            // Create a PDF link annotation            
            rect = g.Transformer.WorldToDefaultPage(new XRect(new XPoint(100, 400), new XSize(300, 150)));
            PdfLinkAnnotation linkAnnot = PdfLinkAnnotation.CreateWebLink(new PdfRectangle(rect), "http://www.xspdf.com");
            page.Annotations.Add(linkAnnot);


            // Save and show the document           
            document.Save("Annotations.pdf");
            Process.Start("Annotations.pdf");
        }
    }
}
