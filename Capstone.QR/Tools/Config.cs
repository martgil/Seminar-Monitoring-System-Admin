using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.QR.Tools
{
    class Config
    {
        public string _host;
        public string _user;
        public string _password;
        public string _master;
        public string _initCatalog;

        public Config()
        {
            _master = "master";
        }


    }
}
