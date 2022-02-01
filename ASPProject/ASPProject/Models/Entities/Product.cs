using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        
        public virtual ProductDetails Details { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
