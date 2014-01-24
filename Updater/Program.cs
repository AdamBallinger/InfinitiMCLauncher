using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Updater
{
    class Program
    {
        internal static string LauncherVersionURL = "http://infiniti-launcher.crunchyware.net/version.txt";
        internal static string LauncherURL = "http://infiniti-launcher.crunchyware.net/InfinitiMCLauncher.exe";
        internal static string AppRuntimeDir = AppDomain.CurrentDomain.BaseDirectory;
        internal static string AppRuntimeParent = Directory.GetParent(AppRuntimeDir).ToString();

        static void Main(string[] args)
        {
            WebClient client = null;
            StreamReader reader = null;

            try
            {
                client = new WebClient();
                reader = new StreamReader(Directory.GetParent(AppRuntimeParent) + @"\current.txt");
                Version latestLauncherVersion = new Version(client.DownloadString(LauncherVersionURL));
                Version currentLauncherVersion = new Version(reader.ReadLine());

                if(currentLauncherVersion < latestLauncherVersion)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Local launcher version: " + currentLauncherVersion);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Latest launcher version: " + latestLauncherVersion);
                    Console.ResetColor();            
                    if(File.Exists(Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe"))
                    {
                        Console.WriteLine("Deleting old launcher: " + Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
                        File.Delete(Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
                        Console.WriteLine("Deleted old launcher executable successfully.");
                    }
                    Console.WriteLine("Downloading latest launcher executable.");
                    client.DownloadFile(LauncherURL, Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Latest launcher downloaded successfully.");
                    Console.ResetColor();
                    Console.WriteLine("Press any key to start the launcher.");
                    Console.ReadKey();
                    Process.Start(Directory.GetParent(AppRuntimeParent) + @"\InfinitiMCLauncher.exe");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Launcher is up to date.");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(client != null)
                {
                    client.Dispose();
                }

                if(reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
        }
    }
}
