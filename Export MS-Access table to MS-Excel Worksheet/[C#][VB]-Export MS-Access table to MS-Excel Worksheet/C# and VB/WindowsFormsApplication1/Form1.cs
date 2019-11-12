using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelOleDbLibrary;
using Cue_BannerLibrary;
using AccessConnections_cs;
using System.IO;
using ExportAccessToExcel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private BindingSource bsTables = new BindingSource();
        private string msAccessFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NorthWind.accdb");
        private AccessInformation ops = new AccessInformation();
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
            ListBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }
        void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWorkSheetName.Text = ListBox1.Text;
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            updateCheckListBox();

        }

        void updateCheckListBox()
        {
            CheckedListBox1.Items.Clear();
            List<string> ColumnNames = ops.ColumnDict[ListBox1.Text];

            foreach (var col in ColumnNames)
            {
                CheckedListBox1.Items.Add(col);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
 
            if (string.IsNullOrWhiteSpace(txtWorkSheetName.Text))
            {
                MessageBox.Show("Please enter a valid worksheet name");
                return;
            }

            // file to export too
            var excelFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Excel1111.xlsx");
            // create a dynamic connection for our Excel file to get sheet names
            var cons = new Connections();
            // this class gets sheet names from excelFile
            var utls = new Utility();

            // determine if sheet exists
            if (!(utls.SheetNames(cons.NoHeaderConnectionString(excelFile)).Where((sheet) => sheet.DisplayName.ToLower() == txtWorkSheetName.Text.ToLower()).Any()))
            {
                // prepare for export 
                // current Header property is ignored
                // compiler suggestion, this hides the form level ops var, no biggie
                ExportToExcel ops = new ExportToExcel
                    {
                        DatabaseName = msAccessFileName,
                        Headers = false,
                        ExcelFileName = excelFile,
                        TableName = ListBox1.Text,
                        WorkSheetName = txtWorkSheetName.Text
                    };

                bool Success = false;

                //
                // Export either all fields or selected fields from CheckListBox.
                // I wrote comments in the Try/Catch for the Execute method about some fields may cause an exception
                // Note I do not attempt to arrange the order of the columns
                //
                if (CheckedListBox1.CheckedItems.Count > 0)
                {
                    Success = ops.Execute(CheckedListBox1.SelectColumns());
                }
                else
                {
                    Success = ops.Execute();
                }

                // indicate how many records were exported or show and exception message
                if (Success)
                {
                    MessageBox.Show($"Exported {ops.RecordsInserted}");
                }
                else
                {
                    MessageBox.Show($"Failed: {ops.ExceptionMessage}");
                }

            }
            else
            {
                MessageBox.Show($"{txtWorkSheetName.Text} already exist, aborted.");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bsTables.DataSource = ops.TableNames(msAccessFileName);
            ListBox1.DataSource = bsTables;

            ops.GetTableColumnInformation(msAccessFileName);

            bsTables.PositionChanged += bsCustomers_PositionChanged;

            txtWorkSheetName.SetCueText("Enter a Worksheet name");
        }
        private void bsCustomers_PositionChanged(object sender, EventArgs e)
        {
            updateCheckListBox();
        }
    }
}
