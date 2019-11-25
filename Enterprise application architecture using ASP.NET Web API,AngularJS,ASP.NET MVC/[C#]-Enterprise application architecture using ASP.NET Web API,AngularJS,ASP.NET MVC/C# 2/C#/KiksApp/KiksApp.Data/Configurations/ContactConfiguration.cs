using KiksApp.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace KiksApp.Data.Configurations
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            Property(c => c.LastName).IsRequired().HasMaxLength(100);
            Property(c => c.Email).IsRequired().HasMaxLength(250);
            Property(c => c.Telephone).HasMaxLength(150);
            Property(c => c.MobilePhone).IsRequired().HasMaxLength(250);
            Property(c => c.Address).IsRequired().HasMaxLength(250);
            Property(c => c.Description).HasMaxLength(250);
        }

    }
}
