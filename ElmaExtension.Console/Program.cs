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

namespace ElmaExtension.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context = new Context();

            ElmaMethod(context);
        }

        private static void ElmaMethod(Context context)
        {
            var httpClient = ElmaHttpFactory.Create("https://localhost:5001/WeatherForecast");

            var result = httpClient.Get();

            System.Console.WriteLine(result.StatusCode);
        }
    }

    public class Context
    {
        public string debug { get; set; }
        public string Debug2 { get; set; }
    }
    
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}