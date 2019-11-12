using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spire.Barcode;

namespace CreateScanBarcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeSettings barsetting = new BarcodeSettings();
            barsetting.Data = "48525582545";
            barsetting.Data2D = "48525582545";

            barsetting.Type = BarCodeType.EAN128;
            barsetting.ShowTextOnBottom = true;

            BarCodeGenerator bargenerator = new BarCodeGenerator(barsetting);
            Image barcodeimage = bargenerator.GenerateImage();
            barcodeimage.Save(@"..\..\barcode_1.png");

            System.Diagnostics.Process.Start(@"..\..\barcode_1.png");

            string[] datas;
            datas = Spire.Barcode.BarcodeScanner.Scan(@"..\..\barcode_1.png");

            MessageBox.Show("The number of barcodes is: " + datas.Length + "The scanning result is: " + datas[0]);

        }
    }
}
