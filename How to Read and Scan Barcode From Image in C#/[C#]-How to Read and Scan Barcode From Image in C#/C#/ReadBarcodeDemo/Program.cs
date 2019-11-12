using System;
using System.Collections.Generic;
using System.Text;

namespace ReadBarcodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader.ReadAllTypeBarcode();
            Reader.ReadSpecifiedTypeBarcode();
        }
    }
}
