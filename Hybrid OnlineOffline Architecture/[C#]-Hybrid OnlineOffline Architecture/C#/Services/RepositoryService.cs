using System.Collections.Generic;
using System.ServiceModel;

using Model;
using Repository;

namespace Services
{
    [ServiceContract]
    public class RepositoryService : IRepository
    {
        Repository.Repository repository = new Repository.Repository("name=Server");

        [OperationContract]
        public IEnumerable<Customer> GetCustomers()
        {
            return repository.GetCustomers();
        }

        [OperationContract]
        public int SaveChanges(IEnumerable<Customer> customers, IEnumerable<Order> orders)
        {
            return repository.SaveChanges(customers, orders);
        }
    }
}