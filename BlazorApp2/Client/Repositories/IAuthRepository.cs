using System.Threading.Tasks;
using BlazorApp2.Shared.Helpers;

namespace BlazorApp2.Client.Repositories
{
    public interface IAuthRepository
    {
        Task<TokenDataHelper> Login(UserDataHelper userDataHelper);
    }
}
