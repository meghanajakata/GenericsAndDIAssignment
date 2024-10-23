using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GenericsAssignment.Implementations
{
    public class Xml
    {
        public static string Serializer<T>(T inputData) where T : class
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, inputData);
                return stringWriter.ToString();
            }
        }

        public static T Deserializer<T>(string xmlData) 
        {
            using(StringReader stringReader = new StringReader(xmlData))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stringReader);
            }

        }
    }
}
