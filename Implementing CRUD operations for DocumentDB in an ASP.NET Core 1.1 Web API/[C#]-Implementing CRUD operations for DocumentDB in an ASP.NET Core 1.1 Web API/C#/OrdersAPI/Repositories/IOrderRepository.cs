using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdersAPI.Models;


namespace OrdersAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<string> Add(ClientOrder order);
        ServerOrder Find(string key);
        Task<string> Update(string id, ClientOrder order);
        Task<string> Remove(string id);
    }
}
