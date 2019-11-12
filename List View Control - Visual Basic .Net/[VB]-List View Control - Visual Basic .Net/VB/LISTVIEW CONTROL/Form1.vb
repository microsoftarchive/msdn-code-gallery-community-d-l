Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showListViewLargeIcon()
        showListViewSmallIcon()
        showListviewList()
        showListViewTitle()
        showListViewDetails()
    End Sub

   
    Private Sub showListViewLargeIcon()
        With ListView1
            .View = View.LargeIcon
            .FullRowSelect = True
            .Columns.Clear()
            .Items.Clear()

            .Items.Add("Hello", 0)
            .Items.Add("World", 0)
        End With
    End Sub

    Private Sub showListViewSmallIcon()
        With ListView2
            .View = View.SmallIcon
            .FullRowSelect = True
            .Columns.Clear()
            .Items.Clear()

            .Items.Add("Hello", 0)
            .Items.Add("World", 0)
        End With
    End Sub

    Private Sub showListviewList()
        With ListView3
            .View = View.List
            .FullRowSelect = True
            .Columns.Clear()
            .Items.Clear()

            .Items.Add("Hello", 0)
            .Items.Add("World", 0)
        End With
    End Sub

    Private Sub showListViewTitle()
        With ListView4
            .View = View.Tile
            .FullRowSelect = True
            .Columns.Clear()
            .Items.Clear()


            .Columns.Add("Hello")
            .Columns.Add("World")

            .Items.Add("Hello", 0).SubItems.Add("World")
            .Items.Add("World", 0).SubItems.Add("Hello")
        End With
    End Sub

    Private Sub showListViewDetails()
        Dim LvwItems As ListViewItem
        With ListView5
            .View = View.Details
            .FullRowSelect = True
            .Columns.Clear()
            .Items.Clear()

            '----Header
            .Columns.Add("No")
            .Columns.Add("Description")
            .Columns.Add("Data")

            '---Details
            Dim i As Integer
            For i = 1 To .Columns.Count
                LvwItems = New ListViewItem(i.ToString, 0)
                LvwItems.SubItems.Add("Hello" & i)
                LvwItems.SubItems.Add("World" & i)
                .Items.Add(LvwItems)
            Next

        End With
    End Sub
End Class
