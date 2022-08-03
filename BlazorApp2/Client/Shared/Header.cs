using System.Threading.Tasks;

namespace BlazorApp2.Client.Shared
{
    public partial class Header
    {
        private async Task Logout()
        {
            await userService.Logout();
            navigationManager.NavigateTo("/Login");
        }
    }
}
