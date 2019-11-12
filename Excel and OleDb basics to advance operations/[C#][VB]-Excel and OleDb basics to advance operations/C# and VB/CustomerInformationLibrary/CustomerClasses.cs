using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInformationLibrary
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JoinedYear { get; set; }

        public Customer()
        {
            /*
             * Code to init
             */
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        

    }
    public class Customers
    {
        public Customers()
        {

        }
        public List<Customer> List
        {
            get
            {
                List<Customer> CustomerList = new List<Customer>() {
				new Customer {FirstName = "Karen", LastName = "Payne", JoinedYear = 2001},
				new Customer {FirstName = "Sam", LastName = "Davis", JoinedYear = 1999},
				new Customer {FirstName = "Ann", LastName = "Smith", JoinedYear = 2014},
				new Customer {FirstName = "Jim", LastName = "Jenkins", JoinedYear = 2009}
			};


                return CustomerList;

            }
        }
    }
}
