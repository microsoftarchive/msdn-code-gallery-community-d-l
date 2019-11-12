using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
namespace ConvertPdfToWord
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile("..\\..\\Sample.pdf");
            string output = "..\\..\\output.doc";
            pdf.SaveToFile(output, FileFormat.DOC);
            System.Diagnostics.Process.Start(output);
        }
    }
}
