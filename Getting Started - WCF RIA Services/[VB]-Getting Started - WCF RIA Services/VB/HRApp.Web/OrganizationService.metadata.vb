
Option Compare Binary
Option Infer On
Option Strict On
Option Explicit On

Imports HRApp
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server


'The MetadataTypeAttribute identifies EmployeeMetadata as the class
' that carries additional metadata for the Employee class.
<MetadataTypeAttribute(GetType(Employee.EmployeeMetadata))>  _
Partial Public Class Employee
    
    'This class allows you to attach custom attributes to properties
    ' of the Employee class.
    '
    'For example, the following marks the Xyz property as a
    ' required property and specifies the format for valid values:
    '    <Required()>
    '    <RegularExpression("[A-Z][A-Za-z0-9]*")>
    '    <StringLength(32)>
    '    Public Property Xyz As String
    Friend NotInheritable Class EmployeeMetadata
        
        'Metadata classes are not meant to be instantiated.
        Private Sub New()
            MyBase.New
        End Sub
        
        Public Property BirthDate As DateTime
        
        Public Property ContactID As Integer
        
        Public Property CurrentFlag As Boolean
        
        Public Property Employee1 As EntityCollection(Of Employee)
        
        Public Property Employee2 As Employee
        
        Public Property EmployeeID As Integer

        <Required()> _
        <CustomValidation(GetType(GenderValidator), "IsGenderValid")> _
        Public Property Gender As String
        
        Public Property HireDate As DateTime
        
        Public Property LoginID As String
        
        Public Property ManagerID As Nullable(Of Integer)
        
        Public Property MaritalStatus As String
        
        Public Property ModifiedDate As DateTime
        
        Public Property NationalIDNumber As String
        
        Public Property rowguid As Guid
        
        Public Property SalariedFlag As Boolean
        
        Public Property SickLeaveHours As Short
        
        Public Property Title As String

        <Range(0, 70)> _
        Public Property VacationHours As Short
    End Class
End Class

