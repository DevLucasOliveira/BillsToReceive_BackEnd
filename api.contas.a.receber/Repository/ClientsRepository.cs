using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ContasContext _context;

        private readonly IOrdersRepository _ordersRepository;

        public ClientsRepository(ContasContext context, IOrdersRepository ordersRepository)
        {
            _context = context;
            _ordersRepository = ordersRepository;
        }

        public void Add(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public Client Find(long id)
        {
            return _context.Client.FirstOrDefault(u => u.IdClient == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Client.ToList();
        }

        public IEnumerable<Client> GetByIdUser(long idUser)
        {
            var clients = _context.Client.Where(w => w.IdUser == idUser);
            foreach (var client in clients)
            {
                var orders = _ordersRepository.GetByIdClient(client.IdClient).ToList();
                if (orders.Count != 0)
                {
                    client.LastOrderDate = orders[orders.Count - 1].Date;
                    client.TotalOrders = orders.Sum(order => order.Total);
                }
            }
            return clients;
        }

        public void Remove(long id)
        {
            try
            {
                var entity = _context.Client.First(u => u.IdClient == id);
                _context.Client.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(Client client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
        }

    }
}
