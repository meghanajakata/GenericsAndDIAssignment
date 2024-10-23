using GenericsAssignment.Implementations;
using GenericsAssignment.Models;

namespace GenericsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Person person = new Person() { FirstName = "Sunil", LastName = "Sharma", Age = 30 };
            string xmlData = Xml.Serializer(person);
            Console.WriteLine("Serialized XML Data :\n" + xmlData);
            Person xmlDeserialized = Xml.Deserializer<Person>(xmlData);
            Console.WriteLine("Deserialized XML Data :\n" + xmlDeserialized);



        }
    }
}
