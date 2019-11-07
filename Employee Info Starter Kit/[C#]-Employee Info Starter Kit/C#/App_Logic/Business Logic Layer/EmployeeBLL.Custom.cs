/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using System;
using Eisk.Helpers;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Eisk.BusinessEntities;
namespace Eisk.BusinessLogicLayer
{
    public partial class EmployeeBLL
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<Employee> GetEmployeesByFilter(
            string lastName = "", string firstName = "", 
            int? reportsTo = 0,
            DateTime birthDate = default(DateTime), 
            DateTime hireDateFrom = default(DateTime), DateTime hireDateTo = default(DateTime))
        {
            if (hireDateFrom.IsEmpty()) hireDateFrom = (DateTime)SqlDateTime.MinValue;
            if (hireDateTo.IsEmpty()) hireDateTo = (DateTime)SqlDateTime.MaxValue;
            
            return (
                from employee in _DatabaseContext.Employees
                    where
                        (lastName.IsEmpty() ? true : employee.LastName.Contains(lastName)) &&
                        (firstName.IsEmpty() ? true : employee.LastName.Contains(firstName)) &&
                        (reportsTo.IsEmpty() ? true : (reportsTo == null ? employee.ReportsTo == null : employee.ReportsTo == reportsTo)) &&
                        (birthDate.IsEmpty() ? true : birthDate == employee.BirthDate) &&
                        (employee.HireDate.CompareTo(hireDateFrom) > 0 && employee.HireDate.CompareTo(hireDateTo) < 0)
                    select employee
                    ).ToList();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<EmployeeWithSupervisorName> GetAllEmployeesWithSupervisors()
        {
            var result = 
                from
                    subordinates in _DatabaseContext.Employees
                join
                    supervisors in _DatabaseContext.Employees
                on 
                    subordinates.ReportsTo equals supervisors.EmployeeId
                select new 
                {
                    EmployeeID = subordinates.EmployeeId,
                    FirstName = subordinates.FirstName,
                    LastName = subordinates.LastName,
                    SupervisorFirstName = supervisors.FirstName,
                    SupervisorLastName = supervisors.LastName
                };

            return result.ToList().ConvertAll ( x => new EmployeeWithSupervisorName
            {
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SupervisorFirstName = x.FirstName,
                    SupervisorLastName = x.LastName
            });

        }

        public Tuple<List<Employee>, List<EmployeeWithSupervisorName>> GetAllTopAndGeneralEmployees()
        {
            List<Employee> topEmployees = GetEmployeesByReportsTo(null);
            
            List<EmployeeWithSupervisorName> generalEmployees = GetAllEmployeesWithSupervisors();
            
            return new Tuple<List<Employee>, List<EmployeeWithSupervisorName>>(topEmployees, generalEmployees);
        }

        public void UpdateEmployee(string firstName, string lastName, int employeeId)
        {
            Employee emp = GetEmployeeByEmployeeId(employeeId);

            emp.FirstName = firstName;
            emp.LastName = lastName;
            
            UpdateEmployee(emp);
        }
    }
}
