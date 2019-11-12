using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CslAppEF.Models.Mapping
{
    public class TbBMap : EntityTypeConfiguration<TbB>
    {
        public TbBMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TbB");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
