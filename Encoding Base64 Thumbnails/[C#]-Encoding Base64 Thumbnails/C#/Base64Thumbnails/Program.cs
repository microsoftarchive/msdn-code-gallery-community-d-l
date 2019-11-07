using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;

namespace Base64Thumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Images";

            List<string> thumbnailTags = path.ToBase64Thumbnails(100, 100, true, null);
                
            StreamReader streamreader = new StreamReader("HtmlTemplate.htm");
            StringBuilder htmlPage = new StringBuilder(streamreader.ReadToEnd());
            streamreader.Close();

            StringBuilder imageTags = new StringBuilder();

            for (int k = 0; k < thumbnailTags.Count; k++)
            {
                imageTags.AppendLine("<p>");
                imageTags.AppendLine(thumbnailTags[k]);
                imageTags.AppendLine("</p>");
            }

            htmlPage.Replace("<!--Tags_Placeholder-->", imageTags.ToString());

            StreamWriter streamwriter = new StreamWriter("TempPage.htm", false, Encoding.UTF8);
            streamwriter.Write(htmlPage.ToString());
            streamwriter.Close();

            Process.Start("TempPage.htm");

            Console.ReadKey();
        }
    }
}
