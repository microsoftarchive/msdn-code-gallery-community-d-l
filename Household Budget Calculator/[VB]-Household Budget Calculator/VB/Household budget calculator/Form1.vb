Imports System.Globalization
Imports System.Drawing.Drawing2D

<System.Serializable()> Public Class Form1

#Region "     Variables"

    Dim propertiesDictionary As New Dictionary(Of String, Decimal)

    Public props As New properties

    Dim barColors() As Color = {Color.FromArgb(215, 215, 195), Color.FromArgb(200, 220, 240), _
                                Color.FromArgb(210, 220, 230), Color.FromArgb(255, 225, 215), _
                                Color.FromArgb(245, 245, 225), Color.FromArgb(235, 225, 235), _
                                Color.FromArgb(220, 240, 245), Color.FromArgb(255, 240, 225), _
                                Color.FromArgb(200, 240, 240), Color.FromArgb(170, 175, 195)}

    Dim rgns(9) As GraphicsPath

    Dim openFileName As String = "Untitled.budget"

    Private Structure openedState
        Dim d1 As Decimal
        Dim d2 As Decimal
        Dim d3 As Decimal
        Dim d4 As Decimal
        Dim d5 As Decimal
        Dim d6 As Decimal
        Dim d7 As Decimal
        Dim d8 As Decimal
        Dim d9 As Decimal
        Dim d10 As Decimal
    End Structure

    Dim original As New openedState

#End Region

