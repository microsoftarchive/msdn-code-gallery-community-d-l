using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Base64Bitmaps
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("NavForward.png");
            Bitmap bmp = new Bitmap(streamReader.BaseStream);
            streamReader.Close();

            string base64ImageAndTag = bmp.ToBase64ImageTag(ImageFormat.Png);

            Console.WriteLine(base64ImageAndTag);

            Console.ReadKey();
        }
    }
}
