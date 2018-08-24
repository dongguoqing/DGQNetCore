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

        public async Task<PaginatedList<UserViewModel>> GetUserInfoAsync(int pageIndex, int pageSize)
        {
            var listUser = (from a in Context.Users
                            join b in Context.UserRole on a.Uid equals b.Id.ToString()
                            select new UserViewModel
                            {
                                Id = a.Id,
                                Email = a.Email,
                                Name = a.Name,
                                UserName = a.UserName,
                                Uid = a.Uid,
                                Enable = a.Enable,
                                Sex = a.Sex,
                                RoleName = b.RoleName,
                            });
            int count = await listUser.CountAsync();
            List<UserViewModel> list = null;
            if (count > 0)
                list = await listUser.OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<UserViewModel>(pageIndex, pageSize, count, new List<UserViewModel>());
        }
    }
}
