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
    public class OrganizeRepository : Repository<Organize>, IOrganizeRepository
    {
        public OrganizeRepository(ApiDBContent context) : base(context)
        {
        }

        /// <summary>
        /// 获取部门集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<Organize>> GetOrganizeList()
        {
            var organizeList = from a in Context.Organize
                               where a.F_Layers == 2
                               select a;
            return await organizeList.ToListAsync();
        }

        /// <summary>
        /// 获取公司集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<Organize>> GetCompanyList()
        {
            var companyList = from a in Context.Organize
                              where a.F_Layers == 1
                              select a;
            return await companyList.ToListAsync();
        }
    }
}
