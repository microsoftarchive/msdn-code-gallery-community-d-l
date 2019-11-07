using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithCSharp.Models
{
    public class Employee
    {
        [DbColumn(IsIdentity =true, IsPrimary =true)]
        public long EmployeeId { get; set; }
        [DbColumn]
        public string Name { get; set; }
        [DbColumn]
        public string JobDescription { get; set; }
        [DbColumn]
        public string Technology { get; set; }
        [DbColumn]
        public string Email { get; set; }

        public long Age { get; set; }

    }
}
