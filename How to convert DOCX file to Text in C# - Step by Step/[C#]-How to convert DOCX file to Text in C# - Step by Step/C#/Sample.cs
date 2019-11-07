using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            SaveAsText();
        }
        /// <summary>
        /// Load an existing .docx file and save it as Text.
        /// </summary>
        public static void SaveAsText()
        {
            // Working directory
            string workingDir = Path.GetFullPath(@"d:\Tempos\");
            string docxFile = Path.Combine(workingDir, "romeo.docx");
            string textFile = Path.ChangeExtension(docxFile, ".txt");

            //DocumentCore.Serial = "put your serial here";
            DocumentCore docx = DocumentCore.Load(docxFile);

            docx.Save(textFile, SaveOptions.TxtDefault);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(textFile);
        }
 
    }
}
