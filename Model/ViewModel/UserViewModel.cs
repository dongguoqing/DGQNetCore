using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public bool? Sex { get; set; }
        public bool? Enable { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}
