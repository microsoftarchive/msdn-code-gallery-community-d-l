using System;
using System.Diagnostics;
using System.Windows.Forms;
using Aspose.Pdf;

namespace Aspose.PDF.Demo.PDF2Excel.CS
{
    public partial class Form1 : Form
    {
        private readonly License _license = new Pdf.License();
        private string _pdfFileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = "To get a temporary license, please go to Aspose website.";
            linkLabel1.Links.Add(41, 6, "https://purchase.aspose.com/temporary-license");            
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Aspose-PDF2Excel-Demo.pdf";
            if ((saveFileDialog1.ShowDialog() == DialogResult.OK))
            {
                Pdf2XlsConverter.AddInvoiceData(saveFileDialog1.FileName);
                label2.Text = $"File to export: {saveFileDialog1.FileName}";
            }
            _pdfFileName = saveFileDialog1.FileName;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string xlsFileName; 
            if (string.IsNullOrWhiteSpace(_pdfFileName))
            {
                MessageBox.Show("Please, choose a file!", "Missing file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var excelSaveOption = new ExcelSaveOptions
            {
                ScaleFactor = trackBar1.Value/100.0,
                InsertBlankColumnAtFirst = checkBox1.Checked,
                MinimizeTheNumberOfWorksheets = checkBox2.Checked,                
            };
            
            if (radioButton1.Checked)
            {
                xlsFileName = System.IO.Path.ChangeExtension(_pdfFileName, "xml");
                excelSaveOption.Format = ExcelSaveOptions.ExcelFormat.XMLSpreadSheet2003;
            }
            else
            {
                xlsFileName = System.IO.Path.ChangeExtension(_pdfFileName, "xlsx");
                excelSaveOption.Format = ExcelSaveOptions.ExcelFormat.XLSX;
            }
            Module1.SaveToExcel(asposeFilePdf: _pdfFileName, asposeFileXls: xlsFileName, excelSaveOption: excelSaveOption);
            label2.Text = $"File converted to {xlsFileName}";
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Aspose.PDF.lic";
            openFileDialog1.Filter = "LIC files (*.lic)|*.lic";
            if ((openFileDialog1.ShowDialog() == DialogResult.OK))
            {
                _license.SetLicense(openFileDialog1.FileName);
                label1.Text = "Mode: Licensed version";
                button2.Enabled = true;
            }
            openFileDialog1.FileName = string.Empty;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            if ((openFileDialog1.ShowDialog() == DialogResult.OK))
            {
                _pdfFileName = openFileDialog1.FileName;
                label2.Text = $"File to export: {_pdfFileName}";
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = $"Scale factor: {(trackBar1.Value / 100.0).ToString("N2")}" ;
        }
    }
}
