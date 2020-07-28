using Bills.Domain.Entities;
using System;

namespace Bills.Domain.Repositories
{
    public interface IClientRepository
    {
        void Create(Client client);
        void Update(Client client); 
        void Remove(Guid id);
        Client GetClientById(Guid id);
    }
}
