using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IModuleService:IService
    {
        Task<PaginatedList<Module>> GetModuleList(int pageIndex,int pageSize);
        Task<List<Module>> GetModuleList();
    }
}
