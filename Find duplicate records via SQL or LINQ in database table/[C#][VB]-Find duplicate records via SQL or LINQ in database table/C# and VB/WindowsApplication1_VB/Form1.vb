Imports DataOperations_VB
Public Class Form1
    ' VB.NET
    Private Da As New DataAccess
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' C#
        Dim DTDFinder As New DataTableDuplicateFinder

        DataGridView1.DataSource = Da.AllCustomersDataDataTable
        DataGridView1.ExpandColumns()

        DataGridView2.DataSource = Da.DuplicatesDataDataTable
        DataGridView2.ExpandColumns()

        DataGridView3.DataSource = DTDFinder.GetDuplicates
        DataGridView3.ExpandColumns()

    End Sub
    Private Sub cmdDemonstrateDuplicateRowCheck_Click(sender As Object, e As EventArgs) Handles cmdDemonstrateDuplicateRowCheck.Click

        Dim sb As New System.Text.StringBuilder

        Dim Customers = Da.DoesRowExistsTest()

        For Each Customer In Customers
            If Customer.Exists Then
                sb.AppendLine(Customer.AlreadyExistsData)
            Else
                sb.AppendLine(Customer.DoesNotExistsData)
            End If
        Next

        MessageBox.Show(sb.ToString)

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
