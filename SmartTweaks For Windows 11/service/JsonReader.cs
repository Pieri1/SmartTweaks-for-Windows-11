using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SmartTweaks_For_Windows_11.service
{
    internal class JsonReader
    {
        public JsonDocument GetJson(string filePath)
        {
            JsonDocument jsonArray = null;

            try
            {
                var json = File.ReadAllText(filePath);
                jsonArray = JsonDocument.Parse(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON: {ex.Message}");
            }

            return jsonArray;
        }
    }
}
