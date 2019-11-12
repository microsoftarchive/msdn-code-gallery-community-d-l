using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentValidationSample.Models
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}