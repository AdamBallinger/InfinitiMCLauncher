using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using InfinitiMCLauncher2.Utils;
using System.ComponentModel;
using InfinitiMCLauncher2.Launcher;

namespace InfinitiMCLauncher2
{
    public partial class FormLauncher : Form
    {
        delegate void SetTextCallback(string text);

        private MinecraftLogin minecraftLogin = null;

        public FormLauncher()
        {
            InitializeComponent();
        }

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            if(File.Exists(Directories.LauncherRoot + @"\launcher-log.log"))
                File.Delete(Directories.LauncherRoot + @"\launcher-log.log");
            Configuration.Check();
            btnPlay.Enabled = false;
            lblVersion.Text = "Launcher version: " + Launcher.Launcher.LauncherVersion.ToString();
            tbChangeLog.Text = Downloader.DownloadString(new Uri("http://infiniti-launcher.crunchyware.net/changelog.txt"));

            if(Configuration.Parse("RememberLogin") == "true")
            {
                if(!File.Exists(Directories.LauncherRoot + @"\lastlogin.dat"))
                    Logger.WriteLine("lastlogin.dat file does not exist.");
                else
                {
                    cbRemember.Checked = true;
                    StreamReader reader = new StreamReader(Directories.LauncherRoot + @"\lastlogin.dat");
                    string decUsername = Cryption.DecryptString(reader.ReadLine()).Trim();
                    string decPassword = Cryption.DecryptString(reader.ReadLine()).Trim();
                    reader.Close();
                    tbUsername.Text = decUsername;
                    tbPassword.Text = decPassword;
                }     
            }
        }

        private void SaveUserCredentials()
        {
            StreamWriter writer = new StreamWriter(Directories.LauncherRoot + @"\lastlogin.dat");
            string encUsername = Cryption.EncryptString(tbUsername.Text);
            string encPassword = Cryption.EncryptString(tbPassword.Text);
            writer.WriteLine(encUsername);
            writer.WriteLine(encPassword);
            writer.Close();
            Configuration.Set("RememberLogin", "true");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetStatus("Logging in.");
            if(minecraftLogin == null)
                minecraftLogin = new MinecraftLogin();
            minecraftLogin.CreateLegacyLoginSession(tbUsername.Text, tbPassword.Text);
            if(!minecraftLogin.Session.Valid)
                SetStatus("Bad login.");
            else
            {
                if (cbRemember.Checked)
                {
                    Logger.WriteLine("Saving login details.");
                    SaveUserCredentials();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDownload.Value += e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void SetStatus(string status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                this.lblStatus.Text = status;
            }
        }
    }
}
