using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CslAppEF.Models.Mapping;

namespace CslAppEF.Models
{
    public partial class EFrameworkContext : DbContext
    {
        static EFrameworkContext()
        {
            Database.SetInitializer<EFrameworkContext>(null);
        }

        public EFrameworkContext()
            : base("Name=EFrameworkContext")
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }                                                  
        public DbSet<TbA> TbAs { get; set; }
        public DbSet<TbB> TbBs { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PessoaMap());            
            modelBuilder.Configurations.Add(new TbAMap());
            modelBuilder.Configurations.Add(new TbBMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
        }
    }
}
