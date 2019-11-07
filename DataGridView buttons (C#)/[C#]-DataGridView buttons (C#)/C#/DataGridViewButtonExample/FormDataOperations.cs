using DataGridViewButtonLibrary;
using SqlDataOperations;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TeamBaseLibrary;
using TeamBaseLibrary.Extensions;

namespace DataGridViewButtonExample
{
    public class FormDataOperations
    {
        /// <summary>
        /// Data operations reside here
        /// </summary>
        public Operations Operations { get; set; }
        public BindingSource BindingSource { get; set; }
        public DataGridView DataGridView { get; set; }
        /// <summary>
        /// Name of the remove DataGridViewButton
        /// </summary>
        public string RemoveButtonName { get; set; }
        /// <summary>
        /// Name of the edit DataGridViewButton
        /// </summary>
        public string EditButtonName { get; set; }

        private List<ContactType> mContactList;
        public List<ContactType> ContactTypeList { get { return mContactList; } }

        public FormDataOperations()
        {
            Operations = new Operations();
        }
        public void LoadCustomers()
        {
            BindingSource = new BindingSource();
            BindingSource.DataSource = Operations.LoadCustomerData();
        }
        public void LoadContactTypes()
        {
            mContactList = Operations.LoadContactTypes();
        }

        public void SetReadOnlyColumns()
        {
            foreach (DataGridViewColumn column in DataGridView.Columns)
            {
                if (!column.IsA<DataGridViewButtonColumn>())
                {
                    column.ReadOnly = true;
                }
            }
        }
        public void SetColumnHeaders()
        {
            var dictCols = new Dictionary<string, string>()
            {
                {"CompanyName","Company" },
                {"ContactName","Contact" },
                {"ContactTitle","Title" }
            };

            foreach (KeyValuePair<string,string> item in dictCols)
            {
                DataGridView.Columns[item.Key].HeaderText = item.Value;
            }
        }
        public void UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (KarenDialogs.Question($"Remove '{BindingSource.CurrentRow().Field<string>("CompanyName")}'"))
            {
                if (Operations.FakeRemoveCustomer(BindingSource.CurrentRow().Field<int>("CustomerIdentifier")))
                {
                    BindingSource.RemoveCurrent();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        public void CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = ((DataGridView)sender);

            DataGridViewDisableButtonCell removeButtonCell = (DataGridViewDisableButtonCell)
                (dgv.Rows[e.RowIndex].Cells[RemoveButtonName]);
            DataGridViewDisableButtonCell editButtonCell = (DataGridViewDisableButtonCell)
                (dgv.Rows[e.RowIndex].Cells[EditButtonName]);

            removeButtonCell.Enabled = true;
            editButtonCell.Enabled = true;

            if (removeButtonCell.Value == null)
            {
                removeButtonCell.Value = RemoveButtonName;
            }

            if (editButtonCell.Value == null)
            {
                editButtonCell.Value = EditButtonName;
            }

            dgv.Invalidate();
        }

        public void CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = ((DataGridView)sender);
            DataGridViewDisableButtonCell removeButtonCell = (DataGridViewDisableButtonCell)
                (dgv.Rows[e.RowIndex].Cells[RemoveButtonName]);
            DataGridViewDisableButtonCell editButtonCell = (DataGridViewDisableButtonCell)
                (dgv.Rows[e.RowIndex].Cells[EditButtonName]);
            removeButtonCell.Enabled = false;
            editButtonCell.Enabled = false;
            dgv.Invalidate();
        }
        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DataGridView.IsValidDataGridViewButton(RemoveButtonName) || 
                    DataGridView.IsValidDataGridViewButton(EditButtonName))
                {
                    var colName = DataGridView.Columns[DataGridView.CurrentCell.ColumnIndex].Name;
                    if (colName == RemoveButtonName)
                    {
                        PromptToRemoveCurrentRecordInDataGridViewFromBindingSource();
                        e.Handled = true;
                    }
                    else if (colName == EditButtonName)
                    {
                        EditCurrentRecoedInDataGridViewFromBindingSource();
                        e.Handled = true;
                    }
                }
            }
        }
        public void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DataGridView.IsHeaderButtonCell(e))
            {
                var colName = DataGridView.Columns[e.ColumnIndex].Name;
                if (colName == RemoveButtonName)
                {
                    PromptToRemoveCurrentRecordInDataGridViewFromBindingSource();
                }
                else if (colName == EditButtonName)
                {
                    EditCurrentRecoedInDataGridViewFromBindingSource();
                }

            }
        }
        public void PromptToRemoveCurrentRecordInDataGridViewFromBindingSource()
        {
            if (DataGridView.IsValidDataGridViewButton(RemoveButtonName))
            {
                if (KarenDialogs.Question($"Remove '{BindingSource.CurrentRow().Field<string>("CompanyName")}'"))
                {

                    if (Operations.FakeRemoveCustomer(BindingSource.CurrentRow().Field<int>("CustomerIdentifier")))
                    {
                        BindingSource.RemoveCurrent();
                    }
                }
            }
        }
        public void EditCurrentRecoedInDataGridViewFromBindingSource()
        {
            var row = BindingSource.CurrentRow();
            EditorForm f = new EditorForm(row, mContactList);
            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (!Operations.FakeUpdateCustomer(row))
                    {
                        row.RejectChanges();
                        /*
                         * We landed here because there was an exception raised. Since
                         * the DataRow has been updated we use RejectChanges to undue
                         * the changes in our DataGridView.
                         */
                    }
                    else
                    {
                        /*
                         * Landing here means the DataRow has been updated in the
                         * DataGridView and the database table has been updated too.
                         */
                    }
                }
            }
            finally
            {
                f.Dispose();   
            }
        }
    }
}
