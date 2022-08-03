using BlazorApp2.Shared.Helpers;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Services
{
    public interface IUserAuthService
    {
        Task Login(TokenDataHelper tokenData);
        Task Logout();
        Task<bool> CheckToken();
        Task CleanUp();
    }
}
