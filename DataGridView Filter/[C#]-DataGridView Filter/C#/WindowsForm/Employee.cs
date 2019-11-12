using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsForm
{
    public class Employee
    {
        private string lastNameValue;
        private string firstNameValue;
        private int salaryValue;
        private DateTime startDateValue;
        public Employee()
        {
            LastName = "Last Name";
            FirstName = "First Name";
            Salary = 40000;
            StartDate = DateTime.Today;
        }
        public Employee(string lastName, string firstName,
            int salary, DateTime startDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Salary = salary;
            StartDate = startDate;
        }

        public string LastName
        {
            get { return lastNameValue; }
            set { lastNameValue = value; }
        }
        public string FirstName
        {
            get { return firstNameValue; }
            set { firstNameValue = value; }
        }

        public int Salary
        {
            get { return salaryValue; }
            set { salaryValue = value; }
        }

        public DateTime StartDate
        {
            get { return startDateValue; }
            set { startDateValue = value; }
        }

        public override string ToString()
        {
            return LastName + ", " + FirstName + "\n" +
                "Salary:" + salaryValue + "\n" +
                "Start date:" + startDateValue;
        }

    }

    public class SK
    {
        private int _ID;

        private string _Name;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value != ID)
                {
                    _ID = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                }
            }
        }
    }
}
