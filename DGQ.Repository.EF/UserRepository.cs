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
using DGQ.Code;
using DGQ.Code.Extend;
using DGQ.Infrustructure.Contract;

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
                           where a.F_DeleteMark == false
                           select a;
            int count = await listUser.CountAsync();
            List<UserInfo> list = null;
            if (count > 0)
                list = await listUser.OrderBy(a => a.F_CreatorTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<UserInfo>(pageIndex, pageSize, count, list);
        }

        public async Task<UserRoleViewModel> GetUserRoleAsync(string f_id)
        {
            var user = from a in Context.Users
                       join b in Context.UserRole on
                       a.F_RoleId equals b.F_Id
                       join c in Context.UserLogOn on
                       a.F_Id equals c.F_UserId
                       where a.F_Id == f_id && c.F_UserId == f_id
                       select new UserRoleViewModel()
                       {
                           F_FullName = b.F_FullName,
                           F_Gender = a.F_Gender,
                           F_MobilePhone = a.F_MobilePhone,
                           F_NickName = a.F_NickName,
                           F_RealName = a.F_RealName,
                           F_RoleId = b.F_Id,
                           Id = a.F_Id,
                           F_Account = a.F_Account,
                           F_Email = a.F_Email,
                           F_UserPassword = Encrypt.DecryptText(c.F_UserPassword, "dgq"),
                           F_DutyId = a.F_DutyId,
                           F_DepartmentId = a.F_DepartmentId,
                           F_OrganizeId = a.F_OrganizeId,
                           F_EnabledMark = a.F_EnabledMark
                       };
            return await user.FirstOrDefaultAsync();

        }

        public async Task<UserRoleViewModel> GetUserByUserName(string username)
        {
            var user = from a in Context.Users
                       join b in Context.UserLogOn
                       on a.F_Id equals b.F_UserId
                       where a.F_Account == username
                       join c in Context.UserRole
                       on a.F_RoleId equals c.F_Id
                       select new UserRoleViewModel()
                       {
                           F_Gender = a.F_Gender,
                           F_MobilePhone = a.F_MobilePhone,
                           F_NickName = a.F_NickName,
                           F_RealName = a.F_RealName,
                           F_RoleId = b.F_Id,
                           Id = a.F_Id,
                           F_Account = a.F_Account,
                           F_UserPassword = b.F_UserPassword,
                           F_Email = a.F_Email,
                           F_RoleName = c.F_FullName,
                           F_EnabledMark = a.F_EnabledMark
                       };
            return await user.FirstOrDefaultAsync();
        }

        public bool BatchDelUser(string keyValue,string userId)
        {
            string[] IdArray = keyValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var expression = ExtLinq.True<UserInfo>();
            IUnitOfWork db = new EFUnitOfWork(Context).BeginTransaction();
            for (var i = 0; i < IdArray.Length; i++)
            {
                if (i == 0)
                    expression = expression.And(a => a.F_Id == IdArray[i]);
                else
                    expression = expression.Or(a => a.F_Id == IdArray[i]);
            }
            try
            {
                using (db)
                {
                    List<UserInfo> userList = Context.Users.Where(expression).ToList();
                    foreach (UserInfo user in userList)
                    {
                        user.F_DeleteMark = true;
                        user.F_DeleteUserId = userId;
                        user.F_DeleteTime = DateTime.Now;
                        Update(user);
                    }
                }
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return false;
            }
            return true;
        }


    }
}
