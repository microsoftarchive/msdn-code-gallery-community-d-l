using iDiTect.Licensing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDiTect.Demo
{
    public static class ImageHelper
    {
        public static void ConvertPDF2Image()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");
            
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfConverter document = new PdfConverter("sample.pdf");
            //Default is 72, the higher DPI, the bigger size out image will be
            document.DPI = 96;
            //The value need to be 1-100. If set to 100, the converted image will take the
            //original quality with less time and memory. If set to 1, the converted image 
            //will be compressed to minimum size with more time and memory.
            document.CompressedRatio = 80;

            for (int i = 0; i < document.PageCount; i++)
            {
                //The converted image will keep the original size of PDF page
                Image pageImage = document.PageToImage(i);
                //To specific the converted image size by width and height
                //Image pageImage = document.PageToImage(i, 100, 150);
                //You can save this Image object to jpeg, tiff and png format to local file.
                //Or you can make it in memory to other use.
                pageImage.Save(i.ToString() + ".jpg", ImageFormat.Jpeg);
            }
        }

        public static void ConvertPDF2MultipageTiff()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfConverter document = new PdfConverter("sample.pdf");
            //Default is 72, the higher DPI, the bigger size out image will be
            document.DPI = 96;
            //Save pdf to multiple pages tiff to local file
            document.DocumentToMultiPageTiff("sample.tif");
            //Or save the multiple pages tiff in memory to other use
            //Image multipageTif = document.DocumentToMultiPageTiff();
        }

        public static void ConvertPdfToImgParallel(String[] Inputfiles)
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            Parallel.ForEach(Inputfiles, (currentFile) =>
            {
                PdfConverter document = new PdfConverter(currentFile);
                //Default is 72, the higher DPI, the bigger size out image will be
                document.DPI = 96;

                for (int i = 0; i < document.PageCount; i++)
                {
                    //The converted image will keep the original size of PDF page
                    Image pageImage = document.PageToImage(i);
                    //To specific the converted image size by width and height
                    //Image pageImage = document.PageToImage(i, 100, 150);                  

                    Console.WriteLine(currentFile.ToString());

                    // Save converted image to png format
                    pageImage.Save(currentFile.Replace("INPUT", "OUTPUT") + i + ".png", ImageFormat.Png);
                }
            });
        }
    }
}
