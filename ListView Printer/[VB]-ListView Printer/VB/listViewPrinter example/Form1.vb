Public Class Form1

    Dim groupNames() As String = {"Group1", "Group2", "Group3"}
    Dim randomObject As New Random

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For r As Integer = 1 To 250
            Dim randomGroupName As String = groupNames(randomObject.Next(0, 3))
            Dim group As New ListViewGroup(randomGroupName, randomGroupName)
            If Not ListView1.Groups.Cast(Of ListViewGroup).Any(Function(lvg) lvg.Name = randomGroupName) Then
                ListView1.Groups.Add(group)
            End If

            Dim item As ListViewItem = ListView1.Items.Add( _
                                        New ListViewItem(New String() {String.Format("A{0}", r), _
                                                                       String.Format("B{0}", r), _
                                                                       String.Format("C{0}", r), _
                                                                       String.Format("D{0}", r), _
                                                                       String.Format("E{0}", r), _
                                                                       String.Format("F{0}", r), _
                                                                       String.Format("G{0}", r), _
                                                                       String.Format("H{0}", r), _
                                                                       String.Format("I{0}", r), _
                                                                       String.Format("J{0}", r), _
                                                                       String.Format("K{0}", r), _
                                                                       String.Format("L{0}", r), _
                                                                       String.Format("M{0}", r), _
                                                                       String.Format("N{0}", r), _
                                                                       String.Format("O{0}", r), _
                                                                       String.Format("P{0}", r), _
                                                                       String.Format("Q{0}", r), _
                                                                       String.Format("R{0}", r), _
                                                                       String.Format("S{0}", r), _
                                                                       String.Format("T{0}", r), _
                                                                       String.Format("U{0}", r), _
                                                                       String.Format("V{0}", r), _
                                                                       String.Format("W{0}", r), _
                                                                       String.Format("X{0}", r), _
                                                                       String.Format("Y{0}", r), _
                                                                       String.Format("Z{0}", r)}))

            ListView1.Groups.Cast(Of ListViewGroup).First(Function(lvg) lvg.Name = randomGroupName).Items.Add(item)
        Next

        Dim listGroups As List(Of ListViewGroup) = ListView1.Groups.Cast(Of ListViewGroup).ToList
        listGroups.Sort(New groupSorter)
        ListView1.Groups.Clear()
        ListView1.Groups.AddRange(listGroups.ToArray)

        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        For x As Integer = 0 To ListView1.Columns.Count - 1
            ListView1.Columns(x).Width += 12
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim printer As New listViewPrinter(ListView1, New Point(50, 50), chkBorder.Checked, ListView1.Groups.Count > 0, hLines.Checked, vLines.Checked, "titleText")
        printer.print()
    End Sub

End Class

Public Class groupSorter
    Implements IComparer(Of ListViewGroup)

    Public Function Compare(ByVal x As System.Windows.Forms.ListViewGroup, ByVal y As System.Windows.Forms.ListViewGroup) As Integer Implements System.Collections.Generic.IComparer(Of System.Windows.Forms.ListViewGroup).Compare
        Return x.Name.CompareTo(y.Name)
    End Function

End Class
