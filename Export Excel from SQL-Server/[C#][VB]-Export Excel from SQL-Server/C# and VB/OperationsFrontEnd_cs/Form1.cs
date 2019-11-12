using System;
using System.Windows.Forms;
using System.IO;
using Operations_cs;

namespace OperationsFrontEnd_cs
{
    public partial class Form1 : Form
    {
        readonly string _companyFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
        public Form1()
        {
            InitializeComponent();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            var ops = new SqlServerOperations();

            if (CreateNewExcelFileCheckBox.Checked)
            {
                if (!(ops.CopyToApplicationFolder(_companyFileName)))
                {
                    MessageBox.Show(ops.ExceptionMessage);
                    return;
                }
            }

            var rowCount = 0;
            if (ops.ExportAllCustomersToExcel(_companyFileName,ref rowCount))
            {
                MessageBox.Show($"Exported {rowCount} rows.");
            }
            else
            {
                MessageBox.Show(ops.ExceptionMessage);
            }
        }

        private void selectByCountryButton_Click(object sender, EventArgs e)
        {
            if (countriesCombox.Text == "Select")
            {
                MessageBox.Show("Please select a country");
                return;
            }

            var ops = new SqlServerOperations();

            var item = (CountryItem)countriesCombox.SelectedItem;
            var destinationFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{item.Compact}.xlsx");

            if (CreateNewExcelFileCheckBox.Checked)
            {
                if (!(ops.CopyToApplicationFolder(_companyFileName, destinationFileName)))
                {
                    MessageBox.Show("Copy failed");
                    return;
                }
            }

            var rowCount = 0;
            if (ops.ExportByCountryNameCustomersToExcel(destinationFileName, countriesCombox.Text,ref rowCount))
            {
                MessageBox.Show($"Exported {rowCount} rows.");
            }
            else
            {
                MessageBox.Show(ops.ExceptionMessage);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ops = new SqlServerOperations();
            countriesCombox.DataSource = ops.CountryList();
            countriesCombox.DisplayMember = "Name";
        }
    }
}
