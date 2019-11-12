Public Class frmMain

    Private FileName As String = IO.Path.Combine(Application.StartupPath, "Customer.xml")
    ''' <summary>
    ''' Load three ComboBox controls with distinct values from three fields returned from reading
    ''' a XML document via LINQ. Each ComboBox has 'All' inserted as the first item.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub _Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Doc As New XDocument
        Doc = XDocument.Load(FileName)

        Dim DistinctValues As List(Of String) = (From T In Doc...<Customer> Select T.<CompanyName>.Value Distinct).ToList
        DistinctValues.Insert(0, "All")
        cboCompanyNames.DataSource = DistinctValues

        DistinctValues = (From T In Doc...<Customer> Select Value = T.<ContactTitle>.Value Order By Value Distinct).ToList
        DistinctValues.Insert(0, "All")
        cboContactType.DataSource = DistinctValues

        DistinctValues = (From T In Doc...<Customer> Select Value = T.<Country>.Value Order By Value Distinct).ToList
        DistinctValues.Insert(0, "All")
        cboCountries.DataSource = DistinctValues

        Dim dummy As List(Of Customer) = New List(Of Customer)() From
            {
                New Customer With
                {
                    .CompanyName = "",
                    .ContactType = "",
                    .Country = "",
                    .Identifier = ""
                }
            }
        DataGridView1.DataSource = dummy

    End Sub
    ''' <summary>
    ''' Using Lambda statement with an additive where condition from current values
    ''' selected in the three ComboBox controls
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdLambdaFilteringAsList_Click(sender As Object, e As EventArgs) Handles cmdLambdaFilteringAsList.Click
        Dim Demo As New GetFilteredCustomers(FileName, cboCompanyNames.Text, cboContactType.Text, cboCountries.Text)
        DataGridView1.DataSource = Demo.RetrieveList
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.ExpandColumns()
        End If
    End Sub
    ''' <summary>
    ''' Using Lambda statement with an additive where condition from current values
    ''' selected in the three ComboBox controls
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdLambdaFilteringAsDataTable_Click(sender As Object, e As EventArgs) Handles cmdLambdaFilteringAsDataTable.Click
        Dim Demo As New GetFilteredCustomers(FileName, cboCompanyNames.Text, cboContactType.Text, cboCountries.Text)
        DataGridView1.DataSource = Demo.RetrieveDataTable
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.ExpandColumns()
        End If
    End Sub
End Class