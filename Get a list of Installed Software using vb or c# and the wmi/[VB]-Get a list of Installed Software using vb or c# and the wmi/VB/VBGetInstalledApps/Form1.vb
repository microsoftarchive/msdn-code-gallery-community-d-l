Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSoftwareList()
    End Sub

    Private Sub LoadSoftwareList()
        ListBox1.Items.Clear()
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject

        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Product")

        moReturn = moSearch.Get
        For Each mo In moReturn
            ListBox1.Items.Add(mo("Name").ToString)
        Next

    End Sub
End Class
