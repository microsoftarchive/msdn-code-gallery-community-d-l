using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

internal static class PrepareDataGridView
{
    public static void Populate(DataGridView DataGridView)
    {
        DataSet ds = new DataSet();
        using (OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=demo.mdb;"))
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Identifier,ContactPosition FROM PositionType;", cn);
            da.Fill(ds, "PositionType");
            da = new OleDbDataAdapter("SELECT PersonName, ContactPosition FROM People;", cn);
            da.Fill(ds, "Names");
        }

        DataGridViewComboBoxColumn ContactPositionColumn = new DataGridViewComboBoxColumn { DataPropertyName = "ContactPosition", DataSource = ds.Tables["PositionType"], DisplayMember = "ContactPosition", DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, Name = "ContactsColumn", HeaderText = "Position", SortMode = DataGridViewColumnSortMode.Automatic, ValueMember = "ContactPosition", Width = 200 };

        DataGridViewTextBoxColumn PeopleNamesColumn = new DataGridViewTextBoxColumn { DataPropertyName = "PersonName", HeaderText = "Names" };

        DataGridView.AutoGenerateColumns = false;
        DataGridView.Columns.AddRange(new DataGridViewColumn[] { PeopleNamesColumn, ContactPositionColumn });
        DataGridView.DataSource = ds.Tables["Names"];
    }
}