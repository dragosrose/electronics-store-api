using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Models.Entities;

namespace ASPProject.Repositories.CrudRepository
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();

        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
        IQueryable<Category> GetProductsForCategory();
    }
}
