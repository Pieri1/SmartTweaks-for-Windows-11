using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

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

        public JsonElement? GetJsonItem(string filePath, string alias)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var jsonArray = JsonDocument.Parse(json).RootElement.EnumerateArray();

                foreach (var item in jsonArray)
                {
                    if (item.TryGetProperty("alias", out var aliasProp) && aliasProp.GetString() == alias)
                    {
                        return item;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON: {ex.Message}");
            }

            return null;
        }

        public string GetCmdString(string filePath, string alias, string optState)
        {
            string altOpt = optState.Split('(')[0];
            try
            {
                var json = File.ReadAllText(filePath);
                var jsonArray = JsonDocument.Parse(json).RootElement.EnumerateArray();

                foreach (var item in jsonArray)
                {
                    if (item.TryGetProperty("alias", out var aliasProp) && aliasProp.GetString() == alias)
                    {
                        if (item.TryGetProperty("opts", out var opts))
                        {
                            foreach (var opt in opts.EnumerateArray())
                            {
                                if (opt.TryGetProperty("state", out var state))
                                {
                                    Console.WriteLine("state: " + state.GetString() + " ,opt: " + optState + " ,altopt: " + altOpt);
                                    if (state.GetString().Equals(optState) || state.GetString().Equals(altOpt))
                                    {
                                        if (opt.TryGetProperty("cmd", out var cmd))
                                        {
                                            return cmd.GetString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON: {ex.Message}");
            }

            return null;

        }
    }
}
