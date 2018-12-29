using DGQ.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    public class ClientsDataController : ControllerBase
    {

        private readonly IItemsDetailService _itemDetailService;
        private readonly IItemsService _itemService;
        private readonly IOrganizeService _organizeService;
        private readonly IRoleService _roleService;

        public ClientsDataController(IItemsDetailService itemDetailService, IItemsService itemService, IOrganizeService organizeService, IRoleService roleService)
        {
            _itemDetailService = itemDetailService;
            _itemService = itemService;
            _organizeService = organizeService;
            _roleService = roleService;
        }

        //public ActionResult GetClientsDataJson()
        //{

        //}

        public object GetDataItemList()
        {
            var itemDetailData = _itemDetailService.GetList();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            var itemsData = _itemService.GetList();
            foreach (var item in itemsData)
            {
                var dataItemList = itemDetailData.FindAll(a => a.F_ItemId.Equals(item.F_Id));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.F_ItemCode, itemList.F_ItemName);
                }
                dictionaryItem.Add(item.F_EnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }

        public object GetOrganizeList()
        {
            var data = _organizeService.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Organize item in data)
            {
                var fiedItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fiedItem);
            }
            return dictionary;
        }

        public async Task<object> GetRoleList()
        {
            var data = await _roleService.GetRoleList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (UserRole item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }

        public async Task<Object> GetDutyList()
        {
            var data = await _roleService.GetRoleList("2");
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (UserRole item in data)
            {
                var fieldItem = new
                {
                    encode = item.F_EnCode,
                    fullname = item.F_FullName
                };
                dictionary.Add(item.F_Id, fieldItem);
            }
            return dictionary;
        }
    }
}
