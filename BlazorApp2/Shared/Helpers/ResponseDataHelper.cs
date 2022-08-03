using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Helpers
{
    public class ResponseDataHelper<T>
    {
        public ResponseDataHelper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Success = success;
            Response = response;
            HttpResponse = httpResponseMessage;
        }

        public bool Success { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponse.Content.ReadAsStringAsync();
        }
    }
}
