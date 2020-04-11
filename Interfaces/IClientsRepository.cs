using System.Collections.Generic;
using WebapiContas.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace WebapiContas.Interfaces
{
    public interface IClientsRepository
    {
        void Add(Client client);
        IEnumerable<Client> GetAll();
        Client Find(long id);
        void Remove(long id);
        void Update(Client client);

    }
}
