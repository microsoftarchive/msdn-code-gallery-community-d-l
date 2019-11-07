' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization
Imports Excel = Microsoft.Office.Interop.Excel
Imports Office = Microsoft.Office.Core

Partial Class ThisWorkbook

    Public ReadOnly Property IncompleteDataMessage() As String
        Get
            Dim message As String = _
                String.Format(CultureInfo.CurrentUICulture, _
                    My.Resources.DataIncompleteError, _
                    Globals.DataSet.MaxDate)

            Return message
        End Get
    End Property

    ''' <summary>
    ''' "Orders" menu.
    ''' </summary>
    Private menuBar As Office.CommandBarPopup

    ''' <summary>
    ''' "Orders" toolbar.
    ''' </summary>
    Private toolBar As Office.CommandBar

    Private WithEvents weeklyToolbarButton As Office.CommandBarButton

    Private WithEvents unscheduledToolbarButton As Office.CommandBarButton

    Private WithEvents weeklyMenuItem As Office.CommandBarButton

    Private WithEvents unscheduledMenuItem As Office.CommandBarButton

    Private Const salesPivotTableConnectionTemplate As String = "ODBC;DBQ={0};DefaultDir={0};Driver={{Microsoft Text Driver (*.txt; *.csv)}};DriverId=27;Extensions=*;FIL=text;MaxBufferSize=2048;MaxScanRows=25;PageTimeout=5;SafeTransactions=0;Threads=3;UID=admin;UserCommitSync=Yes;"

    Private Const salesPivotTableQueryTemplate As String = "SELECT [Date], Flavor, Sold, Profit FROM {0}"

    Private defaultParameter As Object = System.Type.Missing

    Private Sub ThisWorkbook_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' Set the culture for the resources.
        My.Resources.Culture = CultureInfo.CurrentUICulture

        AddToolbar()
        AddMenu()
    End Sub

    Private Sub ThisWorkbook_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

    ''' <summary>
    ''' Creates a worksheet with a given name. If a worksheet with that name
    ''' exists, an ApplicationException is thrown.
    ''' </summary>
    ''' <param name="name">The name for the new worksheet.</param>
    ''' <returns>The new worksheet.</returns>
    Public Shared Function CreateWorksheet(ByVal name As String) As Excel.Worksheet
        Dim defaultValue As Object = System.Type.Missing
        Dim sheetCollection As Excel.Sheets = Globals.ThisWorkbook.Worksheets

        For Each item As Object In sheetCollection
            If ExcelHelpers.GetName(item) = name Then
                Throw New ArgumentException( _
                    String.Format(CultureInfo.CurrentUICulture, My.Resources.WorksheetExistsError, name), _
                    "name")
            End If
        Next

        Dim after As Object

        ' Add the new worksheet at the very end.
        If (sheetCollection.Count <> 0) Then
            after = sheetCollection(sheetCollection.Count)
        Else
            after = defaultValue
        End If

        Dim sheet As Excel.Worksheet
        sheet = CType(sheetCollection.Add(defaultValue, after), Excel.Worksheet)
        sheet.Name = name
        Return sheet
    End Function

    Public Shared Function GetAbsolutePath(ByRef relativePath As String) As String

        Dim assembyUrl As String = System.Reflection.Assembly.GetExecutingAssembly().CodeBase
        Dim assemblyPath As String = System.IO.Path.GetDirectoryName(New System.Uri(assembyUrl).LocalPath)

        Return System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyPath, relativePath))
    End Function

    Private Sub AddMenu()
        Dim menuCaption As String = My.Resources.OrdersMenu
        Dim weeklyCaption As String = My.Resources.WeeklyMenu
        Dim unscheduledCaption As String = My.Resources.UnscheduledMenu

        Dim menuBar As Office.CommandBar = Me.ThisApplication.CommandBars.ActiveMenuBar

        Dim cmdBarControl As Office.CommandBarPopup = Nothing
        Dim weeklyButton As Office.CommandBarButton
        Dim unscheduledButton As Office.CommandBarButton
        ' Command bars are shared for the whole application.
        ' In case there are two workbooks running this code,
        ' the second workbook should check first if the
        ' toolbar is already there, so that the menu does
        ' not get added twice.
        Dim currentControl As Office.CommandBarControl
        For Each currentControl In menuBar.Controls
            If (currentControl.Caption = menuCaption) Then
                cmdBarControl = CType(currentControl, Office.CommandBarPopup)
                Exit For
            End If
        Next

        If cmdBarControl Is Nothing Then
            cmdBarControl = CType(menuBar.Controls.Add(Office.MsoControlType.msoControlPopup, defaultParameter, defaultParameter, defaultParameter, True), Office.CommandBarPopup)
            cmdBarControl.Caption = menuCaption
            cmdBarControl.Tag = menuCaption
        End If

        If cmdBarControl.CommandBar.FindControl(Tag:=weeklyCaption) Is Nothing Then
            weeklyButton = CType(cmdBarControl.Controls.Add(Office.MsoControlType.msoControlButton, defaultParameter, defaultParameter, defaultParameter, True), Office.CommandBarButton)
            weeklyButton.Caption = weeklyCaption
            weeklyButton.Tag = weeklyCaption
        Else
            weeklyButton = CType(cmdBarControl.Controls(weeklyCaption), Office.CommandBarButton)
        End If

        If cmdBarControl.CommandBar.FindControl(Tag:=unscheduledCaption) Is Nothing Then
            unscheduledButton = CType(cmdBarControl.Controls.Add(Office.MsoControlType.msoControlButton, defaultParameter, defaultParameter, defaultParameter, True), Office.CommandBarButton)
            unscheduledButton.Caption = unscheduledCaption
            unscheduledButton.Tag = unscheduledCaption
        Else
            unscheduledButton = CType(cmdBarControl.Controls(unscheduledCaption), Office.CommandBarButton)
        End If

        ' It is necessary to assign the buttons to member variables,
        ' so they are not "cleaned up" by the garbage collector.
        Me.weeklyMenuItem = CType(weeklyButton, Office.CommandBarButton)
        Me.unscheduledMenuItem = CType(unscheduledButton, Office.CommandBarButton)

        Me.menuBar = cmdBarControl
    End Sub


    Private Sub AddToolbar()

        Dim barName As String = My.Resources.OrdersToolbar
        Dim weeklyCaption As String = My.Resources.WeeklyMenu
        Dim unscheduledCaption As String = My.Resources.UnscheduledMenu

        ' Toolbars are unique for the whole application.
        ' In case there are two workbooks running this code,
        ' the second workbook should check first if the
        ' toolbar is already there.
        ' If it is not, it has to be created.
        ' In any case, a handler must be added.
        Dim commandBar As Office.CommandBar = Nothing

        Dim weeklyButton As Office.CommandBarButton
        Dim unscheduledButton As Office.CommandBarButton

        Dim i As Integer
        For i = 1 To ThisApplication.CommandBars.Count
            If (ThisApplication.CommandBars(i).Name = barName) Then
                commandBar = ThisApplication.CommandBars(i)
                Exit For
            End If
        Next

        If commandBar Is Nothing Then
            commandBar = Me.Application.CommandBars.Add(barName, Office.MsoBarPosition.msoBarTop, defaultParameter, True)
        End If

        If commandBar.FindControl(Tag:=weeklyCaption) Is Nothing Then
            weeklyButton = CType(commandBar.Controls.Add(Office.MsoControlType.msoControlButton, defaultParameter, defaultParameter, defaultParameter, defaultParameter), Office.CommandBarButton)

            weeklyButton.Caption = weeklyCaption
            weeklyButton.Tag = weeklyCaption
            weeklyButton.Picture = ExcelHelpers.ConvertImage(toolBarImages.Images("CreateWeeklyOrder"))
            weeklyButton.Mask = ExcelHelpers.ConvertImage(toolBarImages.Images("CreateWeeklyOrderMask"))
        Else
            weeklyButton = CType(commandBar.Controls(weeklyCaption), Office.CommandBarButton)
        End If

        If commandBar.FindControl(Tag:=unscheduledCaption) Is Nothing Then
            unscheduledButton = CType(commandBar.Controls.Add(Office.MsoControlType.msoControlButton, defaultParameter, defaultParameter, defaultParameter, defaultParameter), Office.CommandBarButton)

            unscheduledButton.Caption = unscheduledCaption
            unscheduledButton.Tag = unscheduledCaption
            unscheduledButton.Picture = ExcelHelpers.ConvertImage(toolBarImages.Images("CreateUnscheduledOrder"))
            unscheduledButton.Mask = ExcelHelpers.ConvertImage(toolBarImages.Images("CreateUnscheduledOrderMask"))
        Else
            unscheduledButton = CType(commandBar.Controls(unscheduledCaption), Office.CommandBarButton)
        End If

        commandBar.Visible = True

        Me.weeklyToolbarButton = weeklyButton
        Me.unscheduledToolbarButton = unscheduledButton

        Me.toolBar = commandBar
    End Sub

    Private Sub ThisWorkbook_ActivateEvent() Handles Me.ActivateEvent
        Me.menuBar.Visible = True
        Me.toolBar.Visible = True
    End Sub

    Private Sub ThisWorkbook_BeforeSave(ByVal SaveAsUI As Boolean, ByRef Cancel As Boolean) Handles Me.BeforeSave
        Globals.DataSet.Save()
    End Sub

    Private Sub ThisWorkbook_Deactivate() Handles Me.Deactivate
        Me.menuBar.Visible = False
        Me.toolBar.Visible = False
    End Sub


    Private Sub unscheduledButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean) Handles unscheduledMenuItem.Click
        Try
            Dim orderingSheet As OrderingSheet = New OrderingSheet(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub weeklyButton_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean) Handles weeklyMenuItem.Click
        Try
            Dim orderingSheet As OrderingSheet = New OrderingSheet(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Public Function CreateSalesPivotTable(ByVal range As Excel.Range, ByVal filePath As String) As Excel.PivotTable
        Dim fileDirectory As String = System.IO.Path.GetDirectoryName(filePath)
        Dim fileName As String = System.IO.Path.GetFileName(filePath)
        Dim pivotTableName As String = My.Resources.SalesAndProfitPivotTableName
        Dim cache As Excel.PivotCache = Me.PivotCaches().Add(Excel.XlPivotTableSourceType.xlExternal, System.Type.Missing)

        cache.Connection = String.Format(CultureInfo.CurrentUICulture, salesPivotTableConnectionTemplate, fileDirectory)
        cache.CommandType = Excel.XlCmdType.xlCmdSql
        cache.CommandText = String.Format(CultureInfo.CurrentUICulture, salesPivotTableQueryTemplate, fileName)

        Dim pivotTable As Excel.PivotTable = cache.CreatePivotTable(range, pivotTableName, System.Type.Missing, Excel.XlPivotTableVersionList.xlPivotTableVersionCurrent)

        ' Adjusts the properties of the new PivotTable to
        ' format information the desired way.
        pivotTable.ErrorString = " -- "
        pivotTable.DisplayErrorString = True
        pivotTable.NullString = " -- "

        Return pivotTable
    End Function

    ''' <summary>
    ''' Exports data from the list object into a text file and updates the PivotTable
    ''' using that data.
    ''' </summary>
    Public Sub UpdateSalesPivotTable(ByVal pivotTable As Excel.PivotTable)
        Dim screenUpdating As Boolean = Globals.ThisWorkbook.Application.ScreenUpdating
        Me.Application.ScreenUpdating = False

        With New TextFileGenerator(Globals.DataSet.Sales)
            Try
                Dim fileDirectory As String = System.IO.Path.GetDirectoryName(.FullPath)
                Dim fileName As String = System.IO.Path.GetFileName(.FullPath)

                Me.ShowPivotTableFieldList = False

                pivotTable.SourceData = New String() { _
                    String.Format(CultureInfo.CurrentUICulture, salesPivotTableConnectionTemplate, fileDirectory), _
                    String.Format(CultureInfo.CurrentUICulture, salesPivotTableQueryTemplate, fileName) _
                }

                Me.Application.CommandBars("PivotTable").Visible = False

            Finally
                .Dispose()
                Me.Application.ScreenUpdating = screenUpdating
            End Try
        End With
    End Sub

    Friend Sub MakeReadOnly()
        Globals.Sheet1.Protect( _
            Password:="", _
            DrawingObjects:=True, _
            Contents:=True, _
            Scenarios:=True, _
            UserInterfaceOnly:=False, _
            AllowFormattingCells:=True, _
            AllowFormattingColumns:=True, _
            AllowFormattingRows:=True, _
            AllowInsertingColumns:=False, _
            AllowInsertingRows:=False, _
            AllowInsertingHyperlinks:=False, _
            AllowDeletingColumns:=False, _
            AllowDeletingRows:=False, _
            AllowSorting:=True, _
            AllowFiltering:=True, _
            AllowUsingPivotTables:=True)
    End Sub

    Friend Sub MakeReadWrite()
        Globals.Sheet1.Unprotect("")

        ' In some scenarios, even after we call Unprotect(),
        ' SetDataBinding fails. Assigning the selection fixes
        ' the problem.
        Dim selection As Excel.Range = CType(Me.Application.Selection, Excel.Range)
        If selection IsNot Nothing Then selection.Select()
    End Sub
End Class

Partial Class Globals
    Private Shared ds As OperationsData = Nothing

    Friend Shared ReadOnly Property DataSet() As OperationsData
        Get
            If ds Is Nothing Then
                ds = New OperationsData
                ds.Load()
            End If

            Return ds
        End Get
    End Property
End Class