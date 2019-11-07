Imports System.IO
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtAddtoListbox.Text = "" Then
            MsgBox("Enter some data")
        Else

            ListBox1.Items.Add(txtAddtoListbox.Text.Trim())

        End If

        txtAddtoListbox.Text = ""
        txtAddtoListbox.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try


        
        Dim fpath As String
        fpath = AppDomain.CurrentDomain.BaseDirectory
        Dim filepath As String
        filepath = fpath & "txtdetails.txt"
        Dim details As String
        If ListBox1.Items.Count > 0 Then
            details = ListBox1.Items(0)
            Dim i As Integer
            For i = 1 To ListBox1.Items.Count - 1

                details = details & vbCrLf & ListBox1.Items(i)

            Next




        End If
            My.Computer.FileSystem.WriteAllText(filepath, details, False)
            MsgBox("Values Inserted Successfully")
        Catch ex As Exception
            MsgBox("Values Can't be inserted this time")
        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fpath As String
        Dim splitdata
        fpath = AppDomain.CurrentDomain.BaseDirectory
        Dim filepath As String
        filepath = fpath & "txtdetails.txt"
        Dim details As String
        details = My.Computer.FileSystem.ReadAllText(filepath)
        splitdata = Split(details, vbCrLf)
        Dim i As Integer
        For i = 0 To UBound(splitdata)
            ListBox1.Items.Add(splitdata(i))
        Next


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If ListBox1.SelectedItem = "" Then
            MsgBox("please select an item")

        Else

            If ListBox1.Items.Count > 0 Then
                If MessageBox.Show("R U Sure u want to remove items", "message", MessageBoxButtons.OKCancel) = MsgBoxResult.Ok Then
                    ListBox1.Items.Remove(ListBox1.SelectedItem.ToString())
                Else

                End If


            End If

        End If

    End Sub
End Class
