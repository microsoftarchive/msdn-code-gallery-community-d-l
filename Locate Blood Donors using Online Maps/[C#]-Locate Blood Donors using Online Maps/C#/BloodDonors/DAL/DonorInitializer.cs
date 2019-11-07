using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BloodDonors.Models;



namespace BloodDonors.DAL
{
    public class DonorInitializer : DropCreateDatabaseIfModelChanges<DonorDBContext>
    {
        protected override void Seed(DonorDBContext context)
        {

            var Donors = new List<Donor>
            {
                new Donor { Name = "Donors-1", Description = "Description-1", Address = "Address-1", Country = "Country-1", Phone = "phone-1", Longitude=1, Latitude =2, Email = "email-1" , Website = "website-1" },
                new Donor { Name = "Donors-2", Description = "Description-2", Address = "Address-2", Country = "Country-2", Phone = "phone-2", Longitude=1, Latitude =2, Email = "email-2" , Website = "website-2" }
            };
            Donors.ForEach(s => context.Donors.Add(s));
            context.SaveChanges();

        }

    }
}