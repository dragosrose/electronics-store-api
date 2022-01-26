using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.OtherServices
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        Product GetById(int id);
        void Create(ProductBlueprint product);
        void Update(ProductBlueprint product);
        void Delete(int id);
    }
}
