using iDiTect.Licensing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDiTect.Demo
{
    public static class WatermarkHelper
    {
        public static void TextWatermark()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Load PDF document
            PdfWatermarker document = new PdfWatermarker("sample.pdf");
            //rotation by default is showing from left-bottom to top-right
            document.TextRotation = -45;
            //Customize text location
            document.Location = new Point(50, 100);
            //Customize the watermark color, transparent is support
            document.TextColor = Color.FromArgb(128, 255, 0, 0);
            //Customize the font style
            document.TextFont = new Font("Times New Roman", 30f, FontStyle.Regular);
            //Watermark the PDF page with text
            document.AddTextWatermark(0, "watermark");

            document.Save("text-watermark.pdf");
        }

        public static void ImageWatermark()
        {
            //Please repace the trial key from trial-license.txt in download package 
            //This license registration line need to be at very beginning of our other code
            LicenseManager.SetKey("trial key");

            //Set watermark image filename
            string watermarkFile = "watermark.png";
            //Load PDF document
            PdfWatermarker document = new PdfWatermarker("sample.pdf");
            //Customize image location, default is showing at (0, 0)
            document.Location = new Point(100, 100);
            //Customize image size
            //document.ImageSize = new Size(50, 50);
            //Watermark the PDF page with image
            document.AddImageWatermark(0, watermarkFile);

            document.Save("image-watermark.pdf");
        }


    }
}
