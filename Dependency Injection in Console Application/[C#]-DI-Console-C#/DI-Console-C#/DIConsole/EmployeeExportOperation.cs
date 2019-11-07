using DI.Data;
using DI.Service;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsole
{
    public class EmployeeExportOperation :IDisposable
    {
        private readonly IEmployeeService employeeService;

        public EmployeeExportOperation(IKernel kernel)
        {
            employeeService = kernel.Get<EmployeeService>();
        }

        public void SaveEmployee()
        {
            List<Employee> employees = LoadEmployeeJson();
            employeeService.InsertEmployee(employees);
        }
        private List<Employee> LoadEmployeeJson()
        {
            using (StreamReader streamReader = new StreamReader("employee.json"))
            {
                string json = streamReader.ReadToEnd();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                return employees;
            }
        }
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    employeeService.Dispose();
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
