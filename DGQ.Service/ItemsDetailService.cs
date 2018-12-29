using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DGQ.Service
{
    public class ItemsDetailService : IItemsDetailService
    {
        private readonly IItemsDetailRepository _itemDetailRepository;
        public ItemsDetailService(IItemsDetailRepository itemDetailRepository)
        {
            this._itemDetailRepository = itemDetailRepository;
        }

        public List<ItemsDetail> GetList()
        {
            return _itemDetailRepository.Get().ToList();
        }
    }
}
