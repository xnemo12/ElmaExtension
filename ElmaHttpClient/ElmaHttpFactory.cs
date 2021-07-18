using ElmaHttpClient.Contract;

namespace ElmaHttpClient
{
    public static class ElmaHttpFactory
    {
        public static IElmaHttpClient Create()
            => new ElmaHttpClient();

        public static IElmaHttpClient Create(string url)
            => new ElmaHttpClient(url);
    }
}