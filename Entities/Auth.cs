using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Entities
{
    public class Auth
    {
        public string token { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public string  mail { get; set; }
        public int customerId { get; set; }
    }
}
