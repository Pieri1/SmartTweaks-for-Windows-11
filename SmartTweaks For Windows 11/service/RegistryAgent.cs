using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace SmartTweaks_For_Windows_11.service
{
    internal class RegistryAgent
    {
        public string RegRead(string reg, string key)
        {
            if (!IsCurrentUserValid())
            {
                Console.WriteLine("The current user is not valid.");
                //Dar aviso e fechar app
                return null;
            }

            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(reg))
                {
                    if (registryKey != null)
                    {
                        return registryKey.GetValue(key)?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading registry: {ex.Message}");
            }
            return null;
        }

        public string RegRead(string reg)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\SmartTweaks For Windows 11\data\psfunc\Test-RegistryKeyExist.ps1"));

            string powershell64Path = Environment.ExpandEnvironmentVariables(
                @"%SystemRoot%\SysNative\WindowsPowerShell\v1.0\powershell.exe"
            );

            Process process = new Process();
            process.StartInfo.FileName = powershell64Path;
            process.StartInfo.Arguments = $"-ExecutionPolicy Bypass -NoProfile -File \"{relativePath}\" -Key \"{reg}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            try
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd().Trim();
                string error = process.StandardError.ReadToEnd().Trim();

                process.WaitForExit();

                Console.WriteLine("PS Output: " + output);
                Console.WriteLine("PS Error: " + error);

                if (!string.IsNullOrEmpty(output))
                {
                    return output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return null;
        }

        private bool IsCurrentUserValid()
        {
            //Só funciona para meu PC
            string currentUser = Environment.UserName;
            string expectedUser = "Pieri";

            return string.Equals(currentUser, expectedUser, StringComparison.OrdinalIgnoreCase);
        }

        public void RunPs1File(string filePath)
        {
            try
            {
                string powershell64Path = Environment.ExpandEnvironmentVariables(
                    @"%SystemRoot%\SysNative\WindowsPowerShell\v1.0\powershell.exe"
                );

                Process process = new Process();
                process.StartInfo.FileName = powershell64Path;
                process.StartInfo.Arguments = $"-ExecutionPolicy Bypass -NoProfile -File \"{filePath}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Output: " + output);
                }

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error: " + error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running PowerShell script: {ex.Message}");
            }
        }
    }
}
