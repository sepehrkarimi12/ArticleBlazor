using BlazorApp2.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Pages
{
    public partial class Login
    {
        UserDataHelper userDataHelper;
        private bool ShowError;

        [CascadingParameter]
        public Task<AuthenticationState> authenticationState { get; set; }

        protected override void OnInitialized()
        {
            this.userDataHelper = new UserDataHelper();
            this.ShowError = false;
        }

        private async Task LoginUser()
        {
            generateNewToken.Dispose();
            var response = await authRepo.Login(userDataHelper);
            var authentication = await authenticationState;
            if (response.Status)
            {
                generateNewToken.Initiate();
                await userService.Login(response);
                userState.SetUserInfo(authentication.User.Claims.ToList());
                navigationManager.NavigateTo("/");
            }
            else
            {
                this.ShowError = true;
                Console.WriteLine(response.Message);
            }
        }
    }
}
