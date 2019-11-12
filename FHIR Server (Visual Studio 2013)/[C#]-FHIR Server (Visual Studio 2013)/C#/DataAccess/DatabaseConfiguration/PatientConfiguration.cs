using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataAccess.DatabaseConfiguration
{
    public class PatientConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
            // Use Table "Patient"
            ToTable("Patient");

            // Primary key
            HasKey(p => p.RecordNo);
            
            // Do not allow to change the "RecordNo" but retrieve values only from database
            Property(p => p.RecordNo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.PatientId)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("PatientIndex")
                {
                    IsUnique = true,
                    Order = 1
                }));


            Property(p => p.Version)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("PatientIndex")
                {
                    IsUnique = true,
                    Order = 2
                }));
        }
    }
}
