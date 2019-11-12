using System.ComponentModel.DataAnnotations.Schema;

namespace EfDeleteItemFromCollectionDemo
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public virtual Department Department { get; set; }
    }
}
