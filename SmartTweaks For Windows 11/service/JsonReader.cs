using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
                var jsonArray = JsonDocument.Parse(json).RootElement.EnumerateArray();

                foreach (var item in jsonArray)
                {
                    if (item.TryGetProperty("alias", out var alias))
                    {
                        aliases.Add(alias.GetString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON: {ex.Message}");
            }

            return aliases;
        }
    }
}
