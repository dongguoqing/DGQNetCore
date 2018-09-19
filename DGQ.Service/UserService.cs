using System;
using System.Threading.Tasks;
using DGQ.Service.Contract;
using Model;
using Model.ViewModel;
using DGQ.Repository.Contract;

namespace DGQ.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PaginatedList<UserInfo>> GetUserInfoAsync(int pageIndex, int pageSize)
        {
            var pagedList = await _userRepository.GetUserInfoAsync(pageIndex, pageSize);
            if (pageSize * (pageIndex - 1) > pagedList.Count)
            {
                pageIndex = (int)Math.Ceiling(((double)pagedList.Count) / pageSize);
                pagedList = await _userRepository.GetUserInfoAsync(pageIndex, pageSize);
            }
            return pagedList;
        }

        public async Task<UserRoleViewModel> GetUserRoleAsync(string f_id)
        {
            return await _userRepository.GetUserRoleAsync(f_id);
        }

        public void AddUser(UserInfo userInfo)
        {
            _userRepository.Insert(userInfo);
            _userRepository.Save();
        }

        public void EditUser(UserInfo userInfo, string userId)
        {
            userInfo.Modify(userId);
            _userRepository.Update(userInfo);
            _userRepository.Save();
        }

        public UserInfo GetByID(object id)
        {
            return _userRepository.GetByID(id);
        }

        public async Task<UserRoleViewModel> GetUserByUserName(string username)
        {
            return await _userRepository.GetUserByUserName(username);
        }
    }
}
