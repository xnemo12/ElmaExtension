using System.Diagnostics.CodeAnalysis;

namespace ElmaExtension.HttpClient.Models
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