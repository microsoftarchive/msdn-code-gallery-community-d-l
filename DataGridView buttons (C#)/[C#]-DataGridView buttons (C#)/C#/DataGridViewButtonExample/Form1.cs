using DataGridViewButtonLibrary;
using System;
using System.Data;
using System.Windows.Forms;
using TeamBaseLibrary;

namespace DataGridViewButtonExample
{
    public partial class Form1 : Form
    {
        private FormDataOperations formData = new FormDataOperations();      

        private string removeButtonName = "RemoveColumn";
        private string editButtonName = "EditColumn";

        private int mIdentifier = 0;

        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            formData.LoadCustomers();
            formData.LoadContactTypes();

            if (!formData.Operations.HasException)
            {
                formData.BindingSource.PositionChanged += bsCustomers_PositionChanged;
                dataGridView1.DataSource = formData.BindingSource;

                dataGridView1.CreateUnboundButtonColumn(removeButtonName, "Remove", "");
                dataGridView1.CreateUnboundButtonColumn(editButtonName, "Edit", "");

                formData.RemoveButtonName = "RemoveColumn";
                formData.EditButtonName = "EditColumn";
                formData.DataGridView = dataGridView1;
                dataGridView1.CellContentClick += formData.CellContentClick;
                dataGridView1.CellEnter += formData.CellEnter;
                dataGridView1.CellLeave += formData.CellLeave;
                dataGridView1.KeyDown += formData.KeyDown;
                dataGridView1.UserDeletingRow += formData.UserDeletingRow;

                dataGridView1.Sorted += DataGridView1_Sorted;

                dataGridView1.AdjustButtons(removeButtonName);
                dataGridView1.AdjustButtons(editButtonName);

                formData.SetReadOnlyColumns();
                formData.SetColumnHeaders();

                ActiveControl = dataGridView1;
            }
            else
            {
                MessageBox.Show($"Failed to load customers:{Environment.NewLine}{formData.Operations.LastException.Message}");
            }
        }
        private void DataGridView1_Sorted(object sender, EventArgs e)
        {
            formData.BindingSource.Position = formData.BindingSource.Find("CustomerIdentifier", mIdentifier);
            dataGridView1.AdjustButtons(removeButtonName);
            dataGridView1.AdjustButtons(editButtonName);
        }
        private void bsCustomers_PositionChanged(object sender, EventArgs e)
        {
            if (formData.BindingSource.Current != null)
            {
                mIdentifier = formData.BindingSource.CurrentRow().Field<int>("CustomerIdentifier");
            }
        }
        private void cmdAddNewCustomer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
