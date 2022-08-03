using BlazorApp2.Shared.Helpers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp2.Client.Services
{
    public class HttpService : IHttpService
    {
        JsonSerializerOptions defaultJsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        private readonly HttpClient _http;
        public HttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDataHelper<object>> PostAsync<T>(string url, T data)
        {
            var dataSerialize = JsonSerializer.Serialize(data);
            var content = new StringContent(dataSerialize, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, content);

            return new ResponseDataHelper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<ResponseDataHelper<TResponse>> PostAsync<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new ResponseDataHelper<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new ResponseDataHelper<TResponse>(default, false, response);
            }
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
        public async Task<ResponseDataHelper<T>> Get<T>(string url)
        {
            var responseHTTP = await _http.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHTTP, defaultJsonSerializerOptions);
                return new ResponseDataHelper<T>(response, true, responseHTTP);
            }
            else
            {
                return new ResponseDataHelper<T>(default, false, responseHTTP);
            }
        }

    }
}
