using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGQ.Repository.EF
{
    public class ItemsDetailRepository : Repository<ItemsDetail>, IItemsDetailRepository
    {
        public ItemsDetailRepository(ApiDBContent context) : base(context)
        {

        }
    }
}
