using System;
using System.Windows.Forms;

// If you haven't already please visit the following link in order to get GemBox.Spreadsheet Free version:
// http://www.gemboxsoftware.com/spreadsheet/free-version
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;

namespace SpreadsheetEditorWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // GemBox.Spreadsheet can work in three different modes: Free, Trial and Professional.
            // http://www.gemboxsoftware.com/support-center/kb/articles/2-gembox-spreadsheet-free-trial-and-professional
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
            openFileDialog.FilterIndex = 2;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.LoadExcelToDataGridView(openFileDialog.FileName);
        }

        private void LoadExcelToDataGridView(string excelFile)
        {
            ExcelFile ef = ExcelFile.Load(excelFile);
            ExcelWorksheet ws = ef.Worksheets[0];

            // From ExcelFile to DataGridView.
            DataGridViewConverter.ExportToDataGridView(
                ws,
                this.dataGridView1,
                new ExportToDataGridViewOptions() { ColumnHeaders = true });
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLS files (*.xls)|*.xls|XLT files (*.xlt)|*.xlt|XLSX files (*.xlsx)|*.xlsx|XLSM files (*.xlsm)|*.xlsm|XLTX (*.xltx)|*.xltx|XLTM (*.xltm)|*.xltm|ODS (*.ods)|*.ods|OTS (*.ots)|*.ots|CSV (*.csv)|*.csv|TSV (*.tsv)|*.tsv|HTML (*.html)|*.html|MHTML (.mhtml)|*.mhtml|PDF (*.pdf)|*.pdf|XPS (*.xps)|*.xps|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif|WMP (*.wdp)|*.wdp";
            saveFileDialog.FilterIndex = 3;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                this.SaveExcelFromDataGridView(saveFileDialog.FileName);
        }

        private void SaveExcelFromDataGridView(string excelFile)
        {
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("DGW Sheet");

            // From DataGridView to ExcelFile.
            DataGridViewConverter.ImportFromDataGridView(
                ws,
                this.dataGridView1,
                new ImportFromDataGridViewOptions() { ColumnHeaders = true });

            ef.Save(excelFile);
        }
    }
}
