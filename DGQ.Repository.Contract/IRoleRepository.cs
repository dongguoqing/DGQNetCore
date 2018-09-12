using DGQ.Infrustructure.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Repository.Contract
{
    public interface IRoleRepository:IRepository<UserRole>
    {
        Task<List<UserRole>> GetRoleList();
        Task<PaginatedList<UserRole>> GetRoleList(int pageIndex,int pageSize);
    }
}
