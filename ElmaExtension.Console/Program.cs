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
            
            System.Console.WriteLine("{0} test {1}".Format(100.0000979,DateTime.Now.ToShortDateString()));
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