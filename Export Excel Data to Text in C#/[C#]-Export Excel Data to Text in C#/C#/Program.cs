using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;

namespace ConvertExceltoText
{
    class Program
    {
        static void Main(string[] args)
        {

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"..\..\Product Report.xls");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToFile("ExceltoTxt.txt"," ", Encoding.UTF8);
        }
    }
}
