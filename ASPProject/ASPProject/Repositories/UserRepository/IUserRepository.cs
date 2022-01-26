using ASPProject.Models.Entities;
using ASPProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUsersByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
