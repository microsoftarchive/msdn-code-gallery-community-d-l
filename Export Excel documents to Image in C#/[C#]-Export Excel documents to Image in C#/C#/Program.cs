using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;

namespace ToImage
{
    class Program
    {
        static void Main(string[] args)
        {
            //create Workbook instance and load file
            Workbook workbook = new Workbook();

            workbook.LoadFromFile(@"..\..\Sample.xls");

            //save to image
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToImage(@"..\..\sample.bmp");

            System.Diagnostics.Process.Start(@"..\..\sample.bmp");
        }
    }
}
