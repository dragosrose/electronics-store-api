using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models.Blueprints
{
    public class OrderBlueprint
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ProductId { get; set; }
    }
}
