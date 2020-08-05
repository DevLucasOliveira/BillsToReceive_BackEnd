using Bills.Shared.Entities;
using System;

namespace Bills.Domain.Admin.Entities
{
    public class KeyAccess : Entity
    {
        public KeyAccess()
        {
            
        }

        public string Key { get; private set; }
        public bool ValidKey { get; private set; }
        public bool User { get; private set; }

        public string GenerateKeyAccess()
        {
            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[15];
            Random rd = new Random();
            for (int i = 0; i < 15; i++)
            {
                chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
            }
            Key = new string(chars);
            return Key;
        }

        public void ValidateKey()
        {
            ValidKey = true;
        }

        public void InvalidateKey()
        {
            ValidKey = false;
        }

        public void HasUser()
        {
            User = true;
        }

        public void NoHasUser()
        {
            User = false;
        }
    }
}
