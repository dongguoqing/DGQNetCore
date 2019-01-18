using DGQ.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    public class ItemsController : ControllerBase
    {

        private readonly IItemsService itemsService;
        public ItemsController(IItemsService _itemsService)
        {
            this.itemsService = _itemsService;
        }

        [HttpGet(nameof(GetItemsList))]
        [Route("api/Items/GetItemsList")]
        public async Task<ActionResult> GetItemsList()
        {
            List<ItemsViewModel> list = await itemsService.GetItemsViewModel();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var item in list)
            {
                dic.Add(item.F_Id, item);
            }
            return Content(JsonConvert.SerializeObject(dic));
        }
    }
}
