
namespace HRApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the AdventureWorks_DataEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class OrganizationService : LinqToEntitiesDomainService<AdventureWorks_DataEntities>
    {

        // TODO: Consider
        // 1. Adding parameters to this method and constraining returned results, and/or
        // 2. Adding query methods taking different parameters.
        public IQueryable<Employee> GetEmployees()
        {
            return this.ObjectContext.Employees.OrderBy(e => e.EmployeeID);
        }

        public IQueryable<Employee> GetSalariedEmployees()
        {
            return this.ObjectContext.Employees.Where(e => e.SalariedFlag == true).OrderBy(e => e.EmployeeID);
        }

        [RequiresAuthentication()]
        public void ApproveSabbatical(Employee current)
        {
            // Start custom workflow here
           
            this.ObjectContext.Employees.AttachAsModified(current);
            current.CurrentFlag = false;
            
        }

        public void InsertEmployee(Employee employee)
        {
            // Modify the employee data to meet the database constraints.
            employee.HireDate = DateTime.Now;
            employee.ModifiedDate = DateTime.Now;
            employee.VacationHours = 0;
            employee.SickLeaveHours = 0;
            employee.rowguid = Guid.NewGuid();
            employee.ContactID = 1001;
            employee.BirthDate = new DateTime(1967, 3, 18);

            if ((employee.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(employee, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Employees.AddObject(employee);
            }
        }

        public void UpdateEmployee(Employee currentEmployee)
        {
            this.ObjectContext.Employees.AttachAsModified(currentEmployee, this.ChangeSet.GetOriginal(currentEmployee));
        }

        public void DeleteEmployee(Employee employee)
        {
            if ((employee.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Employees.Attach(employee);
            }
            this.ObjectContext.Employees.DeleteObject(employee);
        }
    }
}


