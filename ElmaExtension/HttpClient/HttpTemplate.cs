namespace ElmaExtension.HttpClient
{
    public class HttpTemplate
    {
        public string Url { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public int Timeout { get; set; }
        public HttpContentType HttpContentType { get; set; }
        public string Body { get; set; }
    }
}