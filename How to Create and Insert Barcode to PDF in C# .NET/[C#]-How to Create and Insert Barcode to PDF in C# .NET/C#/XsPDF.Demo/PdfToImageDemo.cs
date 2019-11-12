using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Pdf;

namespace XsPDF.Demo
{
    class PdfToImageDemo
    {
        public static void ConvertPdfToImage()
        {
            // Create a PDF converter instance by loading a local file 
            PdfImageConverter pdfConverter = new PdfImageConverter("sample.pdf");

            // Set the dpi, the output image will be rendered in such resolution
            pdfConverter.DPI = 96;

            for (int i = 0; i < pdfConverter.PageCount; i++)
            {
                // Convert each pdf page to jpeg image with original page size
                //Image pageImage = pdfConverter.PageToImage(i);
                // Convert pdf to jpg in customized image size
                Image pageImage = pdfConverter.PageToImage(i, 500, 800);

                // Save converted image to jpeg format
                pageImage.Save("Page " + i + ".jpg", ImageFormat.Jpeg);
            }
        }

        public static void ConvertPdfToMultiPageTiff()
        {
            // Create a PDF converter instance by loading a local file 
            PdfImageConverter pdfConverter = new PdfImageConverter("sample.pdf");

            // Set the dpi, the output image will be rendered in such resolution
            pdfConverter.DPI = 96;

            // Convert whole pdf document to a multipage tiff image file
            // you can set the target image size for each page
            pdfConverter.DocumentToMultiPageTiff(500, 800, "Page_multiple.tiff");
        }
    }
}
