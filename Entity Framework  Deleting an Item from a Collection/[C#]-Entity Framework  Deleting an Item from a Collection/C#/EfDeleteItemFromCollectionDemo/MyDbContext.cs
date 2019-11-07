using System.Data.Entity;

namespace EfDeleteItemFromCollectionDemo
{
    public class MyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}
