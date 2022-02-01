using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.GeneralServices
{
    public interface IGeneralManager
    {
        List<object> GetOrdersWithProduct();
        List<object> GetProductsOfCategory(int id);
    }
}
