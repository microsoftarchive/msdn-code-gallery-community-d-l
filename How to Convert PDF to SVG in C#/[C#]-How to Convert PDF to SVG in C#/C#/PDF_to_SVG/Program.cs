using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;

namespace PDF_to_SVG
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"E:\Visual Studio\Sample\baby.pdf");

            document.SaveToFile("Result.svg", FileFormat.SVG);

        }
    }
}
