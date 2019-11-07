Imports DataGridViewMultiColumnComboColumnDemo
Imports System.Data.OleDb

Public Class Form1
    Private ds As New DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
        DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub
    Private Sub RefreshData()
        Dim cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SampleDB.mdb;")
        Dim da As OleDb.OleDbDataAdapter
        Dim ds As New DataSet

        da = New OleDb.OleDbDataAdapter(
        <SQL>
            SELECT TypeId, TypeName, TypeDescription FROM LogMessageTypes;
        </SQL>.Value, _
        cn)

        da.Fill(ds, "LogMessageTypes")
        da = New OleDb.OleDbDataAdapter(
        <SQL>
            SELECT Id, DateTime, Type, Message FROM LogTable;
        </SQL>.Value, _
        cn)

        da.Fill(ds, "LogTable")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = ds.Tables(1).TableName

        Dim position As Integer = DataGridView1.Columns.Count
        If DataGridView1.Columns.Contains("Type") Then
            position = DataGridView1.Columns("Type").Index

            'create the multicolumncombo column
            Dim newColumn As New DataGridViewMultiColumnComboColumn()

            newColumn.CellTemplate = New DataGridViewMultiColumnComboCell()
            newColumn.DataSource = ds.Tables("LogMessageTypes")
            newColumn.HeaderText = "Types"
            newColumn.DataPropertyName = "Type"
            newColumn.DisplayMember = "TypeName"
            newColumn.ValueMember = "TypeId"
            newColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            DataGridView1.Columns.Remove("Type")
            DataGridView1.Columns.Insert(position, newColumn)
            DataGridView1.Columns(position).Width = 300
        End If
    End Sub

End Class
