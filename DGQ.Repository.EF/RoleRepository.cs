using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DGQ.Repository.EF
{
    public class RoleRepository : Repository<UserRole>, IRoleRepository
    {
        public RoleRepository(ApiDBContent context) : base(context)
        {
        }

        public async Task<List<UserRole>> GetRoleList()
        {
            var roleList = from a in Context.UserRole select a;
            return await roleList.ToListAsync();
        }

        public async Task<PaginatedList<UserRole>> GetRoleList(int pageIndex, int pageSize)
        {
            var roleList = from a in Context.UserRole select a;
            int count = roleList.Count();
            List<UserRole> list = null;
            if (count > 0)
                list = await roleList.OrderBy(a => a.F_Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<UserRole>(pageIndex, pageSize, count, list);
        }
    }
}
