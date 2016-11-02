using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Properties;
using Syncfusion.Windows.Forms;

namespace kBackup.Forms
{
    public partial class Main : MetroForm
    {
        /// <summary>
        /// Required for application initialization.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Handles loading of Main form.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            
        }


        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            if (pnlSideMenu.Width == 50)
            {
                pnlSideMenu.Visible = false;
                pnlSideMenu.Width = 145;
                animMenu.ShowSync(pnlSideMenu);
            }
            else
            {
                //pnlSideMenu.Visible = false;
                //pnlSideMenu.Width = 50;
                animMenu.ShowSync(pnlSideMenu);
            }
        }
    }
}
