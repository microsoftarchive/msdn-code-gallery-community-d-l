using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBatchOperations
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool Status { get; set; }
    }
}
