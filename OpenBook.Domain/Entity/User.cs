﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public int? RoleId { get; set; }
        public Role? Role { get; set; } = new Role();
    }
}
