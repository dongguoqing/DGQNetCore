using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGQ.Service.Contract
{
    public interface IItemsService : IService
    {
        List<Items> GetList();
    }
}
