using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI
{
    public class OrderDbSettings
    {       
        public string DatabaseId { get; set; }
        public string CollectionId { get; set; }
        public string EndpointUrl { get; set; }
        public string AuthorizationKey { get; set; }
    }
}
