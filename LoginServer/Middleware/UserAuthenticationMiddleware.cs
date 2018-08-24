using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServer.Middleware
{
    public class UserAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;

        public UserAuthenticationMiddleware( RequestDelegate next, IMemoryCache cache)
        {

            this._next = next;
            this._cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            //获取当前请求的接口的路径地址
            var requestPath = context.Request.Path.ToString().ToLower();
            //如果是登录接口就不需要进行验证 不是登录接口的话 就需要进行验证
            if (requestPath.StartsWith("/api/login/requesttoken"))
            {
                await _next(context);
                return;
            }
            Console.WriteLine(requestPath);
            //其他的不是登录接口的需要进行认证
            if (requestPath.StartsWith("/api"))
            {
                //获取请求头 如果请求头中包含的Access_Token是正确的 
                var access_token = context.Request.Cookies["Admin-Token"];
                //获取缓存中的access_token  判断两个token是不是一个
                var cacheAccessToken = _cache.Get("access_token");
                if (access_token == "")
                {
                    var result = new
                    {
                        state = 500,
                        ExceptionString = "Need tockenid"
                    };

                    context.Response.ContentType = "application/json; charset=utf-8";
                    context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    return;
                }

                if (cacheAccessToken == null)
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    context.Response.WriteAsync("Invalidate tockenid(用户认证失败)");
                    return;
                }
                if (cacheAccessToken.ToString() != access_token.ToString())
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json; charset=utf-8";
                    context.Response.WriteAsync("Invalidate tockenid(用户认证失败)");
                    return;
                }
            }
            await _next(context);
        }

    }

    public static class UserAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAuthenticationMiddleware>();
        }
    }
}
