Imports System.IO
Imports Microsoft.LightSwitch.Presentation
Imports Microsoft.LightSwitch.Presentation.Extensions
Imports Microsoft.LightSwitch.Client
Imports Microsoft.LightSwitch
Imports Microsoft.LightSwitch.Model
Imports System.Runtime.CompilerServices
Imports Microsoft.LightSwitch.Threading
Imports System.Diagnostics
Imports Microsoft.LightSwitch.Framework
Imports System.Reflection
Imports System.Security
Imports System.Runtime.InteropServices
Imports System.Linq.Expressions
Imports Microsoft.LightSwitch.Sdk.Proxy
Imports Microsoft.VisualStudio.ExtensibilityHosting
Imports Microsoft.LightSwitch.Runtime.Shell.Framework
Imports Microsoft.LightSwitch.Model.Extensions

Public Module Importer
    Private _excelDocRange As String(,)
    Private _collection As IVisualCollection
    Private _columnMappings As List(Of ColumnMapping)
    Private navProperties As Dictionary(Of String, IEntityObject) = New Dictionary(Of String, IEntityObject)
    Private _fileInfo As FileInfo

    ''' <summary> 
    ''' Import data from a comma delimited stream and return a 2-D String array
    ''' </summary> 
    Public Function ImportCommaDelimitedStream(fileStream As FileStream) As String(,)
        Dim parsedData As New List(Of String())()
        Dim columnCount As Int32 = 0

        Using streamReader As New StreamReader(fileStream)
            Dim line As String
            Dim row As String()
            While (InlineAssignHelper(line, streamReader.ReadLine())) IsNot Nothing
                row = line.Split(","c)
                columnCount = Math.Max(columnCount, row.Count)
                parsedData.Add(row)
            End While
        End Using


        Dim valueArray(parsedData.Count - 1, columnCount - 1) As String
        For i = 0 To (parsedData.Count - 1)
            For j = 0 To (parsedData(i).Count - 1)
                valueArray(i, j) = parsedData(i)(j)
            Next
        Next
        Return valueArray
    End Function
    ' ''' <summary> 
    ' ''' Take in a list of string arrays which contains 
    ' ''' all the parsed data for our Contacts entity 
    ' ''' </summary> 
    'Private Sub AddData(dataList As List(Of String()))

    '    For Each row As String() In dataList
    '        'Each row in dataList will be an entity record.
    '        'Need to call AddNew() here for each entity and add a record
    '    Next
    'End Sub
    Private Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    <Extension()> _
    Public Sub ImportFromExcel(ByVal collection As IVisualCollection)
        _collection = collection
        Dispatchers.Main.BeginInvoke(Sub()
                                         If System.Windows.Application.Current.IsRunningOutOfBrowser Then
                                             'Use the standard file dialog
                                             Dim dialog As New OpenFileDialog()
                                             dialog.Multiselect = False
                                             dialog.Filter = "Excel Documents(*.xls;*.xlsx;*.csv)|*.xls;*.xlsx;*.csv|All files (*.*)|*.*"
                                             If dialog.ShowDialog() Then
                                                 Dim f As FileInfo = dialog.File
                                                 Try
                                                     Dim excel As New ExcelHelper()
                                                     excel.OpenWorkbook(f.FullName)
                                                     Dim workSheets = excel.GetWorkSheets(1)
                                                     Dim workSheetList As New WorkSheetList(workSheets)

                                                     'TODO
                                                     'Launch picker dialog if we have multiple worksheets
                                                     If workSheets.Count > 1 Then
                                                     End If

                                                     _excelDocRange = excel.UsedRange(1, 1)
                                                     excel.Dispose()

                                                     'Show the column mapping dialog
                                                     DisplayMappingDialog()
                                                 Catch ex As SecurityException
                                                     collection.Screen.Details.Dispatcher.BeginInvoke(
                                                         Sub()
                                                             _collection.Screen.ShowMessageBox("Error: Silverlight Security error. The excel document must be in the My Documents folder.")
                                                         End Sub
                                                     )
                                                 Catch comEx As COMException
                                                     _collection.Screen.Details.Dispatcher.BeginInvoke(
                                                         Sub()
                                                             _collection.Screen.ShowMessageBox("Error: Could not open this file.  It may not be a valid Excel document.")
                                                         End Sub
                                                     )
                                                 Catch ex2 As Exception
                                                     _collection.Screen.Details.Dispatcher.BeginInvoke(
                                                         Sub()
                                                             _collection.Screen.ShowMessageBox("Unknown error: " + ex2.Message)
                                                         End Sub
                                                     )
                                                 End Try
                                             End If
                                         Else
                                             Dim selectFileWindowContent As New SelectFileWindow()
                                             Dim selectFileWindow As New ScreenChildWindow()
                                             AddHandler selectFileWindow.Closed, AddressOf selectFileWindow_Closed

                                             'set parent to current screen
                                             Dim sdkProxy As IServiceProxy = VsExportProviderService.GetExportedValue(Of IServiceProxy)()
                                             selectFileWindow.Owner = DirectCast(sdkProxy.ScreenViewService.GetScreenView(_collection.Screen).RootUI, Control)
                                             selectFileWindow.Show(_collection.Screen, selectFileWindowContent)
                                         End If
                                     End Sub)

    End Sub


    Private Sub AddItemsToCollection()
        'This should always be called on the logical thread
        Debug.Assert(_collection.Screen.Details.Dispatcher.CheckAccess(), "Expected to run on the logical thread")


        'Add Items to Collection
        Dim numRows = _excelDocRange.GetLength(0) - 1
        For i = 1 To numRows
            Dim currentRow As Int32 = i
            Dim newRow As IEntityObject = _collection.AddNew()
            Dim count As Int32 = 0
            For Each mapping As ColumnMapping In _columnMappings
                If mapping.TableProperty IsNot Nothing AndAlso mapping.TableProperty.Name <> "<Ignore>" Then
                    Dim value As String = _excelDocRange(currentRow, count)
                    If String.IsNullOrEmpty(value) AndAlso mapping.TableProperty.IsNullable Then
                        newRow.Details.Properties(mapping.TableProperty.Name).Value = Nothing
                    ElseIf mapping.TableProperty.EntityType IsNot Nothing Then
                        'Get cached results
                        If navProperties.ContainsKey(mapping.TableProperty.Name + "_" + value) Then
                            newRow.Details.Properties(mapping.TableProperty.Name).Value = navProperties(mapping.TableProperty.Name + "_" + value)
                        End If
                    Else
                        TryConvertValue(mapping.TableProperty.TypeName, value, newRow.Details.Properties(mapping.TableProperty.Name).Value)
                    End If
                End If
                count = count + 1
            Next
        Next
    End Sub
    Private Sub ValidateData()
        Dim errorList As New List(Of String)
        Dim numRows = _excelDocRange.GetLength(0) - 1


        Dim processingDialogContent As New ProcessingDialog()
        Dim processingWindow As New ScreenChildWindow()
        'set parent to current screen
        Dim sdkProxy As IServiceProxy = VsExportProviderService.GetExportedValue(Of IServiceProxy)()
        processingWindow.Owner = DirectCast(sdkProxy.ScreenViewService.GetScreenView(_collection.Screen).RootUI, Control)
        processingWindow.Show(_collection.Screen, processingDialogContent)

        'Dispatch to the logical thread
        _collection.Screen.Details.Dispatcher.BeginInvoke(
            Sub()
                Try
                    'Validate First
                    For i = 1 To numRows
                        Dim currentRow As Int32 = i
                        Dim count As Int32 = 0
                        For Each mapping As ColumnMapping In _columnMappings
                            If mapping.TableProperty IsNot Nothing AndAlso mapping.TableProperty.Name <> "<Ignore>" Then
                                Dim value As String = _excelDocRange(currentRow, count)

                                If Not (String.IsNullOrEmpty(value)) Then
                                    If mapping.TableProperty.EntityType IsNot Nothing Then
                                        Dim targetEntityType As IEntityType = mapping.TableProperty.EntityType


                                        'Need to grab the entity set and check number of results we get
                                        'Search for the module that contains the entity set that we want
                                        Dim entityContainerDefinition As IEntityContainerDefinition
                                        Dim serviceProxy As IServiceProxy = VsExportProviderService.GetExportedValue(Of IServiceProxy)()
                                        Dim moduleWithEntitySets As IModuleDefinition =
                                            (From md As IModuleDefinition In serviceProxy.ModelService.Modules
                                            Where md.GlobalItems.OfType(Of IEntityContainerDefinition).Any(Function(ecd) ecd.EntitySets.Any(Function(es) es.EntityType Is targetEntityType))).FirstOrDefault()
                                        If moduleWithEntitySets IsNot Nothing Then
                                            entityContainerDefinition = (From ecd As IEntityContainerDefinition In moduleWithEntitySets.GlobalItems.OfType(Of IEntityContainerDefinition)()
                                                                        Where ecd.EntitySets.Any(Function(es) es.EntityType Is targetEntityType)).FirstOrDefault()
                                        End If

                                        'Dim appModel As IApplicationDefinition = _collection.Screen.Details.Application.Details.GetModel()
                                        'Dim entityContainerDefinition =
                                        '    (From ecd As IEntityContainerDefinition In appModel.GlobalItems.OfType(Of IEntityContainerDefinition)()
                                        '     Where ecd.EntitySets.Any(Function(es) es.EntityType Is targetEntityType)).FirstOrDefault()

                                        If entityContainerDefinition Is Nothing Then
                                            Throw New Exception("Could not find an entity container representing the entity type: " + targetEntityType.Name)
                                        End If
                                        Dim entitySetDefinition As IEntitySetDefinition = (From es As IEntitySetDefinition In entityContainerDefinition.EntitySets
                                                                                           Where es.EntityType Is targetEntityType).First

                                        Dim entitySet As IEntitySet = DirectCast(_collection.Screen.Details.DataWorkspace.Details.Properties(entityContainerDefinition.Name).Value, IDataService).Details.Properties(entitySetDefinition.Name).Value
                                        Dim dsQuery As IDataServiceQueryable = entitySet.GetQuery()

                                        'Search for the matching enitty for the relationship and add it to a cache
                                        If Not navProperties.ContainsKey(mapping.TableProperty.Name + "_" + value) Then
                                            Dim results As IEnumerable(Of IEntityObject) = SearchEntityMethodInfo.MakeGenericMethod({dsQuery.ElementType}).Invoke(Nothing, New Object() {dsQuery, value, targetEntityType})
                                            Dim searchCount As Int32 = results.Count
                                            If searchCount = 0 Then
                                                errorList.Add("Column:" + mapping.ExcelColumn + " Row:" + currentRow.ToString + " Cannot find a matching '" + mapping.TableProperty.DisplayName + "' for '" + value + "'")
                                            ElseIf searchCount > 1 Then
                                                errorList.Add("Column:" + mapping.ExcelColumn + " Row:" + currentRow.ToString + " Multiple matching '" + mapping.TableProperty.DisplayName + "' for '" + value + "'.  Will select first match.")
                                                navProperties(mapping.TableProperty.Name + "_" + value) = results.FirstOrDefault()
                                            Else
                                                navProperties(mapping.TableProperty.Name + "_" + value) = results.FirstOrDefault()
                                            End If
                                        End If
                                    Else
                                        Dim convertedValue As Object = Nothing
                                        Dim isValid As Boolean = TryConvertValue(mapping.TableProperty.TypeName, value, convertedValue)
                                        If isValid = False Then
                                            errorList.Add("Column:" + mapping.ExcelColumn + " Row:" + currentRow.ToString + " Cannot convert value(" + value + ") to " + mapping.TableProperty.TypeName + " for '" + mapping.TableProperty.DisplayName + "'")
                                        End If
                                    End If
                                ElseIf String.IsNullOrEmpty(value) AndAlso mapping.TableProperty.IsNullable = False AndAlso mapping.TableProperty.EntityType Is Nothing AndAlso mapping.TableProperty.TypeName <> "String" Then
                                    errorList.Add("Column: " + mapping.ExcelColumn + " Row:" + currentRow.ToString + " A value must be specified for " + mapping.TableProperty.DisplayName + ". A default value will be used.")
                                End If
                            End If
                            count = count + 1
                        Next
                    Next
                    Dispatchers.Main.Invoke(Sub()
                                                processingWindow.Close()
                                            End Sub)
                    If errorList.Count > 0 Then
                        DisplayErrors(errorList)
                    Else
                        'Add Items to Collection
                        AddItemsToCollection()
                    End If
                Catch ex As Exception
                    Dispatchers.Main.Invoke(Sub()
                                                processingWindow.Close()
                                            End Sub)
                    Throw ex
                End Try
            End Sub)
    End Sub
    Private Sub DisplayErrors(ByVal errorList As List(Of String))
        Dispatchers.Main.BeginInvoke(Sub()
                                         'Display some sort of dialog indicating that errors occurred
                                         Dim sdkProxy As IServiceProxy = VsExportProviderService.GetExportedValue(Of IServiceProxy)()
                                         Dim errorDialog As New ErrorList()
                                         Dim errorWindow As New ScreenChildWindow()
                                         errorDialog.DataContext = errorList
                                         errorWindow.DataContext = errorList
                                         errorWindow.Owner = DirectCast(sdkProxy.ScreenViewService.GetScreenView(_collection.Screen).RootUI, Control)

                                         AddHandler errorWindow.Closed, AddressOf OnErroDialogClosed
                                         errorWindow.Show(_collection.Screen, errorDialog)
                                     End Sub)
    End Sub
    Private Sub DisplayMappingDialog()
        'Below, this is generic code (irrespective of inbrowser vs. out of browser)
        Dim tablePropertyChoices As List(Of FieldDefinition) = GetTablePropertyChoices()
        _columnMappings = New List(Of ColumnMapping)
        Dim numColumns As Int32 = _excelDocRange.GetLength(1)
        For i = 0 To numColumns - 1
            _columnMappings.Add(New ColumnMapping(_excelDocRange(0, i), tablePropertyChoices))
        Next

        Dim columnMapperContent As New ColumnMapper()
        Dim columnMapperWindow As New ScreenChildWindow()
        columnMapperContent.DataContext = _columnMappings
        AddHandler columnMapperWindow.Closed, AddressOf OnMappingDialogClosed

        'set parent to current screen
        Dim sdkProxy As IServiceProxy = VsExportProviderService.GetExportedValue(Of IServiceProxy)()
        columnMapperWindow.Owner = DirectCast(sdkProxy.ScreenViewService.GetScreenView(_collection.Screen).RootUI, Control)
        columnMapperWindow.Show(_collection.Screen, columnMapperContent)
    End Sub

