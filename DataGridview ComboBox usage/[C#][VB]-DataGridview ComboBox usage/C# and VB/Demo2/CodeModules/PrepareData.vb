Imports System.Data.OleDb
Module PrepareData
    Public Sub Populate(ByVal DataGridView As DataGridView, ByVal bs As BindingSource, ByRef bsPositions As BindingSource)
        Dim ds As New DataSet

        Using cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=demo.mdb;")
            Dim da As New OleDbDataAdapter("SELECT PersonName, ContactPosition FROM People;", cn)
            da.Fill(ds, "Names")
            da = New OleDbDataAdapter("SELECT Identifier,ContactPosition FROM PositionType;", cn)
            da.Fill(ds, "PositionType")
        End Using

        Dim PeopleNamesColumn As New DataGridViewTextBoxColumn With
            {
                .DataPropertyName = "PersonName",
                .HeaderText = "Names"
            }

        bsPositions.DataSource = ds.Tables("PositionType")

        Dim ContactPositionColumn As New DataGridViewComboBoxColumn With
            {
                .DataPropertyName = "ContactPosition",
                .DataSource = bsPositions,
                .DisplayMember = "ContactPosition",
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                .Name = "ContactsColumn",
                .HeaderText = "Position",
                .SortMode = DataGridViewColumnSortMode.Automatic,
                .ValueMember = "ContactPosition"
            }

        DataGridView.AutoGenerateColumns = False
        DataGridView.Columns.AddRange(New DataGridViewColumn() {PeopleNamesColumn, ContactPositionColumn})

        bs.DataSource = ds.Tables("Names")
        DataGridView.DataSource = bs

        DataGridView.ExpandColumns()
    End Sub
End Module
