using ASPProject.Models.Blueprints;
using ASPProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.OtherServices
{
    public interface ICategoryManager
    {
        List<Category> GetCategories();
        Category GetById(int id);
        void Create(CategoryBlueprint category);
        void Update(CategoryBlueprint category);
        void Delete(int id);
    }
}
