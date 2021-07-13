using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElmaExtension.HttpClient
{
    public class HttpResult
    {
        public HttpResult() { }
        
        public HttpResult(
            string result, 
            HttpStatusCode statusCode, 
            bool isSuccess, 
            Exception exception = null)
        {
            Result = result;
            StatusCode = statusCode;
            Exception = exception;
            IsSuccess = isSuccess;
        }

        public string Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }
        
        public bool HasException => Exception != null;

        public JObject ToJObject()
        {
            var data = Result ?? throw new Exception("Ошибка при десерилизации данных");
            
            return JObject.Parse(data);
        }
        public T JsonToObject<T>() where T : class
        {
            var data = Result ?? throw new Exception("Ошибка при десерилизации данных");
            
            return JsonConvert.DeserializeObject<T>(data);
        }
        public T XmlToObject<T>() where T : class
        {
            var data = Result ?? throw new Exception("Ошибка при десерилизации данных");
            
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(data))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
    }
}