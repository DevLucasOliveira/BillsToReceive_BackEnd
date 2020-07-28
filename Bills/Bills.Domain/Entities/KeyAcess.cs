using Bills.Shared.Entities;

namespace Bills.Domain.Entities
{
    public class KeyAcess : Entity
    {
        public KeyAcess(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }
    }
}
