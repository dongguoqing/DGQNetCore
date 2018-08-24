using LoginServer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly ILogger<LoginController> nLogger2;

        public LoginController(ApiDBContent context, IMemoryCache cache, ILogger<LoginController> logger2)
        {
            nLogger2 = logger2;
            this._context = context;
            this._cache = cache;
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
                string data = JObject.FromObject(result).ToString();
                return Content(data, "application/json");
            }
        }

        [HttpGet(nameof(GetInfo))]
        [Route("api/Login/GetInfo")]
        public async Task<ActionResult> GetInfo(string token)
        {
            var listUser = _context.Users.Include("Role").FirstOrDefault();
            return Content(JObject.FromObject(listUser).ToString(), "application/text");
        }

       

        [HttpGet(nameof(GetRoleList))]
        [Route("api/Login/GetRoleList")]
        public async Task<ActionResult> GetRoleList()
        {
            var listRole = _context.UserRole.ToList();
            return Content(JsonConvert.SerializeObject(listRole), "application/text");
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
