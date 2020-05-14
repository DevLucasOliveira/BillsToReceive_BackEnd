using System;
using System.Collections.Generic;
using System.Linq;
using WebapiContas.Interfaces;
using WebapiContas.Models;
using WebapiContas.Models.Entities;

namespace WebapiContas.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ContasContext _context;

        private readonly IOrderRepository _orderRepository;

        public ClientRepository(ContasContext context, IOrderRepository orderRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
        }

        public void Add(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
            var order = new Order();
            order.IdClient = client.IdClient;
            _orderRepository.Add(order);
        }

        public Client Find(long id)
        {
            var client = _context.Client.FirstOrDefault(u => u.IdClient == id);
            client.Orders = _orderRepository.GetByIdClient(client.IdClient).ToList();
            return client;
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
                client.Orders = _orderRepository.GetByIdClient(client.IdClient).ToList();
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
