using Bills.Domain.Clients.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Clients.Queries
{
    public static class ClientQueries
    {
        public static Expression<Func<Client, bool>> GetClientById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Client, bool>> ExistsNameOfClient(Guid id, string name)
        {
            return x => x.User.Id == id && x.Name == name;
        }

        public static Expression<Func<Client, bool>> GetClientsOfUser(Guid id)
        {
            return x => x.User.Id == id;
        }
    }
}
