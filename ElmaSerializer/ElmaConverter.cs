using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// ReSharper disable MemberCanBePrivate.Global

namespace ElmaSerializer
{
    public static class ElmaConverter
    {
        #region Json

        public static string JsonSerializeObject<T>(this T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static T JsonDeserializeObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static object JsonDeserializeObject(this string json)
            => JsonDeserializeObject<object>(json);

        public static JObject JsonToObject(this string json)
        {
            return JObject.Parse(json);
        }

        public static string XmlToJson(this string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(doc);
        }

        #endregion

        #region XML

        public static string XmlSerializeObject<T>(this T data)
        {
            var xsSubmit = new XmlSerializer(data.GetType());

            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, data);
                    return sww.ToString();
                }
            }
        }

        public static string JsonToXmlSerializeObject<T>(this T data)
        {
            var json = JsonSerializeObject(data);
            return JsonToXml(json);
        }

        public static T XmlDeserializeObject<T>(this string xml)
        {
            using (var xmlStream = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(xmlStream);
            }
        }

        public static object XmlDeserializeObject(this string xml)
        {
            var json = XmlToJson(xml);
            return JsonToObject(json);
        }

        public static string JsonToXml(this string json, string root = "Root")
        {
            return JsonConvert.DeserializeXNode(json, root).ToString();
        }

        #endregion
    }
}