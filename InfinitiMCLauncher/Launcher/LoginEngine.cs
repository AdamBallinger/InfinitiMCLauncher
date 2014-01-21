using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace InfinitiMCLauncher
{
    class LoginEngine
    {
        /// <summary>
        /// Attempts to create a login session with the given credentials.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>string array with session data or null if credentials are invalid / servers down</returns>
        public static string[] GenerateSession(string username, string password)
        {
            string[] mcSession = GET(string.Format("https://login.minecraft.net?user={0}&password={1}&version=13", username, password)).Split(':');
            
            if(mcSession[0].ToUpper().Equals("BAD LOGIN"))
            {
                return null;
            }
            else
            {
                //Launcher.SaveUserDetails(username, password);
                return mcSession;
            }
        }

        /// <summary>
        /// Starts minecraft with the given username and password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>If minecraft launches successfully or not.</returns>
        public static bool StartMinecraft(string username, string password, string sessionToken)
        {
            WebClient dler = new WebClient();
            string args = "";
 
            LibraryIdentifier libIdentifier = LibraryIdentifier.Identify(Directories.VersionsDir + @"\1.6.4-Forge\1.6.4-Forge.json");

            args += "java -Djava.library.path=" + Directories.NativesDir + " -cp ";
            args += Directories.VersionsDir + @"\1.6.4-Forge\1.6.4-Forge.jar;";

            foreach(LibraryIdentifier.Lib lib in libIdentifier.libraries)
            {
                string[] semiCSplit = lib.name.Split(':');
                string jarName = semiCSplit[semiCSplit.Length - 2] + "-" + semiCSplit[semiCSplit.Length - 1] + ".jar";
                if(GetLibrary(jarName) != null && !jarName.Contains("debug"))
                {
                    Log.WriteLine("Detected library: " + jarName);
                    args += GetLibrary(jarName) + ";";
                }
            }

            args += " -Xms" + Properties.Settings.Default.MinMem + "M";
            args += " -Xmx" + Properties.Settings.Default.MaxMem + "M";
            args += " " + Properties.Settings.Default.JVMArgs;

            args += " net.minecraft.launchwrapper.Launch ";
            args += " --tweakClass cpw.mods.fml.common.launcher.FMLTweaker ";

            args += " -u=" + username;
            args += " --session " + sessionToken;
            args += " --version 1.6.4-Forge";
            args += " --gameDir {0}";
            args += " --assetsDir {0}\\assets\\virtual\\legacy\\";
            args = string.Format(args, Directories.MinecraftDir);

            Launcher.Execute(args);
            return true;
        }

        /// <summary>
        /// Gets the library from the libraries directory.
        /// </summary>
        /// <param name="jarFile"> Library jar file name.</param>
        /// <returns>string representing the name of the library jar.</returns>
        public static string GetLibrary(string jarFile)
        {
            string[] libraryPaths = Directory.GetFiles(Directories.LibrariesDir + @"\", "*.jar", SearchOption.AllDirectories);
            
            if(jarFile.Contains("platform"))
            {
                jarFile = jarFile.Substring(0, jarFile.Length - 4) + "-natives-windows" + ".jar";
            }

            foreach(string lib in libraryPaths)
            {
                if(lib.Contains(jarFile) && !jarFile.Contains("debug"))
                {
                    return lib;
                }
            }

            Log.WriteLine("Couldn't find library: " + jarFile);
            return null;
        }

        /// <summary>
        /// Performs an HTTP GET request to the given url. (Login session).
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Server response</returns>
        private static string GET(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                Log.WriteException(ex);
                MessageBox.Show("Failed to get a response from the login server. Servers are most likely down.", "Invalid web response", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            StreamReader stringResponse = new StreamReader(response.GetResponseStream());
            return stringResponse.ReadToEnd().Trim();
        }

    }
}
