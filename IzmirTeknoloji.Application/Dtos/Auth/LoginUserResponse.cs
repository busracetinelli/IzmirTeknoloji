﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzmirTeknoloji.Application.Dtos.Auth
{
    public class LoginUserResponse
    {
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; } 
        public string RoleName { get; set; } 
    }
}
