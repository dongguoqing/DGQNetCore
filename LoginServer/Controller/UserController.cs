using DGQ.Code;
using DGQ.Code.Json;
using DGQ.Code.Operator;
using DGQ.Service.Contract;
using Microsoft.AspNetCore.Http;
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
    public class UserController : ControllerBase
    {
        private ApiDBContent _context;
        private IMemoryCache _cache;
        private readonly ILogger<UserController> nLogger2;
        private readonly IUserService _userService;
        private readonly IUserLogOnService _userLogOnService;
        private readonly IHttpContextAccessor _accessor;

        public UserController(ApiDBContent context, IMemoryCache cache, ILogger<UserController> logger2, IUserService userService, IUserLogOnService userLogOnService, IHttpContextAccessor accessor)
        {
            nLogger2 = logger2;
            this._context = context;
            this._userService = userService;
            this._userLogOnService = userLogOnService;
            this._cache = cache;
            _accessor = accessor;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetUserList))]
        [Route("api/User/GetUserList")]
        public async Task<ActionResult> GetUserList(int pageIndex, int pageSize)
        {
            PaginatedList<UserInfo> pagedList = await _userService.GetUserInfoAsync(pageIndex, pageSize);
            Console.WriteLine(pagedList.Items.Count);
            Console.WriteLine(pagedList.Count);
            //写入日志
            nLogger2.LogInformation("nloginfo2");
            nLogger2.LogError("nlogerror2", new Exception("自定义异常"));
            return Content(JsonConvert.SerializeObject(pagedList), "application/text");
        }

        [HttpPost(nameof(AddUser))]
        [Route("api/User/AddUser")]
        public async Task<ActionResult> AddUser(UserInfo userInfo)
        {
            var userId = _accessor.HttpContext.Request.Cookies["uid"];
            userInfo.F_DeleteMark =false;
            var entity = _userService.AddUser(userInfo, userId);
            return new ContentResult() { Content = Json.ToJson(entity), ContentType = "application/json", StatusCode = 200 };
        }

        [HttpPost(nameof(AddUserPassWord))]
        [Route("api/User/AddUserPassWord")]
        public async Task<ActionResult> AddUserPassWord(UserLogOn userLogOn)
        {
            userLogOn.F_UserPassword = Encrypt.EncryptText(userLogOn.F_UserPassword, "dgq");
            _userLogOnService.AddUserLogOn(userLogOn);
            return new ContentResult() { Content = "ok", ContentType = "application/json", StatusCode = 200 };
        }

        [HttpGet(nameof(DelUser))]
        [Route("api/User/DelUser")]
        public async Task<ActionResult> DelUser(string Id)
        {
            //实例化一个实体 将主键设置为
            //var userInfo = new UserInfo() { Id = Id };
            var user = _userService.GetByID(Id);
            //_context.Set<UserInfo>().Remove(userInfo);
            //_context.SaveChanges();
            return Content("ok", "application/text");
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPost(nameof(EditUser))]
        [Route("api/User/EditUser")]
        public async Task<ActionResult> EditUser(UserInfo userInfo)
        {
            var userId = _accessor.HttpContext.Request.Cookies["uid"];
            _userService.EditUser(userInfo, userId);
            return Content("ok", "application/text");
        }

        /// <summary>
        /// 根据用户id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetUserById))]
        [Route("api/Login/GetUserById")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserRoleAsync(id);
            return Content(JsonConvert.SerializeObject(user), "application/text");
        }

        /// <summary>
        /// 超级管理员修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpPost(nameof(UpdatePassWord))]
        [Route("api/Login/UpdatePassWord")]
        public async Task<ActionResult> UpdatePassWord(UserLogOn userLogOn)
        {
            userLogOn.F_UserPassword = Encrypt.EncryptText(userLogOn.F_UserPassword, "dgq");
            _userLogOnService.UpdatePassWord(userLogOn);
            return Content("ok");
        }

        /// <summary>
        /// 当前用户进行密码修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passWord"></param>
        /// <param name="newPassWord"></param>
        /// <returns></returns>
        [HttpPost(nameof(UpdateSelfPassWord))]
        [Route("api/Login/UpdateSelfPassWord")]
        public async Task<ActionResult> UpdateSelfPassWord(string id, string passWord, string newPassWord)
        {
            ContentResult contentResult = new ContentResult();
            //先验证旧密码是否正确 如果正确才能进行修改
            var user = await _userLogOnService.GetByUserId(id);
            //对密码进行加密 然后验证
            if (passWord == Encrypt.DecryptText(user.F_UserPassword, "dgq"))
            {
                user.F_UserPassword = Encrypt.EncryptText(newPassWord, "dgq");
                _userLogOnService.UpdatePassWord(user);
                contentResult.Content = "ok";
                contentResult.StatusCode = 200;
                contentResult.ContentType = "application/json";
            }
            else
            {
                contentResult.Content = "原始密码错误！";
                contentResult.StatusCode = 200;
                contentResult.ContentType = "application/json";
            }

            return contentResult;
        }
    }
}
