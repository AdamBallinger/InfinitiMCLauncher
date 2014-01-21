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
    public partial class FormJVMSettings : Form
    {
        public FormJVMSettings()
        {
            InitializeComponent();
        }

        private void FormJVMSettings_Load(object sender, EventArgs e)
        {
            tb_MinMem.Text = Properties.Settings.Default.MinMem.ToString();
            tb_MaxMem.Text = Properties.Settings.Default.MaxMem.ToString();
            tb_Args.Text = Properties.Settings.Default.JVMArgs;
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinMem = int.Parse(tb_MinMem.Text);
            Properties.Settings.Default.MaxMem = int.Parse(tb_MaxMem.Text);
            Properties.Settings.Default.JVMArgs = tb_Args.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
