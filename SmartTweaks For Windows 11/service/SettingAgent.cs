using System;
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

        public void SavePs1File(string tempPath)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Save configuration file";
                saveDialog.FileName = "MyConfig.ps1";
                saveDialog.Filter = "PowerShell Script (*.ps1)|*.ps1|All files (*.*)|*.*";
                saveDialog.DefaultExt = "ps1";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveDialog.FileName;

                    System.IO.File.Copy(tempPath, targetPath, true);

                    MessageBox.Show("Arquivo salvo em:\n" + targetPath, "Sucesso");
                }
            }
        }

        public void BackupPs1File(string tempPath, string targetPath)
        {
            System.IO.File.Copy(tempPath, targetPath, true);
        }

        public string[] ReadPs1File()
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Open configuration file";
                openDialog.Filter = "PowerShell Script (*.ps1)|*.ps1|All files (*.*)|*.*";
                openDialog.DefaultExt = "ps1";
                openDialog.CheckFileExists = true;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openDialog.FileName;

                    MessageBox.Show("Arquivo selecionado:\n" + selectedPath, "Sucesso");

                    var scriptLines = File.ReadAllLines(selectedPath);
                    return scriptLines;
                }
            }
            return null;
        }
    }
}
