Imports System.Data.OleDb
Module PrepareData
    Public Sub Populate(ByVal DataGridView As DataGridView)
        Dim ds As New DataSet
        Using cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=demo.mdb;")
            Dim da As New OleDbDataAdapter("SELECT Identifier,ContactPosition FROM PositionType;", cn)
            da.Fill(ds, "PositionType")
            da = New OleDbDataAdapter("SELECT PersonName, ContactPosition FROM People;", cn)
            da.Fill(ds, "Names")
        End Using

        Dim ContactPositionColumn As New DataGridViewComboBoxColumn With
            {
                .DataPropertyName = "ContactPosition",
                .DataSource = ds.Tables("PositionType"),
                .DisplayMember = "ContactPosition",
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                .Name = "ContactsColumn",
                .HeaderText = "Position",
                .SortMode = DataGridViewColumnSortMode.Automatic,
                .ValueMember = "ContactPosition",
                .Width = 200
            }

        Dim PeopleNamesColumn As New DataGridViewTextBoxColumn With
            {
                .DataPropertyName = "PersonName",
                .HeaderText = "Names"
            }

        DataGridView.AutoGenerateColumns = False
        DataGridView.Columns.AddRange(New DataGridViewColumn() {PeopleNamesColumn, ContactPositionColumn})
        DataGridView.DataSource = ds.Tables("Names")

    End Sub
End Module
