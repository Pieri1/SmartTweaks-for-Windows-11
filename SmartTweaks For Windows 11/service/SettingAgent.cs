using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTweaks_For_Windows_11.service
{
    internal class SettingAgent
    {
        public void AppendToBatFile(string content, string filePath)
        {
            try
            {
                File.AppendAllText(filePath, content + Environment.NewLine);
                Console.WriteLine("Content appended to .bat file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to .bat file: {ex.Message}");
            }
        }
    }
}
