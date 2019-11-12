using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            ConvertPdfToDocx();            
        }
        public static void ConvertPdfToDocx()
        {
            // Working directory
            string workingDir = Path.GetFullPath(@"Tempos");            
            string pdfFile = Path.Combine(workingDir, "example.pdf");
            string docxFile = Path.Combine(workingDir, "Example-result.docx");

            //DocumentCore.Serial = "put your serial here";

            PdfLoadOptions pdfOptions = new PdfLoadOptions();
            pdfOptions.ConversionMode = PdfConversionMode.Flowing;
            pdfOptions.DetectTables = true;
            pdfOptions.RasterizeVectorGraphics = true;
            pdfOptions.FromPage = 1;            

            DocumentCore pdf = DocumentCore.Load(pdfFile, pdfOptions);            
            
            pdf.Save(docxFile);

            // Open resulting DOCX.            
            System.Diagnostics.Process.Start(docxFile);
        }
    }
}
