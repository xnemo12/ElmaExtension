using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ElmaExtension.HttpClient;
using ElmaExtension.Logger;

namespace ElmaExtension.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context = new Context();

            var logger = new ExceptionLogger(nameof(Main), context);

            var httpClient = new HttpClient.ElmaHttpClient(@"http://192.168.158.11:8080/services/anorhubms/api/anor-hub");
            
            httpClient.AddBearerTokenAuth("asdaddwqweq");
            var result = httpClient.Post("hello");
            
            System.Console.WriteLine(result.Result);
            System.Console.WriteLine(result.Exception);
        }
        
    }

    public class Context
    {
        public string debug { get; set; }    
    }
}