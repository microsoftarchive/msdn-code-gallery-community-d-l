using System;
using System.Data.Entity;
using System.Linq;

namespace EfDeleteItemFromCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MyDbContextInitializer());

            using (MyDbContext context = new MyDbContext())
            {
                foreach (Contact contact in context.Departments.FirstOrDefault().Contacts)
                {
                    Console.WriteLine(contact.Name);
                }
            }
        }
    }
}