Imports ExtendedDataGridView
Imports System.Numerics

Public Class frmMain
    Dim x As Integer
    Dim r As New Random

    Dim dt As New DataTable
    Dim operands(,) As String = {{"+", "-"}, {"/", "*"}}

    Dim answers As List(Of Integer)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDGV1()
        ExtendedDataGridView1.Columns(2).DefaultCellStyle.BackColor = Color.FromArgb(235, 240, 250)
        ExtendedDataGridView1.Rows(1).Cells(2).Style.BackColor = Color.FromArgb(230, 250, 175)
        loadDGV2()
        For Each row As DataGridViewRow In ExtendedDataGridView2.Rows
            If row.Index = ExtendedDataGridView2.NewRowIndex Then Continue For
            row.Cells(2).Value = "Button" & (row.Index + 1).ToString
        Next
        loadDGV3()
        loadDGV4()
    End Sub

#Region "     loadDGVs"

    Public Sub loadDGV1()
        answers = New List(Of Integer)
        ExtendedDataGridView1.Rows.Clear()
        ExtendedDataGridView1.Rows.Add(10)

        For i As Integer = 1 To 10
            Dim i1 As Integer = r.Next(2, 11)
            Dim i2 As Integer = r.Next(2, 11)
            Dim i3 As Integer = r.Next(2, 11)

            Do While i2 = i1
                i2 = r.Next(1, 11)
            Loop

            Do While i3 = i1 Or i3 = i2
                i3 = r.Next(1, 11)
            Loop

            'Label2.Text
            Dim s1 As String = operands(0, r.Next(0, 2)) & " " & i1.ToString
            'Label3.Text
            Dim s2 As String = operands(1, r.Next(0, 2)) & " " & i2.ToString
            'Label4.Text
            Dim s3 As String = operands(0, r.Next(0, 2)) & " " & i3.ToString

            x = r.Next(1, 101)
            Do While CDec(dt.Compute(String.Format("((({0} {1}) {2}) {3})", x.ToString, s1, s2, s3), Nothing)) Mod 1 <> 0
                x = r.Next(1, 101)
            Loop

            ExtendedDataGridView1.Rows(i - 1).Cells(0).Value = String.Format("x {0} {1} {2} = {3}", s1, s2, s3, CInt(dt.Compute(String.Format("((({0} {1}) {2}) {3})", x.ToString, s1, s2, s3), Nothing)))
            ExtendedDataGridView1.Rows(i - 1).Tag = x
            answers.Add(x)
        Next

        answers = answers.OrderBy(Function(x1) r.NextDouble).Distinct.ToList
        DirectCast(ExtendedDataGridView1.Columns(1), DataGridViewComboBoxColumn).ValueType = GetType(Integer)
        DirectCast(ExtendedDataGridView1.Columns(1), DataGridViewComboBoxColumn).DataSource = answers
    End Sub

    Public Sub loadDGV2()
        ExtendedDataGridView2.Rows.Add(10)
        For y As Integer = 0 To 9
            ExtendedDataGridView2.Rows(y).Cells(0).Value = y + 2
            ExtendedDataGridView2.Rows(y).Cells(1).Value = (y + 2).ToString & " ^ 1"
        Next
    End Sub

    Public Sub loadDGV3()
        ExtendedDataGridView3.Rows.Add(10)
        ExtendedDataGridView3.Rows(0).SetValues("Google", "https://www.google.co.uk")
        ExtendedDataGridView3.Rows(1).SetValues("bing", "http://www.bing.com/")
        ExtendedDataGridView3.Rows(2).SetValues("Yahoo", "https://uk.yahoo.com/?p=us")
        ExtendedDataGridView3.Rows(3).SetValues("altavista", "https://search.yahoo.com/?fr=altavista")
        ExtendedDataGridView3.Rows(4).SetValues("excite", "http://www.excite.com/")
        ExtendedDataGridView3.Rows(5).SetValues("Go.com", "http://go.com/")
        ExtendedDataGridView3.Rows(6).SetValues("HotBot", "http://www.hotbot.com/")
        ExtendedDataGridView3.Rows(7).SetValues("Galaxy", "http://www.galaxy.com/")
        ExtendedDataGridView3.Rows(8).SetValues("search.aol", "http://search.aol.com/aol/webhome")
        ExtendedDataGridView3.Rows(9).SetValues("GigaBlast", "http://www.gigablast.com/")
    End Sub

    Public Sub loadDGV4()
        For x As Integer = Asc("A") To Asc("A") + 25
            ExtendedDataGridView4.Columns.Add("column" & (x - Asc("A") + 1).ToString, Chr(x).ToString)
        Next
        ExtendedDataGridView4.Rows.Add(100)
        ExtendedDataGridView4.RowHeadersWidth = 60
        For y As Integer = 0 To 99
            ExtendedDataGridView4.Rows(y).HeaderCell.Value = (y + 1).ToString
        Next
        For y As Integer = 1 To 100
            For x As Integer = 1 To 26
                ExtendedDataGridView4.Rows(y - 1).Cells(x - 1).Value = $"R{y}C{x}"
            Next
        Next
    End Sub

