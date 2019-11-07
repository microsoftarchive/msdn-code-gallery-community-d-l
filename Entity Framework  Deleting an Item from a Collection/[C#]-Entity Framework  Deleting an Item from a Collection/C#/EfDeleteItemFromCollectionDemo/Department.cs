using System.Collections.Generic;

namespace EfDeleteItemFromCollectionDemo
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
