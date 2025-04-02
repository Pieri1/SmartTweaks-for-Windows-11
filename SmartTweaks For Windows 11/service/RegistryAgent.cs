using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

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
            if (!IsCurrentUserValid())
            {
                Console.WriteLine("The current user is not valid.");
                // Fechar app
                return null;
            }

            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(reg))
                {
                    if (registryKey != null)
                    {
                        return registryKey.GetValue(null)?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading registry: {ex.Message}");
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
    }
}
