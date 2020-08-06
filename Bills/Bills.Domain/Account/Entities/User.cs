using Bills.Domain.Account.ValueObjects;
using Bills.Domain.Admin.Entities;
using Bills.Domain.Clients.Entities;
using Bills.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Bills.Domain.Account.Entities
{
    public class User : Entity
    {
        public User()
        {

        }

        public User(string name, string userName, Password password)
        {
            Clients = new List<Client>();
            Name = name;
            UserName = userName;
            PasswordSalt = password.PasswordSalt;
            PasswordHash = password.PasswordHash;
            CreatedAt = DateTime.Now;
        }

        public string Name { get; private set; }
        public string UserName { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public KeyAccess KeyAccess { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Client> Clients { get; private set; }

        public void AddKeyAccess(KeyAccess keyAccess)
        {
            KeyAccess = keyAccess;
            KeyAccess.HasUser();
        }

        public IList<Client> AddClient(Client client)
        {
            if (client.Valid)
                Clients.Add(client);

            return Clients;
        }
    }
}
