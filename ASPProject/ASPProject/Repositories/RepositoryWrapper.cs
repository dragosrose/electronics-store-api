﻿using ASPProject.Models;
using ASPProject.Models.Entities;
using ASPProject.Repositories;
using ASPProject.Repositories.CrudRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
                
        public RepositoryWrapper(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }
                
        
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
