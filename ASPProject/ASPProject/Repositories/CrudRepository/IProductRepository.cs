using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Models.Entities;

namespace ASPProject.Repositories.CrudRepository
{
    public interface IProductRepository
    {
        IQueryable<Product> GetProducts();

        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);

    }
}
