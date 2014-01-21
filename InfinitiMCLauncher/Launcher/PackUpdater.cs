using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Globalization;

namespace InfinitiMCLauncher
{
    class PackUpdater
    {

        internal static Uri ModPackVersionURL = new Uri("http://infiniti-launcher.crunchyware.net/mod-pack/version.txt");
        internal static Uri ForgeLibsURL = new Uri("https://s3.amazonaws.com/Infiniti.Launcher.Download/mod-pack/forgelibs.zip");
        internal static Uri ForgeVersionURL = new Uri("http://infiniti-launcher.crunchyware.net/mod-pack/forge-current.txt");
        internal static Uri ModPackMasterFile = new Uri("http://infiniti-launcher.crunchyware.net/mod-pack/master.txt");
        internal static Uri S3ModsRoot = new Uri("https://s3.amazonaws.com/Infiniti.Launcher.Download/mod-pack/mods/");

        /// <summary>
        /// Check if the mod pack requires an update or not.
        /// </summary>
        /// <returns>True if the pack needs updating. False if it is up to date.</returns>
        public static bool CheckForUpdate()
        {
            WebClient client = new WebClient();
            StreamReader reader = null;
            Version currentVersion = null;
            Version latestVersion = null;

            try
            {
                Log.WriteLine("Checking for mod pack update..");
                // First check if any pack version exists locally.
                if(!File.Exists(Directories.ModPackDir + @"\version\current.txt"))
                {
                    Log.WriteLine("Found no local version of the mod pack. The latest pack will be downloaded now..");
                    return true;
                }
                reader = new StreamReader(Directories.ModPackDir + @"\version\current.txt");
                currentVersion = new Version(reader.ReadLine().Trim());
                latestVersion = new Version(client.DownloadString(ModPackVersionURL).Trim());
            }
            catch (Exception ex)
            {
                Log.WriteException(ex);
                return false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                client.Dispose();
            }

            if (currentVersion < latestVersion)
            {
                Log.WriteLine("Mod pack updated detected!");
                return true;
            }
            else
            {
                Log.WriteLine("Mod pack is up to date!");
                return false;
            }
        }

