using System;
using System.Collections.Generic;
using System.Text;
using PQScan.PDFToImage;
using System.Drawing;
using System.Drawing.Imaging;

namespace PDFToImageDemo
{
    class ImageConvertor
    {
        public static void ConvertPDFToImage()
        {
            PDFDocument doc = new PDFDocument();

            doc.LoadPDF("d:/sample.pdf");

            int pageCount = doc.PageCount;

            for (int i = 0; i < pageCount; i++)
            {
                Bitmap bmp = doc.ToImage(i);
                bmp.Save("d:/sample.png", ImageFormat.Png);
                bmp.Save("d:/sample.jpeg", ImageFormat.Jpeg);
                bmp.Save("d:/sample.gif", ImageFormat.Gif);
                bmp.Save("d:/sample.bmp", ImageFormat.Bmp);
                bmp.Save("d:/sample.tiff", ImageFormat.Tiff);
            }
        }


        public static void ConvertPDFToMultipageTiff()
        {
            PDFDocument doc = new PDFDocument();

            doc.LoadPDF("d:/sample.pdf");

            doc.ToMultiPageTiff("d:/multiTiff.tiff");
        }

        public static void ChangeImageSize()
        {
            PDFDocument doc = new PDFDocument();

            doc.LoadPDF("d:/sample.pdf");

            doc.DPI = 96;

            Bitmap bmp = doc.ToImage(0, 500, 500);

            bmp.Save("d:/sample-size.png", ImageFormat.Png);
        }

    }
}
