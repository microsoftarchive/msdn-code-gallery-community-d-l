﻿
'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

<Assembly: EdmSchemaAttribute("b69ee3ee-2e67-4f5a-ade3-804c3df7c156")>
#Region "EDM Relationship Metadata"
<Assembly: EdmRelationshipAttribute("AdventureWorks_DataModel", "FK_Employee_Employee_ManagerID", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, GetType(Employee), "Employee1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Employee), True)>

#End Region

#Region "Contexts"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
Public Partial Class AdventureWorks_DataEntities
    Inherits ObjectContext

    #Region "Constructors"

    ''' <summary>
    ''' Initializes a new AdventureWorks_DataEntities object using the connection string found in the 'AdventureWorks_DataEntities' section of the application configuration file.
    ''' </summary>
    Public Sub New()
        MyBase.New("name=AdventureWorks_DataEntities", "AdventureWorks_DataEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new AdventureWorks_DataEntities object.
    ''' </summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "AdventureWorks_DataEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new AdventureWorks_DataEntities object.
    ''' </summary>
    Public Sub New(ByVal connection As EntityConnection)
        MyBase.New(connection, "AdventureWorks_DataEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    #End Region

    #Region "Partial Methods"

    Partial Private Sub OnContextCreated()
    End Sub

    #End Region

    #Region "ObjectSet Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    Public ReadOnly Property Employees() As ObjectSet(Of Employee)
        Get
            If (_Employees Is Nothing) Then
                _Employees = MyBase.CreateObjectSet(Of Employee)("Employees")
            End If
            Return _Employees
        End Get
    End Property

    Private _Employees As ObjectSet(Of Employee)

    #End Region
    #Region "AddTo Methods"

    ''' <summary>
    ''' Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
    ''' </summary>
    Public Sub AddToEmployees(ByVal employee As Employee)
        MyBase.AddObject("Employees", employee)
    End Sub

    #End Region
End Class

#End Region
#Region "Entities"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
<EdmEntityTypeAttribute(NamespaceName:="AdventureWorks_DataModel", Name:="Employee")>
<Serializable()>
<DataContractAttribute(IsReference:=True)>
Public Partial Class Employee
    Inherits EntityObject
    #Region "Factory Method"

    ''' <summary>
    ''' Create a new Employee object.
    ''' </summary>
    ''' <param name="employeeID">Initial value of the EmployeeID property.</param>
    ''' <param name="nationalIDNumber">Initial value of the NationalIDNumber property.</param>
    ''' <param name="contactID">Initial value of the ContactID property.</param>
    ''' <param name="loginID">Initial value of the LoginID property.</param>
    ''' <param name="title">Initial value of the Title property.</param>
    ''' <param name="birthDate">Initial value of the BirthDate property.</param>
    ''' <param name="maritalStatus">Initial value of the MaritalStatus property.</param>
    ''' <param name="gender">Initial value of the Gender property.</param>
    ''' <param name="hireDate">Initial value of the HireDate property.</param>
    ''' <param name="salariedFlag">Initial value of the SalariedFlag property.</param>
    ''' <param name="vacationHours">Initial value of the VacationHours property.</param>
    ''' <param name="sickLeaveHours">Initial value of the SickLeaveHours property.</param>
    ''' <param name="currentFlag">Initial value of the CurrentFlag property.</param>
    ''' <param name="rowguid">Initial value of the rowguid property.</param>
    ''' <param name="modifiedDate">Initial value of the ModifiedDate property.</param>
    Public Shared Function CreateEmployee(employeeID As Global.System.Int32, nationalIDNumber As Global.System.String, contactID As Global.System.Int32, loginID As Global.System.String, title As Global.System.String, birthDate As Global.System.DateTime, maritalStatus As Global.System.String, gender As Global.System.String, hireDate As Global.System.DateTime, salariedFlag As Global.System.Boolean, vacationHours As Global.System.Int16, sickLeaveHours As Global.System.Int16, currentFlag As Global.System.Boolean, rowguid As Global.System.Guid, modifiedDate As Global.System.DateTime) As Employee
        Dim employee as Employee = New Employee
        employee.EmployeeID = employeeID
        employee.NationalIDNumber = nationalIDNumber
        employee.ContactID = contactID
        employee.LoginID = loginID
        employee.Title = title
        employee.BirthDate = birthDate
        employee.MaritalStatus = maritalStatus
        employee.Gender = gender
        employee.HireDate = hireDate
        employee.SalariedFlag = salariedFlag
        employee.VacationHours = vacationHours
        employee.SickLeaveHours = sickLeaveHours
        employee.CurrentFlag = currentFlag
        employee.rowguid = rowguid
        employee.ModifiedDate = modifiedDate
        Return employee
    End Function

    #End Region
    #Region "Primitive Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property EmployeeID() As Global.System.Int32
        Get
            Return _EmployeeID
        End Get
        Set
            If (_EmployeeID <> Value) Then
                OnEmployeeIDChanging(value)
                ReportPropertyChanging("EmployeeID")
                _EmployeeID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("EmployeeID")
                OnEmployeeIDChanged()
            End If
        End Set
    End Property

    Private _EmployeeID As Global.System.Int32
    Private Partial Sub OnEmployeeIDChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnEmployeeIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property NationalIDNumber() As Global.System.String
        Get
            Return _NationalIDNumber
        End Get
        Set
            OnNationalIDNumberChanging(value)
            ReportPropertyChanging("NationalIDNumber")
            _NationalIDNumber = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("NationalIDNumber")
            OnNationalIDNumberChanged()
        End Set
    End Property

    Private _NationalIDNumber As Global.System.String
    Private Partial Sub OnNationalIDNumberChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnNationalIDNumberChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property ContactID() As Global.System.Int32
        Get
            Return _ContactID
        End Get
        Set
            OnContactIDChanging(value)
            ReportPropertyChanging("ContactID")
            _ContactID = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("ContactID")
            OnContactIDChanged()
        End Set
    End Property

    Private _ContactID As Global.System.Int32
    Private Partial Sub OnContactIDChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnContactIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property LoginID() As Global.System.String
        Get
            Return _LoginID
        End Get
        Set
            OnLoginIDChanging(value)
            ReportPropertyChanging("LoginID")
            _LoginID = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("LoginID")
            OnLoginIDChanged()
        End Set
    End Property

    Private _LoginID As Global.System.String
    Private Partial Sub OnLoginIDChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnLoginIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property ManagerID() As Nullable(Of Global.System.Int32)
        Get
            Return _ManagerID
        End Get
        Set
            OnManagerIDChanging(value)
            ReportPropertyChanging("ManagerID")
            _ManagerID = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("ManagerID")
            OnManagerIDChanged()
        End Set
    End Property

    Private _ManagerID As Nullable(Of Global.System.Int32)
    Private Partial Sub OnManagerIDChanging(value As Nullable(Of Global.System.Int32))
    End Sub

    Private Partial Sub OnManagerIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Title() As Global.System.String
        Get
            Return _Title
        End Get
        Set
            OnTitleChanging(value)
            ReportPropertyChanging("Title")
            _Title = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("Title")
            OnTitleChanged()
        End Set
    End Property

    Private _Title As Global.System.String
    Private Partial Sub OnTitleChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnTitleChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property BirthDate() As Global.System.DateTime
        Get
            Return _BirthDate
        End Get
        Set
            OnBirthDateChanging(value)
            ReportPropertyChanging("BirthDate")
            _BirthDate = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("BirthDate")
            OnBirthDateChanged()
        End Set
    End Property

    Private _BirthDate As Global.System.DateTime
    Private Partial Sub OnBirthDateChanging(value As Global.System.DateTime)
    End Sub

    Private Partial Sub OnBirthDateChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property MaritalStatus() As Global.System.String
        Get
            Return _MaritalStatus
        End Get
        Set
            OnMaritalStatusChanging(value)
            ReportPropertyChanging("MaritalStatus")
            _MaritalStatus = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("MaritalStatus")
            OnMaritalStatusChanged()
        End Set
    End Property

    Private _MaritalStatus As Global.System.String
    Private Partial Sub OnMaritalStatusChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnMaritalStatusChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Gender() As Global.System.String
        Get
            Return _Gender
        End Get
        Set
            OnGenderChanging(value)
            ReportPropertyChanging("Gender")
            _Gender = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("Gender")
            OnGenderChanged()
        End Set
    End Property

    Private _Gender As Global.System.String
    Private Partial Sub OnGenderChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnGenderChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property HireDate() As Global.System.DateTime
        Get
            Return _HireDate
        End Get
        Set
            OnHireDateChanging(value)
            ReportPropertyChanging("HireDate")
            _HireDate = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("HireDate")
            OnHireDateChanged()
        End Set
    End Property

    Private _HireDate As Global.System.DateTime
    Private Partial Sub OnHireDateChanging(value As Global.System.DateTime)
    End Sub

    Private Partial Sub OnHireDateChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property SalariedFlag() As Global.System.Boolean
        Get
            Return _SalariedFlag
        End Get
        Set
            OnSalariedFlagChanging(value)
            ReportPropertyChanging("SalariedFlag")
            _SalariedFlag = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("SalariedFlag")
            OnSalariedFlagChanged()
        End Set
    End Property

    Private _SalariedFlag As Global.System.Boolean
    Private Partial Sub OnSalariedFlagChanging(value As Global.System.Boolean)
    End Sub

    Private Partial Sub OnSalariedFlagChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property VacationHours() As Global.System.Int16
        Get
            Return _VacationHours
        End Get
        Set
            OnVacationHoursChanging(value)
            ReportPropertyChanging("VacationHours")
            _VacationHours = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("VacationHours")
            OnVacationHoursChanged()
        End Set
    End Property

    Private _VacationHours As Global.System.Int16
    Private Partial Sub OnVacationHoursChanging(value As Global.System.Int16)
    End Sub

    Private Partial Sub OnVacationHoursChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property SickLeaveHours() As Global.System.Int16
        Get
            Return _SickLeaveHours
        End Get
        Set
            OnSickLeaveHoursChanging(value)
            ReportPropertyChanging("SickLeaveHours")
            _SickLeaveHours = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("SickLeaveHours")
            OnSickLeaveHoursChanged()
        End Set
    End Property

    Private _SickLeaveHours As Global.System.Int16
    Private Partial Sub OnSickLeaveHoursChanging(value As Global.System.Int16)
    End Sub

    Private Partial Sub OnSickLeaveHoursChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property CurrentFlag() As Global.System.Boolean
        Get
            Return _CurrentFlag
        End Get
        Set
            OnCurrentFlagChanging(value)
            ReportPropertyChanging("CurrentFlag")
            _CurrentFlag = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("CurrentFlag")
            OnCurrentFlagChanged()
        End Set
    End Property

    Private _CurrentFlag As Global.System.Boolean
    Private Partial Sub OnCurrentFlagChanging(value As Global.System.Boolean)
    End Sub

    Private Partial Sub OnCurrentFlagChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property rowguid() As Global.System.Guid
        Get
            Return _rowguid
        End Get
        Set
            OnrowguidChanging(value)
            ReportPropertyChanging("rowguid")
            _rowguid = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("rowguid")
            OnrowguidChanged()
        End Set
    End Property

    Private _rowguid As Global.System.Guid
    Private Partial Sub OnrowguidChanging(value As Global.System.Guid)
    End Sub

    Private Partial Sub OnrowguidChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property ModifiedDate() As Global.System.DateTime
        Get
            Return _ModifiedDate
        End Get
        Set
            OnModifiedDateChanging(value)
            ReportPropertyChanging("ModifiedDate")
            _ModifiedDate = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("ModifiedDate")
            OnModifiedDateChanged()
        End Set
    End Property

    Private _ModifiedDate As Global.System.DateTime
    Private Partial Sub OnModifiedDateChanging(value As Global.System.DateTime)
    End Sub

    Private Partial Sub OnModifiedDateChanged()
    End Sub

    #End Region
    #Region "Navigation Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <XmlIgnoreAttribute()>
    <SoapIgnoreAttribute()>
    <DataMemberAttribute()>
    <EdmRelationshipNavigationPropertyAttribute("AdventureWorks_DataModel", "FK_Employee_Employee_ManagerID", "Employee1")>
     Public Property Employee1() As EntityCollection(Of Employee)
        Get
            Return CType(Me,IEntityWithRelationships).RelationshipManager.GetRelatedCollection(Of Employee)("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee1")
        End Get
        Set
            If (Not value Is Nothing)
                CType(Me, IEntityWithRelationships).RelationshipManager.InitializeRelatedCollection(Of Employee)("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee1", value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <XmlIgnoreAttribute()>
    <SoapIgnoreAttribute()>
    <DataMemberAttribute()>
    <EdmRelationshipNavigationPropertyAttribute("AdventureWorks_DataModel", "FK_Employee_Employee_ManagerID", "Employee")>
    Public Property Employee2() As Employee
        Get
            Return CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Employee)("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee").Value
        End Get
        Set
            CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Employee)("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee").Value = value
        End Set
    End Property
    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <BrowsableAttribute(False)>
    <DataMemberAttribute()>
    Public Property Employee2Reference() As EntityReference(Of Employee)
        Get
            Return CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Employee)("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee")
        End Get
        Set
            If (Not value Is Nothing)
                CType(Me, IEntityWithRelationships).RelationshipManager.InitializeRelatedReference(Of Employee)("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee", value)
            End If
        End Set
    End Property

    #End Region
End Class

#End Region

