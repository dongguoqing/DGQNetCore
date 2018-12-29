using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DGQ.Repository.EF
{
    public class ItemsRepository : Repository<Items>, IItemsRepository
    {
        public ItemsRepository(ApiDBContent context) : base(context)
        {

        }
    }
}
