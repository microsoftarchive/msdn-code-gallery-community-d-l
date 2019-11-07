using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Pdf;
using XsPDF.Pdf.IO;

namespace XsPDF.Demo
{
    class ProcessDemo
    {
        public static void CombinePDFs()
        {
            // Load several PDF files in
            using (PdfDocument oneDoc = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Import))
            using (PdfDocument twoDoc = PdfReader.Open("file2.pdf", PdfDocumentOpenMode.Import))
            using (PdfDocument outPdf = new PdfDocument())
            {
                // Copy all pages from each PDF document
                CopyPages(oneDoc, outPdf);
                CopyPages(twoDoc, outPdf);

                // Save and show the document
                outPdf.Save("Output.pdf");
                Process.Start("Output.pdf");
            }
        }

        public static void CopyPages(PdfDocument fromPDF, PdfDocument toPDF)
        {
            for (int i = 0; i < fromPDF.PageCount; i++)
            {
                // Append and merge each PDF page to the new PDF document
                toPDF.AddPage(fromPDF.Pages[i]);

                // You can aslo get current PDF page instance,
                // then make some editing on this page, such as add some text or annotation
                // The following is a short demo for adding a line in the page bottom:

                //PdfPage page = toPDF.AddPage(fromPDF.Pages[i]);
                //XGraphics g = XGraphics.FromPdfPage(page);
                //g.DrawLine(XPens.Red, 0, page.Height - 10, page.Width, page.Height - 10);
            }
        }

        public static void SplitPDF()
        {
            // Open the original pdf file
            PdfDocument inputDocument = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Import);

            string saveName = "Split Doc";
            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                // Create new document
                PdfDocument splitDocument = new PdfDocument();

                // Add the same meta from input file to split file
                splitDocument.Version = inputDocument.Version;
                splitDocument.Info.Title = "Page " + (i + 1);
                splitDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                splitDocument.AddPage(inputDocument.Pages[i]);
                splitDocument.Save(String.Format("{0} - Page {1}.pdf", saveName, i + 1));
            }

        }

        public static void InsertPDFPage()
        {
            // Open the original pdf file
            PdfDocument document = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Modify);

            // Insert a blank page to an existed pdf file
            PdfPage blankPage = document.InsertPage(0);

            // Import another pdf document
            PdfDocument importDocument = PdfReader.Open("file2.pdf", PdfDocumentOpenMode.Import);

            // Get a pdf page from a pdf file
            PdfPage importPage = importDocument.Pages[0];

            // Insert a created pdf page to an existed pdf file
            document.InsertPage(1, importPage);

            // Save and show the document           
            document.Save("Insert.pdf");
            Process.Start("Insert.pdf");
        }

        public static void DeletePDFPage()
        {
            // Open the original pdf file
            PdfDocument document = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Modify);

            for (int i = document.PageCount - 1; i >= 0; i--)
            {
                // Delete all the even pages from pdf
                if (i % 2 == 0)
                {
                    document.Pages.RemoveAt(i);
                }
            }

            // Save and show the document           
            document.Save("Removed.pdf");
            Process.Start("Removed.pdf");
        }

        public static void RotatePDFPage()
        {
            // Open the original pdf file
            PdfDocument inputDocument = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Import);

            // Create new document
            PdfDocument rotateDocument = new PdfDocument();


            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                // Rotate each pdf page orientation to 90 degree
                PdfPage page = inputDocument.Pages[i];
                page.Rotate = 90;
                rotateDocument.AddPage(page);
            }

            // Save and show the document           
            rotateDocument.Save("Rotate.pdf");
            Process.Start("Rotate.pdf");
        }

        public static void CompressPDF()
        {
            // Open the original pdf file
            PdfDocument document = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Modify);

            // Compress content streams of PDF pages.
            document.Options.CompressContentStreams = true;

            // You can set modes for best compression (slower) or best speed (larger files).
            document.Options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;

            // Compress JPEG images with the FlateDecode filter.
            document.Options.UseFlateDecoderForJpegImages = PdfUseFlateDecoderForJpegImages.Always;

            // Save and show the document           
            document.Save("Compress.pdf");
            Process.Start("Compress.pdf");
        }
    }
}
