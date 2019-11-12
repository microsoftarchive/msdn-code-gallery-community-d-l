using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelBackEnd;
using FormsExtensionLibrary;
using System.IO;
using System.Text.RegularExpressions;

namespace FrontEndUserInterface
{
    public partial class Form1 : Form
    {
        Operations ops = new Operations();
        string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample1.xlsx");        

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Here we load data from the database.
        /// Passing 0 to Ops.Load will load all records
        /// while passing a value above 0 will load a subset.
        /// Note there are 4,000 records and for quick testing
        /// I recommend loading only a few records then down the
        /// road load all records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // pass 0 to load all rows (4000) or a lesser value to load less.
            dataGridView1.DataSource = ops.LoadFromDatabase(100);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderText = Regex.Replace(col.HeaderText, "([a-z])([A-Z])", "$1 $2");
                if (col.Name == "AccountNumber" || col.Name == "PersonalEmail" || col.Name == "CreditCardType")
                {
                    col.Width = 130;
                }
            }
            dataGridView1.ExpandColumns();
            Width = 1450;
        }
        /// <summary>
        /// Import DataTable, use headers, no format for BirthDay column
        /// Defaults to write in Sheet1 and clears prior cells in the sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void basicImportBirthDayNoFormatButton_Click(object sender, EventArgs e)
        {
            if (ops.ImportDataTable1(fileName, "B2", dataGridView1.DataTable(), true)) ;
            {
                MessageBox.Show("Finished");
            }
        }
        /// <summary>
        /// Import DataTable, use headers, with date format for BirthDay column
        /// Defaults to write in Sheet1 and clears prior cells in the sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// here we are asynchronous for when working a large set of data.
        /// </remarks>
        async void basicImportFormattedButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (ops.ImportDataTable2(fileName, "A1", dataGridView1.DataTable(), true))
                {
                    MessageBox.Show("Finished");
                }
            });

        }
        async void basicFormattingWithATwistButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (ops.ImportDataTable3(fileName, "A1", dataGridView1.DataTable(), true))
                {
                    MessageBox.Show("Finished");
                }
            });

        }
        async void basicFormattingWithATwistButton2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (ops.ImportDataTable4(fileName, "A1", dataGridView1.DataTable(), true))
                {
                    MessageBox.Show("Finished");
                }
            });
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
