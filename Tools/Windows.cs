using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace Capstone.QR.Tools
{
    public static class Windows
    {
        

        static Windows()
        {
            Host = Environment.MachineName;
            User = Environment.UserName;
        }

        public static bool IsServerInstalled()
        {
            bool installed = false;
            using (RegistryKey rk =
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            var displayName = sk.GetValue("DisplayName");

                            if (displayName != null)
                            {
                                if (displayName.ToString().Contains("Microsoft SQL Server"))
                                {
                                    installed = true;
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            return installed;
        }

        public static void ConfigureDirectory()
        {
            bool created = false;
            foreach (string Dir in Dirs)
            {
                if(Directory.Exists(CurrentDir + "/" + Dir))
                {
                    created = true;
                }

                if (created == false)
                {
                    MakeDirectory();
                }
            }
        }

        private static void MakeDirectory()
        {
            foreach (string Dir in Dirs)
            {
                Directory.CreateDirectory(CurrentDir + "/" + Dir);
            }
        }

        public static string Host;
        public static string User;
        private static string CurrentDir = Directory.GetCurrentDirectory();
        private static string[] Dirs = new string[] {"configs","session","temp"};
    }
}
