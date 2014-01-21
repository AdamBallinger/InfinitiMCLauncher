using System;
using System.IO;
using System.Diagnostics;

namespace InfinitiMCLauncher
{
    class Directories
    {

        public static readonly string JarURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/versions.zip");
        public static readonly string LibrariesURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/libraries.zip");
        public static readonly string AssetsURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/assets.zip");
        public static readonly string ModPackURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/mod-pack/latest.zip");
        public static readonly string ConfigsURL = ("https://s3.amazonaws.com/Infiniti.Launcher.Download/mod-pack/config.zip");

        private static string minecraftDir = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\.minecraft-infiniti";
        private static string versionsDir = minecraftDir + @"\versions";
        private static string librariesDir = minecraftDir + @"\libraries";
        private static string assetsDir = minecraftDir + @"\assets";
        private static string nativesDir = librariesDir + @"\org\lwjgl\lwjgl\lwjgl-platform\2.9.0\";
        private static string modPackDir = minecraftDir + @"\mods";

        public static readonly string LauncherRoot = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"\.infiniti-launcher";   

        public static void Build()
        {
            MinecraftDir = Configuration.Parse("MinecraftRoot");
            VersionsDir = MinecraftDir + @"\versions";
            LibrariesDir = MinecraftDir + @"\libraries";
            AssetsDir = MinecraftDir + @"\assets";
            NativesDir = LibrariesDir + @"\org\lwjgl\lwjgl\lwjgl-platform\2.9.0\";
            ModPackDir = MinecraftDir + @"\mods";
        }

        public static string MinecraftDir
        {
            get { return minecraftDir; }
            set { minecraftDir = value; }
        }

        public static string VersionsDir
        {
            get { return versionsDir; }
            set { versionsDir = value; }
        }

        public static string LibrariesDir
        {
            get { return librariesDir; }
            set { librariesDir = value; }
        }

        public static string AssetsDir
        {
            get { return assetsDir; }
            set { assetsDir = value; }
        }

        public static string NativesDir
        {
            get { return nativesDir; }
            set { nativesDir = value; }
        }

        public static string ModPackDir
        {
            get { return modPackDir; }
            set { modPackDir = value; }
        }
    }

}
