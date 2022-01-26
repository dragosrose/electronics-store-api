using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;

namespace ASPProject.Repositories.CrudRepository
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetOrders();

        void Create(Order order);
        void Update(Order order);
        void Delete(Order order);
        
    }
}
