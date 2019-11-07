using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Domain
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            // chave primaria
            this.HasKey(t => t.id);

            // propriedades
            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.endereco)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.bairro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.cidade)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.uf)
                .IsRequired()
                .HasMaxLength(2);

            // tabela e mapeamentos
            this.ToTable("cliente", "estudo");
            this.Property(t => t.id).HasColumnName("COD_CLIENTE");
            this.Property(t => t.nome).HasColumnName("CLI_NOME");
            this.Property(t => t.email).HasColumnName("CLI_EMAIL");
            this.Property(t => t.endereco).HasColumnName("CLI_ENDERECO");
            this.Property(t => t.bairro).HasColumnName("CLI_BAIRRO");
            this.Property(t => t.cidade).HasColumnName("CLI_CIDADE");
            this.Property(t => t.uf).HasColumnName("CLI_ESTADO");
        }
    }
}
