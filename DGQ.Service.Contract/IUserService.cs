using Model;
using Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IUserService:IService
    {
        Task<PaginatedList<UserInfo>> GetUserInfoAsync(int pageIndex, int pageSize);
        UserInfo AddUser(UserInfo userInfo,string userId);
        void EditUser(UserInfo userInfo,string userId);
        Task<UserRoleViewModel> GetUserRoleAsync(string f_id);
        Task<UserRoleViewModel> GetUserByUserName(string username);
        UserInfo GetByID(object id);
    }
}
