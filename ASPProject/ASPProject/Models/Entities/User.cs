﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
