using DGQ.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    public class OrganizeController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public OrganizeController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet(nameof(GetOrganizeList))]
        [Route("api/Organize/GetOrganizeList")]
        public async Task<ActionResult> GetOrganizeList()
        {
            var list = await _roleService.GetRoleList();
            Dictionary<string, UserRole> dic = new Dictionary<string, UserRole>();
            foreach(var item in list)
            {
                dic.Add(item.F_Id, item);
            }
            return Content(JsonConvert.SerializeObject(dic), "application/text");
        }
    }
}
