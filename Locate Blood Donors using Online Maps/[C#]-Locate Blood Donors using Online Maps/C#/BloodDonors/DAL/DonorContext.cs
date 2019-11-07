using System;
using System.Collections.Generic;
using System.Data.Entity;
using BloodDonors.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BloodDonors.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Donor> Donor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}