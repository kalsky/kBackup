using System;
using System.Windows.Forms;
using kBackup.Forms;

namespace kBackup.Classes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bunifu.Framework.License.Authenticate("alpha2twin@gmail.com", "SMyajThtkcHnlxI9ABhfdMFgk7cd6CVTTXMVFZ8HZqw=");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
