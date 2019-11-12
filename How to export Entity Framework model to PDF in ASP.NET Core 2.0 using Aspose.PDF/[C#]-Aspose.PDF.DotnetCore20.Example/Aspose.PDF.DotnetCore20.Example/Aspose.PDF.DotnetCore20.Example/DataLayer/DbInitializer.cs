using System;
using System.Linq;
using Aspose.PDF.DotnetCore20.Example.Models;

namespace Aspose.PDF.DotnetCore20.Example.DataLayer
{
    public class DbInitializer
    {
        public static void Initialize(RentalDbContext context)
        {
            //create database schema if none exists
            context.Database.EnsureCreated();
            if (!context.Tenants.Any())
            {
                for (int i = 0; i < 100; i++)
                {
                    var randomDate = new DateTime(2017, Faker.RandomNumber.Next(1, 12), 1);
                    context.Tenants.Add(
                    new Tenant
                    {
                        FullName = Faker.Name.FullName(Faker.NameFormats.Standard),
                        RentalPropertyAddress = Faker.Address.StreetAddress(),
                        MoveInDate = randomDate,
                        LeaseEndDate = randomDate.AddDays(120),
                        MonthlyPayment = Faker.RandomNumber.Next(1000, 3000)
                    });
                }
                context.SaveChanges();
            }

            if (!context.Apartments.Any())
            {
                var regions = new [] {"North", "West", "South", "East" };
                for (int i = 0; i < 50; i++)
                {
                    context.Apartments.Add(
                        new Apartment
                        {
                            Region = Faker.Extensions.ArrayExtensions.Random(regions),
                            City = Faker.Address.City(),
                            Address = Faker.Address.StreetAddress(),
                            TotalArea = Faker.RandomNumber.Next(123, 321)
                        });
                }
                context.SaveChanges();
            }
        }
    }
}