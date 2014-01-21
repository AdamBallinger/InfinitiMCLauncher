using System;
using System.Windows.Forms;

namespace InfinitiMCLauncher
{
    class Driver
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Launcher launcher = new Launcher();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLauncher());
        }
    }
}
