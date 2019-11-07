using iDiTect.Licensing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDiTect.Demo
{
    public static class TextHelper
    {
        public static void PDF2Text()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfExtractor document = new PdfExtractor("sample.pdf");
            //Set whole document text property
            StringBuilder total = new StringBuilder();

            for (int i = 0; i < document.PageCount; i++)
            {
                //Extract each page text from PDF with original layout
                string pageText = document.PageToText(i);
                //You can save the page text to local file, or left in memory to other use
                File.WriteAllText(i.ToString() + ".txt", pageText, Encoding.UTF8);
                //Add each page text together
                total.Append(pageText);
            }
        }

        public static void SearchText()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfExtractor document = new PdfExtractor("sample.pdf");
            //Whether to match upper and lower case
            document.MatchCase = false;
            //Whether to match whole word only
            document.MatchWholeWord = true;

            //Search text in whole document
            List<TextInfo> infos = document.SearchText("text for search");
            //Search text in first page
            //List<TextInfo> infos = document.SearchText("text for search", 0);

            foreach (TextInfo info in infos)
            {
                Console.WriteLine(info.Text + "-" + info.PageId + "-" + info.Rect.X + "-" + info.Rect.Y);
            }
        }

    }
}
