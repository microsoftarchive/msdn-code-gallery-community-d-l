using System;

namespace OCRTest
{
    using System.Drawing;

    using tessnet2;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var image = new Bitmap(@"C:\OCRTest\number.jpg");
                var ocr = new Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only
                //@"C:\OCRTest\tessdata" contains the language package, without this the method crash and app breaks
                ocr.Init(@"C:\OCRTest\tessdata", "eng", true); 
                var result = ocr.DoOCR(image, Rectangle.Empty);
                foreach (Word word in result)
                    Console.WriteLine("{0} : {1}", word.Confidence, word.Text);

                Console.ReadLine();
            }
            catch (Exception exception)
            {

            }
        }
    }
}
