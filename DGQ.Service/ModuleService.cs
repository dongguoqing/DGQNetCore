using DGQ.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Threading.Tasks;
using DGQ.Repository.Contract;

namespace DGQ.Service
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<PaginatedList<Module>> GetModuleList(int pageIndex, int pageSize)
        {
            var pagedList = await _moduleRepository.GetModuleList(pageIndex, pageSize);
            if ((pageIndex - 1) * pageSize > pagedList.Count)
            {
                pageIndex = (int)Math.Ceiling(((double)pagedList.Count) / pageSize);
                pagedList = await _moduleRepository.GetModuleList(pageIndex, pageSize);
            }
            return pagedList;
        }

        public Task<List<Module>> GetModuleList()
        {
            return _moduleRepository.GetModuleList();
        }
    }
}
