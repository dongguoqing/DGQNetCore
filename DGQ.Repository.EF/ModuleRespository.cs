using DGQ.Infrustructure.EF;
using DGQ.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Model.ViewModel;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Model;

namespace DGQ.Repository.EF
{
    public class ModuleRespository : Repository<Module>, IModuleRepository
    {
        public ModuleRespository(ApiDBContent context) : base(context)
        {

        }

        public async Task<List<Module>> GetModuleList()
        {
            var list = from a in Context.Module select a;
            return await list.ToListAsync();
        }

        public async Task<PaginatedList<Module>> GetModuleList(int pageIndex, int pageSize)
        {
            var moduleList = from a in Context.Module select a;
            int count = moduleList.Count();
            List<Module> list = null;
            if (count > 0)
                list =await moduleList.OrderBy(a => a.F_Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<Module>(pageIndex, pageSize, count, list);
        }
    }
}
