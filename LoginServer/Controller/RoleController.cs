using DGQ.Code.TreeView;
using DGQ.Repository.Contract;
using DGQ.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IModuleButtonService _moduleButtonService;
        private readonly IModuleService _moduleService;
        private readonly IRoleAuthorizeService _roleAuthorizeService;

        public RoleController(IModuleButtonService moduleButtonService, IModuleService moduleService, IRoleAuthorizeService roleAuthorizeService)
        {
            _moduleButtonService = moduleButtonService;
            _moduleService = moduleService;
            _roleAuthorizeService = roleAuthorizeService;
        }

        [HttpGet(nameof(GetPermissionTree))]
        [Route("api/Role/GetPermissionTree")]
        public async Task<ActionResult> GetPermissionTree(string roleId)
        {
            var moduleData = await _moduleService.GetModuleList();
            var moduleButtonData = await _moduleButtonService.GetList();
            var authorizeData = new List<RoleAuthorize>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizeData = await _roleAuthorizeService.GetRoleAuthorizeList(roleId);
            }
            var treeList = new List<TreeViewModel>();
            foreach (Module item in moduleData)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduleData.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.title = item.F_FullName;
                tree.isexpand = true;
                tree.text = item.F_FullName;
                tree.value = item.F_Id;
                tree.parentId = item.F_ParentId;
                tree.hasChildren = hasChildren;
                tree.complete = true;
                tree.showcheck = true;
                treeList.Add(tree);
            }
            foreach (ModuleButton item in moduleButtonData)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduleButtonData.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_EnCode;
                tree.parentId = item.F_ParentId == "0" ? item.F_ModuleId : item.F_ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizeData.Count(t => t.F_ItemId == item.F_Id);
                tree.hasChildren = hasChildren;
                tree.img = item.F_Icon == "" ? "" : item.F_Icon;
                treeList.Add(tree);
            }
            return new ContentResult() { Content = TreeView.TreeViewJson(treeList), StatusCode = 200, ContentType = "applicetion/json" };
        }
    }
}
