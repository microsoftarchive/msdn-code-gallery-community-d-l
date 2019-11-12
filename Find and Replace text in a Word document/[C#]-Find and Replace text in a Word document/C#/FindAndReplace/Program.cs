using System.IO;
using System.Diagnostics;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "Sample Input.docx";
            string outputFile = "Sample Output.docx";

            // Copy Word document.
            File.Copy(inputFile, outputFile, true);

            // Open copied document.
            using (var flatDocument = new FlatDocument(outputFile))
            {
                // Search and replace document's text content.
                flatDocument.FindAndReplace("[TITLE]", "Lorem Ipsum");
                flatDocument.FindAndReplace("[SUBTITLE]", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet...");
                flatDocument.FindAndReplace("[NAME]", "John Doe");
                flatDocument.FindAndReplace("[EMAIL]", "john.doe@email.com");
                flatDocument.FindAndReplace("[PHONE]", "(000)-111-222");
                // Save document on Dispose.
            }

            // Open document in Word application.
            Process.Start(outputFile);
        }
    }
}
