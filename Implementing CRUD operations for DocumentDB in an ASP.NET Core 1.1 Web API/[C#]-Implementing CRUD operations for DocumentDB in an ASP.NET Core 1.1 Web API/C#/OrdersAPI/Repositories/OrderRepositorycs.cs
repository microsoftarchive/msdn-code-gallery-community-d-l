using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using OrdersAPI.Models;
using OrdersAPI;
using System.Threading.Tasks;

namespace OrdersAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static DocumentClient client;

        private readonly OrderDbSettings _settings;

        public OrderRepository(IOptions<OrderDbSettings> settings)
        {
            _settings = settings.Value;
        }


        #region AddOrderToCollection
        public async Task<string> Add(ClientOrder order)
        {
            string id = null;

            //Create a server order with extra properties
            ServerOrder s = new ServerOrder();

            s.customer = order.customer;
            s.item = order.item;

            //Add meta data to the order
            s.OrderStatus = "in progress";
            s.CreationDate = DateTime.UtcNow;

            //Get a Document client
            using (client = new DocumentClient(new Uri(_settings.EndpointUrl), _settings.AuthorizationKey))
            {

                string pathLink = string.Format("dbs/{0}/colls/{1}", _settings.DatabaseId, _settings.CollectionId);

                ResourceResponse<Document> doc = await client.CreateDocumentAsync(pathLink, s);

                //Return the created id
                id = doc.Resource.Id;
            }

            return id;
        }
        #endregion


        #region GetOrderById
        public ServerOrder Find(string key)
        {
            ServerOrder order = null;

            //Get a Document client
            using (client = new DocumentClient(new Uri(_settings.EndpointUrl), _settings.AuthorizationKey))
            {
                string pathLink = string.Format("dbs/{0}/colls/{1}", _settings.DatabaseId, _settings.CollectionId);

                dynamic doc = client.CreateDocumentQuery<Document>(pathLink).Where(d => d.Id == key).AsEnumerable().FirstOrDefault();

                if (doc != null)
                {
                    order = doc;
                }
            }

            return order;
        }
        #endregion


        #region UpdateOrderById
        public async Task<string> Update(string id, ClientOrder order)
        {

            string result = null;

            //Get a Document client
            using (client = new DocumentClient(new Uri(_settings.EndpointUrl), _settings.AuthorizationKey))
            {

                string pathLink = string.Format("dbs/{0}/colls/{1}", _settings.DatabaseId, _settings.CollectionId);

                dynamic doc = client.CreateDocumentQuery<Document>(pathLink).Where(d => d.Id == id).AsEnumerable().FirstOrDefault();

                if (doc != null)
                {
                    ServerOrder s = doc;
                    s.customer = order.customer;
                    s.item = order.item;
                    s.ModifiedDate = DateTime.UtcNow;

                    //Update document using self link.  
                    ResourceResponse<Document> x = await client.ReplaceDocumentAsync(doc.SelfLink, s);

                    result = x.StatusCode.ToString();
                }
            }

            return result;
        }
        #endregion


        #region RemoveOrderById
        public async Task<string> Remove(string id)
        {

            string result = null;

            //Get a Document client
            using (client = new DocumentClient(new Uri(_settings.EndpointUrl), _settings.AuthorizationKey))
            {

                var docLink = string.Format("dbs/{0}/colls/{1}/docs/{2}", _settings.DatabaseId, _settings.CollectionId, id);

                // Delete document using an Uri.  
                var x = await client.DeleteDocumentAsync(docLink);

                if (x != null)
                {

                    result = x.StatusCode.ToString();
                }
            }

            return result;
        }
        #endregion

    }
}
