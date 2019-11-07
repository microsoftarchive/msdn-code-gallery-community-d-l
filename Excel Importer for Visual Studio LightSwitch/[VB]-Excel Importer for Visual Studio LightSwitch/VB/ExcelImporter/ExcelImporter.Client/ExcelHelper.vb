Imports System.Windows.Interop
Imports System.Runtime.InteropServices.Automation

Public Class ExcelHelper
    Implements IDisposable

    Private _excel As Object

#Region "Constants"
    Const XlListObjectSourceType_xlSrcRange = 1
    Const XlYesNoGuess_xlYes = 1
    Const XlDVType_xlValidateList = 3
    Const _XlDVAlertStyle_xlValidAlertStop = 1
#End Region

    Private ReadOnly Property Excel
        Get
            Try
                If _excel Is Nothing Then
                    _excel = AutomationFactory.CreateObject("Excel.Application")
                End If

                Return _excel

            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Sub OpenWorkbook(ByVal filePath As String)
        Dim o As Object
        o = Excel
        If o IsNot Nothing Then
            o.WorkBooks.Open(filePath)
        Else
            Throw New InvalidProgramException("Error: Could not open Excel spreadsheet. Please check it is installed.")
        End If
    End Sub

    Public ReadOnly Property GetWorkSheets(ByVal workBookIndex As Int32) As IEnumerable(Of ExcelWorkSheet)
        Get
            Dim workBook As Object = Excel.WorkBooks(workBookIndex)

            Dim workSheets As New List(Of ExcelWorkSheet)
            Dim index As Int32 = 1
            For Each workSheet In workBook.WorkSheets
                workSheets.Add(New ExcelWorkSheet(index, workSheet.Name))
                index = index + 1
            Next
            Return workSheets
        End Get
    End Property

    'Public ReadOnly Property GetRange(ByVal workBookIndex As Int32, ByVal workSheetIndex As Int32, ByVal cell1 As String, ByVal cell2 As String) As Object
    '    Get
    '        Dim workBook As Object = Excel.WorkBooks(workBookIndex)
    '        Dim workSheet As Object = workBook.WorkSheets(workSheetIndex)
    '        Return workSheet.Range(cell1, cell2)
    '    End Get
    'End Property

    Public ReadOnly Property UsedRange(ByVal workBookIndex As Int32, ByVal workSheetIndex As Int32) As String(,)
        Get
            Dim workBook As Object = Excel.WorkBooks(workBookIndex)
            Dim workSheet As Object = workBook.WorkSheets(workSheetIndex)
            Dim excelRange = workSheet.UsedRange
            Dim columnCount As Int32 = excelRange.Columns.Count
            Dim rowCount As Int32 = excelRange.Rows.Count


            Dim valueArray(rowCount - 1, columnCount - 1) As String
            For i = 1 To rowCount
                For j = 1 To columnCount
                    valueArray(i - 1, j - 1) = excelRange(i, j).Value
                Next
            Next
            Return valueArray
        End Get
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            Excel.DisplayAlerts = False
            Excel.Quit()


            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.

            '_beforeCloseEvent.RemoveEventHandler(New ComAutomationEventHandler(AddressOf BeforeCloseEventHandler))
            '_beforeCloseEvent = Nothing
            _excel = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class

Public Class ExcelWorkSheet
    Public Sub New(ByVal index As Int32, ByVal name As String)
        Me.Index = index
        Me.Name = name
    End Sub
    Public Property Index As Int32
    Public Property Name As String
End Class
