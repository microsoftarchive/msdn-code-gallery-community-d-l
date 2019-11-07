using DI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Service
{
   public interface IEmployeeService : IDisposable
    {
        List<Employee> InsertEmployee(List<Employee> employees);
    }
}
