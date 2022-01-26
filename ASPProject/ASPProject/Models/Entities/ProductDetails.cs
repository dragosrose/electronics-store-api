using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models.Entities
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
