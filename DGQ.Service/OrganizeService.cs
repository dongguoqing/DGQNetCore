using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service
{
    public class OrganizeService : IOrganizeService
    {
        private readonly IOrganizeRepository _organizeRepository;

        public OrganizeService(IOrganizeRepository organizeRepository)
        {
            _organizeRepository = organizeRepository;
        }

        public async Task<List<Organize>> GetOrganizeList()
        {
            return await _organizeRepository.GetOrganizeList();
        }

        public async Task<List<Organize>> GetCompanyList()
        {
            return await _organizeRepository.GetCompanyList();
        }
    }
}
