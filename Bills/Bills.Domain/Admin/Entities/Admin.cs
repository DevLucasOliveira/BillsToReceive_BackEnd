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
        public UserAdmin(long pin)
        {
            Pin = pin;
        }

        public long Pin { get; private set; }
        public List<User> Users { get; private set; }
        public List<KeyAccess> KeyAccesses { get; private set; }
    }
}
