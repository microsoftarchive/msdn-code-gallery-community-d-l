using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
namespace wpf_EntityFramework
{
    public class CustomerVM : VMBase
    {
        public Customer TheCustomer { get; set; }
        public CustomerVM()
        {
            // Initialise the entity or inserts will fail
            TheCustomer = new Customer();
            TheCustomer.CreditLimit = 5000;
            TheCustomer.Outstanding = 0;
        }

    }
}
