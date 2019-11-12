Imports System.Globalization
Public Class DataOperations
    Private mMonthNames As List(Of String) = (From M In CultureInfo.CurrentCulture.DateTimeFormat.MonthNames Where Not String.IsNullOrEmpty(M)).ToList
    Private mMonths As New Dictionary(Of String, Integer)
    Private mMockedData As List(Of MockedData)
    Public ReadOnly Property MonthDictionary As Dictionary(Of String, Integer)
        Get
            Return mMonths
        End Get
    End Property
    Public ReadOnly Property AutoData As String()
        Get
            Return (From T In mMonths Select T.Key Take 5).ToArray
        End Get
    End Property
    Public ReadOnly Property MockedData As List(Of MockedData)
        Get
            Return (From T In mMonthNames.Select(Function(sender, index) New MockedData With {.Index = index, .Name = sender}) Take 4).ToList
        End Get
    End Property

    Public Sub New()
        For Month As Integer = 0 To mMonthNames.Count - 1
            mMonths.Add(mMonthNames(Month), Month + 1)
        Next
    End Sub
End Class
Public Class MockedData
    Public Sub New()

    End Sub
    Public Property Index As Integer
    Public Property Name As String
End Class
