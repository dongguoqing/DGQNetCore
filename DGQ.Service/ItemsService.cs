using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DGQ.Service
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsService(IItemsRepository itemRepository)
        {
            this._itemsRepository = itemRepository;
        }

        public List<Items> GetList()
        {
            return _itemsRepository.Get().ToList();
        }
    }
}
