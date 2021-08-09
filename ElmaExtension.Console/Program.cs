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
            var httpClient = ElmaHttpFactory.Create("http://192.168.158.11:8080/services/anorhubms/api/anor-hub");

            var result = httpClient.Post();

            System.Console.WriteLine(result.Result);
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