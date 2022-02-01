using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;
using ASPProject.Repositories.CrudRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.OtherServices
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository repo;
        public OrderManager(IOrderRepository orderRepository)
        {
            this.repo = orderRepository;
        }
        public void Create(OrderBlueprint order)
        {
            var newOrder = new Order
            {
                Data = order.Data

            };

            repo.Create(newOrder);

        }

        public void Delete(int id)
        {
            var order = GetById(id);
            repo.Delete(order);
        }

        public Order GetById(int id)
        {
            var order = repo.GetOrders().FirstOrDefault(x => x.Id == id);
            return order;
        }

        public List<Order> GetOrders()
        {
            return repo.GetOrders().ToList();
        }

        
        public void Update(OrderBlueprint order)
        {
            var or = GetById(order.Id);
            or.Data = order.Data;
            repo.Update(or);
        }
    }
}
