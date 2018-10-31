using DGQ.Repository.Contract;
using DGQ.Service.Contract;
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

        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            this._moduleService = moduleService;
        }

        [HttpPost(nameof(GetModuleTree))]
        [Route("api/Module/GetModuleTree")]
        public async Task<ActionResult> GetModuleTree()
        {
            var list = await _moduleService.GetModuleList();
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}
