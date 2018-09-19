using DGQ.Infrustructure.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Repository.Contract
{
    public interface IUserLogOnRepository:IRepository<UserLogOn>
    {
        Task<UserLogOn> GetByUserId(string id);
    }
}
