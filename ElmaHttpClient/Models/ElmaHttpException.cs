using System;
using System.Net;

namespace ElmaHttpClient.Models
{
    public class ElmaHttpException : Exception
    {
        public WebExceptionStatus ExceptionStatus { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
    }
}