using System;
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
            
            logger.NoEx<string>(() => null, "test");

            System.Console.WriteLine(conext.JsonSerializeObject().JsonToXml());
        }
        
    }

    public class Context
    {
        public string debug { get; set; }    
    }
}