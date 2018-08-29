﻿using DGQ.Infrustructure.Contract;
using System;
using Model;
using System.Threading.Tasks;
using Model.ViewModel;

namespace DGQ.Repository.Contract
{
    public interface IUserRepository:IRepository<UserInfo>
    {
        Task<PaginatedList<UserInfo>> GetUserInfoAsync( int pageIndex, int pageSize);
    }
}
