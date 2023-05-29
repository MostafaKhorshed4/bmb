using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Entities
{
    public class Orders
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public DateTime? creationDate { get; set; }
        public DateTime? deletedTime { get; set; }
        public DateTime? lastDeletedTime { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
    }
}
