using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service
{
    public class RoleAuthorizeService:IRoleAuthorizeService
    {
        private readonly IRoleAuthorizeRepository _roleAuthorizeRepository;
        public RoleAuthorizeService(IRoleAuthorizeRepository roleAuthorizeRepository)
        {
            this._roleAuthorizeRepository = roleAuthorizeRepository;
        }

        public async Task<List<RoleAuthorize>> GetRoleAuthorizeList(string roleId)
        {
            return await _roleAuthorizeRepository.GetRoleAuthorizeList(roleId);
        }
    }
}
