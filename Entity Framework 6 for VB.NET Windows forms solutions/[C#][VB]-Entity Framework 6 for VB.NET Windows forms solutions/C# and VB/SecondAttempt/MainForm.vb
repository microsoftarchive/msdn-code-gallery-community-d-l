Imports BackendOperations
''' <summary>
''' Load customers into DataGridView using a DTO
''' Note there is no sorting available in this version, will
''' later.
''' </summary>
Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ops As New Operations
        DataGridView1.DataSource = ops.LoadCustomersDTO
    End Sub
End Class
