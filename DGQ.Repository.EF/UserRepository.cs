using System;

using Model;
using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Model.ViewModel;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DGQ.Repository.EF
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
    {
        public UserRepository(ApiDBContent context) : base(context)
        {
        }

        public async Task<PaginatedList<UserInfo>> GetUserInfoAsync(int pageIndex, int pageSize)
        {
            var listUser = from a in Context.Users select a;
            int count = await listUser.CountAsync();
            List<UserInfo> list = null;
            if (count > 0)
                list = await listUser.OrderBy(a => a.F_Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<UserInfo>(pageIndex, pageSize, count, list);
        }
    }
}
