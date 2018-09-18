using DGQ.Infrustructure.EF;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DGQ.Repository.EF
{
    public class RoleAuthorizeRepository:Repository<RoleAuthorize>
    {
        public RoleAuthorizeRepository(ApiDBContent context) : base(context)
        {

        }

        public async Task<List<RoleAuthorize>> GetRoleAuthorizeList(string roleId)
        {
            var list = from a in Context.RoleAuthorize select a;
            return await list.ToListAsync();
        }
    }
}
