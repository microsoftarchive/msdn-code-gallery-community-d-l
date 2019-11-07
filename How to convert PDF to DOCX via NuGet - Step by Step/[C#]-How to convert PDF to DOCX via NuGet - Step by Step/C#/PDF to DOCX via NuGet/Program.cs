using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_to_DOCX_via_NuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfFile = @"d:\Tempos\sample.pdf";
            string wordFile = @"d:\Tempos\sample.docx";

            // Convert PDF file to DOCX file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
           
            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // You may choose output format between Docx and Rtf.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;

                int result = f.ToWord(wordFile);

                // Show the resulting Word document.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(wordFile);
                }
            }

        }
    }
}
