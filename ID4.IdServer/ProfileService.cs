using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace ID4.IdServer
{
    /// <summary>
    /// IdentityServer默认返回的信息只有sub 即context.UserName 要返回更多的信息需要实现IProfileService接口
    /// </summary>
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var cliams = context.Subject.Claims.ToList();
                context.IssuedClaims = cliams;
            }
            catch
            {

            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
