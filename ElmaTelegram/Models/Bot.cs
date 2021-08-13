using ElmaHttpClient.Models;

namespace ElmaTelegram.Models
{
    public interface IBot<T>
    {
        T Options { get; }
        HttpResult SendMessage(string message, string chatId);
    }
}