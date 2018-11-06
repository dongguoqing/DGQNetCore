using System;
using System.Threading.Tasks;
using DGQ.Service.Contract;
using Model;
using Model.ViewModel;
using DGQ.Repository.Contract;
using DGQ.Code.Extend;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public UserInfo AddUser(UserInfo userInfo, string userId)
        {
            userInfo.Create(userId);
            var entity = _userRepository.Insert(userInfo);
            _userRepository.Save();
            return entity;
        }

        public void EditUser(UserInfo userInfo, string userId)
        {
            userInfo.Modify(userId);
            _userRepository.Update(userInfo);
            _userRepository.Save();
        }

        public UserInfo GetByID(string id)
        {
            return _userRepository.GetByID(id);
        }

        public async Task<UserRoleViewModel> GetUserByUserName(string username)
        {
            return await _userRepository.GetUserByUserName(username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PaginatedList<UserInfo>> GetList(string keyword, int pageIndex, int pageSize)
        {
            var expression = ExtLinq.True<UserInfo>();
            if (!String.IsNullOrEmpty(keyword))
            {
                expression = expression.And(a => a.F_NickName == keyword);
                expression = expression.Or(a => a.F_RealName == keyword);
                expression = expression.Or(a => a.F_Account == keyword);
            }
            var resultWhere = _userRepository.Get(expression);
            List<UserInfo> list = null;
            int count = resultWhere.Count();
            if (count > 0)
                list = await resultWhere.OrderBy(a => a.F_CreatorTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<UserInfo>(pageIndex, pageSize, count, list);
        }
    }
}
