using System;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace InfinitiMCLauncher
{
    class LauncherUpdater
    {

        internal static string UpdateCheckURL = "http://infiniti-launcher.crunchyware.net/version.txt";
        internal static string LauncherUpdaterURL = "http://infiniti-launcher.crunchyware.net/Updater.exe";

        public static void CheckForUpdate()
        {
            StreamWriter writer = new StreamWriter("current.txt");
            writer.Write(Launcher.Version);
            writer.Close();

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            Version latestVersion = null;
            try
            {
                latestVersion = new Version(client.DownloadString(UpdateCheckURL).Trim());
            }
            catch (FormatException e)
            {
                Log.WriteLine(e.Message);
                Log.WriteLine("Server returned: " + client.DownloadString(UpdateCheckURL).Trim());
            }

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\update"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\update");
            }

            if(latestVersion > Launcher.Version)
            {
                Log.WriteLine("Found an updated version. Current: " + Launcher.Version.ToString() + "   Latest: " + latestVersion.ToString());
                Log.WriteLine("Waiting for user..");

                if(MessageBox.Show("Update available. Would you like to update?\nCurrent: " + Launcher.Version + "\nLatest: " + latestVersion, "Update Found",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Log.WriteLine("Downloading updater..");
                    client.DownloadFile(LauncherUpdaterURL, AppDomain.CurrentDomain.BaseDirectory + @"\update\Updater.exe");
                    client.Dispose();
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\update\Updater.exe");
                    Environment.Exit(0);
                }
                else
                {
                    Log.WriteLine("Update cancelled.");
                }
            }
            else
            {
                Log.WriteLine("Launcher is up-to-date.");
            }
        }

    }
}
