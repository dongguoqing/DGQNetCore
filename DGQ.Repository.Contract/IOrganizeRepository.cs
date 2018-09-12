using DGQ.Infrustructure.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Repository.Contract
{
    public interface IOrganizeRepository:IRepository<Organize>
    {
        Task<List<Organize>> GetOrganizeList();
        Task<List<Organize>> GetCompanyList();
    }
}
