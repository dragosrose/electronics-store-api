using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;
using ASPProject.Repositories.CrudRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.OtherServices
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository repo;
        private readonly ICategoryManager cat;
        public ProductManager(IProductRepository productRepository, ICategoryManager cat)
        {
            this.repo = productRepository;
            this.cat = cat;
        }
        public void Create(ProductBlueprint product)
        {
            var newProduct = new Product
            {
                
                Name = product.Name,
                Price = product.Price,
                Details = new ProductDetails
                {
                    Description = product.Description,
                    Stock = product.Stock
                },
                Category = cat.GetById(product.CategoryId)
                
            };

            repo.Create(newProduct);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            repo.Delete(product);
        }

        public Product GetById(int id)
        {
            var product = repo.GetProducts().FirstOrDefault(x => x.Id == id);
            return product;
        }

        public List<Product> GetProducts()
        {
            return repo.GetProducts().ToList();
        }

        public void Update(ProductBlueprint product)
        {
            var pr = GetById(product.Id);
            pr.Name = product.Name;
            pr.Price = product.Price;
            pr.Details = new ProductDetails
            {
                Description = product.Description,
                Stock = product.Stock
            };
            repo.Update(pr);
        }
    }
}
