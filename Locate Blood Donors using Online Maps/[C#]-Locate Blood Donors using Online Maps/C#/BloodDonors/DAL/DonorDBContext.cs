using System;
using System.Collections.Generic;
using System.Data.Entity;
using BloodDonors.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace BloodDonors.Models
{
    public class DonorDBContext : DbContext
    {

        public DbSet<Donor> Donors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
