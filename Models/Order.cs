using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebapiContas.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public string ProductName { get; set;}
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get;set; }
        public decimal Total { get; set; }

    }
}
