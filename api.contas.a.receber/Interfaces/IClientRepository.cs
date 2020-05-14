using System.Collections.Generic;
using WebapiContas.Models;


namespace WebapiContas.Interfaces
{
    public interface IClientRepository
    {
        void Add(Client client);
        IEnumerable<Client> GetAll();
        IEnumerable<Client> GetByIdUser(long idUser);
        Client Find(long id);
        void Remove(long id);
        void Update(Client client);

    }
}
