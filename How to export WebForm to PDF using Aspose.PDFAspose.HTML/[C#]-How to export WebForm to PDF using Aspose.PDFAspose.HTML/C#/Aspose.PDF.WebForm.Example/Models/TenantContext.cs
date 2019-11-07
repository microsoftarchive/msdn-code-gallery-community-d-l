using System.Data.Entity;

namespace WebForms.Example.Models
{
    public class TenantContext : DbContext
    {
        public TenantContext()
            : base("RentalDB")
        {
        }
        
        public DbSet<Tenant> Tenants { get; set; }
    }
}