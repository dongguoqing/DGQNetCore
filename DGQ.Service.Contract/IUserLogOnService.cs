using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IUserLogOnService:IService
    {
        Task<UserLogOn> GetByUserId(string id);
        void UpdatePassWord(UserLogOn userLogOn);
        UserLogOn AddUserLogOn(UserLogOn userLogOn);
    }
}
