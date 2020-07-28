using Bills.Shared.Entities;
using System.Collections.Generic;

namespace Bills.Domain.Entities
{
    public class Admin :  Entity
    {
        public Admin(decimal pin)
        {
            Pin = pin;
        }

        public decimal Pin { get; private set; }
        public List<User> Users { get; private set; }
        public List<KeyAccess> keyAccesses { get; private set; }
    }
}
