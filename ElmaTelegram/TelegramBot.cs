using System;
using System.Text.Encodings.Web;
using ElmaHttpClient;
using ElmaHttpClient.Models;
using ElmaTelegram.Models;

namespace ElmaTelegram
{
    public class TelegramBot : IBot<TelegramOptions>
    {
        public TelegramBot(TelegramOptions options)
        {
            Options = options;
        }

        public TelegramOptions Options { get; }
        public HttpResult SendMessage(string message, string chatId = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new NullReferenceException("message пустые для отправки");

            var request =
                "https://api.telegram.org" +
                $"/bot{Options.Token}" +
                $"/sendMessage?chat_id={chatId ?? Options.ChatId}" +
                $"&text={UrlEncode(message)}";
            
            var client = ElmaHttpFactory.Create(request);

            return client.Get();
        }

        public static string UrlEncode(string str)
            => UrlEncoder.Create().Encode(str);
    }

    public struct TelegramOptions
    {
        public string Token { get; set; }
        public string ChatId { get; set; }
    }
}