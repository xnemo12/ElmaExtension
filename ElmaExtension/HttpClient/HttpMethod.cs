using System.Diagnostics.CodeAnalysis;

namespace ElmaExtension.HttpClient
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}