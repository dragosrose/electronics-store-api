using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        public User User { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
