
Imports System.IO
Imports tessnet2
Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class _0cr
    Public m_image As Bitmap
    Private cropped As Bitmap
    Shared English As String = "eng"
    Public fa1 As Boolean = False
    Shared WordList As List(Of tessnet2.Word)
    Shared oOCR As New tessnet2.Tesseract
    Public Shared Function OCR(ByVal bm As System.Drawing.Image, ByVal language As String, ByVal path As String) As String
        OCR = ""
        _0cr.PictureBox1.Update()
        _0cr.ProgressBar1.Value = 25
        If _0cr.RadioButton1.Checked = True Then
            oOCR.SetVariable("tessedit_char_whitelist", "0123456789")
        End If
        oOCR.Init(path, language, False)
        WordList = oOCR.DoOCR(bm, Rectangle.Empty)
        _0cr.ProgressBar1.Value = 40
        _0cr.PictureBox1.Image = bm
        _0cr.ProgressBar1.Value = 60
        Dim LineCount As Integer = tessnet2.Tesseract.LineCount(WordList)
        '_0cr.ProgressBar1.Maximum = 60 + LineCount
        For i As Integer = 0 To LineCount - 1
            OCR &= tessnet2.Tesseract.GetLineText(WordList, i) & vbCrLf
            '_0cr.ProgressBar1.Value = 60 + i
        Next
        _0cr.ProgressBar1.Value = 80
        _0cr.PictureBox1.Refresh()
        oOCR.Dispose()
       
    End Function

    
    Public Shared Function GetPDFIndex(ByRef imgOCR As System.Drawing.Image, ByVal language As String, ByVal path As String) As List(Of PDFWordIndex)
        GetPDFIndex = New List(Of PDFWordIndex)
        _0cr.ProgressBar1.Value = 50
        oOCR.Init(path, language, False)
     
        WordList = oOCR.DoOCR(imgOCR, Rectangle.Empty)
        _0cr.ProgressBar1.Value = 60
        If WordList IsNot Nothing Then
            For Each word As tessnet2.Word In WordList
                Dim pdfWordIndex As New PDFWordIndex
                pdfWordIndex.X = word.Left
                pdfWordIndex.Y = word.Top
                pdfWordIndex.Width = word.Right - word.Left
                pdfWordIndex.Height = word.Bottom - word.Top
                pdfWordIndex.Text = word.Text
                GetPDFIndex.Add(pdfWordIndex)
                _0cr.CheckedListBox1.Text = ""
                _0cr.CheckedListBox1.Items.Add(String.Format("X:{0}   Y:{1}   Width:{2}   Height:{3}   Text:{4}", pdfWordIndex.X, pdfWordIndex.Y, pdfWordIndex.Width, pdfWordIndex.Height, pdfWordIndex.Text))
            Next
        End If
    End Function
   
   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not TextBox2.Text = "" And Not m_image Is Nothing Then
            'ProgressBar1.Value = 25
            TextBox2.BackColor = Color.White
            RichTextBox1.AppendText(OCR(m_image, English, TextBox2.Text))
            'ProgressBar1.Value = 100
        Else
            TextBox2.BackColor = Color.LightPink
            If TextBox2.Text = "" Then
                TextBox2.BackColor = Color.White
                TextBox2.Text = "C:\temp\tessdata"
            End If
        End If
        'Dim g As Graphics = SplitContainer5.Panel2.CreateGraphics()
        'Dim rect1 As Rectangle = New Rectangle(TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        'g.DrawRectangle(Pens.Black, rect1)
        'SplitContainer5.Panel2.Update()
        ProgressBar1.Value = 0
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.FileName = ""
        'SplitContainer5.Panel2.Refresh()
        If (OpenFileDialog1.ShowDialog = DialogResult.OK) Then
            Button6_Click(sender, e)
            If CheckBox2.Checked Then
                image.Main()
                Button2.Update()
            End If
            If OpenFileDialog1.FileName.EndsWith(".TIF") Or OpenFileDialog1.FileName.EndsWith(".BMP") Or OpenFileDialog1.FileName.EndsWith(".GIF") Or OpenFileDialog1.FileName.EndsWith(".JPEG") Or OpenFileDialog1.FileName.EndsWith(".PNG") Or OpenFileDialog1.FileName.EndsWith(".TIFF") Or OpenFileDialog1.FileName.EndsWith(".JPG") _
              Or OpenFileDialog1.FileName.EndsWith(".TIF".ToLower) Or OpenFileDialog1.FileName.EndsWith(".BMP".ToLower) Or OpenFileDialog1.FileName.EndsWith(".GIF".ToLower) Or OpenFileDialog1.FileName.EndsWith(".JPEG".ToLower) Or OpenFileDialog1.FileName.EndsWith(".PNG".ToLower) Or OpenFileDialog1.FileName.EndsWith(".TIFF".ToLower) Or OpenFileDialog1.FileName.EndsWith(".JPG".ToLower) Then
                m_image = New Bitmap(OpenFileDialog1.FileName)
                RichTextBox1.Clear()

                If Not m_image Is Nothing Then
                    PictureBox2.Image = m_image
                End If
            


            SplitContainer5.Panel2.AutoScrollMinSize = m_image.Size
                'SplitContainer5.Panel2.Refresh()
            Else
                MsgBox("Please enter the image")
            End If
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dialog As New FolderBrowserDialog
        dialog.SelectedPath = TextBox2.Text
        If (dialog.ShowDialog = DialogResult.OK) Then
            TextBox2.Text = dialog.SelectedPath
        End If
    End Sub
    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        ProgressBar1.Value = 90
        If CheckState.Checked Then
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemCheckState(i, CheckState.Unchecked)
            Next
            CheckedListBox1.SetItemCheckState(CheckedListBox1.SelectedIndex, CheckState.Checked)
        End If
        Dim x As Integer
        If CheckedListBox1.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and print results.
            Dim s As String = ""
            For x = 0 To CheckedListBox1.CheckedItems.Count - 1
                s = CheckedListBox1.CheckedItems(x)
                TextBox3.Text = s.Substring(s.LastIndexOf("X") + 2, 5)
                TextBox4.Text = s.Substring(s.LastIndexOf("Y") + 2, 5)
                TextBox5.Text = s.Substring(s.LastIndexOf("Width") + 6, 5)
                TextBox6.Text = s.Substring(s.LastIndexOf("Height") + 7, 5)
                RichTextBox1.Text = s.Substring(s.LastIndexOf("Text") + 5)

            Next
        End If
        'If RichTextBox1.Text = "PROJECTS" Then
        '    TextBox3.Text = TextBox3.Text - 568
        '    TextBox4.Text = TextBox4.Text + 88
        '    TextBox5.Text = 25
        '    TextBox6.Text = 40
        '    If fa1 = False Then
        '        fa1 = True
        '    End If
        'End If
        ToolStripTextBox1.Text = TextBox3.Text
        ToolStripTextBox2.Text = TextBox4.Text
        ToolStripTextBox3.Text = TextBox5.Text
        ToolStripTextBox4.Text = TextBox6.Text
        ProgressBar1.Value = 0
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Not TextBox3.Text = "" And Not TextBox4.Text = "" And Not TextBox5.Text = "" And Not TextBox6.Text = "" And Not TextBox2.Text = "" And Not m_image Is Nothing Then
            ProgressBar1.Value = 25
            Dim bmp As Bitmap = New Bitmap(m_image)
            Dim rect As New Rectangle(TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
            cropped = bmp.Clone(rect, bmp.PixelFormat)
            RichTextBox1.Clear()
            RichTextBox1.Text = OCR(cropped, English, TextBox2.Text)
        End If
        ProgressBar1.Value = 0
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RichTextBox1.Clear()
        TextBox3.Text = 165
        TextBox4.Text = 165
        TextBox5.Text = 25
        TextBox6.Text = 40
        
        'CheckedListBox1.Items.Clear()
        ''ComboBox1.Items.Clear()
        ''PictureBox1.Image = Nothing
        'Me.ComboBox1.Text = "Choose one..."
        'Me.SplitContainer5.Panel2.Refresh()
        'SplitContainer5.Panel2.Update()
        PictureBox2.Update()
        PictureBox2.Refresh()
        fa1 = False
        ToolStripTextBox1.Text = TextBox3.Text
        ToolStripTextBox2.Text = TextBox4.Text
        ToolStripTextBox3.Text = TextBox5.Text
        ToolStripTextBox4.Text = TextBox6.Text
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged
        TextBox3.Text = Regex.Replace(TextBox3.Text, "[^\d]", "")
        TextBox4.Text = Regex.Replace(TextBox4.Text, "[^\d]", "")
        TextBox5.Text = Regex.Replace(TextBox5.Text, "[^\d]", "")
        TextBox6.Text = Regex.Replace(TextBox6.Text, "[^\d]", "")
        ToolStripTextBox1.Text = TextBox3.Text
        ToolStripTextBox2.Text = TextBox4.Text
        ToolStripTextBox3.Text = TextBox5.Text
        ToolStripTextBox4.Text = TextBox6.Text
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Not TextBox2.Text = "" And Not m_image Is Nothing Then
            ProgressBar1.Value = 25
            TextBox2.BackColor = Color.White
            Dim indexList As List(Of PDFWordIndex)
            indexList = GetPDFIndex(m_image, English, TextBox2.Text)
            ProgressBar1.Value = 100
            If fa1 = True Then
                fa1 = False
            End If
        Else
            TextBox2.BackColor = Color.LightPink
            If TextBox2.Text = "" Then
                TextBox2.BackColor = Color.White
                TextBox2.Text = "C:\temp\tessdata"
            End If
        End If
        ProgressBar1.Value = 0
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Not m_image Is Nothing Then
            Dim g As Graphics = PictureBox2.CreateGraphics()
            m_image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            g.DrawImage(m_image, SplitContainer5.Panel2.AutoScrollPosition.X, SplitContainer5.Panel2.AutoScrollPosition.Y, m_image.Width, m_image.Height)
            SplitContainer5.Panel2.AutoScrollMinSize = m_image.Size

        End If
    End Sub
    'Private Sub SplitContainer5_Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SplitContainer5.Panel2.MouseMove
    '    Dim g As Graphics = SplitContainer5.Panel2.CreateGraphics()
    '    Dim rect1 As Rectangle
    '    If e.Button = MouseButtons.Left And Not m_image Is Nothing Then
    '        fa1 = True
    '        TextBox3.Text = e.X
    '        TextBox4.Text = e.Y
    '        'Else

    '        SplitContainer5.Panel2.Update()
    '    End If
    '    rect1 = New Rectangle(TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
    '    g.DrawRectangle(Pens.Red, rect1)
    'End Sub
    'Private Sub SplitContainer5_Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SplitContainer5.Panel2.MouseUp
    '    SplitContainer5.Panel2.Invalidate()
    'End Sub
    Private Sub SplitContainer5_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer5.Panel2.Paint
        If Not m_image Is Nothing Then
            e.Graphics.DrawImage(m_image, SplitContainer5.Panel2.AutoScrollPosition.X, SplitContainer5.Panel2.AutoScrollPosition.Y, m_image.Width, m_image.Height)

        End If

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CopyFromScreen.Visible = True
    End Sub

    Private Function IsBlack(ByVal x As Integer, ByVal y As Integer, ByVal bm As Bitmap) As Boolean
        Dim c As Color
        Dim luminance As Double
        c = bm.GetPixel(x, y)
        luminance = (c.R * 0.299) + (c.G * 0.587) + (c.B * 0.114)
        Return luminance < 140
    End Function


    Dim selection As Rectangle = Nothing
    Dim m_Drawing As Boolean = False
    Dim m_Start As Point

    'Returns a rectangle from 2 points
    Private Function RectangleFromPoints(ByVal p1 As Point, ByVal p2 As Point) As Rectangle
        Dim x As Integer
        Dim y As Integer

        If p1.X <= p2.X Then
            x = p1.X
        Else
            x = p2.X
        End If

        If p1.Y <= p2.Y Then
            y = p1.Y
        Else
            y = p2.Y
        End If
        TextBox3.Text = x
        TextBox4.Text = y
        TextBox5.Text = Math.Abs(p1.X - p2.X)
        TextBox6.Text = Math.Abs(p1.Y - p2.Y)
        ToolStripTextBox1.Text = TextBox3.Text
        ToolStripTextBox2.Text = TextBox4.Text
        ToolStripTextBox3.Text = TextBox5.Text
        ToolStripTextBox4.Text = TextBox6.Text

        Return New Rectangle(x, y, Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y))
    End Function

    Dim hbr As New SolidBrush(Color.FromArgb(128, Color.LightPink))
 
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Button2_Click(sender, e)

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Button1_Click(sender, e)

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Button5_Click(sender, e)

    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Button7_Click(sender, e)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Button8_Click(sender, e)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Button4_Click(sender, e)
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Button6_Click(sender, e)
    End Sub

 
    Private Sub ImageConverterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageConverterToolStripMenuItem.Click
        CheckBox2.Checked = ImageConverterToolStripMenuItem.Checked
    End Sub

    Private Sub DigitOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DigitOnlyToolStripMenuItem.Click
        RadioButton1.Checked = DigitOnlyToolStripMenuItem.Checked
    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        'Remember where mouse was pressed
        m_Start = e.Location
        'Clear the selection rectangle
        selection = Nothing
        PictureBox2.Invalidate()
        'Selection drawing is on
        m_Drawing = True
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        If m_Drawing Then
            selection = RectangleFromPoints(m_Start, e.Location)
            'Update selection
            PictureBox2.Invalidate()
        End If
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        'Stop drawing
        m_Drawing = False
    End Sub

    Private Sub PictureBox2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        If selection <> Nothing Then
            'There is a selection rectangle so draw it
            e.Graphics.FillRectangle(hbr, selection)
            e.Graphics.DrawRectangle(Pens.Black, selection)

        End If
      
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click

        If FindToolStripMenuItem.Checked = True Then
            RichTextBox1.Refresh()
            TextBox1.Visible = True
            Label5.Visible = True
        Else
            TextBox1.Visible = False
            Label5.Visible = False
        End If

    End Sub

    Private Sub ReplaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaseToolStripMenuItem.Click

        If ReplaseToolStripMenuItem.Checked = True Then
            TextBox1.Visible = True
            TextBox14.Visible = True
            Label6.Visible = True
            Label5.Visible = True
        Else
            TextBox1.Visible = False
            TextBox14.Visible = False
            Label6.Visible = False
            Label5.Visible = False
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FindToolStripMenuItem.Checked = True Then
            RichTextBox1.Refresh()
            TextBox1.Visible = True
            Dim textEnd As Integer = RichTextBox1.TextLength
            Dim index As Integer
            Dim lastIndex As Integer = RichTextBox1.Text.LastIndexOf(TextBox1.Text)
            If RichTextBox1.Text.ToString.Contains(TextBox1.Text) = True Then
                While (index < lastIndex + 1)
                    RichTextBox1.Find(TextBox1.Text, index, textEnd, RichTextBoxFinds.MatchCase)
                    RichTextBox1.SelectionLength = TextBox1.Text.Length
                    'RichTextBox1.Text.SelectionColor = Color.Red
                    RichTextBox1.SelectionBackColor = Color.LightPink
                    index = RichTextBox1.Text.IndexOf(TextBox1.Text, index) + 1
                End While
            End If
        Else
            TextBox1.Visible = False
        End If

    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ReplaseToolStripMenuItem.Checked = True Then
            TextBox1.Visible = True
            TextBox14.Visible = True
            RichTextBox1.SelectionColor = Color.White
            If Not TextBox1.Text = "" Then
                RichTextBox1.Text = RichTextBox1.Text.Replace(TextBox1.Text, TextBox14.Text)
            End If
        Else
            TextBox1.Visible = False
            TextBox14.Visible = False
        End If

    End Sub

End Class
Public Class PDFWordIndex
    Public X As Integer
    Public Y As Integer
    Public Width As Integer
    Public Height As Integer
    Public FontSize As Integer
    Public Text As String
End Class







