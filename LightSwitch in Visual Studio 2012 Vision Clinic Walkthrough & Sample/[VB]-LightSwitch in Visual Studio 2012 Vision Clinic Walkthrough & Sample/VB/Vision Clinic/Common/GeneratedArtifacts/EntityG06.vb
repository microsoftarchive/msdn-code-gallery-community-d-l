
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports __ProductRebate = LightSwitchApplication.ProductRebate

Namespace LightSwitchApplication

    #Region "Entities"
    
    ''' <summary>
    ''' No Modeled Description Available
    ''' </summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    Public NotInheritable Partial Class ProductRebate
        Inherits Global.Microsoft.LightSwitch.Framework.Base.EntityObject(Of __ProductRebate, __ProductRebate.DetailsClass)
    
        #Region "Constructors"
    
        ''' <summary>
        ''' Initializes a new instance of the ProductRebate entity.
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Sub New()
            Me.New(Nothing)
        End Sub
    
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Sub New(entitySet As Global.Microsoft.LightSwitch.Framework.EntitySet(Of __ProductRebate))
            MyBase.New(entitySet)
            
            __ProductRebate.DetailsClass.Initialize(Me)
        End Sub
    
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub ProductRebate_Created()
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub ProductRebate_AllowSaveWithErrors(ByRef result As Boolean)
        End Sub
    
        #End Region
    
        #Region "Private Properties"
        
        ''' <summary>
        ''' Gets the Application object for this application.  The Application object provides access to active screens, methods to open screens and access to the current user.
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Private ReadOnly Property Application As Global.Microsoft.LightSwitch.IApplication(Of Global.LightSwitchApplication.DataWorkspace)
            Get
                Return Global.LightSwitchApplication.Application.Current
            End Get
        End Property
        
        ''' <summary>
        ''' Gets the containing data workspace.  The data workspace provides access to all data sources in the application.
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Private ReadOnly Property DataWorkspace As Global.LightSwitchApplication.DataWorkspace
            Get
                Return DirectCast(Me.Details.EntitySet.Details.DataService.Details.DataWorkspace, Global.LightSwitchApplication.DataWorkspace)
            End Get
        End Property
        
        #End Region
    
        #Region "Public Properties"
    
        ''' <summary>
        ''' No Modeled Description Available
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public ReadOnly Property ProductRebateID As Integer
            Get
                Return __ProductRebate.DetailsClass.GetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.ProductRebateID)
            End Get
        End Property
        
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub ProductRebateID_IsReadOnly(ByRef result As Boolean)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub ProductRebateID_Validate(ByVal results As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub ProductRebateID_Changed()
        End Sub

        ''' <summary>
        ''' No Modeled Description Available
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Property RebateStart As Global.System.Nullable(Of Date)
            Get
                Return __ProductRebate.DetailsClass.GetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.RebateStart)
            End Get
            Set
                __ProductRebate.DetailsClass.SetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.RebateStart, Value)
            End Set
        End Property
        
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub RebateStart_IsReadOnly(ByRef result As Boolean)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub RebateStart_Validate(ByVal results As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub RebateStart_Changed()
        End Sub

        ''' <summary>
        ''' No Modeled Description Available
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Property RebateEnd As Global.System.Nullable(Of Date)
            Get
                Return __ProductRebate.DetailsClass.GetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.RebateEnd)
            End Get
            Set
                __ProductRebate.DetailsClass.SetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.RebateEnd, Value)
            End Set
        End Property
        
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub RebateEnd_IsReadOnly(ByRef result As Boolean)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub RebateEnd_Validate(ByVal results As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub RebateEnd_Changed()
        End Sub

        ''' <summary>
        ''' No Modeled Description Available
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Property Rebate As Global.System.Nullable(Of Decimal)
            Get
                Return __ProductRebate.DetailsClass.GetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.Rebate)
            End Get
            Set
                __ProductRebate.DetailsClass.SetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.Rebate, Value)
            End Set
        End Property
        
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub Rebate_IsReadOnly(ByRef result As Boolean)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub Rebate_Validate(ByVal results As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub Rebate_Changed()
        End Sub

        ''' <summary>
        ''' No Modeled Description Available
        ''' </summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Property Product As Global.LightSwitchApplication.Product
            Get
                Return __ProductRebate.DetailsClass.GetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.Product)
            End Get
            Set
                __ProductRebate.DetailsClass.SetValue(Me, __ProductRebate.DetailsClass.PropertySetProperties.Product, Value)
            End Set
        End Property
        
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub Product_IsReadOnly(ByRef result As Boolean)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub Product_Validate(ByVal results As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
        End Sub
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Private Partial Sub Product_Changed()
        End Sub

        #End Region
    
        #Region "Details Class"
    
        <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")> _
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public NotInheritable Class DetailsClass
            Inherits Global.Microsoft.LightSwitch.Details.Framework.Base.EntityDetails(Of _
                __ProductRebate, _
                __ProductRebate.DetailsClass, _
                __ProductRebate.DetailsClass.IImplementation, _
                __ProductRebate.DetailsClass.PropertySet, _
                Global.Microsoft.LightSwitch.Details.Framework.EntityCommandSet(Of __ProductRebate, __ProductRebate.DetailsClass), _
                Global.Microsoft.LightSwitch.Details.Framework.EntityMethodSet(Of __ProductRebate, __ProductRebate.DetailsClass))
    
            Shared Sub New()
                Dim initializeEntry = __ProductRebate.DetailsClass.PropertySetProperties.ProductRebateID
            End Sub
    
            <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
            Private Shared ReadOnly __ProductRebateEntry As Global.Microsoft.LightSwitch.Details.Framework.Base.EntityDetails(Of __ProductRebate, __ProductRebate.DetailsClass).Entry = _
                New Global.Microsoft.LightSwitch.Details.Framework.Base.EntityDetails(Of __ProductRebate, __ProductRebate.DetailsClass).Entry( _
                    AddressOf __ProductRebate.DetailsClass.__ProductRebate_CreateNew, _
                    AddressOf __ProductRebate.DetailsClass.__ProductRebate_Created, _
                    AddressOf __ProductRebate.DetailsClass.__ProductRebate_AllowSaveWithErrors)
            Private Shared Function __ProductRebate_CreateNew(es As Global.Microsoft.LightSwitch.Framework.EntitySet(Of __ProductRebate)) As __ProductRebate
                Return New __ProductRebate(es)
            End Function
            Private Shared Sub __ProductRebate_Created(e As __ProductRebate)
                e.ProductRebate_Created()
            End Sub
            Private Shared Function __ProductRebate_AllowSaveWithErrors(e As __ProductRebate) As Boolean
                Dim result As Boolean = False
                e.ProductRebate_AllowSaveWithErrors(result)
                Return result
            End Function
    
            Public Sub New()
                MyBase.New()
            End Sub
    
            Public ReadOnly Shadows Property Commands As Global.Microsoft.LightSwitch.Details.Framework.EntityCommandSet(Of __ProductRebate, __ProductRebate.DetailsClass)
                Get
                    Return MyBase.Commands
                End Get
            End Property
    
            Public ReadOnly Shadows Property Methods As Global.Microsoft.LightSwitch.Details.Framework.EntityMethodSet(Of __ProductRebate, __ProductRebate.DetailsClass)
                Get
                    Return MyBase.Methods
                End Get
            End Property
    
            Public ReadOnly Shadows Property Properties As __ProductRebate.DetailsClass.PropertySet
                Get
                    Return MyBase.Properties
                End Get
            End Property
    
            <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
            <Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")> _
            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
            Public NotInheritable Class PropertySet
                Inherits Global.Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet(Of __ProductRebate, __ProductRebate.DetailsClass)
    
                Public Sub New()
                    MyBase.New()
                End Sub
    
                Public ReadOnly Property ProductRebateID As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Integer)
                    Get
                        Return TryCast(
                            MyBase.GetItem(__ProductRebate.DetailsClass.PropertySetProperties.ProductRebateID),
                            Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Integer))
                    End Get
                End Property
                
                Public ReadOnly Property RebateStart As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date))
                    Get
                        Return TryCast(
                            MyBase.GetItem(__ProductRebate.DetailsClass.PropertySetProperties.RebateStart),
                            Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)))
                    End Get
                End Property
                
                Public ReadOnly Property RebateEnd As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date))
                    Get
                        Return TryCast(
                            MyBase.GetItem(__ProductRebate.DetailsClass.PropertySetProperties.RebateEnd),
                            Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)))
                    End Get
                End Property
                
                Public ReadOnly Property Rebate As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Decimal))
                    Get
                        Return TryCast(
                            MyBase.GetItem(__ProductRebate.DetailsClass.PropertySetProperties.Rebate),
                            Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Decimal)))
                    End Get
                End Property
                
                Public ReadOnly Property Product As Global.Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.LightSwitchApplication.Product)
                    Get
                        Return TryCast(
                            MyBase.GetItem(__ProductRebate.DetailsClass.PropertySetProperties.Product),
                            Global.Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.LightSwitchApplication.Product))
                    End Get
                End Property
                
            End Class
    
            <Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")> _
            Public Interface IImplementation
                Inherits Global.Microsoft.LightSwitch.Internal.IEntityImplementation
    
                Shadows ReadOnly Property ProductRebateID As Integer
                Shadows Property RebateStart As Global.System.Nullable(Of Date)
                Shadows Property RebateEnd As Global.System.Nullable(Of Date)
                Shadows Property Rebate As Global.System.Nullable(Of Decimal)
                Shadows Property Product As Global.Microsoft.LightSwitch.Internal.IEntityImplementation
    
            End Interface
    
            <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
            Friend Class PropertySetProperties
    
                <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
                Public Shared ReadOnly ProductRebateID As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Integer).Entry = _
                    New Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Integer).Entry( _
                        "ProductRebateID", _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._ProductRebateID_Stub, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._ProductRebateID_ComputeIsReadOnly, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._ProductRebateID_Validate, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._ProductRebateID_GetImplementationValue, _
                        Nothing, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._ProductRebateID_OnValueChanged)
                Private Shared Sub _ProductRebateID_Stub(c As Global.Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback(Of __ProductRebate.DetailsClass, Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Integer).Data), d As __ProductRebate.DetailsClass, sf As Object)
                    c(d, d._ProductRebateID, sf)
                End Sub
                Private Shared Function _ProductRebateID_ComputeIsReadOnly(e As __ProductRebate) As Boolean
                    Dim result As Boolean = False
                    e.ProductRebateID_IsReadOnly(result)
                    Return result
                End Function
                Private Shared Sub _ProductRebateID_Validate(e As __ProductRebate, r As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
                    e.ProductRebateID_Validate(r)
                End Sub
                Private Shared Function _ProductRebateID_GetImplementationValue(d As __ProductRebate.DetailsClass) As Integer
                    Return d.ImplementationEntity.ProductRebateID
                End Function
                Private Shared Sub _ProductRebateID_OnValueChanged(e As __ProductRebate)
                    e.ProductRebateID_Changed()
                End Sub
    
                <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
                Public Shared ReadOnly RebateStart As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Entry = _
                    New Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Entry( _
                        "RebateStart", _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateStart_Stub, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateStart_ComputeIsReadOnly, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateStart_Validate, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateStart_GetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateStart_SetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateStart_OnValueChanged)
                Private Shared Sub _RebateStart_Stub(c As Global.Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback(Of __ProductRebate.DetailsClass, Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Data), d As __ProductRebate.DetailsClass, sf As Object)
                    c(d, d._RebateStart, sf)
                End Sub
                Private Shared Function _RebateStart_ComputeIsReadOnly(e As __ProductRebate) As Boolean
                    Dim result As Boolean = False
                    e.RebateStart_IsReadOnly(result)
                    Return result
                End Function
                Private Shared Sub _RebateStart_Validate(e As __ProductRebate, r As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
                    e.RebateStart_Validate(r)
                End Sub
                Private Shared Function _RebateStart_GetImplementationValue(d As __ProductRebate.DetailsClass) As Global.System.Nullable(Of Date)
                    Return d.ImplementationEntity.RebateStart
                End Function
                Private Shared Sub _RebateStart_SetImplementationValue(d As __ProductRebate.DetailsClass, v As Global.System.Nullable(Of Date))
                    d.ImplementationEntity.RebateStart = __ProductRebate.DetailsClass.ClearDateTimeKind(v)
                End Sub
                Private Shared Sub _RebateStart_OnValueChanged(e As __ProductRebate)
                    e.RebateStart_Changed()
                End Sub
    
                <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
                Public Shared ReadOnly RebateEnd As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Entry = _
                    New Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Entry( _
                        "RebateEnd", _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateEnd_Stub, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateEnd_ComputeIsReadOnly, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateEnd_Validate, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateEnd_GetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateEnd_SetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._RebateEnd_OnValueChanged)
                Private Shared Sub _RebateEnd_Stub(c As Global.Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback(Of __ProductRebate.DetailsClass, Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Data), d As __ProductRebate.DetailsClass, sf As Object)
                    c(d, d._RebateEnd, sf)
                End Sub
                Private Shared Function _RebateEnd_ComputeIsReadOnly(e As __ProductRebate) As Boolean
                    Dim result As Boolean = False
                    e.RebateEnd_IsReadOnly(result)
                    Return result
                End Function
                Private Shared Sub _RebateEnd_Validate(e As __ProductRebate, r As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
                    e.RebateEnd_Validate(r)
                End Sub
                Private Shared Function _RebateEnd_GetImplementationValue(d As __ProductRebate.DetailsClass) As Global.System.Nullable(Of Date)
                    Return d.ImplementationEntity.RebateEnd
                End Function
                Private Shared Sub _RebateEnd_SetImplementationValue(d As __ProductRebate.DetailsClass, v As Global.System.Nullable(Of Date))
                    d.ImplementationEntity.RebateEnd = __ProductRebate.DetailsClass.ClearDateTimeKind(v)
                End Sub
                Private Shared Sub _RebateEnd_OnValueChanged(e As __ProductRebate)
                    e.RebateEnd_Changed()
                End Sub
    
                <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
                Public Shared ReadOnly Rebate As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Decimal)).Entry = _
                    New Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Decimal)).Entry( _
                        "Rebate", _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Rebate_Stub, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Rebate_ComputeIsReadOnly, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Rebate_Validate, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Rebate_GetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Rebate_SetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Rebate_OnValueChanged)
                Private Shared Sub _Rebate_Stub(c As Global.Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback(Of __ProductRebate.DetailsClass, Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Decimal)).Data), d As __ProductRebate.DetailsClass, sf As Object)
                    c(d, d._Rebate, sf)
                End Sub
                Private Shared Function _Rebate_ComputeIsReadOnly(e As __ProductRebate) As Boolean
                    Dim result As Boolean = False
                    e.Rebate_IsReadOnly(result)
                    Return result
                End Function
                Private Shared Sub _Rebate_Validate(e As __ProductRebate, r As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
                    e.Rebate_Validate(r)
                End Sub
                Private Shared Function _Rebate_GetImplementationValue(d As __ProductRebate.DetailsClass) As Global.System.Nullable(Of Decimal)
                    Return d.ImplementationEntity.Rebate
                End Function
                Private Shared Sub _Rebate_SetImplementationValue(d As __ProductRebate.DetailsClass, v As Global.System.Nullable(Of Decimal))
                    d.ImplementationEntity.Rebate = v
                End Sub
                Private Shared Sub _Rebate_OnValueChanged(e As __ProductRebate)
                    e.Rebate_Changed()
                End Sub
    
                <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
                Public Shared ReadOnly Product As Global.Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.LightSwitchApplication.Product).Entry = _
                    New Global.Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.LightSwitchApplication.Product).Entry( _
                        "Product", _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_Stub, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_ComputeIsReadOnly, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_Validate, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_GetCoreImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_GetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_SetImplementationValue, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_Refresh, _
                        AddressOf __ProductRebate.DetailsClass.PropertySetProperties._Product_OnValueChanged)
                Private Shared Sub _Product_Stub(c As Global.Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback(Of __ProductRebate.DetailsClass, Global.Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.LightSwitchApplication.Product).Data), d As __ProductRebate.DetailsClass, sf As Object)
                    c(d, d._Product, sf)
                End Sub
                Private Shared Function _Product_ComputeIsReadOnly(e As __ProductRebate) As Boolean
                    Dim result As Boolean = False
                    e.Product_IsReadOnly(result)
                    Return result
                End Function
                Private Shared Sub _Product_Validate(e As __ProductRebate, r As Global.Microsoft.LightSwitch.EntityValidationResultsBuilder)
                    e.Product_Validate(r)
                End Sub
                Private Shared Function _Product_GetCoreImplementationValue(d as __ProductRebate.DetailsClass) As Global.Microsoft.LightSwitch.Internal.IEntityImplementation
                    Return d.ImplementationEntity.Product
                End Function
                Private Shared Function _Product_GetImplementationValue(d as __ProductRebate.DetailsClass) As Global.LightSwitchApplication.Product
                    Return d.GetImplementationValue(Of Global.LightSwitchApplication.Product, Global.LightSwitchApplication.Product.DetailsClass)(__ProductRebate.DetailsClass.PropertySetProperties.Product, d._Product)
                End Function
                Private Shared Sub _Product_SetImplementationValue(d As __ProductRebate.DetailsClass, v As Global.LightSwitchApplication.Product)
                    d.SetImplementationValue(__ProductRebate.DetailsClass.PropertySetProperties.Product, d._Product, Sub(i, ev) i.Product = ev, v)
                End Sub
                Private Shared Sub _Product_Refresh(d As __ProductRebate.DetailsClass)
                    d.RefreshNavigationProperty(__ProductRebate.DetailsClass.PropertySetProperties.Product, d._Product)
                End Sub
                Private Shared Sub _Product_OnValueChanged(e As __ProductRebate)
                    e.Product_Changed()
                End Sub
    
            End Class
    
            <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
            Private _ProductRebateID As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Integer).Data
            
            <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
            Private _RebateStart As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Data
            
            <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
            Private _RebateEnd As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Date)).Data
            
            <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
            Private _Rebate As Global.Microsoft.LightSwitch.Details.Framework.EntityStorageProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.System.Nullable(Of Decimal)).Data
            
            <Global.System.Diagnostics.DebuggerBrowsable(Global.System.Diagnostics.DebuggerBrowsableState.Never)> _
            Private _Product As Global.Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty(Of __ProductRebate, __ProductRebate.DetailsClass, Global.LightSwitchApplication.Product).Data
            
        End Class
    
        #End Region
    
    End Class
    
    #End Region
End Namespace
