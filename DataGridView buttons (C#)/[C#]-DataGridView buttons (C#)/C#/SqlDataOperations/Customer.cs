using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataOperations
{
    public class Customer
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }
    }
}
