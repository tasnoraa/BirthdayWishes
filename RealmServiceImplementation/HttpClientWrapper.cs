using System.Net.Http;

namespace RealmService
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;
        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }
        public HttpResponseMessage GetAsync(string url)
        {
            return _httpClient.GetAsync(url).Result;
        }
    }
}