using System;
using System.Collections.Generic;
namespace ProductStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByID(int id);
        void Add(Product product);
    }
}
