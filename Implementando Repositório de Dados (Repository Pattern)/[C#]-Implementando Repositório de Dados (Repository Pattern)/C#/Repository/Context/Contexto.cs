using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Transactions;
using Repository.Domain;

namespace Repository.Context
{
    public class Contexto : DbContext
    {
        static Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public Contexto() : base("Name=estudoContext")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }

    }
}
