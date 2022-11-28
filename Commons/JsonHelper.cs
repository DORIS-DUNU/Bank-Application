using BankAppTask.Commons.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BankAppTask.Commons
{
    public class JsonHelper : IJsonHelper
    {
        private readonly string _store = Directory.GetCurrentDirectory() + "/Database";
        public async Task<List<T>> ReadFromJson<T>(string jsonFile)
        {
            var readText = await File.ReadAllTextAsync(_store + jsonFile);

            var result = new List<T>();

            var serializer = new JsonSerializer();

            using (var stringReader = new StringReader(readText))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                jsonReader.SupportMultipleContent = true;

                while (jsonReader.Read())
                {
                    var json = serializer.Deserialize<T>(jsonReader);

                    result.Add(json);
                }
            }

            return result;
        }

        public async Task<bool> UpdateJson<T>(List<T> model, string jsonFile)
        {
            string json = string.Empty;

            foreach (var item in model)
            {
                json += JsonConvert.SerializeObject(item) + Environment.NewLine;
            }
            await File.WriteAllTextAsync(_store + jsonFile, json);
            return true;

        }

        public async Task<bool> WriteToJson<T>(T model, string jsonFile)
        {
            var json = JsonConvert.SerializeObject(model) + Environment.NewLine;
            await File.AppendAllTextAsync(_store + jsonFile, json);
            return true;
        }
    }
}
