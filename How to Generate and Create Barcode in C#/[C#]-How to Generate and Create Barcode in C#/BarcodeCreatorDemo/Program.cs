using System;
using System.Collections.Generic;
using System.Text;
using PQScan.BarcodeCreator;
using System.Drawing.Imaging;

namespace BarcodeCreatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Barcode barcode = new Barcode();

            barcode.BarType = BarCodeType.QRCode;

            barcode.Data = "11123456789ABC";

            barcode.Width = 200;
            barcode.Height = 200;

            barcode.QRCodeECL = ErrorCorrectionLevelMode.L;

            barcode.PictureFormat = ImageFormat.Jpeg;

            barcode.CreateBarcode("qrcode.jpeg");

        }
    }
}
