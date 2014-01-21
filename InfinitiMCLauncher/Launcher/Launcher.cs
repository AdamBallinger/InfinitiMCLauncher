using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace InfinitiMCLauncher
{
    class Launcher
    {
        public static readonly Version Version = new Version("1.25");

        public static void Execute(string args)
        {
            string tmpArgs = "\"" + args + "\"";
            Log.WriteLine("Launch arguments:");
            Log.WriteLine(tmpArgs);

            ProcessStartInfo processInfo = new ProcessStartInfo("cmd", "/c " + tmpArgs);

            if(Properties.Settings.Default.ShowConsole)
            {
                processInfo.CreateNoWindow = false;
            }
            else
            {
                processInfo.CreateNoWindow = true;
            }

            processInfo.UseShellExecute = false;
            processInfo.WindowStyle = ProcessWindowStyle.Normal;
            processInfo.WorkingDirectory = Directories.MinecraftDir;

            Log.WriteLine("Starting minecraft process..");

            try
            {
                Process.Start(processInfo);
                Log.WriteLine("Minecraft process started.");
            }
            catch (Exception ex)
            {
                Log.WriteException(ex);
                Log.WriteLine("Process failed to start.");
            }
            finally
            {
                FormLauncher form = (FormLauncher)FormLauncher.ActiveForm;
                Log.WriteLine("Disposing background workers..");
                form.assetsDler.Dispose();
                form.packDler.Dispose();
                Log.WriteLine("Workers disposed.. Exiting application.");
                Application.Exit();
            }  
        }
    }
}
