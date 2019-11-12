using EFCodeFirstCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstCore.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }

    }
}