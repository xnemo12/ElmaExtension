using System;
using ElmaHttpClient;
using ElmaLogger;
using ElmaSerializer;

namespace ElmaExtension.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var conext = new Context();

            var logger = LoggerFactory.Create("main", conext);

            var user = new User {username = "user", password = "user"};
            
            var client = ElmaHttpFactory.Create("http://192.168.158.11:8080/auth/login");

            var result = client.Post(user.JsonSerializeObject());

            logger.NoEx(() => throw new Exception("test"));
            logger.NoEx(() => throw new Exception("test"));

            System.Console.WriteLine(conext.debug);
        }
        
    }

    public class Context
    {
        public string debug { get; set; }    
    }
    
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}