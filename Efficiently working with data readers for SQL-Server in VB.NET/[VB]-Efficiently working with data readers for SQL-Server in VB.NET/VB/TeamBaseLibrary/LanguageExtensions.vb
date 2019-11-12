Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Module LanguageExtensions
    <Runtime.CompilerServices.Extension>
    Public Iterator Function [Select](Of T)(
        ByVal reader As SqlDataReader,
        ByVal projection As Func(Of SqlDataReader, T)) As IEnumerable(Of T)

        Do While reader.Read()
            Yield projection(reader)
        Loop

    End Function
    <Runtime.CompilerServices.Extension>
    Public Function ExecuteReaderAsync(ByVal source As SqlCommand) As Task(Of SqlDataReader)

        Return Task(Of SqlDataReader).Factory.
            FromAsync(New Func(Of AsyncCallback, Object, IAsyncResult)(AddressOf source.BeginExecuteReader),
                      New Func(Of IAsyncResult, SqlDataReader)(AddressOf source.EndExecuteReader), Nothing)

    End Function

    <Runtime.CompilerServices.Extension>
    Public Iterator Function [Select](Of T)(
        ByVal reader As OleDbDataReader,
        ByVal projection As Func(Of OleDbDataReader, T)) As IEnumerable(Of T)

        Do While reader.Read()
            Yield projection(reader)
        Loop

    End Function
    ''' <summary>
    ''' 	Gets the record value casted as int or 0.
    ''' </summary>
    ''' <param name = "pReader">The data reader.</param>
    ''' <param name = "pField">The name of the record field.</param>
    ''' <returns>The record value</returns>
    <Runtime.CompilerServices.Extension>
    Public Function GetInt32Safe(ByVal pReader As IDataReader, ByVal pField As String) As Integer
        Return pReader.GetInt32Safe(pField, 0)
    End Function

    ''' <summary>
    ''' 	Gets the record value casted as int or the specified default value.
    ''' </summary>
    ''' <param name = "pReader">The data reader.</param>
    ''' <param name = "pField">The name of the record field.</param>
    ''' <param name = "pDefaultValue">The default value.</param>
    ''' <returns>The record value</returns>
    <Runtime.CompilerServices.Extension>
    Public Function GetInt32Safe(ByVal pReader As IDataReader, ByVal pField As String, ByVal pDefaultValue As Integer) As Integer

        Dim value = pReader(pField)
        Return (If(TypeOf value Is Integer, CInt(Fix(value)), pDefaultValue))

    End Function
    ''' <summary>
    ''' Gets the record value casted as decimal or 0.
    ''' </summary>
    ''' <param name = "pReader">The data reader.</param>
    ''' <param name = "pField">The name of the record field.</param>
    ''' <returns>The record value</returns>
    <Runtime.CompilerServices.Extension>
    Public Function GetDoubleSafe(ByVal pReader As IDataReader, ByVal pField As String) As Double
        Return pReader.GetDoubleSafe(pField, 0)
    End Function

    ''' <summary>
    ''' Gets the record value casted as double or the specified default value.
    ''' </summary>
    ''' <param name = "pReader">The data reader.</param>
    ''' <param name = "pField">The name of the record field.</param>
    ''' <param name = "pDefaultValue">The default value.</param>
    ''' <returns>The record value</returns>
    <Runtime.CompilerServices.Extension>
    Public Function GetDoubleSafe(
        ByVal pReader As IDataReader,
        ByVal pField As String,
        ByVal pDefaultValue As Long) As Double

        Dim value = pReader(pField)
        Return (If(TypeOf value Is Double, CDbl(value), pDefaultValue))

    End Function
    ''' <summary>
    ''' 	Gets the record value casted as DateTime or DateTime.MinValue.
    ''' </summary>
    ''' <param name = "pReader">The data reader.</param>
    ''' <param name = "pField">The name of the record field.</param>
    ''' <returns>The record value</returns>
    <Runtime.CompilerServices.Extension>
    Public Function GetDateTimeSafe(ByVal pReader As IDataReader, ByVal pField As String) As Date

        Return pReader.GetDateTimeSafe(pField, Date.MinValue)

    End Function

    ''' <summary>
    ''' Gets the record value casted as DateTime or the specified default value.
    ''' </summary>
    ''' <param name = "pReader">The data reader.</param>
    ''' <param name = "pField">The name of the record field.</param>
    ''' <param name = "pDefaultValue">The default value.</param>
    ''' <returns>The record value</returns>
    <Runtime.CompilerServices.Extension>
    Public Function GetDateTimeSafe(ByVal pReader As IDataReader, ByVal pField As String,
        ByVal pDefaultValue As Date) As Date

        Dim value = pReader(pField)
        Return (If(TypeOf value Is Date, CDate(value), pDefaultValue))

    End Function
    <Runtime.CompilerServices.Extension>
    Public Function GetStringSafe(ByVal pReader As IDataReader, ByVal pField As String) As String

        Return If(TypeOf pReader(pField) Is DBNull, Nothing, pReader(pField).ToString())

    End Function

End Module
