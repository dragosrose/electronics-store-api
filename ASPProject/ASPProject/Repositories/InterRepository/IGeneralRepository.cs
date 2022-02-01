using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories.InterRepository
{
    public interface IGeneralRepository
    {
        IQueryable<object> GetOrdersWithProducts();
        IQueryable<object> GetProductsFromCategory(int id);
        
    }
}
