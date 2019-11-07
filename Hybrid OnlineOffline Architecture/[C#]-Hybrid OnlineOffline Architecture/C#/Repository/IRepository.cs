using System.Collections.Generic;

using Model;

namespace Repository
{
    public interface IRepository
    {
        IEnumerable<Customer> GetCustomers();

        int SaveChanges(IEnumerable<Customer> customers, IEnumerable<Order> orders);
    }
}