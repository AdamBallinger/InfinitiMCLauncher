using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfinitiMCLauncher
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            tb_McRoot.Text = Configuration.Parse("MinecraftRoot");
            cb_Console.Checked = Properties.Settings.Default.ShowConsole;
        }

        private void btn_Directory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog();

            if(result == DialogResult.OK)
            {
                tb_McRoot.Text = folderBrowser.SelectedPath.ToString();
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if(!Configuration.Parse("MinecraftRoot").Equals(tb_McRoot.Text))
            {
                Configuration.Set("MinecraftRoot", tb_McRoot.Text);
                MessageBox.Show("The launcher must be restarted for these changes to take effect.", "Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }        
            Properties.Settings.Default.ShowConsole = cb_Console.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
