using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CodeBlogFitness.BL.Controller
{
    internal class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var fileName = typeof(T).Name;
            if (!File.Exists(fileName))
            {
                var defaultObject = new List<T>();
                Save(defaultObject);
                return defaultObject;
            }
            string json = File.ReadAllText(fileName);

            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Файл пуст, создаётся новый объект Person");
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void Save<T>(List<T> item) where T : class
        {
            var fileName = typeof(T).Name;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string json = JsonSerializer.Serialize(item, options);
            File.WriteAllText(fileName, json);
        }
    }
}
