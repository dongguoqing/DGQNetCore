using DGQ.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Threading.Tasks;
using DGQ.Repository.Contract;

namespace DGQ.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public async Task<PaginatedList<UserRole>> GetRoleList(int pageIndex, int pageSize)
        {
            var pagedList = await _roleRepository.GetRoleList(pageIndex, pageSize);
            if (pageSize * (pageIndex - 1) > pagedList.Count)
            {
                pageIndex = (int)Math.Ceiling(((double)pagedList.Count) / pageSize);
                pagedList = await _roleRepository.GetRoleList(pageIndex, pageSize);
            }
            return pagedList;
        }

        public async Task<List<UserRole>> GetRoleList()
        {
            return await _roleRepository.GetRoleList();
        }
    }
}
