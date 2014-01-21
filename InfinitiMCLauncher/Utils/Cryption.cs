using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitiMCLauncher
{
    class Cryption
    {

        public static string EncryptString(string rawString)
        {
            string encString = "";

            foreach (char c in rawString)
            {
                encString += "" + Convert.ToChar(((int)c * 31));
            }

            return encString;
        }

        public static string DecryptString(string encString)
        {
            string decString = "";

            foreach (char c in encString)
            {
                decString += "" + Convert.ToChar(((int)c / 31));
            }

            return decString;
        }

    }
}
