using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.Data;
using DI.Repo;

namespace DI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> repoEmployee;

        public EmployeeService(IRepository<Employee> repoEmployee)
        {
            this.repoEmployee = repoEmployee;
        }

        public List<Employee> InsertEmployee(List<Employee> employees)
        {
            repoEmployee.InsertCollection(employees);
            return employees;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    repoEmployee.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
