using System;
using System.Collections.Generic;
using System.Text;
using PQScan.BarcodeScanner;

namespace ReadBarcodeDemo
{
    class Reader
    {
        public static void ReadAllTypeBarcode()
        {
            BarcodeResult[] results = BarCodeScanner.Scan("d:/barcode.png");

            foreach (BarcodeResult result in results)
            {
                Console.WriteLine(result.BarType.ToString() + "-" + result.Data);
            }

        }

        public static void ReadSpecifiedTypeBarcode()
        {
            BarcodeResult[] results = BarCodeScanner.Scan("d:/qrcode.png", BarCodeType.QRCode);

            foreach (BarcodeResult result in results)
            {
                Console.WriteLine(result.Data);
            }
        }


    }
}
