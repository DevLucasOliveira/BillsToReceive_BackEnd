using Bills.Domain.Account.Entities;
using Bills.Shared.Entities;
using System.Collections.Generic;

namespace Bills.Domain.Admin.Entities
{
    public class UserAdmin :  Entity
    {
        public UserAdmin()
        {

        }
        public UserAdmin(decimal pin)
        {
            Pin = pin;
        }

        public decimal Pin { get; private set; }
        public List<User> Users { get; private set; }
        public List<KeyAccess> KeyAccesses { get; private set; }
    }
}
