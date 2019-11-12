using Example_cs.Classes;
using Example_cs.Exensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Example_cs
{
    public partial class Form1 : Form
    {
        private BindingSource bsPerson = new BindingSource();
        private BindingSource bsComboBox = new BindingSource();
        private BindingSource bsColorInformation = new BindingSource();

        /// <summary>
        /// Contains color index and color from backend database table
        /// used to show the currnent color of the current row in the
        /// DataGridView
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> ColorDictionary;
        public Form1()
        {
            InitializeComponent();
            ColorDictionary = new Dictionary<int, string>();
            bsPerson.PositionChanged += bsPerson_PositionChanged;
            DataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DataGridView1.CurrentCell.IsComboBoxCell())
            {
                if (DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name == "ColorsColumn")
                {
                    ComboBox cb = e.Control as ComboBox;
                    cb.SelectionChangeCommitted -= _SelectionChangeCommitted;
                    cb.SelectionChangeCommitted += _SelectionChangeCommitted;
                }
            }
        }

        private void bsPerson_PositionChanged(object sender, EventArgs e)
        {
            updateFormControls();
        }

        private void _SelectionChangeCommitted(object sender, EventArgs e)
        {

            int ColorId = ((DataRowView)(((DataGridViewComboBoxEditingControl)sender).SelectedItem)).Row.Field<int>("ColorId");

            UpdateTable(bsPerson.Identifier(), ColorId);
            Label1.Text = ColorId.ToString();
            Label2.Text = bsColorInformation.ColorMessage(ColorId);
            Panel2.BackColor = Color.FromName(ColorDictionary[ColorId]);
        }
        private void updateFormControls()
        {
            Label1.Text = bsPerson.ColorIdFromPerson().ToString();
            var index = bsColorInformation.Find("Id", bsPerson.ColorIdFromPerson());
            Label2.Text = bsColorInformation.ColorMessage(bsPerson.ColorIdFromPerson());
            Panel2.BackColor = Color.FromName(ColorDictionary[bsPerson.ColorId()]);
        }
        private void UpdateTable(int personId, int ColorId)
        {
            DataOperations operation = new DataOperations();
            operation.UpdatePerson(personId, ColorId);
            if (operation.Exception.HasError)
            {
                MessageBox.Show(operation.Exception.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataOperations operation = new DataOperations();
            operation.GetData();

            if (!operation.Exception.HasError)
            {
                ColorDictionary = operation.ColorDictionary;

                DataGridView1.AutoGenerateColumns = false;
                bsComboBox.DataSource = operation.ColorTable;

                ColorsColumn.DisplayMember = "ColorText";
                ColorsColumn.ValueMember = "ColorId";
                ColorsColumn.DataSource = bsComboBox;
                ColorsColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                bsPerson.DataSource = operation.PersonsTable;
                DataGridView1.DataSource = bsPerson;

                bsColorInformation.DataSource = operation.InformationTable;

                updateFormControls();
            }
        }
    }
}
