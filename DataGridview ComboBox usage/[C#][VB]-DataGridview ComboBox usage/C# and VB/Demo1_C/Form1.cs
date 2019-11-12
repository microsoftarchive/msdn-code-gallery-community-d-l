using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1_C
{
    public partial class Form1 : Form
    {
        private BindingSource bsPeople = new BindingSource();
        private BindingSource bsPositions = new BindingSource();
        private BindingSource bsBadges = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
            DataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
        }

        void Form1_Shown(object sender, EventArgs e)
        {
            PrepareData pd = new PrepareData();
            pd.Populate(DataGridView1, ref bsPeople, ref bsPositions, ref bsBadges);
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (DataGridView1.CurrentCell.IsComboBoxCell())
            {
                if (DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name == "ContactsColumn")
                {
                    ComboBox cb = e.Control as ComboBox;
                    if (cb != null)
                    {
                        cb.SelectionChangeCommitted -= _SelectionChangeCommitted;
                        cb.SelectionChangeCommitted += _SelectionChangeCommitted;
                    }
                }
            }
        }
        private void _SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                MessageBox.Show(((DataGridViewComboBoxEditingControl)sender).Text);
            }
            else
            {
                if (bsPositions.Current != null)
                {
                    Int32 Index = bsPositions.Find("ContactPosition", ((DataGridViewComboBoxEditingControl)sender).Text);

                    if (Index != -1)
                    {
                        bsBadges.Position = Index;
                        DataGridView1
                            .CurrentRow
                            .Cells[DataGridView1.Columns["BadgeColumn"].Index]
                            .Value = ((DataRowView)bsBadges.Current).Row.Field<string>("Badge");
                    }
                }
            }
        }
    }
}