#Region "Dialog Closing Methods"
    Private Sub OnErroDialogClosed(ByVal sender As Object, ByVal e As EventArgs)
        Dim errorWindow As ScreenChildWindow = sender
        Dim result As Boolean? = errorWindow.DialogResult
        If result.HasValue AndAlso result.Value = True Then
            _collection.Screen.Details.Dispatcher.BeginInvoke(Sub()
                                                                  AddItemsToCollection()
                                                              End Sub)
        End If
    End Sub

    Private Sub OnMappingDialogClosed(ByVal sender As Object, ByVal e As EventArgs)
        Dim mappingWindow As ScreenChildWindow = sender
        Dim result As Boolean? = mappingWindow.DialogResult
        If result.HasValue AndAlso result.Value = True Then
            ValidateData()
        End If
    End Sub

    ''' <summary>
    ''' Invoked when our custom Silverlight window closes
    ''' </summary>
    Private Sub selectFileWindow_Closed(sender As Object, e As EventArgs)
        Dim selectFileWindow As ScreenChildWindow = sender
        ' Continue if they hit the OK button AND they selected a file
        Dim result As Boolean? = selectFileWindow.DialogResult
        If result.HasValue AndAlso result.Value = True Then
            Try
                Dim excelFile As FileInfo = DirectCast(selectFileWindow.Content, SelectFileWindow).ExcelDocument
                If excelFile IsNot Nothing Then
                    Dim myStream As System.IO.FileStream = excelFile.OpenRead
                    _excelDocRange = ImportCommaDelimitedStream(myStream)
                    myStream.Close()

                    DisplayMappingDialog()
                End If


            Catch secEx As SecurityException
                _collection.Screen.Details.Dispatcher.BeginInvoke(
                    Sub()
                        _collection.Screen.ShowMessageBox("Error: Silverlight Security error. The excel document must be in the My Documents folder.")
                    End Sub
                )
            Catch ex As Exception
                _collection.Screen.Details.Dispatcher.BeginInvoke(
                    Sub()
                        _collection.Screen.ShowMessageBox("Unknown error: " + ex.Message)
                    End Sub
                )
            End Try
        End If
    End Sub
#End Region


    Private Function GetTablePropertyChoices() As List(Of FieldDefinition)
        'Dim contentItem As IContentItem = Me.DataContext
        'Dim visualCollection As IVisualCollection = contentItem.Value
        Dim entityType As IEntityType = _collection.Details.GetModel.ElementType



        Dim tablePropertyChoices As New List(Of FieldDefinition)
        For Each p As IEntityPropertyDefinition In entityType.Properties
            'Ignore hidden fields and computed field
            If p.Attributes.Where(Function(a) a.Class.Name = "Computed").FirstOrDefault Is Nothing Then
                If Not TypeOf p.PropertyType Is ISequenceType Then
                    'ignore collections and entities
                    Dim fd As New FieldDefinition()
                    fd.Name = p.Name

                    'TODO: Get display name correctly

                    fd.DisplayName = p.GetDefaultDisplayName()
                    'fd.DisplayName = p.Name

                    Dim isNullable As Boolean
                    fd.TypeName = GetPropertyType(p.PropertyType, isNullable)
                    fd.IsNullable = isNullable
                    If fd.TypeName = "Entity" Then
                        fd.EntityType = DirectCast(p.PropertyType, IEntityType)
                    End If

                    tablePropertyChoices.Add(fd)
                End If
            End If
        Next
        tablePropertyChoices.Add(New FieldDefinition("<Ignore>", "<Ignore>", "", False))
        Return tablePropertyChoices
    End Function
    Private Function GetPropertyType(ByVal p As IDataType, ByRef isNullable As Boolean) As String
        Dim typeName As String = ""
        If TypeOf (p) Is ISemanticType Then
            typeName = DirectCast(p, ISemanticType).UnderlyingType.Name
            isNullable = False
        ElseIf TypeOf (p) Is INullableType AndAlso TypeOf (DirectCast(p, INullableType).UnderlyingType) Is ISemanticType Then
            typeName = DirectCast(DirectCast(p, INullableType).UnderlyingType, ISemanticType).UnderlyingType.Name
            isNullable = True
        ElseIf TypeOf (p) Is INullableType Then
            typeName = DirectCast(p, INullableType).UnderlyingType.Name
            isNullable = True
        ElseIf TypeOf (p) Is ISimpleType Then
            typeName = DirectCast(p, ISimpleType).Name
            isNullable = False
        ElseIf TypeOf (p) Is IEntityType Then
            typeName = "Entity"
            isNullable = True
            'fd.EntityType = DirectCast(p.PropertyType, IEntityType)
        Else
            Throw New NotSupportedException("Could not determine the property type")
        End If
        Return typeName
    End Function

#Region "Generic method to search an entity"
    Private _SearchEntityMethodInfo As MethodInfo
    Private Function SearchEntityMethodInfo() As MethodInfo
        If _SearchEntityMethodInfo Is Nothing Then
            _SearchEntityMethodInfo = GetType(Importer).GetMethod("SearchEntity", BindingFlags.Static Or BindingFlags.NonPublic)
            Debug.Assert(_SearchEntityMethodInfo IsNot Nothing)
        End If
        Return _SearchEntityMethodInfo
    End Function
    Private Function SearchEntity(Of T As IEntityObject)(ByVal query As IDataServiceQueryable(Of T), ByVal value As String, ByVal entityType As IEntityType) As IEnumerable(Of IEntityObject)
        'LOGIC
        'Search PK field (if only one)
        'Search summary field (if not computed)
        'Do a generic search

        If entityType.KeyProperties.Count = 1 Then
            Dim entityKey As IKeyPropertyDefinition = entityType.KeyProperties.First
            Dim propertyType As String = GetPropertyType(entityKey.PropertyType, Nothing)

            Dim convertedValue As Object = Nothing
            If TryConvertValue(propertyType, value, convertedValue) Then
                Dim pe As ParameterExpression = Expression.Parameter(query.ElementType, "entity")
                Dim wherePredicate As Expression = Expression.Equal(Expression.Property(pe, entityKey.Name), Expression.Constant(convertedValue))
                Dim whereExpression As Expression(Of Func(Of T, Boolean)) = Expression.Lambda(wherePredicate, pe)

                Dim keyResults As IEnumerable(Of IEntityObject) = query.Where(whereExpression).Execute.Cast(Of IEntityObject)()
                If keyResults.Count > 0 Then
                    Return keyResults
                End If
            End If
        End If

        Dim summaryProperty As IEntityPropertyDefinition = GetSummaryProperty(entityType)
        If summaryProperty IsNot Nothing AndAlso Not IsComputed(summaryProperty) Then
            Dim propertyType As String = GetPropertyType(summaryProperty.PropertyType, Nothing)

            Dim convertedValue As Object = Nothing
            If TryConvertValue(propertyType, value, convertedValue) Then
                Dim pe As ParameterExpression = Expression.Parameter(GetType(T), "entity")
                Dim wherePredicate As Expression = Expression.Equal(Expression.Property(pe, summaryProperty.Name), Expression.Constant(convertedValue))
                Dim whereExpression As Expression(Of Func(Of T, Boolean)) = Expression.Lambda(wherePredicate, pe)

                Dim summaryResults As IEnumerable(Of IEntityObject) = query.Where(whereExpression).Execute.Cast(Of IEntityObject)()
                If summaryResults.Count > 0 Then
                    Return summaryResults
                End If
            End If
        End If


        Return query.Search({value}).Execute().Cast(Of IEntityObject)()
    End Function
#End Region


#Region "Model Utilities"
    Private Function GetSummaryProperty(ByVal entityType As IEntityType) As IEntityPropertyDefinition
        'Return the specified property if one is specified
        Dim attribute As ISummaryPropertyAttribute = entityType.Attributes.OfType(Of ISummaryPropertyAttribute)().FirstOrDefault()
        If attribute IsNot Nothing AndAlso attribute.Property IsNot Nothing Then
            Return attribute.Property
        End If


        'If none is specified, try infer one
        Dim properties As IEnumerable(Of IEntityPropertyDefinition) = entityType.Properties.Where(Function(p) (Not TypeOf p Is INavigationPropertyDefinitionBase) AndAlso (Not p.PropertyType.Name.Contains("Binary")))
        Dim stringProperty As IEntityPropertyDefinition = properties.FirstOrDefault(Function(p) p.PropertyType.Name.Contains("String"))
        If stringProperty Is Nothing Then
            Return properties.FirstOrDefault
        Else
            Return stringProperty
        End If
    End Function

    Private Function IsComputed(ByVal entityProperty As IEntityPropertyDefinition) As Boolean
        Return entityProperty.Attributes.OfType(Of IComputedAttribute).Any()
    End Function

#End Region

    Private Function TryConvertValue(ByVal propertyType As String, ByVal value As String, ByRef convertedValue As Object) As Boolean
        Dim canConvert As Boolean = False

        Dim convertedTry As Object = Nothing

        Select Case propertyType
            Case "Binary"
                canConvert = False
            Case "Boolean"
                canConvert = Boolean.TryParse(value, convertedTry)
            Case "DateTime"
                canConvert = DateTime.TryParse(value, convertedTry)
            Case "Decimal"
                canConvert = Decimal.TryParse(value, convertedTry)
            Case "Double"
                canConvert = Double.TryParse(value, convertedTry)
            Case "Int32"
                canConvert = Int32.TryParse(value, convertedTry)
            Case "Int16"
                canConvert = Int16.TryParse(value, convertedTry)
            Case "Int64"
                canConvert = Int64.TryParse(value, convertedTry)
            Case "String"
                canConvert = True
                convertedTry = value
            Case Else
                Throw New NotSupportedException()
        End Select

        If canConvert Then
            convertedValue = convertedTry
        End If
        Return canConvert
    End Function
End Module

Public Class WorkSheetList
    Public Property SelectedItem As ExcelWorkSheet
    Public Property List As IEnumerable(Of ExcelWorkSheet)

    Public Sub New(ByVal baseList As IEnumerable(Of ExcelWorkSheet))
        List = baseList
        SelectedItem = List.FirstOrDefault()
    End Sub
End Class



Public Class ColumnMapping
    Public Sub New(ByVal excelColumn As String, ByVal tablePropertyChoices As List(Of FieldDefinition))
        Me.ExcelColumn = excelColumn
        Me.TablePropertyChoices = tablePropertyChoices

        'Try match up the column name to the table property choice
        TableProperty = tablePropertyChoices.Where(Function(f) f.Name = excelColumn OrElse f.DisplayName = excelColumn).FirstOrDefault()
    End Sub
    Public Property ExcelColumn As String
    Public Property TableProperty As FieldDefinition
    Public Property TablePropertyChoices As List(Of FieldDefinition)
End Class

Public Class FieldDefinition
    Public Property Name As String
    Public Property DisplayName As String
    Public Property TypeName As String
    Public Property IsNullable As Boolean
    Public Property EntityType As IEntityType

    Public Sub New()

    End Sub

    Public Sub New(ByVal name As String, ByVal displayName As String, ByVal typeName As String, ByVal isNullable As Boolean)
        Me.Name = name
        Me.DisplayName = displayName
        Me.TypeName = typeName
        Me.IsNullable = isNullable
    End Sub
End Class
