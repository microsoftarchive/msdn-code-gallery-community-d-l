using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebForms.Example.Models
{
    public class TenantDatabaseInitializer : DropCreateDatabaseAlways<TenantContext>
    {
        protected override void Seed(TenantContext context)
        {
            GetTenants().ForEach(c => context.Tenants.Add(c));
            
        }

        private static List<Tenant> GetTenants()
        {
            var tenants = new List<Tenant>();

            for (var i = 0; i < 50; i++)
            {
                var randomDate = new DateTime(2017, Faker.RandomNumber.Next(1, 12), 1);
                tenants.Add(
                    new Tenant
                    {
                        FullName = Faker.Name.FullName(Faker.NameFormats.Standard),
                        RentalPropertyAddress = Faker.Address.StreetAddress(),
                        MoveInDate = randomDate,
                        LeaseEndDate = randomDate.AddDays(120),
                        MonthlyPayment = Faker.RandomNumber.Next(1000, 3000)
                    });
            }
            return tenants;
        }
    }
}