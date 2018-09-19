using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DGQ.Service
{
    public class UserLogOnService : IUserLogOnService
    {

        private readonly IUserLogOnRepository _userLogOnRepository;

        public UserLogOnService(IUserLogOnRepository userLogOnRepository)
        {
            this._userLogOnRepository = userLogOnRepository;
        }

        public async Task<UserLogOn> GetByUserId(string id)
        {
            return await _userLogOnRepository.GetByUserId(id);
        }

        public   void UpdatePassWord(UserLogOn userLogOn)
        {
            _userLogOnRepository.Update(userLogOn);
            _userLogOnRepository.Save();
        }

        public UserLogOn AddUserLogOn(UserLogOn userLogOn)
        {
            var entity = _userLogOnRepository.Insert(userLogOn);
            _userLogOnRepository.Save();
            return entity;
        }
    }
}
