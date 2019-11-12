using System.Collections.Generic;
using System.Linq;

using Model;

using RepositoryProxy.RepositoryService;

namespace RepositoryProxy
{
    public class OnlineProxy : IRepositoryProxy
    {
        public IEnumerable<Customer> GetCustomers()
        {
            //Automatic change tracking is enabled by default when deserialising.
            //This is turned off to give the same behaviour as offline. Deletions have to be tracked manually anyway.
            using (var repositoryService = new RepositoryServiceClient())
                return ((IEnumerable<Customer>)repositoryService.GetCustomers()).StopTrackingAll();
        }

        public int SaveChanges(IEnumerable<Customer> customers, IEnumerable<Order> orders)
        {
            using (var repositoryService = new RepositoryServiceClient())
                return repositoryService.SaveChanges(customers.ToArray(), orders.ToArray());
        }

        public bool Online
        {
            get { return true; }
        }
    }
}