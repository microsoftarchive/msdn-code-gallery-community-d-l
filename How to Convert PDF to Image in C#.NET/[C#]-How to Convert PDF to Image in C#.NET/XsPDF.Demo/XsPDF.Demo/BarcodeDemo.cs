using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XsPDF.Barcode;
using XsPDF.Drawing;
using XsPDF.Pdf;

namespace XsPDF.Demo
{
    class BarcodeDemo
    {
        public static void AddCode128ToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to code 128 symbol
            barcode.BarType = BarCodeType.Code128;

            // Input the barcode data content
            barcode.Data = "123456789";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 100);

            // Only 1D barcodes support show the data text under the barcode graphics
            barcode.ShowText = true;

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddPDF417ToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to pdf417 symbol
            barcode.BarType = BarCodeType.PDF417;

            // Set barcode date to encode
            barcode.Data = "xspdf123456789";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set pdf417 compact/truncated
            barcode.PDF417Compact = false;

            // Set the barcode Position and location
            barcode.Location = new XPoint(70, 50);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 100);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddCode39ToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to code 3 of 9 symbol
            barcode.BarType = BarCodeType.Code39;

            // Set barcode date to encode
            barcode.Data = "123456789";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set 1d barcode human-readable text to display
            barcode.ShowText = true;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 50);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddEAN13ToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to ean-13 symbol
            barcode.BarType = BarCodeType.EAN13;

            // Input the barcode data content, only need 12 digital data
            // our library will add the check sum automatically
            barcode.Data = "123456789012";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set 1d barcode human-readable text to display
            barcode.ShowText = true;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 50);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddUPCAToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to upc-a symbol
            barcode.BarType = BarCodeType.UPCA;

            // Input the barcode data content
            barcode.Data = "123456789012";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set 1d barcode human-readable text to display
            barcode.ShowText = true;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 50);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddAztecToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to aztec symbol
            barcode.BarType = BarCodeType.Aztec;

            // Input the barcode data content
            barcode.Data = "xspdf123456789";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set aztec layer mode
            barcode.AztecLayer = LayerMode.Default;

            // Set aztec code error correction
            barcode.AztecErrorCorrection = 33;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 200);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddQRCodeToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to qrcode symbol
            barcode.BarType = BarCodeType.QRCode;

            // Input the barcode data content
            barcode.Data = "xspdf123456789";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            // Set qrcode error correction level
            barcode.QRCodeECL = ErrorCorrectionLevelMode.L;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 200);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }

        public static void AddDataMatrixToPDF()
        {
            // Create a new PDF document.
            PdfDocument document = new PdfDocument();

            // Create a page.
            PdfPage page = document.AddPage();

            // Get graphics object from pdf page
            XGraphics g = XGraphics.FromPdfPage(page);

            // Create a pdf barcode object
            PdfBarcode barcode = new PdfBarcode();

            // Set the barcode type to data matrix symbol
            barcode.BarType = BarCodeType.DataMatrix;

            // Input the barcode data content
            barcode.Data = "xspdf123456789";

            // Change foreground and background color of barcode
            barcode.BarcodeColor = XColors.Black;
            barcode.BackgroundColor = XColors.White;

            //Set datamatrix shape mode: rectangle or square
            barcode.DataMatrixShape = SymbolShapeMode.Square;

            // Set the barcode Position and location
            barcode.Location = new XPoint(100, 100);

            // Set the barcode width and height
            barcode.Size = new XSize(200, 200);

            barcode.DrawBarcode(g);

            // Save and show the document           
            document.Save("Barcode.pdf");
            Process.Start("Barcode.pdf");

        }
    }
}
