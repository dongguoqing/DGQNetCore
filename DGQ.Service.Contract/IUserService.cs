using Model;
using Model.ViewModel;
using System;
using System.Threading.Tasks;

namespace DGQ.Service.Contract
{
    public interface IUserService:IService
    {
        Task<PaginatedList<UserViewModel>> GetUserInfoAsync(int pageIndex, int pageSize);
    }
}
