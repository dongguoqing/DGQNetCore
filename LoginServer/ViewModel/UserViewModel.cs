﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Uid { get; set; }
        public int Sex { get; set; }
        public int Enable { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}
