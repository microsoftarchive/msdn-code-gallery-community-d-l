using ExcelToAccessLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string AccessFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb");

        private string ExcelFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Importer ImportData =
                new Importer(
                    new ExcelInfo
                    {
                        FileName = ExcelFile,
                        HasHeaders = true,
                        SheetName = "Customers1"
                    },
                    new AccessInfo
                    {
                        FileName = AccessFile,
                        TableName = "Customers1",
                        FieldNames = "CompanyName,ContactName"
                    });

            if (ImportData.Run())
            {
                MessageBox.Show("Import complete");
            }
        }
    }
}