using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiContas.Models;
using WebapiContas.Models.Entities;

namespace WebapiContas.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order item);
        IEnumerable<Order> GetAll();
        Order Find(long id);
        IEnumerable<Order> GetByIdClient(long idClient);
        void Remove(long id);
        void Update(Order item);
    }
}
