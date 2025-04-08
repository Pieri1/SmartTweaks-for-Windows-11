﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SmartTweaks_For_Windows_11.service
{
    internal class SettingAgent
    {
        public void AppendToPs1File(string content, string filePath)
        {
            try
            {
                File.AppendAllText(filePath, content + Environment.NewLine);
                Console.WriteLine("Content appended to .ps1 file successfully.\nAdded line: " + content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to .ps1 file: {ex.Message}");
            }
        }

        public void ClearPs1File(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing .ps1 file: {ex.Message}");
            }
        }

        public void StartingPs1File(string filePath)
        {
            AppendToPs1File("# Aplica alterações de registro e reinicia o Explorer", filePath);
            AppendToPs1File("Write-Output \"[+] Iniciando aplicação de configurações...\"", filePath);
        }

        public void EndingPs1File(string filePath)
        {
            AppendToPs1File("# Reinício do Explorer", filePath);
            AppendToPs1File("Stop-Process -Name explorer -Force -ErrorAction SilentlyContinue", filePath);
            AppendToPs1File("Start-Sleep -Milliseconds 500", filePath);
            AppendToPs1File("Start-Process explorer.exe", filePath);
            AppendToPs1File("Write-Output \"[+] Explorer reiniciado com sucesso.\"", filePath);
        }
    }
}
