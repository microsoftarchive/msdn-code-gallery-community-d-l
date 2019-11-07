using System;
using System.Windows.Forms;
using System.IO;
using ExcelUsedLibrary;

namespace UsedRowsCols
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Demo.xlsx");
        private string sheetName = "Sheet1";
        /// <summary>
        /// Get last row and last column for a worksheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ExcelUsed eu = new ExcelUsed();
            ExcelLast results = eu.UsedRowsColumns(fileName, sheetName);
            MessageBox.Show($"row {results.Row} col {results.Column}");
        }

        /// <summary>
        /// Get last used column for a specific row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// If you call the code below minus the finally Excel stays
        /// in memory but will be released when the app closes
        /// 
        /// When running this demo, open Task Manager.
        /// Try running code with the CheckBox checked then un-checked
        ///  - When checked, we make a call to the garbage collector which 
        ///    will release memory but is not prudent. Only time this method
        ///    should be used is when an operation such as this one is called
        ///    many times and might cause the system to run low or out of memory
        ///  - When un-checked memory is released when the app is closed.
        /// </remarks>
        private void button2_Click(object sender, EventArgs e)
        {
            int row = (int)numericUpDown1.Value;
            ExcelUsed eu = new ExcelUsed();

            try
            {
                int results = eu.LastColumnForRow(fileName, sheetName,row);
                MessageBox.Show($"Row {row}: {results}");
            }
            finally
            {
                if (forceCheckBox.Checked)
                {
                    eu.CallGarbageCollector();
                }
            }
        }
        /// <summary>
        /// Get last cell address in a range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ExcelUsed eu = new ExcelUsed();
            string value = eu.LastRowInRange(fileName, sheetName, "A1", "B20");
            MessageBox.Show(value);
        }
    }
}
