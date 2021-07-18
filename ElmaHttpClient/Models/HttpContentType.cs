using System;

namespace ElmaHttpClient.Models
{
    public enum HttpContentType
    {
        Json, // application/json
        Xml, // application/xml
        String, // text/plain
        Html, // text/html
    }

    public static class HttpContentTypeExtension
    {
        public static string EnumToString(this HttpContentType data)
        {
            switch (data)
            {
                case HttpContentType.Json:
                    return "application/json";
                case HttpContentType.Xml:
                    return "application/xml";
                case HttpContentType.String:
                    return "text/plain";
                case HttpContentType.Html:
                    return "text/html";
                default:
                    throw new ArgumentOutOfRangeException(nameof(data), data, null);
            }
        }
    }
    
}