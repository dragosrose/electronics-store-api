using ASPProject.Repositories.InterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.GeneralServices
{
    public class GeneralManager : IGeneralManager
    {
        private readonly IGeneralRepository repo;
        public GeneralManager(IGeneralRepository repo)
        {
            this.repo = repo;
        }
        public List<object> GetOrdersWithProduct()
        {
            var objs = repo.GetOrdersWithProducts();

            return objs.ToList();
        }
    }
}
