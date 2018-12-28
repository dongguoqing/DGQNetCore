using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DGQ.Code.Extend;

namespace DGQ.Repository.EF
{
    public class RoleRepository : Repository<UserRole>, IRoleRepository
    {
        public RoleRepository(ApiDBContent context) : base(context)
        {
        }

        public async Task<List<UserRole>> GetRoleList(string fType = "")
        {
            var expression = ExtLinq.True<UserRole>();
            if (fType != "")
            {
                string[] fTypeArray = fType.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < fTypeArray.Length; i++)
                {
                    if (i == 0)
                        expression = expression.And(a => a.F_Type == fType);
                    else
                        expression = expression.Or(a => a.F_Type == fType);
                }
            }
            var roleList = from a in Context.UserRole select a;
            return await roleList.Where(expression).ToListAsync();
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
