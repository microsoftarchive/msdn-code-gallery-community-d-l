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

using System.Linq;
using Eisk.BusinessEntities;
using System;
using Eisk.Helpers;

namespace Eisk.BusinessLogicLayer
{
    public partial class EmployeeBLL
    {
        partial void OnEmployeeSaving(Employee employee)
        {
            /* an employee's country must be same as his supervisors country */
            if (employee.ReportsTo != null)
                employee.Supervisor = GetEmployeeByEmployeeId((int)employee.ReportsTo);

            if (employee.Supervisor != null)
            {
                if (employee.Country != employee.Supervisor.Country)
                    throw new BusinessRuleViolationOnDbAccessException("An employee's country must be same as his supervisors country.");
            }

        }

    }
}
