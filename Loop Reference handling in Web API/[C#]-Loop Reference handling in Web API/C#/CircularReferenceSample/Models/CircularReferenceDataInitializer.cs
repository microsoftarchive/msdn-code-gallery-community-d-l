using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CircularReferenceSample.Models
{
    public class CircularReferenceDataInitializer : DropCreateDatabaseAlways<CircularReferenceSampleContext>
    {
        protected override void Seed(CircularReferenceSampleContext context)
        {
            context.Categories.Add(new Category()
            {
                Name = "Diary",
                Products = new Product[] {
                    new Product() {
                        Name = "Whole Milk"
                    },
                    new Product() {
                        Name = "Yogurt"
                    }
                }
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}