using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dynamic_Tabs_In_ANgular_JS.Models
{
    public class Test
    {
        public List<Customer> GetData()
        {
            try
            {
                List<Customer> cst = new List<Customer>();
                for (int i = 0; i < 5; i++)
                {
                    Customer c = new Customer();
                    c.CustomerID = i;
                    c.CustomerCode = "CST" + i;
                    cst.Add(c);
                }
                return cst;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }
        public class Customer
        {
            public int CustomerID { get; set; }
            public string CustomerCode { get; set; }
        }
    }
}