using System;
using System.Xml;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using Ionic.Zip;

namespace InfinitiMCLauncher
{
    public partial class FormLauncher : Form
    {
        delegate void SetTextCallback(string text);

        public FormLauncher()
        {
            InitializeComponent();
        }

        internal void CheckRootDirectory()
        {
            WebClient dler = new WebClient();

            if (!Directory.Exists(Directories.MinecraftDir))
            {
                Log.WriteLine("Creating minecraft directory");
                Directory.CreateDirectory(Directories.MinecraftDir);
            }

            if (!Directory.Exists(Directories.LauncherRoot))
            {
                Log.WriteLine("Creating launcher config directory");
                Directory.CreateDirectory(Directories.LauncherRoot);
            }

            if (!Directory.Exists(Directories.ModPackDir) || !Directory.Exists(Directories.VersionsDir) 
                || !Directory.Exists(Directories.LibrariesDir) || !Directory.Exists(Directories.AssetsDir))
            {
                SetStatus("Files are missing and will be downloaded.");
            }
            else
            {
                SetStatus("Ready to play.");
            }      
        }

        internal void CheckMinecraftDirectories()
        {
            WebClient dler = new WebClient();

            if (!Directory.Exists(Directories.VersionsDir))
            {
                Directory.CreateDirectory(Directories.VersionsDir);
                Log.WriteLine("Downloading minecraft jar..");
                SetStatus("Downloading minecraft jar..");
                try
                {
                    dler.DownloadFile(Directories.JarURL, Directories.MinecraftDir + @"\versions.zip");
                }
                catch (WebException ex)
                {
                    Log.WriteException(ex);
                }

                SetStatus("Extracting minecraft jar..");
                ExtractZIP(Directories.MinecraftDir + @"\versions.zip", Directories.MinecraftDir);
                File.Delete(Directories.MinecraftDir + @"\versions.zip");
            }

            if (!Directory.Exists(Directories.LibrariesDir))
            {
                Directory.CreateDirectory(Directories.LibrariesDir);
                Log.WriteLine("Downloading libraries..");
                SetStatus("Downloading minecraft libraries..");
                try
                {
                    dler.DownloadFile(Directories.LibrariesURL, Directories.MinecraftDir + @"\libraries.zip");
                }
                catch (WebException ex)
                {
                    Log.WriteException(ex);
                }

                SetStatus("Extracting minecraft libraries..");
                ExtractZIP(Directories.MinecraftDir + @"\libraries.zip", Directories.LibrariesDir);
                File.Delete(Directories.MinecraftDir + @"\libraries.zip");
            }

            if (!Directory.Exists(Directories.AssetsDir))
            {
                Directory.CreateDirectory(Directories.AssetsDir);
                Log.WriteLine("Downloading assets..");
                SetStatus("Downloading minecraft assets..");
                try
                {
                    dler.DownloadFile(Directories.AssetsURL, Directories.MinecraftDir + @"\assets.zip");
                }
                catch (WebException ex)
                {
                    Log.WriteException(ex);
                }

                SetStatus("Extracting minecraft assets..");
                ExtractZIP(Directories.MinecraftDir + @"\assets.zip", Directories.AssetsDir);
                File.Delete(Directories.MinecraftDir + @"\assets.zip");
            }

            if (!File.Exists(Directories.NativesDir + "lwjgl.dll"))
            {
                Log.WriteLine("Extracting lwjgl windows natives..");
                SetStatus("Extracting lwjgl natives..");
                ExtractZIP(Directories.NativesDir + "lwjgl-platform-2.9.0-natives-windows.jar", Directories.NativesDir);
            }

            dler.Dispose();
        }

