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
        private readonly IOrganizeService _organizeService;

        public OrganizeController(IRoleService roleService, IOrganizeService organizeService)
        {
            this._roleService = roleService;
            this._organizeService = organizeService;
        }

        [HttpGet(nameof(GetOrganizeList))]
        [Route("api/Organize/GetOrganizeList")]
        public async Task<ActionResult> GetOrganizeList()
        {
            var list = await _organizeService.GetOrganizeList();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in list)
            {
                dic.Add(item.F_Id, item);
            }
            return Content(JsonConvert.SerializeObject(dic), "application/text");
        }

        [HttpGet(nameof(GetCompanyList))]
        [Route("api/Organize/GetCompanyList")]
        public async Task<ActionResult> GetCompanyList()
        {
            var list = await _organizeService.GetCompanyList();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in list)
            {
                dic.Add(item.F_Id, item);
            }
            return Content(JsonConvert.SerializeObject(dic), "application/text");
        }

        [HttpGet(nameof(GetDutyList))]
        [Route("api/Organize/GetDutyList")]
        public async Task<ActionResult> GetDutyList()
        {
            var list = await _roleService.GetRoleList();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in list)
            {
                dic.Add(item.F_Id, item);
            }
            return Content(JsonConvert.SerializeObject(dic), "application/text");
        }

        [HttpGet(nameof(GetRoleList))]
        [Route("api/Organize/GetRoleList")]
        public async Task<ActionResult> GetRoleList()
        {
            var list = await _roleService.GetRoleList("1,2");
            return Content(JsonConvert.SerializeObject(list), "application/text");
        }
    }
}
