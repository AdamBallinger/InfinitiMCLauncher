using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitiMCLauncher2.Utils
{
    class Directories
    {

        public static readonly string JarURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/versions.zip");
        public static readonly string LibrariesURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/libraries.zip");
        public static readonly string AssetsURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/assets.zip");
        public static readonly string ModPackURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/mod-pack/latest.zip");
        public static readonly string ConfigsURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/mod-pack/config.zip");
        public static readonly string LauncherRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.infiniti-launcher";

        private static string minecraftRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft-infiniti";
        private static string versionsDir = minecraftRoot + @"\versions";
        private static string librariesDir = minecraftRoot + @"\libraries";
        private static string assetsDir = minecraftRoot + @"\assets";
        private static string modsDir = minecraftRoot + @"\mods";
        private static string nativesDir = librariesDir + @"\org\lwjgl\lwjgl\lwjgl-platform\2.9.0\";

        public static void Build()
        {
            Logger.WriteLine("Building directories.");
            MinecraftRoot = Configuration.Parse("MinecraftRoot");
            VersionsDir = MinecraftRoot + @"\versions";
            LibrariesDir = MinecraftRoot + @"\libraries";
            AssetsDir = MinecraftRoot + @"\assets";
            ModsDir = MinecraftRoot + @"\mods";
            NativesDir = LibrariesDir + @"\org\lwjgl\lwjgl\lwjgl-platform\2.9.0\";
        }

        public static string MinecraftRoot
        {
            set { minecraftRoot = value; }
            get { return minecraftRoot; }
        }

        public static string VersionsDir
        {
            set { versionsDir = value; }
            get { return versionsDir; }
        }

        public static string LibrariesDir
        {
            set { librariesDir = value; }
            get { return librariesDir; }
        }

        public static string AssetsDir
        {
            set { assetsDir = value; }
            get { return assetsDir; }
        }

        public static string ModsDir
        {
            set { modsDir = value; }
            get { return modsDir; }
        }

        public static string NativesDir
        {
            set { nativesDir = value; }
            get { return nativesDir; }
        }
    }
}
