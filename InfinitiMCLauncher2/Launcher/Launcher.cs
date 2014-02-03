using System;
using System.Diagnostics;

using InfinitiMCLauncher2.Utils;
using System.Windows.Forms;

namespace InfinitiMCLauncher2.Launcher
{
    class Launcher
    {

        public static readonly Version LauncherVersion = new Version("0.1.0");

        public void StartProcess(string args)
        {
            // Surround args in "" to support spaces in directories.
            string cmdArgs = "\"" + args + "\"";

            ProcessStartInfo processInfo = new ProcessStartInfo("cmd", "/c " + cmdArgs);

            if(Configuration.Parse("ShowConsole") == "true")
            {
                processInfo.CreateNoWindow = false;
            }
            else
            {
                processInfo.CreateNoWindow = true;
            }

            processInfo.UseShellExecute = false;
            processInfo.WindowStyle = ProcessWindowStyle.Normal;
            processInfo.WorkingDirectory = Directories.MinecraftRoot;

            Logger.WriteLine("Starting minecraft process.");
            Process.Start(processInfo);

            //TODO: Add form bg worker disposal.
            Application.Exit();
        }

    }
}
