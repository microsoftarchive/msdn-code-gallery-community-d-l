Public Class Form1
    WithEvents bsPerson As New BindingSource
    WithEvents bsComboBox As New BindingSource
    Private bsColorInformation As New BindingSource

    ''' <summary>
    ''' Contains color index and color from backend database table
    ''' used to show the currnent color of the current row in the
    ''' DataGridView
    ''' </summary>
    ''' <returns></returns>
    Private Property ColorDictionary As New Dictionary(Of Integer, String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim operation As New DataOperations
        operation.GetData()
        If Not operation.Exception.HasError Then
            ColorDictionary = operation.ColorDictionary

            DataGridView1.AutoGenerateColumns = False
            bsComboBox.DataSource = operation.ColorTable

            ColorsColumn.DisplayMember = "ColorText"
            ColorsColumn.ValueMember = "ColorId"
            ColorsColumn.DataSource = bsComboBox
            ColorsColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

            bsPerson.DataSource = operation.PersonsTable
            DataGridView1.DataSource = bsPerson

            bsColorInformation.DataSource = operation.InformationTable

            updateFormControls()

        End If

    End Sub
    ''' <summary>
    ''' Each time the DataGridView row changes update labels
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub bsData1_PositionChanged(sender As Object, e As EventArgs) Handles bsPerson.PositionChanged
        updateFormControls()
    End Sub
    ''' <summary>
    ''' Hook into changes while user is traversing items in the
    ''' DataGridViewComboBox column
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

        If DataGridView1.CurrentCell.IsComboBoxCell Then
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = "ColorsColumn" Then
                Dim cb As ComboBox = TryCast(e.Control, ComboBox)
                RemoveHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
                AddHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
            End If
        End If

    End Sub
    Private Sub _SelectionChangeCommitted(sender As Object, e As EventArgs)

        Dim ColorId As Integer = CType(CType(sender, DataGridViewComboBoxEditingControl).SelectedItem, DataRowView).Row.Field(Of Integer)("ColorId")

        UpdateTable(bsPerson.Identifier, ColorId)
        Label1.Text = ColorId.ToString
        Label2.Text = bsColorInformation.ColorMessage(ColorId)
        Panel2.BackColor = Color.FromName(ColorDictionary(ColorId))
    End Sub
    Private Sub updateFormControls()
        Label1.Text = bsPerson.ColorIdFromPerson.ToString
        Dim index = bsColorInformation.Find("Id", bsPerson.ColorIdFromPerson)
        Label2.Text = bsColorInformation.ColorMessage(bsPerson.ColorIdFromPerson)
        Panel2.BackColor = Color.FromName(ColorDictionary(bsPerson.ColorId))
    End Sub
    Private Sub UpdateTable(ByVal personId As Integer, ByVal ColorId As Integer)
        Dim operation As New DataOperations
        operation.UpdatePerson(personId, ColorId)
        If operation.Exception.HasError Then
            MessageBox.Show(operation.Exception.Message)
        End If
    End Sub
End Class
