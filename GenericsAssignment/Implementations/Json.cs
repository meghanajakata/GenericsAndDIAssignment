using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GenericsAssignment.Implementations
{
    public class Json
    {
        public string Serializer<T>(T inputData) where T : class
        {
            string jsonData = JsonSerializer.Serialize(inputData);
            return jsonData;
        }

        public T Deserializer<T>(string jsonData) where T : class
        {
            T jsonDeserialized = JsonSerializer.Deserialize<T>(jsonData);
            return jsonDeserialized;
        }
    }
}
