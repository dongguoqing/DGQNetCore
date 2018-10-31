using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DGQ.Repository.EF
{
    public class ModuleButtonRepository:Repository<ModuleButton>,IModuleButtonRepository
    {
        public ModuleButtonRepository(ApiDBContent context):base(context)
        {            
        }

        public async Task<List<ModuleButton>> GetList()
        {
            var list = from a in Context.ModuleButton
                       select a;
            return await list.ToListAsync();
        }
    }
}
