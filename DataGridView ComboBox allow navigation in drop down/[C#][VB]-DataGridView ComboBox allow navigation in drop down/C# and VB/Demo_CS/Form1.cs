using ExtensionMethods_VB;
using MockedData_VB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Demo_CS
{
    public partial class Form1 : Form
    {
        private AutoCompleteStringCollection AutoList = 
            new AutoCompleteStringCollection();

        private ComboBox cbo;
        private string ComboColumnName = "C1";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            // DataOperation contains mocked data for this demo
            //
            DataOperations Data = new DataOperations();

            var dict = Data.MonthDictionary;
            List<MockedData> DataGridViewData = Data.MockedData;

            DataGridViewComboBoxColumn MonthNameColumn = new DataGridViewComboBoxColumn 
            { 
                DataSource = Data.AutoData, 
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, 
                Name = ComboColumnName, 
                HeaderText = "Demo", 
                SortMode = DataGridViewColumnSortMode.NotSortable 
            };

            DataGridViewTextBoxColumn IndexColumn = new DataGridViewTextBoxColumn 
            { 
                Name = "C2", 
                HeaderText = "Col 2" 
            };

            AutoList.AddRange(Data.AutoData);

            DataGridView1.Columns.AddRange(new DataGridViewColumn[] 
            { 
                MonthNameColumn, IndexColumn 
            });

            foreach (var item in Data.MockedData)
            {
                DataGridView1.Rows.Add(new object[] { item.Name, item.Index });
            }

            DataGridView1.CellLeave += DataGridView1_CellLeave;
            DataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        private void DataGridView1_EditingControlShowing(
            object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // IsComboBoxCell is an exension method in ExtensionMethods_VB project
            if (DataGridView1.CurrentCell.IsComboBoxCell())
            {
                if (DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name == ComboColumnName)
                {
                    cbo = e.Control as ComboBox;
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                    cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }

        private void DataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cbo != null)
            {
                if (!(string.IsNullOrWhiteSpace(cbo.Text)))
                {
                    if (!(AutoList.Contains(cbo.Text)))
                    {
                        var cb = (DataGridViewComboBoxColumn)(DataGridView1.Columns[0]);
                        AutoList.Add(cbo.Text);
                        List<string> Items = ((string[])cb.DataSource).ToList();
                        Items.Add(cbo.Text);
                        var Index = Items.FindIndex((x) => x.ToLower() == cbo.Text.ToLower());
                        cb.DataSource = Items.ToArray();
                        cbo.SelectedIndex = Index;
                        //
                        // For your project here is where you can do say a save back to the
                        // database.
                        //
                    }
                }
            }
        }
    }
}