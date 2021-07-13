using System.Threading.Tasks;

namespace ElmaExtension.HttpClient
{
    public partial class ElmaHttpClient
    {
        #region Get

        public HttpResult Get()
            => Get(Url);
        
        public HttpResult Get(string url)
        {
            var template = new HttpTemplate()
            {
                Url = url,
                HttpMethod = HttpMethod.GET,
                HttpContentType = ContentType,
                Timeout = TimeOut
            };

            return BaseHttpRequest(template, Headers);
        }

        public Task<HttpResult> GetAsync()
            => Task.Factory.StartNew(() => Get());

        public Task<HttpResult> GetAsync(string url)
            => Task.Factory.StartNew(() => Get(url));

        #endregion

        #region Post

        public HttpResult Post(string url, string body)
        {
            var template = new HttpTemplate()
            {
                Url = url,
                HttpMethod = HttpMethod.POST,
                HttpContentType = ContentType,
                Timeout = TimeOut,
                Body = body
            };

            return BaseHttpRequest(template, Headers);
        }

        public HttpResult Post(string body)
            => Post(Url, body);

        public HttpResult Post()
            => Post(Url, null);

        #endregion

        #region Put

        public HttpResult Put(string url, string body)
        {
            var template = new HttpTemplate()
            {
                Url = url,
                HttpMethod = HttpMethod.PUT,
                HttpContentType = ContentType,
                Timeout = TimeOut,
                Body = body
            };

            return BaseHttpRequest(template, Headers);
        }

        public HttpResult Put(string body)
            => Post(Url, body);
        
        public HttpResult Put()
        {
            var template = new HttpTemplate()
            {
                Url = Url,
                HttpMethod = HttpMethod.PUT,
                HttpContentType = ContentType,
                Timeout = TimeOut
            };

            return BaseHttpRequest(template, Headers);
        }

        #endregion
        
        #region Delete

        public HttpResult Delete(string url, string body)
        {
            var template = new HttpTemplate()
            {
                Url = url,
                HttpMethod = HttpMethod.DELETE,
                HttpContentType = ContentType,
                Timeout = TimeOut,
                Body = body
            };

            return BaseHttpRequest(template, Headers);
        }

        public HttpResult Delete(string body)
            => Post(Url, body);

        public Task<HttpResult> DeleteAsync(string url, string body)
            => Task.Factory.StartNew(() => Post(url, body));
        
        public Task<HttpResult> DeleteAsync(string body)
            => Task.Factory.StartNew(() => Post(Url, body));

        #endregion
    }
}