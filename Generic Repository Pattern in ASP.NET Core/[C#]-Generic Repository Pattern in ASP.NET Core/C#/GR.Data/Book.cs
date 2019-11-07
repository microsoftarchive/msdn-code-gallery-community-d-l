using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GR.Data
{
    public class Book : BaseEntity
    {
        public Int64 AuthorId { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public virtual Author Author { get; set; }
    }
}
