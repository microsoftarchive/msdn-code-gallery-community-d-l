using System;
using System.Collections.Generic;
using System.Text;

namespace PDFToImageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageConvertor.ConvertPDFToImage();
            ImageConvertor.ConvertPDFToMultipageTiff();
        }
    }
}
