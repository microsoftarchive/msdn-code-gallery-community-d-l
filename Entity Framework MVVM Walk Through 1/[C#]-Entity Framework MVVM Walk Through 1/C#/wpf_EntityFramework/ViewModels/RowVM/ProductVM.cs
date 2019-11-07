using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;

namespace wpf_EntityFramework
{
    public class ProductVM : VMBase
    {
        public Product TheProduct { get; set; }
        public ProductVM()
        {
            // Initialise the entity or inserts will fail
            TheProduct = new Product();
        }

    }
}
