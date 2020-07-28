using Bills.Domain.ValueObjects;
using Bills.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Bills.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string userName, Password password, KeyAccess keyAccess)
        {
            Name = name;
            UserName = userName;
            PasswordSalt = password.PasswordSalt;
            PasswordHash = password.PasswordHash;
            KeyAccess = keyAccess;
        }

        public string Name { get; private set; }
        public string UserName { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public KeyAccess KeyAccess { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Client> Clients { get; private set; }
    }
}
