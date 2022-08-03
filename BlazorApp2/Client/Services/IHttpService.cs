using System.Threading.Tasks;
using BlazorApp2.Shared.Helpers;

namespace BlazorApp2.Client.Services
{
    public interface IHttpService
    {
        Task<ResponseDataHelper<object>> PostAsync<T>(string url, T data);
        Task<ResponseDataHelper<TResponse>> PostAsync<T, TResponse>(string url, T data);
        Task<ResponseDataHelper<T>> Get<T>(string url);
    }
}
