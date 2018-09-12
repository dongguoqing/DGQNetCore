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
            var listUser = from a in Context.Users

                           select a;
            int count = await listUser.CountAsync();
            List<UserInfo> list = null;
            if (count > 0)
                list = await listUser.OrderBy(a => a.F_Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<UserInfo>(pageIndex, pageSize, count, list);
        }

        public async Task<UserRoleViewModel> GetUserRoleAsync(string f_id)
        {
            var user = from a in Context.Users
                       join b in Context.UserRole on
                       a.F_RoleId equals b.F_Id
                       where a.F_Id == f_id
                       select new UserRoleViewModel()
                       {
                          F_FullName = b.F_FullName,
                          F_Gender = a.F_Gender,
                          F_MobilePhone = a.F_MobilePhone,
                          F_NickName = a.F_NickName,
                          F_RealName = a.F_RealName,
                          F_RoleId = b.F_Id,
                          Id = a.F_Id,
                       };
            return await user.FirstOrDefaultAsync();

        }

        public async Task<UserRoleViewModel> GetUserByUserName(string username)
        {
            var user = from a in Context.Users
                       join b in Context.UserLogOn
                       on a.F_Id equals b.F_UserId
                       where a.F_Account == username select new UserRoleViewModel()
                       {
                           F_Gender = a.F_Gender,
                           F_MobilePhone = a.F_MobilePhone,
                           F_NickName = a.F_NickName,
                           F_RealName = a.F_RealName,
                           F_RoleId = b.F_Id,
                           Id = a.F_Id,
                           F_Account = a.F_Account,
                           F_UserPassword = b.F_UserPassword,
                           F_Email = a.F_Email
                       };
            return await user.FirstOrDefaultAsync();
        }
    }
}
