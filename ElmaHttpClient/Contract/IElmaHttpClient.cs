using System.Threading.Tasks;
using ElmaHttpClient.Models;
// ReSharper disable InconsistentNaming

namespace ElmaHttpClient.Contract
{
    public interface IElmaHttpClient
    {
        string Url { get; set; }
        int TimeOut { get; set; }
        HttpContentType ContentType { get; set; }
        void AddJWTAuth(string token);
        void AddBasicAuth(string login, string password);
        HttpResult Get();
        HttpResult Get(string url);
        Task<HttpResult> GetAsync();
        Task<HttpResult> GetAsync(string url);
        HttpResult Post(string url, string body);
        HttpResult Post(string body);
        HttpResult Post();
        HttpResult Put(string url, string body);
        HttpResult Put(string body);
        HttpResult Put();
        HttpResult Delete(string url, string body);
        HttpResult Delete(string body);
    }
}