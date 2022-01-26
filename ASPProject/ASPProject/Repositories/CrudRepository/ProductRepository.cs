using ASPProject.Models;
using ASPProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories.CrudRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext context)
        {
            this.db = context;
        }
        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IQueryable<Product> GetProducts()
        {
            var products = db.Products;
            return products;
        }

        public void Update(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
