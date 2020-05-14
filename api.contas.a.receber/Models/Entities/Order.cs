using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebapiContas.Models.Entities
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        [NotMapped]
        public List<OrderItem> Items { get; set; }
    }
}
