using DGQ.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    public class ModuleController : ControllerBase
    {

        private readonly IModuleRepository _moduleRepository;

        public ModuleController(IModuleRepository moduleRepository)
        {
            this._moduleRepository = moduleRepository;
        }

        [HttpPost(nameof(GetModuleTree))]
        [Route("api/Module/GetModuleTree")]
        public async Task<ActionResult> GetModuleTree()
        {
            var list = await _moduleRepository.GetModuleList();
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}
