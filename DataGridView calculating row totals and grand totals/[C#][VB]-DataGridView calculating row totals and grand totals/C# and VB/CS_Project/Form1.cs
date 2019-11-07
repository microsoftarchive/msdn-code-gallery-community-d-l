using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CS_Example
{
    public partial class Form1 : Form
    {
        private BindingSource bsData = new BindingSource();
        private DataOperations DataAccess = new DataOperations();
        private string Identifier = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void UpDateTotal()
        {
            DataTable dt = (DataTable)bsData.DataSource;

            if (bsData.Position != -1)
            {
                if (!(((DataRowView)bsData.Current).Row.RowState == DataRowState.Detached))
                {
                    dt.Rows[bsData.Position].EndEdit();
                }
            }

            DataView dv = new DataView() { Table = dt, RowStateFilter = DataViewRowState.CurrentRows, AllowDelete = false };

            try
            {
                lblTotalSale.Text = "Grand Total: " + (from T in dv.ToTable().AsEnumerable() select T.Field<int>(DataAccess.RowTotalFieldName)).Sum().ToString();
            }
            catch (Exception ex)
            {
                //
                // If you land here most likely there is a value for a month that is null
                //
                MessageBox.Show("UpDateTotal throw an exception: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataAccess.LoadData();
            bsData.DataSource = DataAccess.DataTable;

            DataGridView1.DataSource = bsData;

            DataGridView1.Columns[DataAccess.RowTotalFieldName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Columns[DataAccess.RowTotalFieldName].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView1.Columns[DataAccess.RowTotalFieldName].SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (var item in DataAccess.ColumnNames)
            {
                DataGridView1.Columns[item].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            DataGridView1.Columns["TheYear"].HeaderText = "Year";

            DataGridView1.ExpandColumns();
            DataGridView1.Columns[DataAccess.RowTotalFieldName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataAccess.DataTable.RowChanged += _RowChanged;
            DataAccess.DataTable.ColumnChanged += _ColumnChanged;
            DataAccess.DataTable.RowDeleted += _RowDeleted;

            UpDateTotal();

            // lets make sure all data is shown without scrolling
            this.Width = 1250;

            BindingNavigator1.BindingSource = bsData;
            
            DataGridView1.CellValidating += DataGridView1_CellValidating;
            DataGridView1.Sorted += DataGridView1_Sorted;

            bsData.PositionChanged += bsData_PositionChanged;
        }

        private void DataGridView1_Sorted(object sender, EventArgs e)
        {
            bsData.Position = bsData.Find("Identifier", Identifier);
        }

        private void bsData_PositionChanged(object sender, EventArgs e)
        {
            Identifier = ((DataRowView)bsData.Current)["Identifier"].ToString();
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DataGridView1[e.ColumnIndex, e.RowIndex].IsInEditMode)
            {
                if (DataGridView1[e.ColumnIndex, e.RowIndex].ValueType == typeof(Int32))
                {
                    Control c = DataGridView1.EditingControl;
                    System.Int32 tempVar = 0;
                    if (!(int.TryParse(c.Text, out tempVar)))
                    {
                        MessageBox.Show("Must be numeric");
                        e.Cancel = true;
                        DataGridView1.CancelEdit();
                    }
                }
            }
        }

        private void _RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            UpDateTotal();
        }

        private void _ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (!(e.Row.RowState == DataRowState.Deleted))
            {
                if (DataAccess.ColumnNames.Contains(e.Column.ColumnName))
                {
                    if (!(e.Row.RowState == DataRowState.Detached))
                    {
                        if (Convert.IsDBNull(e.Row[e.Column.ColumnName]))
                        {
                            e.Row[e.Column.ColumnName] = 0;
                        }

                        e.Row.AcceptChanges();
                    }

                    UpDateTotal();
                }
            }
        }

        private void _RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add || e.Action == DataRowAction.Change || e.Action == DataRowAction.Commit || e.Action == DataRowAction.Change)
            {
                UpDateTotal();
            }
        }
    }
}