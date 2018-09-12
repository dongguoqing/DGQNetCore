using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IOrganizeService:IService
    {
        Task<List<Organize>> GetCompanyList();
        Task<List<Organize>> GetOrganizeList();
    }
}
