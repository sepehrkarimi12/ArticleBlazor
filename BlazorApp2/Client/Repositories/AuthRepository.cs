using BlazorApp2.Client.Services;
using BlazorApp2.Shared.Helpers;
using System;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpService _httpService;
        private readonly string authUrl = "api/auth";
        public AuthRepository(IHttpService http)
        {
            _httpService = http;
        }
        public async Task<TokenDataHelper> Login(UserDataHelper userData)
        {
            var response = await _httpService.PostAsync<UserDataHelper, TokenDataHelper>($"{authUrl}/login", userData);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}
