using System;
using System.IO;
using System.Text;
using SautinSoft.Document;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to Docx file.
            FileInfo pathToDocx = new FileInfo(@"..\..\example.docx");

            // Let's parse docx docuemnt and get all text from it.
            DocumentCore docx = DocumentCore.Load(pathToDocx.FullName);

            StringBuilder text = new StringBuilder();

            foreach (Paragraph par in docx.GetChildElements(true, ElementType.Paragraph))
            {
                foreach (Run run in par.GetChildElements(true, ElementType.Run))
                {
                    text.Append(run.Text);
                }
                text.AppendLine();
            }

            // Show extracted text.
            Console.WriteLine(text);
            Console.ReadLine();

        }
    }
}
