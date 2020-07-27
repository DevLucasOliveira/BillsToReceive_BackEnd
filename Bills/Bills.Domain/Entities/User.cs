using Bills.Domain.ValueObjects;
using Bills.Shared.Entities;

namespace Bills.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string userName, Password password)
        {
            Name = name;
            UserName = userName;
            PasswordSalt = password.PasswordSalt;
            PasswordHash = password.PasswordHash;
        }

        public string Name { get; private set; }
        public string UserName { get; private set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
