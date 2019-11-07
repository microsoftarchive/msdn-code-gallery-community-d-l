using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;

namespace GeneratePDFTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.<br>
            PdfDocument doc = new PdfDocument();
            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;
            // Create new page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);
            float y = 10;
            //title
            PdfBrush brush1 = PdfBrushes.Black;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString("Country List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Country List", format1).Height;
            y = y + 5;

            String[] data
            = {
               "Name;Capital;Continent;Area;Population",
               "Argentina;Buenos Aires;South America;2777815;32300003",
               "Bolivia;La Paz;South America;1098575;7300000",
               "Brazil;Brasilia;South America;8511196;150400000",
               "Canada;Ottawa;North America;9976147;26500000",
               };
            String[][] dataSource
                = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }

            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.DataSource = dataSource;
            PdfLayoutResult result = table.Draw(page, new PointF(0, y));
            y = y + result.Bounds.Height + 5;
            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            page.Canvas.DrawString(String.Format("* {0} countries in the list.", data.Length - 1), font2, brush2, 5, y);

            //Save pdf file.
            doc.SaveToFile("SimpleTable.pdf");
            doc.Close();
            System.Diagnostics.Process.Start("SimpleTable.pdf");
        }
    }
}
