using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer
{
    public class UserResult
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool IsSystem { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Uid { get; set; }
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string Expires_in { get; set; }
        public List<UserRole> Role { get; set; }
    }

}