#End Region

    Private Sub ExtendedDataGridView1_cellCheckedChanged(sender As Object, e As CheckBoxChangedEventArgs) Handles ExtendedDataGridView1.cellCheckedChanged
        ExtendedDataGridView1(1, e.rowIndex).ReadOnly = e.newValue
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'preview
        DirectCast(TabControl1.SelectedTab.Controls(0), ExtendedDataGridView.ExtendedDataGridView).PreviewPrint()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'print
        DirectCast(TabControl1.SelectedTab.Controls(0), ExtendedDataGridView.ExtendedDataGridView).Print()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'save
        DirectCast(TabControl1.SelectedTab.Controls(0), ExtendedDataGridView.ExtendedDataGridView).SaveasCSV()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'check answers
        For Each row As DataGridViewRow In ExtendedDataGridView1.Rows
            If row.Index = ExtendedDataGridView1.NewRowIndex Then Continue For
            Dim correctAnswer As Integer = DirectCast(row.Tag, Integer)
            Dim userAnswer As Integer
            If row.Cells(1).Value IsNot Nothing Then
                userAnswer = CInt(row.Cells(1).Value.ToString)
            Else
                row.Cells(3).Value = My.Resources.cross
                Continue For
            End If
            If correctAnswer = userAnswer Then
                row.Cells(3).Value = My.Resources.tick
            Else
                row.Cells(3).Value = My.Resources.cross
            End If
        Next
    End Sub

    Private Sub ExtendedDataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ExtendedDataGridView2.CellContentClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse e.RowIndex = ExtendedDataGridView2.NewRowIndex Then Return
        If TypeOf ExtendedDataGridView2(e.ColumnIndex, e.RowIndex) Is DataGridViewButtonCell Then
            Dim value As BigInteger = BigInteger.Parse(ExtendedDataGridView2(0, e.RowIndex).Value.ToString)
            ExtendedDataGridView2(0, e.RowIndex).Value = BigInteger.Pow(value, 2)
            ExtendedDataGridView2(1, e.RowIndex).Value = value.ToString & " ^ 2"
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Button4.Visible = TabControl1.SelectedIndex = 0
    End Sub

    Private Sub ExtendedDataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ExtendedDataGridView3.CellContentClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse e.RowIndex = ExtendedDataGridView3.NewRowIndex Then Return
        If e.ColumnIndex = 1 Then
            Dim o As Object = ExtendedDataGridView3(1, e.RowIndex).Value
            If o IsNot Nothing Then
                Dim uri As Uri = Nothing
                If Uri.TryCreate(o.ToString, UriKind.Absolute, uri) Then
                    Process.Start(uri.ToString)
                End If
            End If
        End If
    End Sub

    Private Sub ExtendedDataGridView1_cellSelectedIndexChanged(sender As Object, e As ComboIndexChangedEventArgs) Handles ExtendedDataGridView1.cellSelectedIndexChanged

    End Sub
End Class
