using Model;
using Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IUserService
    {
        Task<PaginatedList<UserInfo>> GetUserInfoAsync(int pageIndex, int pageSize);
        void AddUser(UserInfo userInfo);
        void EditUser(UserInfo userInfo);
    }
}
