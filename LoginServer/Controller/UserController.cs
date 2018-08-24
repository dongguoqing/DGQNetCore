using DGQ.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Model;
using Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private ApiDBContent _context;
        private IMemoryCache _cache;
        private readonly ILogger<UserController> nLogger2;
        private readonly IUserService _userService;

        public UserController(ApiDBContent context, IMemoryCache cache, ILogger<UserController> logger2,IUserService userService)
        {
            nLogger2 = logger2;
            this._context = context;
            this._userService = userService;
            this._cache = cache;
        }

        [HttpGet(nameof(GetUserList))]
        [Route("api/User/GetUserList")]
        public async Task<ActionResult> GetUserList(int pageIndex, int pageSize)
        {
            PaginatedList<UserViewModel> pagedList =  await _userService.GetUserInfoAsync(1, 10);
            Console.WriteLine(pagedList.Items.Count);
            Console.WriteLine(pagedList.Count);
            //写入日志
            nLogger2.LogInformation("nloginfo2");
            nLogger2.LogError("nlogerror2", new Exception("自定义异常"));
            return Content(JsonConvert.SerializeObject(pagedList), "application/text");
        }

        [HttpPost(nameof(AddUser))]
        [Route("api/User/AddUser")]
        public async Task<ActionResult> AddUser(UserViewModel userViewModel)
        {
            UserInfo userInfo = new UserInfo()
            {
                Email = userViewModel.Email,
                Enable = userViewModel.Enable,
                Name = userViewModel.Name,
                Sex = userViewModel.Sex,
                PassWord = "123456",
                Uid = userViewModel.RoleId,
                UserName = userViewModel.UserName
            };
            _userService.AddUser(userInfo);
            return Content("ok", "application/text");
        }

        [HttpGet(nameof(DelUser))]
        [Route("api/User/DelUser")]
        public async Task<ActionResult> DelUser(int Id)
        {
            //实例化一个实体 将主键设置为
            var userInfo = new UserInfo() { Id = Id };
            _context.Set<UserInfo>().Remove(userInfo);
            _context.SaveChanges();
            return Content("ok", "application/text");
        }

        [HttpGet(nameof(EditUser))]
        [Route("api/User/EditUser")]
        public async Task<ActionResult> EditUser(UserViewModel userViewModel)
        {
            UserInfo userInfo = new UserInfo()
            {
                Email = userViewModel.Email,
                Enable = userViewModel.Enable,
                Name = userViewModel.Name,
                Sex = userViewModel.Sex,
                Uid = userViewModel.RoleId,
                UserName = userViewModel.UserName
            };
            _context.Set<UserInfo>().Attach(userInfo);
            _context.Entry(userInfo).State = EntityState.Modified;
            return Content("ok", "application/text");
        }

        [HttpGet(nameof(GetUserById))]
        [Route("api/Login/GetUserById")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = _context.Users.Where(a => a.Id == id).FirstOrDefault();
            return Content(JsonConvert.SerializeObject(user), "application/text");
        }
    }
}
