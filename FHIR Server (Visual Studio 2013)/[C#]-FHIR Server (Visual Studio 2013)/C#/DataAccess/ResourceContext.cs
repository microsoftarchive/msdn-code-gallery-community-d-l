using System.Data.Entity;
using DataAccess.DatabaseConfiguration;
using Model;

namespace DataAccess
{
    public class ResourceContext : DbContext
    {
        public DbSet<Patient> Patients { set; get; }
        // public DbSet<PatientHistory> PatientHistories { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PatientConfiguration());
            // modelBuilder.Configurations.Add(new PatientHistoryConfiguration());
        }
    }
}
    
