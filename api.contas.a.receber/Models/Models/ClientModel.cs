using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebapiContas.Models.Models
{
    public class ClientModel
    {
        public int IdClient { get; set; }
        public int IdUser { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
    }
}
