Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Management

Public Class altPrintDialog

    Dim document As PrintDocument
    Dim dt As New DataTable

    Dim states As New Dictionary(Of Integer, String) From {{1, "Other"}, {2, "Unknown"}, {3, "Idle"}, {4, "Printing"},
                                                                 {5, "Warmup"}, {6, "Stopped Printing"}, {7, "Offline"}}

    Dim ep As New ErrorProvider

    Public Property maxPortraitPages As Integer
    Public Property maxLandscapePages As Integer


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="document"></param>
    Public Sub New(document As PrintDocument, maxPortraitPages As Integer, maxLandscapePages As Integer)
        dt.Columns.Add("Name")
        dt.Columns.Add("Status")
        dt.Columns.Add("Type")
        dt.Columns.Add("Where")

        queryPrinters(dt)

        Me.document = document
        Me.maxPortraitPages = maxPortraitPages
        Me.maxLandscapePages = maxLandscapePages
        Dim selectedPrinter As String = Me.document.PrinterSettings.PrinterName

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "Name"

        Label7.DataBindings.Add("Text", dt, "Status")
        Label8.DataBindings.Add("Text", dt, "Type")
        Label9.DataBindings.Add("Text", dt, "Where")

        ComboBox1.SelectedIndex = ComboBox1.FindStringExact(selectedPrinter)

        NumericUpDown4.Value = document.DefaultPageSettings.Margins.Left
        NumericUpDown5.Value = document.DefaultPageSettings.Margins.Right
        NumericUpDown6.Value = document.DefaultPageSettings.Margins.Top
        NumericUpDown7.Value = document.DefaultPageSettings.Margins.Bottom

        RadioButton4.Checked = Me.document.DefaultPageSettings.Landscape
        NumericUpDown3.Maximum = If(RadioButton4.Checked, maxLandscapePages, maxPortraitPages)
        NumericUpDown2.Maximum = NumericUpDown3.Maximum

        NumericUpDown3.Value = NumericUpDown3.Maximum
        NumericUpDown2.Value = 1

        Me.document.PrinterSettings.FromPage = 1
        Me.document.PrinterSettings.ToPage = CInt(NumericUpDown3.Value)

        Me.document.PrinterSettings.Collate = False

    End Sub

    Private Sub queryPrinters(ByRef dt As DataTable)
        Dim printerQuery = New ManagementObjectSearcher("SELECT * from Win32_Printer")
        For Each p In printerQuery.Get()
            Dim Name As String = p.GetPropertyValue("Name").ToString
            Dim status As String = states(CInt(p.GetPropertyValue("PrinterStatus").ToString))
            Dim [type] As String = p.GetPropertyValue("deviceID").ToString
            Dim [where] As String = p.GetPropertyValue("portName").ToString
            dt.Rows.Add(Name, status, [type], [where])
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            PictureBox1.Image = My.Resources.a
            CheckBox1.Top += 3
        Else
            PictureBox1.Image = My.Resources.b
            CheckBox1.Top -= 3
        End If
        Me.document.PrinterSettings.Collate = CheckBox1.Checked
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim drv As DataRowView = DirectCast(ComboBox1.SelectedItem, DataRowView)
        Me.document.PrinterSettings.PrinterName = drv.Item("Name").ToString
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value > 1 Then
            CheckBox1.Enabled = True
        Else
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        End If
        Me.document.PrinterSettings.Copies = CShort(NumericUpDown1.Value)
    End Sub

    Private Sub RadioButtonsPageSelection_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        Label2.Enabled = RadioButton2.Checked
        NumericUpDown2.Enabled = RadioButton2.Checked
        Label3.Enabled = RadioButton2.Checked
        NumericUpDown3.Enabled = RadioButton2.Checked
        If RadioButton1.Checked Then
            Me.document.PrinterSettings.FromPage = 1
            Me.document.PrinterSettings.ToPage = CInt(NumericUpDown3.Maximum)
        Else
            Me.document.PrinterSettings.FromPage = CInt(NumericUpDown2.Value)
            Me.document.PrinterSettings.ToPage = CInt(NumericUpDown3.Value)
        End If
    End Sub

    Private Sub RadioButtonsOrientation_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        Me.document.DefaultPageSettings.Landscape = RadioButton4.Checked
        NumericUpDown3.Maximum = If(RadioButton4.Checked, maxLandscapePages, maxPortraitPages)
        NumericUpDown3.Value = If(RadioButton1.Checked, CInt(NumericUpDown3.Maximum), NumericUpDown3.Value)
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        Me.document.PrinterSettings.FromPage = CInt(NumericUpDown2.Value)
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        NumericUpDown2.Maximum = NumericUpDown3.Value
        Me.document.PrinterSettings.ToPage = CInt(NumericUpDown3.Value)
    End Sub

    Private Sub NumericUpDowns_TextChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.TextChanged, NumericUpDown2.TextChanged, NumericUpDown3.TextChanged
        Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
        Dim value As Integer
        If Integer.TryParse(nud.Text, value) Then
            If Not Enumerable.Range(1, CInt(nud.Maximum)).Contains(value) Then
                ep.SetError(nud, $"Valid Range: 1 to {CInt(nud.Maximum)}")
            Else
                ep.Clear()
            End If
        End If
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged
        Me.document.DefaultPageSettings.Margins.Left = CInt(NumericUpDown4.Value)
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged
        Me.document.DefaultPageSettings.Margins.Right = CInt(NumericUpDown5.Value)
    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged
        Me.document.DefaultPageSettings.Margins.Top = CInt(NumericUpDown6.Value)
    End Sub

    Private Sub NumericUpDown7_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown7.ValueChanged
        Me.document.DefaultPageSettings.Margins.Bottom = CInt(NumericUpDown7.Value)
    End Sub

End Class