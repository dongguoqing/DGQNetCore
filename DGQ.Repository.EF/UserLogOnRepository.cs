using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DGQ.Repository.EF
{
    public class UserLogOnRepository:Repository<UserLogOn>,IUserLogOnRepository
    {
        public UserLogOnRepository(ApiDBContent context) : base(context)
        {
        }

        public async Task<UserLogOn> GetByUserId(string id)
        {
            var userLogOn = (from a in Context.UserLogOn
                            where a.F_UserId == id
                            select a);
            return await userLogOn.FirstOrDefaultAsync();
        }
    }
}
