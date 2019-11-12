using Aspose.PDF.DotnetCore20.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspose.PDF.DotnetCore20.Example.DataLayer
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
    }
}