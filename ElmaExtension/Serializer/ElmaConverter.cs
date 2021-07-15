using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElmaExtension.Serializer
{
    public static class ElmaConverter
    {
        public static string JsonSerializeObject(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static T JsonDeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static object JsonDeserializeObject(string json)
            => JsonDeserializeObject<object>(json);
        
        public static JObject JsonToObject(string json)
        {
            return JObject.Parse(json);
        }
        
        public static string XmlToJson(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(doc);
        }

        public static string XmlSerializeObject(object data)
        {
            var xsSubmit = new XmlSerializer(data.GetType());

            using(var sww = new StringWriter())
            {
                using(var writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, data);
                    return sww.ToString();
                }
            }
        }

        public static T XmlDeserializeObject<T>(string xml)
        {
            using (var xmlStream = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(xmlStream);
            }
        }

        public static object XmlDeserializeObject(string xml)
            => XmlDeserializeObject<object>(xml);

        public static string JsonToXml(string json, string root = "Root")
        {
            return JsonConvert.DeserializeXNode(json, root).ToString();
        }
    }
}