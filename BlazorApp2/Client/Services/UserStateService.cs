using BlazorApp2.Shared.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlazorApp2.Client.Services
{
    public class UserStateService
    {
        public UserStateDataHelper user { get; set; }
        public UserStateDataHelper GetUserInfo()
        {
            return user;
        }

        public void SetUserInfo(IEnumerable<Claim> claims)
        {
            user = new UserStateDataHelper
            {
                Email = claims.Where(p => p.Type == ClaimTypes.Email).Select(c => c.Value).FirstOrDefault(),
                RoleName = claims.Where(p => p.Type == ClaimTypes.Role).Select(c => c.Value).FirstOrDefault(),
                FirstName = claims.Where(p => p.Type == "FirstName").Select(c => c.Value).FirstOrDefault(),
                LastName = claims.Where(p => p.Type == "LastName").Select(c => c.Value).FirstOrDefault(),
                Id = claims.Where(p => p.Type == "UserId").Select(c => c.Value).FirstOrDefault()
            };
        }
    }
}
