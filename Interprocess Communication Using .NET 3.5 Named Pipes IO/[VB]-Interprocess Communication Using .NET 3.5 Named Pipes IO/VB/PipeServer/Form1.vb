Imports System
Imports System.IO.Pipes
Imports System.Text
Imports System.Threading

''' <summary>
''' PipeServer creates a listener thread and waits for messages from clients.
''' Received messages are displayed in Textbox "tbox"
''' </summary>
''' <remarks></remarks>
Public Class Form1
    Private Sub Form1_Load(ByVal sender As Object, _
                           ByVal e As System.EventArgs) Handles MyBase.Load
        tbox.Text = ""
        PipeServer.pipeName = "testpipe"
        PipeServer.owner = Me
        Dim pipeThread As ThreadStart = _
                         New ThreadStart(AddressOf PipeServer.createPipeServer)
        Dim listenerThread As Thread = New Thread(pipeThread)
        listenerThread.SetApartmentState(ApartmentState.STA)
        listenerThread.IsBackground = True
        listenerThread.Start()
    End Sub

End Class

Public Class PipeServer
    Public Shared owner As Form1
    Public Shared pipeName As String
    Private Shared pipeServer As NamedPipeServerStream
    Private Shared ReadOnly BufferSize As Integer = 256

    Delegate Sub SetTextboxDelegate(ByVal text As String)
    Private Shared doSetTextBox As SetTextboxDelegate

    Private Shared Sub SetTextbox(ByVal text As String)
        Dim tb As TextBox = owner.tbox

        tb.Text = String.Concat(tb.Text, text)
        ' Scroll to the bottom of the textbox
        tb.SelectionStart = tb.Text.Length - 2
        tb.ScrollToCaret()
    End Sub

    Public Shared Sub createPipeServer()
        Dim decdr As Decoder = Encoding.Default.GetDecoder()
        Dim bytes(BufferSize) As Byte
        Dim chars(BufferSize) As Char
        Dim numBytes As Integer = 0
        Dim msg As StringBuilder = New StringBuilder()
        doSetTextBox = New SetTextboxDelegate(AddressOf SetTextbox)
        Try
            pipeServer = New NamedPipeServerStream(pipeName, PipeDirection.In, 1, _
                                                   PipeTransmissionMode.Message, _
                                                   PipeOptions.Asynchronous)
            While True
                pipeServer.WaitForConnection()
                Do
                    msg.Length = 0
                    Do
                        numBytes = pipeServer.Read(bytes, 0, BufferSize)
                        If numBytes > 0 Then
                            Dim numChars As Integer = _
                                         decdr.GetCharCount(bytes, 0, numBytes)
                            decdr.GetChars(bytes, 0, numBytes, chars, 0, False)
                            msg.Append(chars, 0, numChars)
                        End If
                    Loop Until (numBytes = 0) Or (pipeServer.IsMessageComplete)
                    decdr.Reset()
                    If numBytes > 0 Then
                        owner.Invoke(doSetTextBox, New Object() {msg.ToString()})
                    End If
                Loop Until numBytes = 0
                pipeServer.Disconnect()
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
