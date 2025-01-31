using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CodeBlogFitness.BL.Controller
{
    internal class SerializeDataSaver : IDataSaver
    {
        public T Load<T>(string fileName) where T : class
        {
            if (!File.Exists(fileName))
            {
                var defaultObject = default(T);
                Save(fileName, defaultObject);
                return defaultObject;
            }
            string json = File.ReadAllText(fileName);

            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Файл пуст, создаётся новый объект Person");
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(json);
        }

        public void Save(string fileName, object item)
        {
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
