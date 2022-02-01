using ASPProject.Models;
using ASPProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories.CrudRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext db;
        
                
        public OrderRepository(AppDbContext context)
        {
            this.db = context;
            
        }
        public void Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Delete(Order order)
        {
            db.Orders.Remove(order);
            db.SaveChanges();
        }

        public IQueryable<Order> GetOrders()
        {
            var orders = db.Orders;
            return orders;
        }

        
        public void Update(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }
    }
}
