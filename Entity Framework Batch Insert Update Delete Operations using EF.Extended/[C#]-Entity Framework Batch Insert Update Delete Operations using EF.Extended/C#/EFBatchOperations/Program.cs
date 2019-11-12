using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;

namespace EFBatchOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataContext())
            {
                // Insert
                var customers = GetCustomers();
                db.Customers.AddRange(customers);
                db.SaveChanges();

                // Update country USA to IN
                db.Customers.Where(c => c.Country == "USA").Update(c => new Customer() {Country = "IN"});

                // Delete customers which have country China
                db.Customers.Where(c => c.Country == "CHINA").Delete();

                foreach (var customer in db.Customers.ToList())
                {
                    Console.WriteLine("CustomerInfo - {0}-{1}-{2}", customer.Name, customer.Country, customer.Status);
                }
            }

            Console.ReadLine();
        }

        public static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>{
                new Customer() {Name = "John", Country = "IN", Status = true},
                new Customer() {Name = "Tom", Country = "USA", Status = true},
                new Customer() {Name = "Eric", Country = "USA", Status = false},
                new Customer() {Name = "Sam", Country = "CHINA", Status = true},
                new Customer() {Name = "Rick", Country = "IN", Status = false},
                new Customer() {Name = "Addy", Country = "IN", Status = true},
                new Customer() {Name = "Chang", Country = "CHINA", Status = false}
            };

            return customers;
        }
    }
}
