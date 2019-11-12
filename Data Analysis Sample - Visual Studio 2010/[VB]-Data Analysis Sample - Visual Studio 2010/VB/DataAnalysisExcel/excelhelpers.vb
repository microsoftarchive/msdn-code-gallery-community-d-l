' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Option Strict On
Imports System
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class ExcelHelpers

#Region "Range-related functions"

    ''' <summary>
    ''' Returns the range with the given name from the workbook.
    ''' </summary>
    ''' <param name="workbook">The workbook containing the named range.</param>
    ''' <param name="name">The name of the desired range.</param>
    ''' <returns>The range with the given name from the workbook.</returns>
    Public Shared Function GetNamedRange(ByVal workbook As Excel.Workbook, _
       ByVal name As String) As Excel.Range

        GetNamedRange = workbook.Names.Item(name).RefersToRange
    End Function

    ''' <summary>
    ''' Returns the range with the given name from the given worksheet.
    ''' </summary>
    ''' <param name="worksheet">The worksheet containing the named range.</param>
    ''' <param name="name">The name of the desired range.</param>
    ''' <returns>The range with the given name from the given worksheet.</returns>
    Public Shared Function GetNamedRange(ByVal worksheet As Excel.Worksheet, _
       ByVal name As String) As Excel.Range

        GetNamedRange = worksheet.Range(name)
    End Function

    ''' <summary>
    ''' Returns a range with the column at the specified index of the range.
    ''' </summary>
    ''' <param name="rowRange">The range containing the desired column.</param>
    ''' <param name="column">The index of the desired column from the range.</param>
    ''' <returns>The range containing the specified column from the given range.</returns>
    Public Shared Function GetColumnFromRange(ByVal rowRange As Excel.Range, _
       ByVal column As Integer) As Excel.Range

        Return CType(rowRange.Columns(column), Excel.Range)
    End Function

    ''' <summary>
    ''' Returns a range with the row at the specified index of the range.
    ''' </summary>
    ''' <param name="columnRange">The range containing the desired row.</param>
    ''' <param name="row">The index of the desired row from the range.</param>
    ''' <returns>The range containing the specified row from the given range.</returns>
    Public Shared Function GetRowFromRange(ByVal columnRange As Excel.Range, _
       ByVal row As Integer) As Excel.Range

        Return CType(columnRange.Rows(row), Excel.Range)
    End Function

    ''' <summary>
    ''' Returns a range consisting of the cell at the specified row and column.
    ''' </summary>
    ''' <param name="range">The range containing the desired cell.</param>
    ''' <param name="row">The index of the row containing the desired cell.</param>
    ''' <param name="column">The index of the column containing the desired cell.</param>
    ''' <returns></returns>
    Public Shared Function GetCellFromRange(ByVal range As Excel.Range, _
       ByVal row As Integer, ByVal column As Integer) As Excel.Range

        Return CType(range.Cells(row, column), Excel.Range)
    End Function

    ''' <summary>
    ''' Returns the value of the given range as an object.
    ''' </summary>
    ''' <param name="range">The range from which the value will be obtained.</param>
    ''' <param name="address">The local address of the subrange from which to pull the value.</param>
    ''' <returns>Returns the value of the cell in the subrange specified by the address.</returns>
    Public Shared Function GetValue(ByVal range As Excel.Range, _
       ByVal address As String) As Object

        GetValue = range.Range(address).Value2
    End Function

    ''' <summary>
    ''' Returns the value of the given range as a double.
    ''' </summary>
    ''' <param name="range">The range from which the value will be obtained.</param>
    ''' <returns>Returns the value of the range as a double.</returns>
    Public Shared Function GetValueAsDouble( _
       ByVal range As Excel.Range) As Double

        If (TypeOf range.Value2 Is Double) Then
            Return CType(range.Value2, Double)
        End If

        Return Double.NaN
    End Function

    ''' <summary>
    ''' Returns the value of the cell at the specified indexes as a double.
    ''' </summary>
    ''' <param name="range">The range containing the desired cell.</param>
    ''' <param name="row">The row of the range containing the cell.</param>
    ''' <param name="column">The column of the range containing the cell.</param>
    ''' <returns>Returns the value of the cell at the specified indexes as a double.</returns>
    Public Shared Function GetValueAsDouble(ByVal range As Excel.Range, _
       ByVal row As Integer, ByVal column As Integer) As Double

        Dim subRange As Excel.Range = _
           GetCellFromRange(range, row, column)
        Return GetValueAsDouble(subRange)
    End Function

    ''' <summary>
    ''' Returns the value of the cell at the specified indexes as a double.
    ''' </summary>
    ''' <param name="worksheet">The worksheet containing the desired cell.</param>
    ''' <param name="row">The row of the worksheet containing the cell.</param>
    ''' <param name="column">The column of the worksheet containing the cell.</param>
    ''' <returns>Returns the value of the cell at the given indexes as a double.</returns>
    Public Shared Function GetValueAsDouble(ByVal worksheet As Excel.Worksheet, _
       ByVal row As Integer, ByVal column As Integer) As Double

        Dim subRange As Excel.Range = _
           GetCellFromRange(worksheet.Cells, row, column)
        Return GetValueAsDouble(subRange)
    End Function

    ''' <summary>
    ''' Returns the value of the given range as a string.
    ''' </summary>
    ''' <param name="range">The range from which the value will be obtained.</param>
    ''' <returns>Returns the value of the given range as a string.</returns>
    Public Shared Function GetValueAsString( _
       ByVal range As Excel.Range) As String

        If (Not range.Value2 Is Nothing) Then
            Return range.Value2.ToString()
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Returns the value of the cell at the specified indexes as a string.
    ''' </summary>
    ''' <param name="range">The range containing the desired cell.</param>
    ''' <param name="row">The row of the range containing the cell.</param>
    ''' <param name="column">The column of the range containing the cell.</param>
    ''' <returns>Returns the value of the cell at the specified indexes as a string.</returns>
    Public Shared Function GetValueAsString(ByVal range As Excel.Range, _
       ByVal row As Integer, ByVal column As Integer) As String

        Dim subRange As Excel.Range = _
           CType(range(row, column), Excel.Range)
        GetValueAsString = GetValueAsString(subRange)
    End Function

    ''' <summary>
    ''' Returns the value of the cell at the specified indexes as a string.
    ''' </summary>
    ''' <param name="worksheet">The worksheet containing the desired cell.</param>
    ''' <param name="row">The row of the worksheet containing the cell.</param>
    ''' <param name="column">The column of the worksheet containing the cell.</param>
    ''' <returns>Returns the value of the cell at the given indexes as a string.</returns>
    Public Shared Function GetValueAsString( _
       ByVal worksheet As Excel.Worksheet, ByVal row As Integer, _
       ByVal column As Integer) As String

        Dim subRange As Excel.Range = _
           CType(worksheet.Cells()(row, column), Excel.Range)
        GetValueAsString = GetValueAsString(subRange)
    End Function

#End Region
#Region "Worksheet-related functions"

    ''' <summary>
    ''' Escapes special characters in a name and truncates it so that it
    ''' could be used as a worksheet name in Excel. The name is truncated to 31
    ''' characters; the characters ':', '\', '/', '?', '*', '[' and ']' are replaced
    ''' with '_'.
    ''' </summary>
    ''' <param name="name">The original name.</param>
    ''' <returns>The escaped name.</returns>
    Public Shared Function CreateValidWorksheetName(ByVal name As String) As String
        ' Worksheet name cannot be longer than 31 characters.
        Dim escapedString As System.Text.StringBuilder

        If (name.Length <= 31) Then
            escapedString = New System.Text.StringBuilder(name)
        Else
            escapedString = New System.Text.StringBuilder(name, 0, 31, 31)
        End If

        For i As Integer = 0 To escapedString.Length - 1
            If escapedString(i) = ":"c Or _
             escapedString(i) = "\"c Or _
             escapedString(i) = "/"c Or _
             escapedString(i) = "?"c Or _
             escapedString(i) = "*"c Or _
             escapedString(i) = "["c Or _
             escapedString(i) = "]"c Then
                escapedString(i) = "_"c
            End If
        Next

        Return escapedString.ToString()
    End Function

    ''' <summary>
    ''' Returns the worksheet with the given name.
    ''' </summary>
    ''' <param name="workbook">The workbook containing the worksheet.</param>
    ''' <param name="name">The name of the desired worksheet.</param>
    ''' <returns>The worksheet from the workbook with the given name.</returns>
    Public Shared Function GetWorksheet(ByVal workbook As Excel.Workbook, _
       ByVal name As String) As Excel.Worksheet

        GetWorksheet = Nothing
        Try

            GetWorksheet = CType(workbook.Worksheets(name), Excel.Worksheet)
        Catch
            ' Fall through
        End Try
    End Function

    ''' <summary>
    ''' Returns the worksheet at the given index.
    ''' </summary>
    ''' <param name="workbook">The workbook containing the worksheet.</param>
    ''' <param name="index">The index of the desired worksheet.</param>
    ''' <returns>The worksheet from the workbook with the given name.</returns>
    Public Shared Function GetWorksheet(ByVal workbook As Excel.Workbook, _
       ByVal index As Integer) As Excel.Worksheet

        GetWorksheet = Nothing
        Try
            GetWorksheet = CType(workbook.Worksheets(index), Excel.Worksheet)
        Catch Ex As Exception
            ' Fall through
        End Try
    End Function

    ''' <summary>
    ''' Returns the active worksheet from the workbook.
    ''' </summary>
    ''' <param name="workbook">The workbook containing the worksheet.</param>
    ''' <returns>The active worksheet from the given workbook.</returns>
    Public Shared Function GetActiveSheet( _
       ByVal workbook As Excel.Workbook) As Excel.Worksheet

        Return CType(workbook.ActiveSheet, Excel.Worksheet)
    End Function


    ''' <summary>
    ''' Returns the worksheet or chart's name.
    ''' </summary>
    ''' <param name="item">Worksheet or chart.</param>
    ''' <returns>The worksheet or chart's name.</returns>
    Public Shared Function GetName(ByVal item As Object) As String

        Dim wsItem As Excel.Worksheet = TryCast(item, Excel.Worksheet)
        If wsItem IsNot Nothing Then
            GetName = wsItem.Name
        Else
            Dim chItem As Excel.Chart = TryCast(item, Excel.Chart)
            If chItem IsNot Nothing Then
                GetName = chItem.Name
            Else
                GetName = Nothing
            End If
        End If
    End Function
#End Region

    Public Shared Function ConvertImage(ByVal image As System.Drawing.Image) As stdole.IPictureDisp
        Return ImageToPictureConverter.Convert(image)
    End Function

    ''' <summary>
    ''' Class for exposing protected method GetIPictureDispFromPicture
    ''' of AxHost.
    ''' </summary>
    Private Class ImageToPictureConverter
        Inherits System.Windows.Forms.AxHost

        Private Sub New()
            MyBase.New(Nothing)
        End Sub

        Public Shared Function Convert(ByVal image As System.Drawing.Image) As stdole.IPictureDisp
            Return CType(System.Windows.Forms.AxHost.GetIPictureDispFromPicture(image), stdole.IPictureDisp)
        End Function
    End Class
End Class
