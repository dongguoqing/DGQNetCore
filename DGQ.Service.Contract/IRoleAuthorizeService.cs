using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IRoleAuthorizeService:IService
    {
        Task<List<RoleAuthorize>> GetRoleAuthorizeList(string roleId);
    }
}
