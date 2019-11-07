using SQLiteWithCSharp.Common;
using SQLiteWithCSharp.Models;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithCSharp.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        public EmployeeService()
            :base(Storage.ConnectionString)
        {

        }


        // you can write extended methods here
    }
}