#Region "     Form"

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If hasChanged() Then
            Dim response As MsgBoxResult = MsgBox("Budget has changes. Save it now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
            If response = MsgBoxResult.Yes Then
                SaveAsToolStripMenuItem.PerformClick()
            ElseIf response = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PropertyGrid1.SelectedObject = props
        propertiesDictionary.Add("Total Income", 0)
        propertiesDictionary.Add("Household", 0)
        propertiesDictionary.Add("Transport", 0)
        propertiesDictionary.Add("Finance", 0)
        propertiesDictionary.Add("Leisure", 0)
        propertiesDictionary.Add("Regular Bills", 0)
        propertiesDictionary.Add("Insurance", 0)
        propertiesDictionary.Add("Children", 0)
        propertiesDictionary.Add("Other Bills", 0)
        propertiesDictionary.Add("Remaining", 0)

        original.d1 = 0
        original.d2 = 0
        original.d3 = 0
        original.d4 = 0
        original.d5 = 0
        original.d6 = 0
        original.d7 = 0
        original.d8 = 0
        original.d9 = 0
        original.d10 = 0

        Me.Text = String.Format("{0} - Household Budget Calculator", openFileName)

        AddHandler props.propertiesChanged, AddressOf props_propertiesChanged

        If My.Settings.recentFiles Is Nothing Then
            My.Settings.recentFiles = New Specialized.StringCollection
        End If

        reOrderRecentFiles()

        If Not IO.Directory.Exists(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Saved Budgets")) Then
            IO.Directory.CreateDirectory(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Saved Budgets"))
        End If

    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawLine(Pens.Black, PictureBox1.Left, PictureBox1.Bottom, PictureBox1.Left + 490, PictureBox1.Bottom)
    End Sub

#End Region

#Region "     Methods/Functions"

    Private Function hasChanged() As Boolean
        Return original.d1 <> propertiesDictionary("Total Income") OrElse _
                    original.d2 <> propertiesDictionary("Household") OrElse _
                    original.d3 <> propertiesDictionary("Transport") OrElse _
                    original.d4 <> propertiesDictionary("Finance") OrElse _
                    original.d5 <> propertiesDictionary("Leisure") OrElse _
                    original.d6 <> propertiesDictionary("Regular Bills") OrElse _
                    original.d7 <> propertiesDictionary("Insurance") OrElse _
                    original.d8 <> propertiesDictionary("Children") OrElse _
                    original.d9 <> propertiesDictionary("Other Bills") OrElse _
                    original.d10 <> propertiesDictionary("Remaining")
    End Function

    Private Sub reOrderRecentFiles()
        Dim hasItems As Boolean = False
        For x As Integer = FileToolStripMenuItem.DropDownItems.Count - 1 To 0 Step -1
            If FileToolStripMenuItem.DropDownItems(x).Tag IsNot Nothing Then
                FileToolStripMenuItem.DropDownItems.RemoveAt(x)
                hasItems = True
            End If
        Next
        If hasItems Then
            FileToolStripMenuItem.DropDownItems.RemoveAt(2)
        End If
        For x As Integer = My.Settings.recentFiles.Count - 1 To 0 Step -1
            If My.Settings.recentFiles(x).Trim = "" Then
                My.Settings.recentFiles.RemoveAt(x)
            End If
        Next
        Dim insertAt As Integer = 3
        If My.Settings.recentFiles.Count > 0 Then
            Dim tss As New ToolStripSeparator
            FileToolStripMenuItem.DropDownItems.Insert(3, tss)
        End If
        For x As Integer = My.Settings.recentFiles.Count - 1 To 0 Step -1
            Dim tsi As New ToolStripMenuItem(IO.Path.GetFileName(My.Settings.recentFiles(x)), Nothing, AddressOf recentFile_Clicked) With {.Tag = My.Settings.recentFiles(x)}
            FileToolStripMenuItem.DropDownItems.Insert(insertAt, tsi)
            insertAt += 1
        Next
    End Sub

    Private Sub openBudget(ByVal fileName As String)

        If hasChanged() Then
            Dim response As MsgBoxResult = MsgBox("Budget has changes. Save it now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
            If response = MsgBoxResult.Yes Then
                SaveAsToolStripMenuItem.PerformClick()
            ElseIf response = MsgBoxResult.Cancel Then
                Return
            End If
        End If

        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fs As New IO.FileStream(fileName, IO.FileMode.Open)
        props = DirectCast(formatter.Deserialize(fs), properties)
        fs.Close()
        openFileName = IO.Path.GetFileName(fileName)
        PropertyGrid1.SelectedObject = props

        props.removeEventHandlers()
        props.addEventHandlers()

        AddHandler props.propertiesChanged, AddressOf props_propertiesChanged

        Dim decValue As Decimal
        Decimal.TryParse(props.totalIncome, NumberStyles.Currency, CultureInfo.CurrentCulture, decValue)
        propertiesDictionary("Total Income") = decValue
        propertiesDictionary("Household") = props.houseHold.totalHousehold
        propertiesDictionary("Transport") = props.transport.totalTransport
        propertiesDictionary("Finance") = props.finance.totalFinance
        propertiesDictionary("Leisure") = props.leisure.totalLeisure
        propertiesDictionary("Regular Bills") = props.regularBills.totalRegularBills
        propertiesDictionary("Insurance") = props.insurance.totalInsurance
        propertiesDictionary("Children") = props.children.totalChildren
        propertiesDictionary("Other Bills") = props.otherBills.totalOtherBills
        If propertiesDictionary("Total Income") <> 0 Then
            propertiesDictionary("Remaining") = propertiesDictionary("Total Income") - propertiesDictionary.Values.Skip(1).Take(8).Sum
        Else
            propertiesDictionary("Remaining") = 0
        End If
        PictureBox1.Invalidate()

        original.d1 = propertiesDictionary("Total Income")
        original.d2 = propertiesDictionary("Household")
        original.d3 = propertiesDictionary("Transport")
        original.d4 = propertiesDictionary("Finance")
        original.d5 = propertiesDictionary("Leisure")
        original.d6 = propertiesDictionary("Regular Bills")
        original.d7 = propertiesDictionary("Insurance")
        original.d8 = propertiesDictionary("Children")
        original.d9 = propertiesDictionary("Other Bills")
        original.d10 = propertiesDictionary("Remaining")

        Me.Text = String.Format("{0} - Household Budget Calculator", openFileName)
    End Sub

#End Region

#Region "     Menus"

    Private Sub recentFile_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tsi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        If Not IO.File.Exists(tsi.Tag.ToString) Then
            My.Settings.recentFiles.Remove(tsi.Tag.ToString)
            reOrderRecentFiles()
        Else
            openBudget(tsi.Tag.ToString)
            My.Settings.recentFiles.Remove(tsi.Tag.ToString)
            My.Settings.recentFiles.Add(tsi.Tag.ToString)
            reOrderRecentFiles()
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

        If hasChanged() Then
            Dim response As MsgBoxResult = MsgBox("Budget has changes. Save it now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
            If response = MsgBoxResult.Yes Then
                SaveAsToolStripMenuItem.PerformClick()
            ElseIf response = MsgBoxResult.Cancel Then
                Return
            End If
        End If

        props = New properties
        AddHandler props.propertiesChanged, AddressOf props_propertiesChanged
        PropertyGrid1.SelectedObject = props
        propertiesDictionary("Total Income") = 0
        propertiesDictionary("Household") = 0
        propertiesDictionary("Transport") = 0
        propertiesDictionary("Finance") = 0
        propertiesDictionary("Leisure") = 0
        propertiesDictionary("Regular Bills") = 0
        propertiesDictionary("Insurance") = 0
        propertiesDictionary("Children") = 0
        propertiesDictionary("Other Bills") = 0
        propertiesDictionary("Remaining") = 0
        PictureBox1.Invalidate()

        original.d1 = 0
        original.d2 = 0
        original.d3 = 0
        original.d4 = 0
        original.d5 = 0
        original.d6 = 0
        original.d7 = 0
        original.d8 = 0
        original.d9 = 0
        original.d10 = 0

        openFileName = "Untitled.budget"
        Me.Text = String.Format("{0} - Household Budget Calculator", openFileName)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

        Dim ofd As New OpenFileDialog With { _
        .Filter = "Household Budget files (*.budget)|*.budget", _
        .FilterIndex = 0, _
        .Title = "Choose Budget file", _
        .InitialDirectory = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Saved Budgets")}

        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            openBudget(ofd.FileName)
            My.Settings.recentFiles.Remove(ofd.FileName)
            My.Settings.recentFiles.Add(ofd.FileName)
            reOrderRecentFiles()
        End If

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog With { _
        .Filter = "Household Budget files (*.budget)|*.budget", _
        .FilterIndex = 0, _
        .Title = "Save Budget file", _
        .InitialDirectory = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "Saved Budgets"), _
        .AddExtension = True, _
        .FileName = openFileName}

        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            props.removeEventHandlers()
            RemoveHandler props.propertiesChanged, AddressOf props_propertiesChanged
            Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim fs As New IO.FileStream(sfd.FileName, IO.FileMode.Create)
            formatter.Serialize(fs, props)
            fs.Close()
            openFileName = IO.Path.GetFileName(sfd.FileName)
            props.addEventHandlers()
            AddHandler props.propertiesChanged, AddressOf props_propertiesChanged
            If Not My.Settings.recentFiles.Contains(sfd.FileName) Then
                My.Settings.recentFiles.Add(sfd.FileName)
                If My.Settings.recentFiles.Count = 13 Then My.Settings.recentFiles.RemoveAt(0)
                reOrderRecentFiles()
            End If
            original.d1 = propertiesDictionary("Total Income")
            original.d2 = propertiesDictionary("Household")
            original.d3 = propertiesDictionary("Transport")
            original.d4 = propertiesDictionary("Finance")
            original.d5 = propertiesDictionary("Leisure")
            original.d6 = propertiesDictionary("Regular Bills")
            original.d7 = propertiesDictionary("Insurance")
            original.d8 = propertiesDictionary("Children")
            original.d9 = propertiesDictionary("Other Bills")
            original.d10 = propertiesDictionary("Remaining")
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

#End Region

#Region "     PictureBox1"

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If rgns.Any(Function(rgn) rgn IsNot Nothing AndAlso rgn.IsVisible(e.X, -(PictureBox1.Height - e.Y))) Then
            Dim index As Integer = Array.FindLastIndex(rgns, Function(rgn) rgn IsNot Nothing AndAlso rgn.IsVisible(e.X, -(PictureBox1.Height - e.Y)))
            ToolStripStatusLabel1.Text = String.Format("{0}: {1:c2}", propertiesDictionary.ElementAt(index).Key, propertiesDictionary.ElementAt(index).Value)
        Else
            ToolStripStatusLabel1.Text = ""
        End If
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        If propertiesDictionary("Total Income") <> 0 Then

            Dim totalHeight As Integer = CInt(propertiesDictionary("Total Income"))
            Dim topHeight As Integer = CInt(totalHeight * 0.05)

            ' Flip vertically and scale to fit.
            Dim scalex As Single = 20.0F
            Dim scaley As Single = CSng(-PictureBox1.Height / (totalHeight * 1.5))
            e.Graphics.ScaleTransform(scalex, scaley, MatrixOrder.Append)

            ' Translate so (0, MAX_VALUE) maps to the origin.
            e.Graphics.TranslateTransform(0, PictureBox1.Height, MatrixOrder.Append)

            Dim front() As PointF = { _
            New PointF(0, 0), _
            New PointF(0, totalHeight), _
            New PointF(2, totalHeight), _
            New PointF(2, 0), _
            New PointF(0, 0) _
            }

            Dim top() As PointF = { _
                New PointF(0, totalHeight), _
                New PointF(1, totalHeight + topHeight), _
                New PointF(3, totalHeight + topHeight), _
                New PointF(2, totalHeight), _
                New PointF(0, totalHeight) _
            }

            Dim right() As PointF = { _
                New PointF(2, totalHeight), _
                New PointF(3, totalHeight + topHeight), _
                New PointF(3, topHeight), _
                New PointF(2, 0), _
                New PointF(2, totalHeight) _
            }

            ' Draw the histogram.
            For x As Integer = 0 To propertiesDictionary.Count - 1
                rgns(x) = New GraphicsPath
                Dim value As Integer = CInt(propertiesDictionary.ElementAt(x).Value)
                If value > 0 Then
                    Dim offsetX As Single = CSng(x * 2.5)

                    Dim barFront() As PointF = Array.ConvertAll(front, Function(pf) New PointF(pf.X + offsetX, pf.Y))
                    barFront(1).Y = value
                    barFront(2).Y = value
                    e.Graphics.FillPolygon(New SolidBrush(barColors(x)), barFront)
                    e.Graphics.DrawPolygon(New Pen(Color.Black, 0), barFront)

                    rgns(x).AddPolygon(Array.ConvertAll(barFront, Function(pf) New PointF(pf.X * scalex, pf.Y * scaley)))

                    Dim barTop() As PointF = Array.ConvertAll(top, Function(pf) New PointF(pf.X + offsetX, value))
                    barTop(1).Y += topHeight
                    barTop(2).Y += topHeight
                    e.Graphics.FillPolygon(New SolidBrush(barColors(x)), barTop)
                    e.Graphics.DrawPolygon(New Pen(Color.Black, 0), barTop)

                    rgns(x).AddPolygon(Array.ConvertAll(barTop, Function(pf) New PointF(pf.X * scalex, pf.Y * scaley)))

                    Dim barRight() As PointF = Array.ConvertAll(right, Function(pf) New PointF(pf.X + offsetX, pf.Y))
                    barRight(0).Y = value
                    barRight(1).Y = value + topHeight
                    barRight(4).Y = value
                    e.Graphics.FillPolygon(New SolidBrush(barColors(x)), barRight)
                    e.Graphics.DrawPolygon(New Pen(Color.Black, 0), barRight)

                    rgns(x).AddPolygon(Array.ConvertAll(barRight, Function(pf) New PointF(pf.X * scalex, pf.Y * scaley)))

                End If
            Next

            e.Graphics.ResetTransform()

        Else
            Array.Clear(rgns, 0, 10)
        End If
    End Sub

#End Region

#Region "     PropertyGrid"

    Private Sub props_propertiesChanged(ByVal e As propertiesChangedEventArgs)
        propertiesDictionary(e.propName) = e.newValue
        If propertiesDictionary("Total Income") <> 0 Then
            propertiesDictionary("Remaining") = propertiesDictionary("Total Income") - propertiesDictionary.Values.Skip(1).Take(8).Sum
        Else
            propertiesDictionary("Remaining") = 0
        End If
        PictureBox1.Invalidate()
    End Sub

#End Region

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
End Class
