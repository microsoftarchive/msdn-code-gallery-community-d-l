using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationNavigation.Model
{
    public class Person
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public DateTime? StartDate { get; set; }
        public double HappyRating { get; set; }
        public bool IsDead { get; set; }
    }
}
