using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Text;

namespace ElmaExtension.HttpClient
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public partial class ElmaHttpClient
    {
        public string Url { get; set; }
        public int TimeOut { get; set; } = 20000;
        public HttpContentType ContentType { get; set; } = HttpContentType.Json;
        public readonly Dictionary<string, string> Headers = new Dictionary<string, string>();
        
        public ElmaHttpClient() { }
        public ElmaHttpClient(string url) => Url = url;

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public static HttpResult BaseHttpRequest(HttpTemplate template,Dictionary<string, string> header)
        {
            var result = new HttpResult();
            
            try
            {
                var client = WebRequest.Create(template.Url);

                client.Method = template.HttpMethod.ToString();
                client.Timeout = template.Timeout;
                client.ContentType = template.HttpContentType.EnumToString();
                
                foreach (var value in header)
                {
                    client.Headers.Add(value.Key,value.Value);
                }

                if (!string.IsNullOrWhiteSpace(template.Body))
                {
                    var body = Encoding.UTF8.GetBytes(template.Body);

                    using (var sendStream = client.GetRequestStream())
                    {
                        sendStream.Write(body, 0, body.Length);
                    }
                }

                var responseClient = (HttpWebResponse) client.GetResponse();

                result.StatusCode = responseClient.StatusCode;
                
                using (var responseStream = responseClient.GetResponseStream())
                {
                    var streamReader = new StreamReader(responseStream, Encoding.UTF8);

                    result.Result = streamReader.ReadToEnd();
                }
                
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        public void AddBearerTokenAuth(string token)
        {
            if(!Headers.TryGetValue("Authorization", out _))
                Headers.Add("Authorization", $"Bearer {token}");
        }
        
        public void AddBasicAuth(string login, string password)
        {
            if(!Headers.TryGetValue("Authorization", out _))
                Headers.Add("Authorization", 
                    $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{login}:{password}"))}");
        }
    }
}