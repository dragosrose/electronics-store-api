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
        private readonly IProductRepository repo;
        public OrderRepository(AppDbContext context, IProductRepository repo)
        {
            this.db = context;
            this.repo = repo;
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

        public IQueryable<object> GetOrdersWithProducts()
        {
            var orders = GetOrders();
            var products = repo.GetProducts();
            var join = db.OrderProduct.Join(orders, a => a.OrderId, b => b.Id, (a, b) => new
            {
                a,
                b
            }).Join(products, x => x.a.ProductId, y => y.Id, (x, y) => new 
            {
                x.a.OrderId,
                x.b.Data,
                y.Id,
                y.Name
                
            });

            return join;
        }

        public void Update(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }
    }
}
