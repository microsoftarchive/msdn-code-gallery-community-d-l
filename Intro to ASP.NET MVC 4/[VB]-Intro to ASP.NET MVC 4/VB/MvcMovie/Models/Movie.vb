Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class Movie

    Public Property ID As Integer

    <Required()> _
    Public Property Title As String

    <DataType(DataType.Date)> _
    <DisplayFormat(DataFormatString:="{0:d}")> _
    Public Property ReleaseDate As Date

    <Required()> _
    Public Property Genre As String

    <Range(1, 100)> _
    <DataType(DataType.Currency)> _
    <DisplayFormat(DataFormatString:="{0:c}")> _
    Public Property Price As Decimal

    <StringLength(5)> _
    Public Property Rating As String

End Class

Public Class MovieDBContext
    Inherits DbContext

    Public Property Movies() As DbSet(Of Movie)

End Class