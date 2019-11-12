using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Model;

using Repository.Properties;

namespace Repository
{
    public class Repository : IRepository
    {
        readonly string connection;

        public Repository(string connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var entities = new Entities(connection))
                return entities.Customers.Include("Orders").ToList();
        }

        public int SaveChanges(IEnumerable<Customer> customers, IEnumerable<Order> orders)
        {
            using (var entities = new Entities(connection)) {

                foreach (var customer in customers)
                    //Automatically deleting a customer with orders will confuse context
                    if (customer.ChangeTracker.State == ObjectState.Deleted) {
                        entities.Customers.Attach(customer);
                        entities.Customers.DeleteObject(customer);
                    }
                    else
                        entities.Customers.ApplyChanges(customer);

                foreach (var order in orders)
                    entities.Orders.ApplyChanges(order);

                return entities.SaveChanges();
            }
        }

        public static void Reseed(int min, int max, SqlConnection connection)
        {
            using (var reseed = new SqlCommand(Settings.Default.Reseed, connection)) {
                if (connection.State != ConnectionState.Open) connection.Open();
                reseed.Parameters.AddWithValue("min", min);
                reseed.Parameters.AddWithValue("max", max);
                reseed.ExecuteNonQuery();
            }
        }
    }
}