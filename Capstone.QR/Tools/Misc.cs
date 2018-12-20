using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Capstone.QR.Tools
{
    /// <summary>
    /// Class for options in logo and brand name.
    /// </summary>

    public static class Misc
    { 
        public static string logo = "default";
        public static string brand_name = "default";



        public static string GetLogoPath()
        {
            string logoPath = "";
            var doc = new XmlDocument();
            doc.Load("misc.xml");
            try
            { 
                foreach (XmlNode node in doc.DocumentElement)
                {
                    if (node.Name == "settings")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "LogoPath")
                            {
                                if (child.InnerText != "default")
                                    logoPath = child.InnerText;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return logoPath;
        }

        private static string StatusResolver(int statusCode)
        {
            string resolved = "";
            if (statusCode == -1)
                resolved = "Pending";
            else if (statusCode == 1)
                resolved = "Open";
            else if (statusCode == 0)
                resolved = "Closed";
            else
                resolved = "Unknown";
            return resolved;
        }



        public static string GetBrand()
        {
            string Brand = "";
            var doc = new XmlDocument();
            doc.Load("misc.xml");
            try
            {
                foreach (XmlNode node in doc.DocumentElement)
                {
                    if (node.Name == "settings")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "BrandName")
                            {
                                if (child.InnerText != "default")
                                    Brand = child.InnerText;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return Brand;
        }
        public static string StripColonLeft(string str)
        {
            string moded = "";
            int i = str.IndexOf(":");
            moded = str.Substring(0, i);
            return moded;
        }
        public static string StripColonRight(string str)
        {
            string moded = "";
            int i = str.IndexOf(":");
            moded = str.Substring(i+1,str.Length-(i+1));
            return moded;
        }

        public static Color GetColor()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(255,205,64)); //yellow
            colors.Add(Color.FromArgb(221, 83, 71)); //red
            colors.Add(Color.FromArgb(26, 161, 95)); //green
            colors.Add(Color.FromArgb(255, 102, 51)); //orange
            colors.Add(Color.FromArgb(0, 153, 204)); //blue

            Random random = new Random();
            int i = random.Next(0, 4);
            return colors[i];
        }

        public static string StringToElipsis(string str,int lengthToElipsis)
        {
            string moded = "";
            if (str.Length >= lengthToElipsis)
            {
                moded = str.Substring(0, lengthToElipsis);
                moded += "...";
            }
            else
                moded = str;
            
            return moded;
        }

        public static string To12HourFormat(TimeSpan time)
        {
            string timez = "";
            int hour = time.Hours;

            if (hour <= 12)
                timez = hour + "AM";
            else
                timez = (hour - 12) + "PM";

            return timez;
        }
    }
}
