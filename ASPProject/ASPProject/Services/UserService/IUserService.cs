using ASPProject.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
