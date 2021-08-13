using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Xml;
using ElmaExtensionMethods;
using ElmaHttpClient;
using ElmaLogger;
using ElmaSerializer;
using ElmaTelegram;

namespace ElmaExtension.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var telegram = new TelegramBot(new TelegramOptions()
            {
                ChatId = "-532658423",
                Token = "1815800309:AAGIgDMEWWCJFc4BNTHuCxWWn_LtZDhlR7Y"
            });

            telegram.SendMessage("sadasdasdsadd");
        }
    }
}