using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.OtherServices
{
    public interface IOrderManager
    {
        List<Order> GetOrders();
        Order GetById(int id);
        void Create(OrderBlueprint order);
        void Update(OrderBlueprint order);
        void Delete(int id);
    }
}
