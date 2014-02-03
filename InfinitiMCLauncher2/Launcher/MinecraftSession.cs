using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitiMCLauncher2.Launcher
{
    class MinecraftSession
    {
        internal bool valid = false;
        internal string minecraftUsername = string.Empty;
        internal string minecraftPassword = string.Empty;
        internal string minecraftSessionToken = string.Empty;
        internal string minecraftAccessToken = string.Empty;

        public bool Valid
        {
            set { valid = value; }
            get { return valid; }
        }

        public string MinecraftUsername
        {
            set { minecraftUsername = value; }
            get { return minecraftUsername; }
        }

        public string MinecraftPassword
        {
            set { minecraftPassword = value; }
            get { return minecraftPassword; }
        }

        public string MinecraftSessionToken
        {
            set { minecraftSessionToken = value; }
            get { return minecraftSessionToken; }
        }

        public string MinecraftAccessToken
        {
            set { minecraftAccessToken = value; }
            get { return minecraftAccessToken; }
        }
    }
}