        private static void UpdateForge()
        {
            WebClient client = new WebClient();
            Log.WriteLine("Checking for old forge jar..");
            if (Directory.Exists(Directories.LibrariesDir + @"\net\minecraftforge"))
            {
                Log.WriteLine("Deleting old forge jar.");
            }
            else
            {
                Log.WriteLine("No old forge jar found.");
            }

            Log.WriteLine("Updating local forge version..");
            if(!Directory.Exists(Directories.ModPackDir + @"\version"))
            {
                Directory.CreateDirectory(Directories.ModPackDir + @"\version");
            }
            client.DownloadFile(ForgeVersionURL, Directories.ModPackDir + @"\version\forge-current.txt");

            Log.WriteLine("Deleting versions directory..");
            Directory.Delete(Directories.MinecraftDir + @"\versions", true);
            FormLauncher form = (FormLauncher)FormLauncher.ActiveForm;
            form.SetStatus("Downloading minecraft jar..");

            Log.WriteLine("Downloading updated minecraft jar..");
            client.DownloadFile(Directories.JarURL, Directories.MinecraftDir + @"\versions.zip");
            FormLauncher.ExtractZIP(Directories.MinecraftDir + @"\versions.zip", Directories.MinecraftDir + @"\");
            form.SetStatus("Downloading latest forge libraries..");

            Log.WriteLine("Downloading forge libraries for latest version..");
            client.DownloadFile(ForgeLibsURL, Directories.LibrariesDir + @"\net\forgelibs.zip");
            form.SetStatus("Extracting latest forge libraries..");
            FormLauncher.ExtractZIP(Directories.LibrariesDir + @"\net\forgelibs.zip", Directories.LibrariesDir + @"\net\");

            client.Dispose();
        }

        /// <summary>
        /// Updates the pack by downloading and decompressing the updates mods and config zip files.
        /// </summary>
        public static void UpdatePack()
        {
            WebClient client = new WebClient();
            StreamReader reader = null;

            // List of latest mods from master. (remote)
            List<string> mods_master = new List<string>();
            // List of the current mods on the client.
            List<string> mods_current = new List<string>();
            // List of urls for the updated mods from master comparison to local.
            List<string> modsToUpdate = new List<string>();
            // List of installed mods to delete before downloading mods from modsToUpdate list.
            List<string> modsToDelete = new List<string>();

            Log.WriteLine("Checking for forge update..");
            if(!File.Exists(Directories.ModPackDir + @"\version\forge-current.txt"))
            {
                Log.WriteLine("Failed to find local forge version file. Will download the latest version of forge now..");
                UpdateForge();
            }
            else
            {
                reader = new StreamReader(Directories.ModPackDir + @"\version\forge-current.txt");
                Version localForgeVersion = new Version(reader.ReadLine());
                Version latestForgeVersion = new Version(client.DownloadString(ForgeVersionURL));
                if(localForgeVersion < latestForgeVersion)
                {
                    Log.WriteLine("Forge update available. Will download..");
                    UpdateForge();
                }
            }

            Log.WriteLine("Downloading mod pack update..");
            try
            {
                FormLauncher form = (FormLauncher)FormLauncher.ActiveForm;

                Log.WriteLine("Downloading configs..");
                form.SetStatus("Downloading configs..");
                client.DownloadFile(Directories.ConfigsURL, Directories.MinecraftDir + @"\config.zip");
                form.SetStatus("Extracting configs..");
                FormLauncher.ExtractZIP(Directories.MinecraftDir + @"\config.zip", Directories.MinecraftDir + @"\");
                File.Delete(Directories.MinecraftDir + @"\config.zip");

                Log.WriteLine("Updating modpack..");
                form.SetStatus("Fetching modpack updates..");

                client.DownloadFile(ModPackMasterFile, Directories.ModPackDir + @"\version\master.txt");

                try
                {
                    reader = new StreamReader(Directories.ModPackDir + @"\version\master.txt");

                    string mod_string = null;
                    while ((mod_string = reader.ReadLine()) != null)
                    {
                        Log.WriteLine("Reading mod from remote: " + mod_string);
                        mods_master.Add(mod_string);
                    }

                    // Gets the installed mods locally.
                    foreach (string file in Directory.EnumerateFiles(Directories.ModPackDir, "*.*", SearchOption.TopDirectoryOnly))
                    {
                        // Filters out the directory C:\ etc to just modname.filetype etc
                        string fileDir = file.Remove(0, Directories.ModPackDir.Length + 1);
                        string[] fileSub = fileDir.Split('~');
                        if(fileSub[0].EndsWith(".jar") || fileSub[0].EndsWith(".zip"))
                        {
                            fileSub[0] = Path.GetFileNameWithoutExtension(fileSub[0]);
                        }     
                        Log.WriteLine("Checking sub: " + fileSub[0]);
                        if(mods_master.Any(str => str.Contains(fileSub[0])))
                        {
                            Log.WriteLine("Found installed mod similar to remote: " + fileDir);
                            if(!mods_master.Contains(fileDir))
                            {
                                Log.WriteLine("Outdated mod: " + fileDir + " will be deleted.");
                                modsToDelete.Add(fileDir);
                            }
                            else
                            {
                                Log.WriteLine("Adding mod: " + fileDir + " to current mods.");
                                mods_current.Add(fileDir);
                            }            
                        }
                        else
                        {
                            Log.WriteLine("Ignoring: " + fileDir);
                            continue;
                        }
                    }

                    Log.WriteLine("==== Comparing installed mods to latest ====");

                    foreach (string mod in mods_master)
                    {
                        string[] subMod = mod.Split('~');
                        if (mods_current.Contains(mod))
                        {
                            Log.WriteLine("Installed mod: " + mod + " is up to date!");
                        }
                        else
                        {
                            if (File.Exists(Directories.ModPackDir + @"\" + subMod[0] + ".jar"))
                            {
                                Log.WriteLine("Outdated local mod: " + subMod[0] + ".jar");
                                Log.WriteLine("Will delete old mod: " + subMod[0] + ".jar");
                                modsToDelete.Add(subMod[0] + ".jar");
                            }
                            else
                            {
                                Log.WriteLine("Missing local mod: " + mod);
                                if(File.Exists(Directories.ModPackDir + @"\" + subMod[0] + ".jar"))
                                {
                                    Log.WriteLine("Will delete old: " + subMod[0]);
                                    modsToDelete.Add(subMod[0] + ".jar");
                                }
                            }
                            modsToUpdate.Add(mod);
                        }
                    }

                    foreach (string mod in modsToUpdate)
                    {
                        form.SetStatus("Downloading mod: " + mod);
                        Log.WriteLine("Downloading mod: " + S3ModsRoot + mod);
                        client.DownloadFile(S3ModsRoot + mod, Directories.ModPackDir + @"\" + mod);
                    }

                    foreach (string mod in modsToDelete)
                    {
                        if (File.Exists(Directories.ModPackDir + @"\" + mod))
                        {
                            Log.WriteLine("Deleting mod file: " + mod);
                            File.Delete(Directories.ModPackDir + @"\" + mod);
                        }
                    }

                    Log.WriteLine("Updating local pack version..");
                    client.DownloadFile(ModPackVersionURL, Directories.ModPackDir + @"\version\current.txt");
                }
                catch (Exception ex)
                {
                    Log.WriteException(ex);
                }
            }
            catch (WebException ex)
            {
                Log.WriteException(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                client.Dispose();
            }
        }

    }
}
