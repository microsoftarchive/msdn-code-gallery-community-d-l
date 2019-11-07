
Option Compare Binary
Option Infer On
Option Strict On
Option Explicit On

Imports HRApp
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Data
Imports System.Linq
Imports System.ServiceModel.DomainServices.EntityFramework
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server


'Implements application logic using the AdventureWorks_DataEntities context.
' TODO: Add your application logic to these methods or in additional methods.
' TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
' Also consider adding roles to restrict access as appropriate.
'<RequiresAuthentication> _
<EnableClientAccess()>  _
Public Class OrganizationService
    Inherits LinqToEntitiesDomainService(Of AdventureWorks_DataEntities)
    
    'TODO: Consider
    ' 1. Adding parameters to this method and constraining returned results, and/or
    ' 2. Adding query methods taking different parameters.
    Public Function GetEmployees() As IQueryable(Of Employee)
        Return Me.ObjectContext.Employees.OrderBy(Function(e) e.EmployeeID)
    End Function

    Public Function GetSalariedEmployees() As IQueryable(Of Employee)
        Return Me.ObjectContext.Employees.Where(Function(e) e.SalariedFlag = True).OrderBy(Function(e) e.EmployeeID)
    End Function

    <RequiresAuthentication()> _
    Public Sub ApproveSabbatical(ByVal current As Employee)
        Me.ObjectContext.Employees.AttachAsModified(current)
        current.CurrentFlag = False
    End Sub


    Public Sub InsertEmployee(ByVal employee As Employee)
        'Modify the employee data to meet the database constraints.
        employee.HireDate = DateTime.Now
        employee.ModifiedDate = DateTime.Now
        employee.VacationHours = 0
        employee.SickLeaveHours = 0
        employee.rowguid = Guid.NewGuid()
        employee.ContactID = 1001
        employee.BirthDate = New DateTime(1967, 3, 18)

        If ((employee.EntityState = EntityState.Detached) _
                    = False) Then
            Me.ObjectContext.ObjectStateManager.ChangeObjectState(employee, EntityState.Added)
        Else
            Me.ObjectContext.Employees.AddObject(employee)
        End If
    End Sub
    
    Public Sub UpdateEmployee(ByVal currentEmployee As Employee)
        Me.ObjectContext.Employees.AttachAsModified(currentEmployee, Me.ChangeSet.GetOriginal(currentEmployee))
    End Sub
    
    Public Sub DeleteEmployee(ByVal employee As Employee)
        If (employee.EntityState = EntityState.Detached) Then
            Me.ObjectContext.Employees.Attach(employee)
        End If
        Me.ObjectContext.Employees.DeleteObject(employee)
    End Sub
End Class

