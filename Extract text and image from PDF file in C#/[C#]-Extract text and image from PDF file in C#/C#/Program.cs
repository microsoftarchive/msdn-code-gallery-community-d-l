using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Spire.Pdf;

namespace ExtractImageText
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"../../New Zealand.pdf");

            StringBuilder buffer = new StringBuilder();
            IList<Image> images = new List<Image>();

            foreach (PdfPageBase page in doc.Pages)
            {
                buffer.Append(page.ExtractText());
                foreach (Image image in page.ExtractImages())
                {
                    images.Add(image);
                }
            }

            doc.Close();

            //save text
            String fileName = @"../../TextInPdf.txt";
            File.WriteAllText(fileName, buffer.ToString());

            //save image
            int index = 0;
            foreach (Image image in images)
            {
                String imageFileName
                    = String.Format(@"../../Image-{0}.png", index++);
                image.Save(imageFileName, ImageFormat.Png);
            }

        }
    }
}
