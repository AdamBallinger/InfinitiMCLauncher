using System;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace Updater
{
    class Program
    {
        internal static string LauncherURL = "http://infiniti-launcher.crunchyware.net/InfinitiMCLauncher.exe";
        internal static string AppRuntimeDir = AppDomain.CurrentDomain.BaseDirectory;
        internal static string AppRuntimeParent = Directory.GetParent(AppRuntimeDir).ToString();

        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            StreamReader reader = new StreamReader(Directory.GetParent(AppRuntimeParent) + @"\current.txt");
            Version currentVersion = new Version(reader.ReadLine());
            reader.Close();

            Version latestVersion = new Version(Encoding.UTF8.GetString(client.DownloadData("http://infiniti-launcher.crunchyware.net/version.txt")).Replace(",", CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator));

            if(latestVersion > currentVersion)
            {
                Console.WriteLine("Updating launcher please wait..");
                Console.WriteLine("AppRuntimeDir: " + AppRuntimeDir);
                Console.WriteLine("AppRuntimeParent: " + AppRuntimeParent);

                if (File.Exists(Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe"))
                {
                    File.Delete(Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
                    Console.WriteLine("Deleting File: " + (Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe"));
                }

                client.DownloadFile(LauncherURL, Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
                Console.WriteLine("Update finished. Press any key to open the launcher.");
                Process.Start(Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
            }
            else
            {
                Console.WriteLine("The launcher is already up-to-date.");
                Console.ReadKey();
            }
        }
    }
}
