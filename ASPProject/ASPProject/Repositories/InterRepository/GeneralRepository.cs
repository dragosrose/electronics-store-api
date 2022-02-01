using ASPProject.Models;
using ASPProject.Repositories.CrudRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories.InterRepository
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly AppDbContext db;
        private readonly IOrderRepository _order;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        public GeneralRepository(AppDbContext context, IOrderRepository _order, IProductRepository _product, ICategoryRepository _category)
        {
            this.db = context;
            this._order = _order;
            this._product = _product;
            this._category = _category;
        }
        public IQueryable<object> GetOrdersWithProducts()
        {
            var orders = _order.GetOrders();
            var products = _product.GetProducts();
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

        public IQueryable<object> GetProductsFromCategory(int id)
        {
            var products = _product.GetProducts();
            var categories = _category.GetCategories();
            var join =
               from p in products
               join c in categories on p.Category.Id equals c.Id
               where c.Id == id
               select new
               {
                   p.Name,
                   p.Price
               };

            return join;
        }

        
    }
}