        private void CreateConfig()
        {
            Log.WriteLine("Creating default launcher configuration file.");
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            XmlWriter xmlWriter = XmlWriter.Create(Directories.LauncherRoot + @"\config.xml", xmlSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteComment("Launcher configuration file.");
            xmlWriter.WriteStartElement("Launcher");
            xmlWriter.WriteComment("The end of the directory must not end with a \\");
            xmlWriter.WriteElementString("MinecraftRoot", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft-infiniti");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();
            xmlWriter.Close();
        }

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            if(File.Exists(Directories.LauncherRoot + @"\launcher-log.log"))
            {
                File.Delete(Directories.LauncherRoot + @"\launcher-log.log");
            }

            if(!Directory.Exists(Directories.LauncherRoot))
            {
                Log.WriteLine("Creating launcher root directory.");
                Directory.CreateDirectory(Directories.LauncherRoot);
            }

            if (!File.Exists(Directories.LauncherRoot + @"\config.xml"))
            {
                CreateConfig();
            }

            Directories.Build();

            LauncherUpdater.CheckForUpdate();
            CheckRootDirectory();

            if(Properties.Settings.Default.RememberPassword)
            {
                Log.WriteLine("Loading remember me details from file.");
                FileStream fileStream = null;
                StreamReader reader = null;
                string username = "";
                string password = "";
                try
                {
                    fileStream = new FileStream(Directories.LauncherRoot + @"\lastlogin.dat", FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(fileStream);
                    username = reader.ReadLine().Trim();
                    password = Cryption.DecryptString(reader.ReadLine().Trim());
                    check_Remember.Checked = true;
                }
                catch (Exception ex)
                {
                    Log.WriteException(ex);
                }
                finally
                {
                    if(reader != null)
                    {
                        reader.Close();
                    }

                    if(fileStream != null)
                    {
                        fileStream.Close();
                    }
                }

                tb_Username.Text = username;
                tb_Password.Text = password;       
            }
            lbl_Version.Text = "Version: " + Launcher.Version;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            btn_Login.Enabled = false;
            assetsDler.RunWorkerAsync();
        }

        /// <summary>
        /// Extracts zip archives or jar files.
        /// </summary>
        /// <param name="zipFileDir"> Directory of the zip to be extracted.</param>
        /// <param name="extractPath"> Path the zip will be extracted too.</param>
        public static void ExtractZIP(string zipFileDir, string extractPath)
        {
            try
            {
                Log.WriteLine("Extracting zip: " + zipFileDir + "\n to: " + extractPath);
                //ZipFile.ExtractToDirectory(zipFileDir, extractPath); 
                using (ZipFile zip = ZipFile.Read(zipFileDir))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        entry.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting zip archive: " + zipFileDir, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WriteException(ex);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FormJVMSettings formJVM = new FormJVMSettings();
            formJVM.Show();
        }

        private void assetsDler_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CheckMinecraftDirectories();
        }

        private void assetsDler_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //TODO get progress bar working with webclient.
        }

        private void assetsDler_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            SetStatus("Checking modpack..");
            packDler.RunWorkerAsync();
        }

        public void SetStatus(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbl_Status.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lbl_Status.Text = text;
            }
        }

        private void packDler_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if(PackUpdater.CheckForUpdate())
            {
                PackUpdater.UpdatePack();
            }
        }

        private void packDler_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // TODO: Get progress bar to update with mod pack update progress somehow.
        }

        private void packDler_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Log.WriteLine("Attempting to login..");
            SetStatus("Logging in..");
            StreamWriter writer;
            string[] session = LoginEngine.GenerateSession(tb_Username.Text, tb_Password.Text);

            if (session == null)
            {
                Log.WriteLine("null session > bad login from login.minecraft.net");
                btn_Login.Enabled = true;
                SetStatus("Bad login");
                return;
            }
            else
            {
                if (check_Remember.Checked)
                {
                    Log.WriteLine("Importing login details from lastlogin file.");
                    Properties.Settings.Default.RememberPassword = true;
                    writer = new StreamWriter(Directories.LauncherRoot + @"\lastlogin.dat");
                    writer.WriteLine(tb_Username.Text);
                    writer.Write(Cryption.EncryptString(tb_Password.Text));
                    writer.Close();
                }
                else
                {
                    Properties.Settings.Default.RememberPassword = false;
                }

                Properties.Settings.Default.Save();
                Log.WriteLine("Launching Minecraft..");
                LoginEngine.StartMinecraft(session[2], tb_Password.Text, session[3]);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            FormOptions formOptions = new FormOptions();
            formOptions.Show();
        }

        private void link_ReportBug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Crunchy-Nut/InfinitiMCLauncher/issues");
        }

        private void lnkLbl_ChangeLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://infiniti-launcher.crunchyware.net/changelog.txt");
        }
    }
}
