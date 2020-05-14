using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebapiContas.Models.Entities;

namespace WebapiContas.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public int IdUser { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<Order> Orders{ get; set; }

    }
}
