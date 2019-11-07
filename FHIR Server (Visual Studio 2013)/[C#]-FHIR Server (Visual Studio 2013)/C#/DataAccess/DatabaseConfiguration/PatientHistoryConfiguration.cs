using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataAccess.DatabaseConfiguration
{
    class PatientHistoryConfiguration : EntityTypeConfiguration<PatientHistory>
    {
        public PatientHistoryConfiguration()
        {
            // To table "PatientHistory"
            ToTable("PatientHistory");

            // Primary Key
            HasKey(h => h.Id);

            // Do not allow to change the "Id" but retrieve values only from database
            Property(h => h.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
 
            // Add unique index to PatientHistory on properties "PatientId" and "HistoricVersion"
            Property(p => p.PatientId)
                .HasColumnAnnotation("Index", 
                new IndexAnnotation( new IndexAttribute("PatientIndex")
                {
                    IsUnique = true,
                    Order = 1
                }));

            Property(p => p.HistoricVersion)
                .HasColumnAnnotation("Index", 
                new IndexAnnotation( new IndexAttribute("PatientIndex")
                {
                    IsUnique = true, 
                    Order=2
                }));
        }
    }
}
