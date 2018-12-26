using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IRoleService : IService
    {
        Task<PaginatedList<UserRole>> GetRoleList(int pageIndex, int pageSize);
        Task<List<UserRole>> GetRoleList(string fType = "");
    }
}
