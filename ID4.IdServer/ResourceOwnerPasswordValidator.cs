using DGQ.Code;
using DGQ.Repository.Contract;
using DGQ.Service;
using DGQ.Service.Contract;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ID4.IdServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // Console.WriteLine("111");
            //获取数据库中的用户
            var user = await _userService.GetUserByUserName(context.UserName);
            if (user != null)
            {
                if (user.F_EnabledMark == true)
                {
                    //根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
                    Console.WriteLine(Encrypt.EncryptText(context.Password, "dgq"));
                    Console.WriteLine(user.F_UserPassword);
                    if (Encrypt.EncryptText(context.Password, "dgq") == user.F_UserPassword)
                    {
                        context.Result = new GrantValidationResult(
                           subject: context.UserName,
                           authenticationMethod: "custom",
                           claims: new Claim[] { new Claim("Name", context.UserName), new Claim("UserId", user.Id), new Claim("RealName", user.F_RealName), new Claim("Email", user.F_Email) }
                        );
                    }
                    else
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "密码不正确，请重新输入！");
                }
                //  }
                else
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "当前账户已经被锁定，请联系管理员！");
            }
            else
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "当前账户不存在！");
        }

        //可以根据自己的需要设置相应的Claim
        private Claim[] GetUserClaims()
        {
            return new Claim[] {
              new   Claim("UserId",1.ToString()),
                new Claim(JwtClaimTypes.Name,"dgq"),
                new Claim(JwtClaimTypes.GivenName,"doraemon"),
                new Claim(JwtClaimTypes.FamilyName,"dongguoqing"),
                new Claim(JwtClaimTypes.Email,"1038467462@qq.com"),
                new Claim(JwtClaimTypes.Role,"admin")
            };
        }
    }
}
