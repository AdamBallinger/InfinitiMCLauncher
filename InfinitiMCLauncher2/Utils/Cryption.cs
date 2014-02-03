using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitiMCLauncher2.Utils
{
    class Cryption
    {
        /// <summary>
        /// Encrypt a string with a basic custom algorithm.
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns>Encrypted version of the passed in string.</returns>
        public static string EncryptString(string rawString)
        {
            string encString = "";

            foreach (char c in rawString)
            {
                encString += "" + Convert.ToChar(((int)c * 32));
            }

            return encString;
        }

        /// <summary>
        /// Decrypt an encrypted string with the same algorithm.
        /// </summary>
        /// <param name="encString"></param>
        /// <returns>Decrypted version of an encrypted string.</returns>
        public static string DecryptString(string encString)
        {
            string decString = "";

            foreach (char c in encString)
            {
                decString += "" + Convert.ToChar(((int)c / 32));
            }

            return decString;
        }
    }
}
