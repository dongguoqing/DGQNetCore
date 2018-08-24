using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Uid { get; set; }
        public int Sex { get; set; }
        public int Enable { get; set; }
        public virtual List<UserRole> Role { get; set; }
    }
}
