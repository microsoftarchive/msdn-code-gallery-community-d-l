using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CslAppEF.Models.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            // Primary Key
            this.HasKey(t => t.PessoaId);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pessoa");
            this.Property(t => t.PessoaId).HasColumnName("PessoaId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
        }
    }
}
