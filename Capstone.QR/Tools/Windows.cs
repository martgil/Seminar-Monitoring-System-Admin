using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static bool RememberUser()
        {
            bool auth = false;
            string currentSession = sessionPath + sessionFile;
            if (File.Exists(currentSession))
            {
                using (StreamReader sr = new StreamReader(currentSession))
                {

                    string account = sr.ReadLine();
                    string[] x = account.Split(":".ToCharArray());
                    if (SqlUtils.VerifyAccount(x[0], Cipher.Decrypt(x[1], Cipher.secret)))
                    {
                        auth = true;
                    }

                }
            }
            return auth;
        }

        public static void CreateSession(string username, string password)
        {
            using (StreamWriter sw = new StreamWriter(sessionPath + sessionFile))
            {
                sw.WriteLine(username + ":" + password);
            }
        }

        public static void RemoveSession()
        {
            try
            {
                if (File.Exists(sessionPath + sessionFile))
                {
                    File.Delete(sessionPath + sessionFile);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Session File Cannot Find.");
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
        private static string[] Dirs = {"configs","session","temp"};
        private static string sessionPath = CurrentDir + @"/" + Dirs[1];
        private const string sessionFile = @"/user.session";
    }
}
