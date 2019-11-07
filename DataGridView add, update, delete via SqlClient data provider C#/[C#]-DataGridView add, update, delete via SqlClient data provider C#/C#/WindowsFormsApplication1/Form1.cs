using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private BindingSource bsCustomers = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataOperations DataOps = new DataOperations();
            bsCustomers.DataSource = DataOps.GetCustomers();
            DataGridView1.DataSource = bsCustomers;
            DataGridView1.ExpandColumns();
        }
        /// <summary>
        /// Add all new rows from DataGridView.
        /// DataOperations.UpDateRows is not implemented and if so we could
        /// iterate the underlying DataTable as done for add new rows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddNewRow_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)bsCustomers.DataSource;
            var dtChanges = dt.GetChanges(DataRowState.Added);

            Console.WriteLine();

            DataOperations DataOps = new DataOperations();
            DataOps.AddCustomers(dt);
        }
        /// <summary>
        /// Delete current row if user replies yes. Note there is also
        /// DataOperations.RemoveRows not implemented but by following the instructions
        /// in RemoveRows you can implement this too.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeleteCurrentRow_Click(object sender, EventArgs e)
        {
            string CustomerName = ((DataRowView)bsCustomers.Current).Row.Field<string>("CompanyName");
            if (MyDialogs.Question("Remove '" + CustomerName + "' record"))
            {
                DataOperations DataOps = new DataOperations();
                if (DataOps.RemoveRow(((DataRowView)bsCustomers.Current).Row.Field<int>("Identifier")))
                {
                    bsCustomers.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Failed to remove '" + CustomerName + "'");
                }
            }
        }
        /// <summary>
        /// Save current row only in the DataGridView, no checks are made
        /// to detect if changes where made.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEditCurrentRow_Click(object sender, EventArgs e)
        {
            if (MyDialogs.Question("Save current row"))
            {
                DataOperations DataOps = new DataOperations();
                if (!(DataOps.UpdateRow(((DataRowView)bsCustomers.Current).Row)))
                {
                    MessageBox.Show("Update failed");
                }
            }
        }
        /// <summary>
        /// Ask user if they want to add a new row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == DataGridView1.NewRowIndex)
            {
                if (MyDialogs.Question("Add new row?") == false)
                {
                    bsCustomers.CancelEdit();
                    bsCustomers.AllowNew = false;
                    bsCustomers.AllowNew = true;
                    SendKeys.Send("{UP}");
                }
            }
        }
        /// <summary>
        /// Validate we have a complete record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (DataGridView1["CompanyName", e.RowIndex].Value == DBNull.Value || DataGridView1["ContactName", e.RowIndex].Value == DBNull.Value || DataGridView1["ContactTitle", e.RowIndex].Value == DBNull.Value)
            {
                MessageBox.Show("Must fill in all cells to have a valid entry. Please complete all entries or after this dialog closes press ESC.");
                bsCustomers.MoveLast();
                e.Cancel = true;
            }
        }
    }
}