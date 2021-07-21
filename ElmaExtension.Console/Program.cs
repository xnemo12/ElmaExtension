using System;
using System.Collections.Generic;
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
            var list = new List<string>
            {
                "1",
                "2",
                "3",
                "4"
            }.Random();
            
            System.Console.WriteLine(list.JoinToString(" - "));
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