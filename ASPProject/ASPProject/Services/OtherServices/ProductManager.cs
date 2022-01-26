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
        public ProductManager(IProductRepository productRepository)
        {
            this.repo = productRepository;
        }
        public void Create(ProductBlueprint product)
        {
            var newProduct = new Product
            {
                
                Name = product.Name

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
            repo.Update(pr);
        }
    }
}
