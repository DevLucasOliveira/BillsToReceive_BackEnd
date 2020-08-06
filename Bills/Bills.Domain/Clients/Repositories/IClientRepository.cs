using Bills.Domain.Clients.Entities;
using System;

namespace Bills.Domain.Clients.Repositories
{
    public interface IClientRepository
    {
        void Create(Client client);
        void Update(Client client); 
        void Remove(Guid id);
        Client GetClientById(Guid id);
        bool NameAlreadyExists(Guid id, string name);
    }
}
