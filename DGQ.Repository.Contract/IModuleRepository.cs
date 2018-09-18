using DGQ.Infrustructure.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Repository.Contract
{
    public interface IModuleRepository:IRepository<Module>
    {
        Task<List<Module>> GetModuleList();
        Task<PaginatedList<Module>> GetModuleList(int pageIndex, int pageSize);
    }
}
