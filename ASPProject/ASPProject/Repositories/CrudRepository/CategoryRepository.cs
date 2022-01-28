using ASPProject.Models;
using ASPProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories.CrudRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext db;
        public CategoryRepository(AppDbContext context)
        {
            this.db = context;
        }
        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Delete(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public IQueryable<Category> GetCategories()
        {
            var categories = db.Categories;
            return categories;
        }

        public IQueryable<Category> GetProductsForCategory()
        {
            var prodcat = GetCategories().Include(x => x.Products);
            return prodcat;
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
    }
}
