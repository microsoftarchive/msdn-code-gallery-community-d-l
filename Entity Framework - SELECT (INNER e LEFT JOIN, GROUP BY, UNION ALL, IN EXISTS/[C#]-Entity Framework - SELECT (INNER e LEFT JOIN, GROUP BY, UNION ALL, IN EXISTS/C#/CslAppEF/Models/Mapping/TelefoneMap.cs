using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CslAppEF.Models.Mapping
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            // Primary Key
            this.HasKey(t => t.TelefoneId);

            // Properties
            this.Property(t => t.Ddd)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("Telefone");
            this.Property(t => t.TelefoneId).HasColumnName("TelefoneId");
            this.Property(t => t.PessoaId).HasColumnName("PessoaId");
            this.Property(t => t.Ddd).HasColumnName("Ddd");
            this.Property(t => t.Numero).HasColumnName("Numero");

            // Relationships
            this.HasOptional(t => t.Pessoa)
                .WithMany(t => t.Telefones)
                .HasForeignKey(d => d.PessoaId);

        }
    }
}
