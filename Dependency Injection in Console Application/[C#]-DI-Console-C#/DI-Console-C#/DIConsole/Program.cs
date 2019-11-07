using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new EmployeeExportModule());
            EmployeeExportOperation employeeExportOperation = new EmployeeExportOperation(kernal);
            employeeExportOperation.SaveEmployee();
            System.Console.ReadKey();
        }
    }
}
