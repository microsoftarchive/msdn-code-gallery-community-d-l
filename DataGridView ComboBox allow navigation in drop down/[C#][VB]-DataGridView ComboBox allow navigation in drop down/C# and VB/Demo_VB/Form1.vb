Imports MockedData_VB
Public Class Form1
    Private AutoList As AutoCompleteStringCollection =
        New AutoCompleteStringCollection

    Private cbo As ComboBox
    Private ComboColumnName As String = "C1"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '
        ' DataOperation contains mocked data for this demo
        '
        Dim Data As New DataOperations

        Dim dict = Data.MonthDictionary
        Dim DataGridViewData As List(Of MockedData) = Data.MockedData

        Dim MonthNameColumn As New DataGridViewComboBoxColumn With
            {
                .DataSource = Data.AutoData,
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                .Name = ComboColumnName,
                .HeaderText = "Demo",
                .SortMode = DataGridViewColumnSortMode.NotSortable
            }

        Dim IndexColumn As New DataGridViewTextBoxColumn With
            {
                .Name = "C2",
                .HeaderText = "Col 2"
            }

        AutoList.AddRange(Data.AutoData)

        DataGridView1.Columns.AddRange(New DataGridViewColumn() {MonthNameColumn, IndexColumn})

        For Each item In Data.MockedData
            DataGridView1.Rows.Add(New Object() {item.Name, item.Index})
        Next

    End Sub
    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellLeave

        If cbo IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(cbo.Text) Then
                If Not AutoList.Contains(cbo.Text) Then
                    Dim cb = CType(DataGridView1.Columns(0), DataGridViewComboBoxColumn)
                    AutoList.Add(cbo.Text)
                    Dim Items As List(Of String) = CType(cb.DataSource, String()).ToList
                    Items.Add(cbo.Text)
                    Dim Index = Items.FindIndex(Function(x) x.ToLower = cbo.Text.ToLower)
                    cb.DataSource = Items.ToArray
                    cbo.SelectedIndex = Index
                    '
                    ' For your project here is where you can do say a save back to the
                    ' database.
                    '
                End If
            End If
        End If

    End Sub
    Private Sub DataGridView1_EditingControlShowing(
        sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
    Handles DataGridView1.EditingControlShowing

        ' IsComboBoxCell is an exension method in ExtensionMethods_VB project
        If DataGridView1.CurrentCell.IsComboBoxCell Then
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = ComboColumnName Then
                cbo = TryCast(e.Control, ComboBox)
                cbo.DropDownStyle = ComboBoxStyle.DropDown
                cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                cbo.AutoCompleteSource = AutoCompleteSource.ListItems
            End If
        End If
    End Sub

End Class
