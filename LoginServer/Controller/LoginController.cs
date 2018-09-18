
using DGQ.Code;
using DGQ.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Model;
using Model.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LoginServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ApiDBContent _context;
        private IMemoryCache _cache;
        // private readonly ILogger<LoginController> nLogger2;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public LoginController(ApiDBContent context, IMemoryCache cache, IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
            // nLogger2 = logger2;
            this._cache = cache;
            this._context = context;
        }

        [HttpPost(nameof(RequestToken))]
        [Route("api/Login/RequestToken")]
        public async Task<ActionResult> RequestToken(LoginRequest model)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["client_id"] = "clientPC1";
            dict["client_secret"] = "123321";
            dict["grant_type"] = "password";
            dict["username"] = model.Email;
            dict["password"] = model.PassWord;
            //外键关联查询 通过外键的名称进行关联
            //var listUser = _context.Users.Include("Role").ToList().FirstOrDefault();
            //根据用户名去查询相应的用户信息 
            Console.WriteLine(model.Email);
            var user = await _userService.GetUserByUserName(model.Email);
            Console.WriteLine(user);
            //由登录服务器向IdentityServer发请求获取Token
            using (HttpClient http = new HttpClient())
            using (var content = new FormUrlEncodedContent(dict))
            {
                var msg = await http.PostAsync("http://192.168.1.47:9500/connect/token", content);
                UserResult result = await msg.Content.ReadAsAsync<UserResult>();
                //将获取的Access_Token存入缓存中 以便在后续的接口请求中判断
                _cache.Set("access_token", result.Access_token);
                Console.WriteLine(_cache.Get("access_token"));
                result.Email = model.Email;
                result.Uid = user.Id;
                string data = JObject.FromObject(result).ToString();
                return Content(data, "application/json");
            }
        }

        [HttpGet(nameof(GetInfo))]
        [Route("api/Login/GetInfo")]
        public async Task<ActionResult> GetInfo(string uid)
        {
            var user = await _userService.GetUserRoleAsync(uid);
            Console.WriteLine(JsonConvert.SerializeObject(user));
            return Content(JObject.FromObject(user).ToString(), "application/text");
        }



        [HttpGet(nameof(GetRoleList))]
        [Route("api/Login/GetRoleList")]
        public async Task<ActionResult> GetRoleList()
        {
            var listRole = await _roleService.GetRoleList();
            return Content(JsonConvert.SerializeObject(listRole.Where(a=>a.F_Type!=null)), "application/text");
        }






        //[HttpPost(nameof(IsLogin))]
        //[Route("api/Login/IsLogin")]
        //public async Task<ActionResult> IsLogin(LoginRequest model)
        //{
        //    var list = _context.Users.Where(a => a.Email == model.Email && a.Password == model.PassWord).ToList();
        //    var result = string.Empty;
        //    Console.WriteLine(list.Count);
        //    if (list.Count > 0)
        //        Response.StatusCode = 200;
        //    else
        //        Response.StatusCode = 500;
        //    using (HttpClient http = new HttpClient())
        //    using (var content = new FormUrlEncodedContent(dict))
        //    {
        //        var msg = await http.PostAsync("http://192.168.1.47:9500/connect/token", content);
        //        string result = await msg.Content.ReadAsStringAsync();
        //        Console.WriteLine(result);
        //        return Content(result, "application/json");
        //    }
        //    return Content(result);
        //}
    }
}
