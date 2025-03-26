using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SmartTweaks_For_Windows_11.service
{
    internal class JsonReader
    {
        public List<string> GetAliasesFromJson(string filePath)
        {
            var aliases = new List<string>();

            try
            {
                var json = File.ReadAllText(filePath);
                var jsonArray = JArray.Parse(json);

                foreach (var item in jsonArray)
                {
                    var alias = item["alias"]?.ToString();
                    if (!string.IsNullOrEmpty(alias))
                    {
                        aliases.Add(alias);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine($"Error reading JSON: {ex.Message}");
            }

            return aliases;
        }
    }
}
