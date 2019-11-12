using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HiQPdf;

namespace HiQPdf_Demo
{
    public partial class PdfOutlinesAndLinks : System.Web.UI.Page
    {
        protected void buttonCreatePdf_Click(object sender, EventArgs e)
        {
            // create a PDF document
            PdfDocument document = new PdfDocument();

            // set a demo serial number
            document.SerialNumber = "YCgJMTAE-BiwJAhIB-EhlWTlBA-UEBRQFBA-U1FOUVJO-WVlZWQ==";

            // display the outlines when the document is opened
            document.Viewer.PageMode = PdfPageMode.Outlines;

            // create the true type fonts that can be used in document
            System.Drawing.Font sysFont = new System.Drawing.Font("Times New Roman", 10, System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFont = document.CreateFont(sysFont);
            PdfFont pdfFontEmbed = document.CreateFont(sysFont, true);

            System.Drawing.Font sysFontBold = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold, 
                                System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFontBold = document.CreateFont(sysFontBold);
            PdfFont pdfFontBoldEmbed = document.CreateFont(sysFontBold, true);

            System.Drawing.Font sysFontBig = new System.Drawing.Font("Times New Roman", 16, System.Drawing.FontStyle.Bold, 
                                System.Drawing.GraphicsUnit.Point);
            PdfFont pdfFontBig = document.CreateFont(sysFontBig);
            PdfFont pdfFontBigEmbed = document.CreateFont(sysFontBig, true);

            // create a reference Graphics used for measuring
            System.Drawing.Bitmap refBmp = new System.Drawing.Bitmap(1, 1);
            System.Drawing.Graphics refGraphics = System.Drawing.Graphics.FromImage(refBmp);
            refGraphics.PageUnit = System.Drawing.GraphicsUnit.Point;

            // create page 1
            PdfPage page1 = document.AddPage();

            float crtXPos = 10;
            float crtYPos = 20;

            #region Create Table of contents

            // create table of contents title
            PdfText tableOfContentsTitle = new PdfText(crtXPos, crtYPos, "Table of Contents", pdfFontBigEmbed);
            page1.Layout(tableOfContentsTitle);

            // create a top outline for the table of contents
            PdfDestination tableOfContentsDest = new PdfDestination(page1, new System.Drawing.PointF(crtXPos, crtYPos));
            document.CreateTopOutline("Table of Contents", tableOfContentsDest);

            // advance current Y position in page
            crtYPos += pdfFontBigEmbed.Size + 10;

            // create Chapter 1 in table of contents
            PdfText chapter1TocTitle = new PdfText(crtXPos + 30, crtYPos, "Chapter 1", pdfFontBoldEmbed);
            // layout the chapter 1 title in TOC
            page1.Layout(chapter1TocTitle);

            // get the bounding rectangle of the chapter 1 title in TOC
            System.Drawing.SizeF textSize = refGraphics.MeasureString("Chapter 1", sysFontBold);
            System.Drawing.RectangleF chapter1TocTitleRectangle = new System.Drawing.RectangleF(crtXPos + 30, crtYPos, textSize.Width, textSize.Height);

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create Subchapter 1 in table of contents
            PdfText subChapter11TocTitle = new PdfText(crtXPos + 60, crtYPos, "Subchapter 1", pdfFontEmbed);
            // layout the text
            page1.Layout(subChapter11TocTitle);

            // get the bounding rectangle of the subchapter 1 title in TOC
            textSize = refGraphics.MeasureString("Subchapter 1", sysFont);
            System.Drawing.RectangleF subChapter11TocTitleRectangle = new System.Drawing.RectangleF(crtXPos + 60, crtYPos, textSize.Width, textSize.Height);

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create Subchapter 2 in table of contents
            PdfText subChapter21TocTitle = new PdfText(crtXPos + 60, crtYPos, "Subchapter 2", pdfFontEmbed);
            // layout the text
            page1.Layout(subChapter21TocTitle);

            // get the bounding rectangle of the subchapter 2 title in TOC
            textSize = refGraphics.MeasureString("Subchapter 2", sysFont);
            System.Drawing.RectangleF subChapter21TocTitleRectangle = new System.Drawing.RectangleF(crtXPos + 60, crtYPos, textSize.Width, textSize.Height);

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create Chapter 2 in table of contents
            PdfText chapter2TocTitle = new PdfText(crtXPos + 30, crtYPos, "Chapter 2", pdfFontBoldEmbed);
            // layout the text
            page1.Layout(chapter2TocTitle);

            // get the bounding rectangle of the chapter 2 title in TOC
            textSize = refGraphics.MeasureString("Capter 2", sysFontBold);
            System.Drawing.RectangleF chapter2TocTitleRectangle = new System.Drawing.RectangleF(crtXPos + 30, crtYPos, textSize.Width, textSize.Height);

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create Subchapter 1 in table of contents
            PdfText subChapter12TocTitle = new PdfText(crtXPos + 60, crtYPos, "Subchapter 1", pdfFontEmbed);
            // layout the text
            page1.Layout(subChapter12TocTitle);

            // get the bounding rectangle of the subchapter 1 title in TOC
            textSize = refGraphics.MeasureString("Subchapter 1", sysFont);
            System.Drawing.RectangleF subChapter12TocTitleRectangle = new System.Drawing.RectangleF(crtXPos + 60, crtYPos, textSize.Width, textSize.Height);

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create Subchapter 2 in table of contents
            PdfText subChapter22TocTitle = new PdfText(crtXPos + 60, crtYPos, "Subchapter 2", pdfFontEmbed);
            // layout the text
            page1.Layout(subChapter22TocTitle);

            // get the bounding rectangle of the subchapter 2 title in TOC
            textSize = refGraphics.MeasureString("Subchapter 2", sysFont);
            System.Drawing.RectangleF subChapter22TocTitleRectangle = new System.Drawing.RectangleF(crtXPos + 60, crtYPos, textSize.Width, textSize.Height);

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create the website link in the table of contents
            PdfText visitWebSiteText = new PdfText(crtXPos + 30, crtYPos, "Visit HiQPdf Website", pdfFontEmbed);
            visitWebSiteText.ForeColor = System.Drawing.Color.Navy;
            // layout the text
            page1.Layout(visitWebSiteText);

            // get the bounding rectangle of the website link in TOC
            textSize = refGraphics.MeasureString("Visit HiQPdf Website", sysFont);
            System.Drawing.RectangleF visitWebsiteRectangle = new System.Drawing.RectangleF(crtXPos + 30, crtYPos, textSize.Width, textSize.Height);

            // create the link to website in table of contents
            document.CreateUriLink(page1, visitWebsiteRectangle, "http://www.hiqpdf.com");

            // advance current Y position in page
            crtYPos += pdfFontEmbed.Size + 10;

            // create a text note at the end of TOC
            PdfTextNote textNote = document.CreateTextNote(page1, new System.Drawing.PointF(crtXPos + 10, crtYPos),
                            "The table of contents contains internal links to chapters and subchapters");
            textNote.IconType = PdfTextNoteIconType.Note;
            textNote.IsOpen = true;

            #endregion

            #region Create Chapter 1 content and the link from TOC

            // create page 2
            PdfPage page2 = document.AddPage();

            // create the Chapter 1 title
            PdfText chapter1Title = new PdfText(crtXPos, 10, "Chapter 1", pdfFontBoldEmbed);
            // layout the text
            page2.Layout(chapter1Title);

            // create the Chapter 1 root outline
            PdfDestination chapter1Destination = new PdfDestination(page2, new System.Drawing.PointF(crtXPos, 10));
            PdfOutline chapter1Outline = document.CreateTopOutline("Chapter 1", chapter1Destination);
            chapter1Outline.TitleColor = System.Drawing.Color.Navy;

            // create the PDF link from TOC to chapter 1
            document.CreatePdfLink(page1, chapter1TocTitleRectangle, chapter1Destination);

            #endregion

            #region Create Subchapter 1 content and the link from TOC

            // create the Subchapter 1 
            PdfText subChapter11Title = new PdfText(crtXPos, 300, "Subchapter 1 of Chapter 1", pdfFontEmbed);
            // layout the text
            page2.Layout(subChapter11Title);

            // create subchapter 1 child outline
            PdfDestination subChapter11Destination = new PdfDestination(page2, new System.Drawing.PointF(crtXPos, 300));
            PdfOutline subchapter11Outline = document.CreateChildOutline("Subchapter 1", subChapter11Destination, chapter1Outline);

            // create the PDF link from TOC to subchapter 1
            document.CreatePdfLink(page1, subChapter11TocTitleRectangle, subChapter11Destination);

            #endregion

            #region Create Subchapter 2 content and the link from TOC

            // create the Subchapter 2 
            PdfText subChapter21Title = new PdfText(crtXPos, 600, "Subchapter 2 of Chapter 1", pdfFontEmbed);
            // layout the text
            page2.Layout(subChapter21Title);

            // create subchapter 2 child outline
            PdfDestination subChapter21Destination = new PdfDestination(page2, new System.Drawing.PointF(crtXPos, 600));
            PdfOutline subchapter21Outline = document.CreateChildOutline("Subchapter 2", subChapter21Destination, chapter1Outline);

            // create the PDF link from TOC to subchapter 2
            document.CreatePdfLink(page1, subChapter21TocTitleRectangle, subChapter21Destination);

            #endregion

            #region Create Chapter 2 content and the link from TOC

            // create page 3
            PdfPage page3 = document.AddPage();

            // create the Chapter 2 title
            PdfText chapter2Title = new PdfText(crtXPos, 10, "Chapter 2", pdfFontBoldEmbed);
            // layout the text
            page3.Layout(chapter2Title);

            // create chapter 2 to outline
            PdfDestination chapter2Destination = new PdfDestination(page3, new System.Drawing.PointF(crtXPos, 10));
            PdfOutline chapter2Outline = document.CreateTopOutline("Chapter 2", chapter2Destination);
            chapter2Outline.TitleColor = System.Drawing.Color.Green;

            // create the PDF link from TOC to chapter 2
            document.CreatePdfLink(page1, chapter2TocTitleRectangle, chapter2Destination);

            #endregion

            #region Create Subchapter 1 content and the link from TOC

            // create the Subchapter 1 
            PdfText subChapter12Title = new PdfText(crtXPos, 300, "Subchapter 1 of Chapter 2", pdfFontEmbed);
            // layout the text
            page3.Layout(subChapter12Title);

            // create subchapter 1 child outline
            PdfDestination subChapter12Destination = new PdfDestination(page3, new System.Drawing.PointF(crtXPos, 300));
            PdfOutline subchapter12Outline = document.CreateChildOutline("Subchapter 1", subChapter12Destination, chapter2Outline);

            // create the PDF link from TOC to subchapter 1
            document.CreatePdfLink(page1, subChapter12TocTitleRectangle, subChapter12Destination);

            #endregion

            #region Create Subchapter 2 content and the link from TOC

            // create the Subchapter 2 
            PdfText subChapter22Title = new PdfText(crtXPos, 600, "Subchapter 2 of Chapter 2", pdfFontEmbed);
            // layout the text
            page3.Layout(subChapter22Title);

            // create subchapter 2 child outline
            PdfDestination subChapter22Destination = new PdfDestination(page3, new System.Drawing.PointF(crtXPos, 600));
            PdfOutline subchapter22Outline = document.CreateChildOutline("Subchapter 2", subChapter22Destination, chapter2Outline);

            // create the PDF link from TOC to subchapter 2
            document.CreatePdfLink(page1, subChapter22TocTitleRectangle, subChapter22Destination);

            #endregion

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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.SelectNode("pdfOutlines");
            }
        }
    }
}