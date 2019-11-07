Option Strict On
Option Infer On
Imports System.Text
Imports System.Globalization
Imports System.IO
Imports System.IO.Ports
Imports System.Drawing

''' <summary>
''' Demo Serialport terminal Ellen Ramcke 2012
''' </summary>
''' <remarks>update 2012-06-27</remarks>
Public Class frmMain

    Private WithEvents _rs232 As New RS232
    Private xScale As Integer = 830      ' pixel / Char * 100
    Private charsInline As Integer = 80  ' def n start
    Private isConnected As Boolean
    Private RXcount, TXcount As Integer
    Private comparams() As String = RS232.DefaultParams
    Private buffer() As Byte


#Region "load and init form"
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text &= String.Format(" Version {0}.{1:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        Me.status0.Text = "Terminal connect: none"
        setRuler(rtbRX, False)
        setRuler(rtbTX, False)

        ' read available ports on system
        Dim Portnames As String() = SerialPort.GetPortNames

        If Portnames.Length > 0 Then
            Me.cboComPort.Text = Portnames(0)
        Else
            Me.status0.Text = "no ports detected"
            Exit Sub
        End If

        Me.cboComPort.Items.Clear()
        Me.cboComPort.Items.AddRange(Portnames)


    End Sub

#End Region
#Region "form events"
    '
    ' copy, cut paste txbox
    Private Sub CopyTx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyTx.Click
        Me.rtbTX.Copy()
    End Sub
    Private Sub PasteTx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteTx.Click
        Me.rtbTX.Paste()
    End Sub
    Private Sub CutTx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutTx.Click
        Me.rtbTX.Cut()
    End Sub

    ''' <summary>
    ''' send selected text
    ''' </summary>
    Private Sub SendTx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.cboEnterMessage.Text = Me.rtbTX.SelectedText
        sendToCom()
    End Sub

    ''' <summary>
    ''' send position of caret line from tx box 
    ''' </summary>
    Private Sub SendLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendLine.Click
        Dim loc As Integer = Me.rtbTX.GetFirstCharIndexOfCurrentLine
        Dim ln As Integer = Me.rtbTX.GetLineFromCharIndex(loc)
        If ln > 0 Then
            Me.cboEnterMessage.Text = Me.rtbTX.Lines(ln)
            sendToCom()
        End If
    End Sub

    ''' <summary>
    ''' send only selection in tx box to com
    ''' </summary>
    Private Sub SendSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendSelect.Click
        If Me.rtbTX.SelectionLength > 0 Then
            Me.cboEnterMessage.Text = Me.rtbTX.SelectedText
            sendToCom()
        End If
    End Sub

    ''' <summary>
    ''' fetch on line from rtbTX to cboEnterMessage box
    ''' </summary>
    Private Sub rtbTX_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbTX.MouseClick
        Dim rb As RichTextBox = CType(sender, RichTextBox)
        Dim loc As Integer = rb.GetFirstCharIndexOfCurrentLine
        Dim ln As Integer = rb.GetLineFromCharIndex(loc)
        Me.cboEnterMessage.Text = rb.Lines(ln)
    End Sub

    ''' <summary>
    ''' clear rx box
    ''' </summary>
    Private Sub btnClearReceiveBoxr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearReceiveBox.Click
        Me.rtbRX.Clear()
        Me.rtbRX.Text = "1"
        Me.charsInline = setRuler(rtbRX, Me.chkRxShowHex.Checked)
        Me.RXcount = 0
        Me.lblRxCnt.Text = String.Format("count: {0:D6}", Me.RXcount)
        Me.statusRX.Image = If(Me.isConnected, My.Resources.ledOrange, My.Resources.ledGray)
    End Sub

    ''' <summary>
    ''' clear tx box
    ''' </summary>
    Private Sub btnClearTxBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearTxBox.Click
        Me.rtbTX.Clear()
        Me.rtbTX.Text = "1"
        Me.charsInline = setRuler(rtbTX, chkTxShowHex.Checked)
        Me.TXcount = 0
        Me.lblTxCnt.Text = String.Format("count: {0:D3}", Me.TXcount)
        Me.statusTX.Image = If(Me.isConnected, My.Resources.ledOrange, My.Resources.ledGray)
    End Sub

    ''' <summary>
    ''' button connect
    ''' </summary>
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If CType(sender, ToolStripButton).Text = "*connect*" Then

            Me.comparams(RS232.cP.cPort) = cboComPort.Text
            Me.comparams(RS232.cP.cBaud) = cboBaudrate.Text
            Me.comparams(RS232.cP.cData) = cboDataBits.Text
            Me.comparams(RS232.cP.cParity) = cboParity.Text
            Me.comparams(RS232.cP.cStop) = cboStopbits.Text
            Me.comparams(RS232.cP.cDelay) = cboDelay.Text
            Me.comparams(RS232.cP.cThreshold) = cboThreshold.Text
            _rs232.connect(comparams)
        Else
            _rs232.disconnect()
        End If
    End Sub

    ''' <summary>
    ''' used in cboEnterMessage.TextUpdate
    ''' </summary>
    Private count As Integer

    ''' <summary>
    ''' build hex string in textbox
    ''' </summary>
    Private Sub cboEnterMessage_TextUpdate(ByVal sender As System.Object, _
                                           ByVal e As System.EventArgs) _
                                           Handles cboEnterMessage.TextUpdate

        If Not Me.chkTxEnterHex.Checked Then Exit Sub
        Dim cb As ToolStripComboBox = CType(sender, ToolStripComboBox)
        Dim s As String = cb.Text
        count += 1
        If count = 2 Then
            cb.Text &= " "
            count = 0
        End If
        cb.SelectionStart = cb.Text.Length

    End Sub

    ''' <summary>
    ''' enter only allowed keys in hex mode
    ''' </summary>
    Private Sub cboEnterMessage_KeyPress(ByVal sender As System.Object, _
                                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                                   Handles cboEnterMessage.KeyPress

        Dim allowedChars As String = "0123456789ABCDEFabcdef"
        Dim found As Boolean

        If e.KeyChar <> vbCr Then
            If chkTxEnterHex.Checked Then
                For i As Integer = 1 To allowedChars.Length
                    If e.KeyChar = GetChar(allowedChars, i) Then
                        found = True
                        Exit For
                    End If
                Next

                If Not found Then
                    e.Handled = True
                End If
            End If
        Else
            count = 0
            sendToCom()
        End If

    End Sub

    ''' <summary>
    ''' send data to com port
    ''' </summary>
    Private Sub sendToCom() 'Handles cbxsendToCom.KeyDown

        Dim data() As Byte = Nothing

        With Me.cboEnterMessage
            If .Text.Length > 0 Then

                If Not Me.chkTxEnterHex.Checked Then
                    If Me.chkAddCR.Checked Then .Text &= ControlChars.Cr
                    If Me.chkAddLF.Checked Then .Text &= ControlChars.Lf
                    data = Encoding.ASCII.GetBytes(.Text)
                Else
                    data = reconvert(.Text)
                End If

                'send data:
                _rs232.SendData(data)

                'tx counter:
                Me.TXcount += data.Length
                Me.lblTxCnt.Text = String.Format("{0:D6}", TXcount)
                Me.statusTX.Image = My.Resources.ledGray

                ' display in box:
                If chkTxShowHex.Checked And Not chkTxShowAscii.Checked Then
                    appendBytes(Me.rtbTX, data, Me.charsInline, False)
                ElseIf chkTxShowHex.Checked And chkTxShowAscii.Checked Then
                    appendBytes(Me.rtbTX, data, Me.charsInline, True)
                ElseIf Not chkTxShowHex.Checked And chkTxShowAscii.Checked Then
                    Me.rtbTX.ScrollToCaret()
                    Me.rtbTX.AppendText(.Text & vbCr)
                End If

                'remember data in cbx
                Me.cboEnterMessage.Items.Add(.Text)
                .Text = String.Empty

            End If
        End With

    End Sub

    ''' <summary>
    ''' view hex in rx box
    ''' </summary>
    Private Sub RxShowHex_CheckedChanged(ByVal sender As System.Object, _
                                         ByVal e As System.EventArgs) Handles chkRxShowHex.CheckedChanged
        Me.charsInline = setRuler(Me.rtbRX, Me.chkRxShowHex.Checked)
    End Sub

    ''' <summary>
    ''' view hex in tx box
    ''' </summary>
    Private Sub chkTxShowHex_CheckedChanged(ByVal sender As System.Object, _
                                         ByVal e As System.EventArgs) Handles chkTxShowHex.CheckedChanged
        Me.charsInline = setRuler(Me.rtbTX, Me.chkTxShowHex.Checked)
    End Sub

    ''' <summary>
    ''' save rx box to file
    ''' </summary>
    Private Sub btnSaveFileFromRxBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFileFromRxBox.Click

        SaveFileDialog1.DefaultExt = "*.TXT"
        SaveFileDialog1.Filter = "txt Files | *.TXT"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim fullpath As String = SaveFileDialog1.FileName()
            Me.rtbRX.SaveFile(fullpath, RichTextBoxStreamType.PlainText)
            MessageBox.Show(IO.Path.GetFileName(fullpath) & " written")

        Else
            MessageBox.Show("no data choosen")
        End If
    End Sub

    ''' <summary>
    ''' load file into tx box
    ''' </summary>
    Private Sub TxbtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFileToTxBox.Click

        OpenFileDialog1.DefaultExt = "*.TXT"
        OpenFileDialog1.Filter = "txt Files | *.TXT"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            Dim fullpath As String = OpenFileDialog1.FileName()
            Me.rtbTX.Clear()
            Me.rtbTX.LoadFile(fullpath, RichTextBoxStreamType.PlainText)

        Else
            MessageBox.Show("no data choosen")
        End If
    End Sub

    ''' <summary>
    ''' load config
    ''' </summary>
    Private Sub LoadC(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadConfig.Click
        Dim fname As String = "comterm.ini"
        Try
            Dim sr As New StreamReader(fname)
            Me.cboComPort.Text = sr.ReadLine()
            Me.cboBaudrate.Text = sr.ReadLine()
            Me.cboDataBits.Text = sr.ReadLine()
            Me.cboParity.Text = sr.ReadLine()
            Me.cboStopbits.Text = sr.ReadLine()
            Me.cboThreshold.Text = sr.ReadLine
            Me.cboDelay.Text = sr.ReadLine
            sr.Close()
            If sender IsNot Nothing Then MessageBox.Show(fname & " read")
        Catch ex As IOException
            MessageBox.Show(fname & " error: " & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' save comparms
    ''' </summary>
    Private Sub SaveConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveConfig.Click
        Dim fname As String = "comterm.ini"
        Dim sw As New StreamWriter(fname)
        sw.WriteLine(Me.cboComPort.Text)
        sw.WriteLine(Me.cboBaudrate.Text)
        sw.WriteLine(Me.cboDataBits.Text)
        sw.WriteLine(Me.cboParity.Text)
        sw.WriteLine(Me.cboStopbits.Text)
        sw.WriteLine(Me.cboThreshold.Text)
        sw.WriteLine(Me.cboDelay.Text)
        sw.Close()
        MessageBox.Show(fname & " written")
    End Sub

    ''' <summary>
    '''  exit
    ''' </summary>
    Private Sub ExitTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitTool.Click
        Me.Close()
    End Sub

    ''' <summary>
    '''  form resize
    ''' </summary>
    Private Sub frmMain_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        Me.charsInline = setRuler(rtbRX, chkRxShowHex.Checked)
        Me.charsInline = setRuler(rtbTX, chkTxShowHex.Checked)
    End Sub

#End Region
#Region "Com Port class events"

    ''' <summary>
    '''  update boxes
    ''' </summary>
    ''' <param name="buffer">received bytes from class RS232</param>
    ''' <remarks></remarks>
    Private Sub doUpdate(ByVal buffer() As Byte) Handles _rs232.Datareceived

        Me.RXcount += buffer.Length
        Me.lblRxCnt.Text = String.Format("count: {0:D3}", RXcount)

        If Me.chkRxShowHex.Checked And Not Me.chkRxShowAscii.Checked Then
            appendBytes(Me.rtbRX, buffer, Me.charsInline, False)

        ElseIf Me.chkRxShowHex.Checked And Me.chkRxShowAscii.Checked Then
            appendBytes(Me.rtbRX, buffer, Me.charsInline, True)

        ElseIf Not Me.chkRxShowHex.Checked And Me.chkRxShowAscii.Checked Then
            Dim s As String = Encoding.ASCII.GetString(buffer, 0, buffer.Length)
            Me.rtbRX.ScrollToCaret()
            'TODO
            Me.rtbRX.AppendText(s) ' & vbCr)

        End If
    End Sub

    ''' <summary>
    ''' senda data OK NOK
    ''' </summary>
    Private Sub sendata(ByVal sendStatus As Boolean) Handles _rs232.sendOK
        If sendStatus Then
            Me.statusTX.Image = My.Resources.ledGreen
        Else
            Me.statusTX.Image = My.Resources.ledRed
        End If
    End Sub

    ''' <summary>
    ''' receive successfull
    ''' </summary>
    Private Sub rdata(ByVal receiveStatus As Boolean) Handles _rs232.recOK
        If receiveStatus Then
            Me.statusRX.Image = My.Resources.ledGreen
        Else
            Me.statusRX.Image = My.Resources.ledRed
        End If
    End Sub

    ''' <summary>
    '''  connection status
    ''' </summary>
    Private Sub connection(ByVal status As Boolean) Handles _rs232.connection
        If status Then
            Me.cboParity.Enabled = False
            Me.cboStopbits.Enabled = False
            Me.cboComPort.Enabled = False
            Me.cboBaudrate.Enabled = False
            Me.cboDataBits.Enabled = False
            Me.cboDelay.Enabled = False
            Me.cboThreshold.Enabled = False
            Me.btnConnect.Text = "disconnect"
            Me.statusC.Image = My.Resources.ledGreen
            Me.statusRX.Image = My.Resources.ledOrange
            Me.statusTX.Image = My.Resources.ledOrange
            Me.sLabel(comparams)
            Me.isConnected = True
        Else
            Me.cboParity.Enabled = True
            Me.cboStopbits.Enabled = True
            Me.cboComPort.Enabled = True
            Me.cboBaudrate.Enabled = True
            Me.cboDataBits.Enabled = True
            Me.cboDelay.Enabled = True
            Me.cboThreshold.Enabled = True
            Me.btnConnect.Text = "*connect*"
            Me.statusC.Image = My.Resources.ledRed
            Me.statusRX.Image = My.Resources.ledGray
            Me.statusTX.Image = My.Resources.ledGray
            Me.status0.Text = " Terminal connect: none"
            Me.isConnected = False
        End If
    End Sub

    ''' <summary>
    ''' exception message
    ''' </summary>
    Private Sub getmessage(ByVal msg As String) Handles _rs232.errormsg
        'Me.status0.Text = msg
        MsgBox(msg)
    End Sub

#End Region
#Region "utilities"

    ''' <summary>
    ''' set ruler in box
    ''' </summary>
    ''' <returns>length of ruler</returns>
    Private Function setRuler(ByRef rb As RichTextBox, ByVal isHex As Boolean) As Integer

        Dim rbWidth As Integer = rb.Width
        Dim s As String = String.Empty
        Dim anzMarks As Integer

        If Not isHex Then
            anzMarks = CInt((rbWidth * 100 / xScale) / 5)
            For i As Integer = 1 To anzMarks
                If i < 2 Then
                    s &= String.Format("    {0:0}", i * 5)
                ElseIf i < 20 Then
                    s &= String.Format("   {0:00}", i * 5)
                Else
                    s &= String.Format("  {0:000}", i * 5)
                End If
            Next
        Else
            anzMarks = CInt((rbWidth * 100 / xScale) / 3)
            For i As Integer = 1 To anzMarks
                s &= String.Format(" {0:00}", i)
            Next
        End If


        ' coloring ruler
        Dim cl As Color = rb.BackColor
        rb.Select(0, rb.Lines(0).Length)
        rb.SelectionBackColor = Color.LightGray
        rb.SelectedText = s
        If rb.Lines.Length = 1 Then rb.AppendText(vbCr)
        rb.SelectionBackColor = cl
        rb.SelectionLength = 0
        Return s.Length

    End Function

    ''' <summary>
    ''' select a font
    ''' </summary>
    Private Sub fontMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LargeToolStripMenuItem.Click, MediumToolStripMenuItem.Click, SmallToolStripMenuItem.Click

        Dim s As String = CType(sender, ToolStripMenuItem).Text
        Dim fnt As Font = Nothing

        If s = "Large" Then
            fnt = New Font("Lucida Console", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ElseIf s = "Medium" Then
            fnt = New Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ElseIf s = "Small" Then
            fnt = New Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If

        Dim g As Graphics = Me.rtbTX.CreateGraphics
        'measure with teststring
        Dim szF As SizeF = g.MeasureString("0123456789", fnt)
        Me.xScale = CInt(szF.Width) * 10
        g.Dispose()

        Me.rtbRX.Font = fnt
        Me.rtbTX.Font = fnt

    End Sub

    ''' <summary>
    ''' append frame in one Richtextbox
    ''' </summary>
    ''' <param name="rb">tx or rx box here</param>
    ''' <param name="data">data frame</param>
    ''' <param name="currentLenght">possible chars in box</param>
    ''' <param name="showHexAndAscii">determines whether also displaying Hex True</param>
    ''' <remarks></remarks>
    Private Sub appendBytes(ByVal rb As RichTextBox, ByRef data() As Byte, ByRef currentLenght As Integer, ByVal showHexAndAscii As Boolean)

        Dim HexString As String = String.Empty
        Dim CharString As String = String.Empty
        Dim count As Integer = 0

        For i As Integer = 0 To data.Length - 1
            HexString &= String.Format(" {0:X2}", data(i))
            If data(i) > 31 Then
                CharString &= String.Format("  {0}", Chr(data(i)))
            Else
                CharString &= "  ."
            End If
            count += 3

            'start a new line
            If count >= currentLenght Then
                rb.ScrollToCaret()
                rb.AppendText(HexString & vbCr)
                If showHexAndAscii Then
                    rb.ScrollToCaret()
                    rb.AppendText(CharString & vbCr)
                End If
                HexString = String.Empty
                CharString = String.Empty
                count = 0
            End If

        Next

        rb.ScrollToCaret()
        rb.AppendText(HexString & vbCr)
        If showHexAndAscii Then
            rb.ScrollToCaret()
            rb.AppendText(CharString & vbCr)
        End If
    End Sub

    ''' <summary>
    ''' convert HEX string to its representing binary values
    ''' </summary>
    Private Function reconvert(ByVal str As String) As Byte()
        Dim data() As Byte = Nothing
        Dim s() As String = str.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
        data = New Byte(s.Length - 1) {}
        For i As Integer = 0 To data.Length - 1
            If Not Byte.TryParse(s(i), NumberStyles.HexNumber, CultureInfo.CurrentCulture, data(i)) Then
                data(i) = 255
                MsgBox("conversion failed!", MsgBoxStyle.Information)
            End If
        Next
        Return data
    End Function

    ''' <summary>
    ''' show status of connection
    ''' </summary>
    Private Sub sLabel(ByVal comparams() As String)

        Me.status0.Text = " Terminal connect: "
        For Each s As String In comparams
            Me.status0.Text &= " -" & s
        Next

    End Sub

#End Region

End Class
