Imports System.Data.OleDb
Module PrepareData
    Private ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=demo.mdb;"
    ''' <summary>
    ''' Gathers data from People and ContactPosition tables into a single
    ''' DataSet which is then used to populate the DataGridView columns and
    ''' is done differently than simply assigning a DataTable to the DataGridView's
    ''' DataSource Property.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FetchData() As DataSet

        Using cn As New OleDbConnection(ConnectionString)

            Dim da As New OleDbDataAdapter("SELECT PersonName, ContactPosition, Country FROM People;", cn)
            Dim ds As New DataSet

            da.Fill(ds, "Names")

            da = New OleDbDataAdapter("SELECT ContactPosition FROM PositionType ORDER BY ContactPosition;", cn)

            da.Fill(ds, "PositionType")

            da = New OleDbDataAdapter("SELECT Country FROM Countries ORDER BY Country;", cn)
            da.Fill(ds, "Countries")

            Return ds

        End Using

    End Function
    Public Sub FillGridView(ByVal DataGridView As DataGridView)
        Dim dsPeople As DataSet

        dsPeople = FetchData()

        'For Each table As DataTable In dsPeople.Tables
        '    Console.WriteLine(table.TableName)
        'Next

        Dim PeopleNames As New DataGridViewTextBoxColumn With _
            { _
                .DataPropertyName = "PersonName", _
                .HeaderText = "Names" _
            }

        ' Setup so that this column only shows the drop down when selected.
        Dim ContactPosition As New DataGridViewComboBoxColumn With _
            { _
                .DataPropertyName = "ContactPosition", _
                .DataSource = dsPeople.Tables("PositionType"), _
                .DisplayMember = "ContactPosition", _
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, _
                .Name = "ContactsColumn", _
                .HeaderText = "Position", _
                .SortMode = DataGridViewColumnSortMode.NotSortable, _
                .ValueMember = "ContactPosition" _
            }

        Dim CountriesCol As New DataGridViewComboBoxColumn With _
            { _
                .DataPropertyName = "Country", _
                .DataSource = dsPeople.Tables("Countries"), _
                .DisplayMember = "Country", _
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, _
                .Name = "CountryColumn", _
                .HeaderText = "Country", _
                .SortMode = DataGridViewColumnSortMode.NotSortable, _
                .ValueMember = "Country" _
            }

        Dim UnBoundCol As New DataGridViewComboBoxColumn With _
            { _
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, _
                .Name = "ColorsColumn", _
                .HeaderText = "Colors", _
                .SortMode = DataGridViewColumnSortMode.NotSortable _
            }
        UnBoundCol.Items.AddRange(Color.Red, Color.Yellow, Color.Green, Color.Blue)
        UnBoundCol.ValueType = GetType(Color)
        UnBoundCol.DefaultCellStyle.NullValue = "(empty)"

        With DataGridView
            .AutoGenerateColumns = False
            .Columns.AddRange(New DataGridViewColumn() {PeopleNames, ContactPosition, CountriesCol, UnBoundCol})
        End With

        frmMainForm.People.DataSource = dsPeople.Tables(0)
        DataGridView.DataSource = frmMainForm.People.DataSource 'dsPeople.Tables(0)

        For x As Integer = 0 To DataGridView.Rows.Count - 1
            If Not DataGridView.Rows(x).IsNewRow Then
                If x.IsEven Then
                    CType(DataGridView.Rows(x).Cells("ColorsColumn"), DataGridViewComboBoxCell).Value = Color.Red
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Provides single click support for opening a ComboBox 
    ''' DataGridView Column rather than two.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim dgv As DataGridView = CType(sender, DataGridView)

        If dgv(e.ColumnIndex, e.RowIndex).EditType IsNot Nothing Then
            If dgv(e.ColumnIndex, e.RowIndex).EditType.ToString().Contains("DataGridViewComboBoxEditingControl") Then
                SendKeys.Send("{F4}")
            End If
        End If
    End Sub

End Module
