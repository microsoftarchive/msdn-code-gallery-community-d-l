using System;
using System.Collections.Generic;
using System.Text;
using PQScan.ImageToPDF;
using System.IO;

namespace ImageToPDFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            createPDFfromDisk();
            createPDFtoStream();
            appendImageToPDF();
        }

        private static void createPDFfromDisk()
        {
            PDFConverter converter = new PDFConverter();
            converter.PageSizeType = PageSizeMode.A4;
            string[] imgFiles = new string[3];
            imgFiles[0] = "input1.png";
            imgFiles[1] = "input2.bmp";
            imgFiles[2] = "input3.jpg";

            string outFile = "output.pdf";

            converter.CreatePDF(imgFiles, outFile);
        }

        private static void createPDFtoStream()
        {
            PDFConverter converter = new PDFConverter();
            converter.PageSizeType = PageSizeMode.ImageSize;
            string[] imgFiles = new string[3];
            imgFiles[0] = "input1.png";
            imgFiles[1] = "input2.bmp";
            imgFiles[2] = "input3.jpg";

            FileStream fileStream = new FileStream("output1.pdf", FileMode.Create);

            converter.CreatePDF(imgFiles, fileStream);
        }

        private static void appendImageToPDF()
        {
            PDFConverter converter = new PDFConverter();
            converter.PageSizeType = PageSizeMode.ImageSize;
            string[] imgFiles = new string[3];
            imgFiles[0] = "input1.png";
            imgFiles[1] = "input2.bmp";
            imgFiles[2] = "input3.jpg";

            string existFile = "output.pdf";

            converter.AppendToPDF(imgFiles, existFile);
        }
    }
}
