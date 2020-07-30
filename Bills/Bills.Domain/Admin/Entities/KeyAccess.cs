using Bills.Shared.Entities;

namespace Bills.Domain.Admin.Entities
{
    public class KeyAccess : Entity
    {
        public KeyAccess(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }
        public bool ValidKey { get; private set; }
    }
}
