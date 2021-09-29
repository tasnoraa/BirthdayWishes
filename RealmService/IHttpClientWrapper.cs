using System.Net.Http;

namespace RealmService
{
    public interface IHttpClientWrapper
    {
        HttpResponseMessage GetAsync(string url);
    }
}