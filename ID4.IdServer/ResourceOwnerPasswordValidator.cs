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
        //private ApiDBContent _context;
        //public ResourceOwnerPasswordValidator(ApiDBContent context)
        //{
        //    this._context = context;
        //}

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //获取数据库中的用户
            //var user = _context.Users.Where(a => a.Email == context.UserName).FirstOrDefault();
         //   Console.WriteLine(user);
           // if (user != null)
           // {
                //根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
                if (context.UserName == "admin@wz.com" && context.Password =="123456")
                {
                    context.Result = new GrantValidationResult(
                       subject: context.UserName,
                       authenticationMethod: "custom",
                       claims: new Claim[] { new Claim("Name", context.UserName), new Claim("UserId", "111"), new Claim("RealName", "董国庆"), new Claim("Email", "1038467462@qq.com") }
                    );
                }
          //  }
            else
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
        }

        //可以根据自己的需要设置相应的Claim
        private Claim[] GetUserClaims()
        {
            return new Claim[] {
                new Claim("UserId",1.ToString()),
                new Claim(JwtClaimTypes.Name,"dgq"),
                new Claim(JwtClaimTypes.GivenName,"doraemon"),
                new Claim(JwtClaimTypes.FamilyName,"dongguoqing"),
                new Claim(JwtClaimTypes.Email,"1038467462@qq.com"),
                new Claim(JwtClaimTypes.Role,"admin")
            };
        }
    }
}
