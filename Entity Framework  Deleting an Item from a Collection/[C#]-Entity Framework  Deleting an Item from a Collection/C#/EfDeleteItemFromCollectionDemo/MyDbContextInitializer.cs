using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EfDeleteItemFromCollectionDemo
{
    public class MyDbContextInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Departments.AddOrUpdate(d => d.Name, new Department()
            {
                Name = "Microsoft Visual Studio",
                Contacts = new List<Contact>()
                    {
                        new Contact() { Name = "Jaliya Udagedara" },
                        new Contact() { Name = "John Smith" }
                    }
            });
            context.SaveChanges();

            Department department = context.Departments.FirstOrDefault();
            Contact contact = department.Contacts.FirstOrDefault();

            //// Can omit this line
            //department.Contacts.Remove(contact);

            // option 1 : Marking the entity state as deleted
            context.Entry(contact).State = EntityState.Deleted;

            //// option 2 : ObjectContext.DeleteObject
            //((IObjectContextAdapter)context).ObjectContext.DeleteObject(contact);

            context.SaveChanges();
        }
    }
}
