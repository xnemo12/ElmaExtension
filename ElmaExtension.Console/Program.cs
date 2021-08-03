using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            var list = new List<int>
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
            };
            
            System.Console.WriteLine(list.TakeFromIndex(10, 1)
                .Select(x => x.ToString())
                .JoinToString(" - "));
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