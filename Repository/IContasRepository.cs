

using System.Collections.Generic;
using WebapiContas.Models;

namespace WebapiContas.Repository
{
    public interface IContasRepository
    {
        void AddClient(Client client);
        IEnumerable<Client> GetAllClient();
        Client FindClient(long id);
        void RemoveClient(long id);
        void UpdateClient(Client client);


        void AddOrder(Order item);
        IEnumerable<Order> GetAllOrder();
        Order FindOrder(long id);
        void RemoveOrder(long id);
        void UpdateOrder(Order item);
    }
}
