using ElmaExtension.HttpClient.Contract;

namespace ElmaExtension.HttpClient
{
    public static class ElmaHttpFactory
    {
        public static IElmaHttpClient Create()
            => new ElmaHttpClient();

        public static IElmaHttpClient Create(string url)
            => new ElmaHttpClient(url);
    }
}