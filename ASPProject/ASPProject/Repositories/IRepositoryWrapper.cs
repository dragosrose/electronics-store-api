using ASPProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }

        Task SaveAsync();
    }
}
