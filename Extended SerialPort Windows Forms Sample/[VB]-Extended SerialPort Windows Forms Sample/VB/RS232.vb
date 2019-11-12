Imports System.IO
Imports System.IO.Ports
Imports System.Threading

''' <summary>
''' comChat - native serialPort services
''' </summary>
''' <remarks>update 2012-06-27</remarks>
Public Class RS232

    Private isconnected, sendstatus, comopen As Boolean
    Private WithEvents serialport1 As New SerialPort
    Private _receiveDelay As Integer = 1
    Private _threshold As Integer
    Private buffer() As Byte
    Private sc As SynchronizationContext

    ''' <summary>
    ''' set or get the tim in ms where the Datareived handle waits
    ''' </summary>
    Public Property ReceiveDelay() As Integer
        Get
            Return Me._receiveDelay
        End Get
        Set(ByVal value As Integer)
            Me._receiveDelay = value
        End Set
    End Property

    ''' <summary>
    ''' get or set the value when datareceived event fires
    ''' </summary>
    Public Property Threshold() As Integer
        Get
            Return Me._threshold
        End Get
        Set(ByVal value As Integer)
            Me._threshold = value
            Me.serialport1.ReceivedBytesThreshold = value
        End Set
    End Property


    ''' <summary>
    ''' Default com params
    ''' </summary>
    ''' <returns>...,receiveTimout,Threshold,Delay</returns>
    Public Shared ReadOnly Property DefaultParams() As String()
        Get
            Return New String() {"COM1", "9600", "8", "None", "One", "1", "1"}
        End Get
    End Property

    ''' <summary>
    ''' cParms - enumeration for Com Parameter
    ''' </summary>
    Public Enum cP
        cPort
        cBaud
        cData
        cParity
        cStop
        cThreshold
        cDelay
    End Enum

    ''' <summary>
    ''' Event data send back to calling form
    ''' </summary>
    ''' <param name="buf">byte array data</param>
    Public Event Datareceived(ByVal buf() As Byte)

    ''' <summary>
    ''' connection status back to form True: ok
    ''' </summary>
    ''' <param name="cStatus">True/False</param>
    Public Event connection(ByVal cStatus As Boolean)

    ''' <summary>
    ''' data send successfull (True)
    ''' </summary>
    Public Event sendOK(ByVal sStatus As Boolean)

    ''' <summary>
    ''' data receive successfull 
    ''' </summary>
    ''' <param name="sReceive">True/False</param>
    Public Event recOK(ByVal sReceive As Boolean)

    ''' <summary>
    ''' initialize a new instance
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        sc = SynchronizationContext.Current
    End Sub

    ''' <summary>
    ''' overloaded version opens the port immediate
    ''' </summary>
    Public Sub New(ByVal comParams() As String)

        sc = SynchronizationContext.Current
        connect(comParams)

    End Sub

    ''' <summary>
    ''' Com Port connect 
    ''' </summary>
    ''' <param name="comParams">{"COM1", "9600", "8", "None", "One", "1", "1"}</param>
    ''' <remarks></remarks>
    Public Sub connect(ByVal comParams() As String)

        Try
            'params device
            With serialport1
                .PortName = comParams(cP.cPort)
                .BaudRate = CInt(comParams(cP.cBaud))
                'demo working with enumerations. get enum value from string
                .Parity = DirectCast([Enum].Parse(GetType(Parity), comParams(cP.cParity)), Parity) 'get enum value from string
                .DataBits = CInt(comParams(cP.cData))
                .StopBits = DirectCast([Enum].Parse(GetType(StopBits), comParams(cP.cStop)), StopBits)
                .Handshake = Handshake.None
                .RtsEnable = False
                'set the set the number of bytes in readbuffer, when event will be fired
                .ReceivedBytesThreshold = CInt(comParams(cP.cThreshold))
                Me._threshold = .ReceivedBytesThreshold
                'i this usage 5000ms will never be reached because we read only bytes present in readbuffer
                .ReadTimeout = 5000
                'default value. make changes here
                .ReadBufferSize = 4096
                'default value
                .WriteBufferSize = 2048
                'make changes here
                .Encoding = System.Text.Encoding.ASCII
                'delay so that event handle can fetch more bytes at once
                Me._receiveDelay = CInt(comParams(cP.cDelay))
            End With

            'open and check device if is available?
            serialport1.Open()

        Catch ex As IOException
            showmessage(ex.Message & " ComOpen IO")

        Catch ex As Exception
            showmessage(ex.Message & " ComOpen EX")

        Finally
            isconnected = serialport1.IsOpen
            RaiseEvent connection(isconnected)
        End Try

    End Sub

    ''' <summary>
    ''' disConnect com port
    ''' </summary>
    Public Sub disconnect()
        Try
            serialport1.DiscardInBuffer()
            serialport1.Close()
        Catch ex As Exception
            showmessage("disConnect: " & ex.Message)
        Finally
            isconnected = serialport1.IsOpen
            RaiseEvent connection(isconnected)
        End Try
    End Sub

    ''' <summary>
    ''' send data
    ''' </summary>
    ''' <param name="data">byte array data</param>
    Public Sub SendData(ByRef data() As Byte)

        Try
            serialport1.Write(data, 0, data.Length)
            sendstatus = True
        Catch ex As Exception
            showmessage("sendData: " & ex.Message)
            sendstatus = False
        Finally
            RaiseEvent sendOK(sendstatus)
        End Try

    End Sub

    ''' <summary>
    '''  threading. read the COM Port
    ''' </summary>
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, _
                                         ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
                                         Handles serialport1.DataReceived

        If Not Me.isconnected Then
            Me.serialport1.DiscardInBuffer()
            Exit Sub
        End If

        Try
            Thread.Sleep(Me._receiveDelay)
            Dim len As Integer = serialport1.BytesToRead
            Me.buffer = New Byte(len - 1) {}
            serialport1.Read(Me.buffer, 0, len)
            RaiseEvent recOK(True)
        Catch ex As Exception
            showmessage("Read " & ex.Message)
            RaiseEvent recOK(False)
            Exit Sub
        End Try

        ' data from secondary thread
        sc.Post(New SendOrPostCallback(AddressOf doUpdate), Me.buffer)

    End Sub

    ''' <summary>
    ''' send data to main UI thread
    ''' </summary>
    Private Sub doUpdate(ByVal b As Object)

        'now to UI class
        RaiseEvent Datareceived(CType(b, Byte()))

    End Sub


    ''' <summary>
    ''' exception message to form UI
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Public Event errormsg(ByVal msg As String)

    ''' <summary>
    ''' error to UI
    ''' </summary>
    Private Sub showmessage(ByVal msg As String)
        RaiseEvent errormsg("<SerialPort " & Me.serialport1.PortName & "> " & msg)
    End Sub

End Class
