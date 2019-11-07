using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBatchOperations
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
