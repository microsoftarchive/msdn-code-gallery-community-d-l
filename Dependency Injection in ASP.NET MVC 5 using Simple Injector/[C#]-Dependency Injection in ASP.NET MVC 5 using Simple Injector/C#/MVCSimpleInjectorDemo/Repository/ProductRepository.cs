using MVCSimpleInjectorDemo.DomainModels;
using MVCSimpleInjectorDemo.Interfaces;
using System;
using System.Collections.Generic;

namespace MVCSimpleInjectorDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            // Add products for the Demonstration
            Add(new Product { Name = "TV", Category = "Electronics", Price = 100 });
            Add(new Product { Name = "Computer", Category = "Electronics", Price = 1000 });
            Add(new Product { Name = "Laptop", Category = "Electronics", Price = 8000 });
            Add(new Product { Name = "Google Pixel 2", Category = "Phone", Price = 150 });
        }

        public IEnumerable<Product> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return products;
        }

        public Product Get(int id)
        {
            // TO DO : Code to find a record in database
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            products.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}