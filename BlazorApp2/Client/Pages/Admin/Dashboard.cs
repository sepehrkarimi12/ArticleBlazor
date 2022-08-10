using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Pages.Admin
{
    public partial class Dashboard
    {
        private AuthenticationState authState { get; set; }
        private List<Claim> claims { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);
            this.authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            this.claims = this.authState.User.Claims.ToList();
        }
    }
}