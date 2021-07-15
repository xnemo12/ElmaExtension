using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElmaExtension.HttpClient;
using ElmaExtension.Logger;
using ElmaExtension.Serializer;

namespace ElmaExtension.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var xml = File.ReadAllText("test.xml");
            var json = File.ReadAllText("test.json");
            
            dynamic qqq;

            object xmlObj = ElmaConverter.XmlDeserializeObject<dynamic>(xml);

            System.Console.WriteLine(string.Join("\r\n", xmlObj.GetType().GetProperties()
                .Select(x => $"name - {x.Name} - value - {x.GetValue(xmlObj, new object[]{})}")));
        }
        
    }
}