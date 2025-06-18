using System;
using System.Collections.Generic;
using System.Linq;

namespace IzmirTeknoloji.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = "User"; // Default role is User

        public ICollection<User> Users { get; set; } = new List<User>(); // Navigation property to Users
    }
}
