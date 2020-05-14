using System;
using System.ComponentModel.DataAnnotations;

namespace WebapiContas.Models
{
    public class OrderItem
    {
        [Key]
        public int IdOrderItem { get; set; }
        public int IdOrder { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

    }
}
