using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Pdf;
using XsPDF.Pdf.IO;

namespace XsPDF.Demo
{
    class ExtractDemo
    {
        public static void ExtractTextFromPDF()
        {
            // Read a local PDF file in the disk
            PdfDocument document = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.ReadOnly);

            // Extract text from whole PDF document, contains every PDF pages 
            string allText = PdfTextExtractor.GetText(document);
            Console.WriteLine(allText);

            // Convert text from PDF to a txt file
            File.WriteAllText("Output.txt", allText);



            // Get total page count
            int total = document.Pages.Count;

            foreach (PdfPage page in document.Pages)
            {
                // Extract text from each page of PDF
                string text = PdfTextExtractor.GetText(page);
                Console.WriteLine(text);
            }

        }

        public static void ExtractImageFromPDF()
        {
            // Open the pdf file
            using (PdfDocument document = PdfReader.Open("file1.pdf", PdfDocumentOpenMode.Import))
            {
                int pageIndex = 0;

                // Get all the pdf pages
                foreach (PdfPage page in document.Pages)
                {
                    int imageIndex = 0;

                    // Find all the images in the pdf page
                    foreach (Image image in page.GetImages())
                    {
                        // Capture each image in the page, you can save it as jpg, png, tiff, bmp and gif.
                        // Here is saved as png format, transparent png is also supported.
                        image.Save(String.Format(@"{0}-{1}.png", pageIndex + 1, imageIndex + 1), ImageFormat.Png);
                        imageIndex++;
                    }
                    pageIndex++;
                }
            }
        }
    }
}
