using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;
using ASPProject.Repositories.CrudRepository;
using ASPProject.Services.OtherServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models.OtherServices
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository repo;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this.repo = categoryRepository;
        }

        public void Create(CategoryBlueprint category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                
            };

            repo.Create(newCategory);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            repo.Delete(category);
        }

        public Category GetById(int id)
        {
            var category = repo.GetCategories().FirstOrDefault(x => x.Id == id);
            return category;
        }

        public List<Category> GetCategories()
        {
            return repo.GetCategories().ToList();
        }

        public List<Category> GetProductsForCategories()
        {
            var prodcat = repo.GetProductsForCategory();
            return prodcat.ToList();
        }

        public void Update(CategoryBlueprint category)
        {
            var categ = GetById(category.Id);
            categ.Id = category.Id;
            categ.Name = category.Name;
            repo.Update(categ);
        }
    }
}
