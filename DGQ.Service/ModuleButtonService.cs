using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DGQ.Service
{
    public class ModuleButtonService:IModuleButtonService
    {
        private readonly IModuleButtonRepository _moduleButtonRepository;
        
        public ModuleButtonService(IModuleButtonRepository moduleButtonRepository)
        {
            _moduleButtonRepository = moduleButtonRepository;
        }

        public async Task<List<ModuleButton>> GetList()
        {
            return await _moduleButtonRepository.GetList();
        }
    }
}
