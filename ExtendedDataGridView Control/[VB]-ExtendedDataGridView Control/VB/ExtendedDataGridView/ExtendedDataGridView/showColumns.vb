Imports System.Windows.Forms

Public Class showColumns

    Private dgv As DataGridView
    Private cms As ContextMenuStrip

    Public Sub New(ByVal dgv As DataGridView, ByVal cms As ContextMenuStrip)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.dgv = dgv
        Me.cms = cms

        For x As Integer = 0 To dgv.Columns.Count - 1
            If Not dgv.Columns(x).Visible AndAlso TypeOf dgv.Columns(x).HeaderCell Is checkHideColumnHeaderCell Then
                ListBox1.Items.Add(dgv.Columns(x).HeaderText.Trim)
            End If
        Next

        Button1.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For x As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.GetSelected(x) Then
                Dim tempX As Integer = x
                DirectCast(dgv.Columns(Array.FindIndex(dgv.Columns.Cast(Of DataGridViewColumn).ToArray, Function(c) c.HeaderText.Trim.Equals(ListBox1.GetItemText(ListBox1.Items(tempX))))).HeaderCell, checkHideColumnHeaderCell).isChecked = True
            End If
        Next
        cms.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Button1.Enabled = ListBox1.SelectedItems.Count > 0
    End Sub

End Class
