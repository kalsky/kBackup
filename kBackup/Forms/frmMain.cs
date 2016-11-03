using System;
using System.Collections.Generic;
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
    public partial class frmMain : MetroForm
    {
        /// <summary>
        /// Required for application initialization.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles loading of Main form.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            // sync the data to List<object>

            // load lists into grid based on cat and sect filters
            dgCategories.DataSource = new List<string> {"Category1","Category2","Category3"};

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

        private void btnHelpCenter_Click(object sender, EventArgs e)
        {
            pnlCommunity.Visible = false;
            pnlMigrate.Visible = false;
            pnlSettings.Visible = false;
            pnlHelpCenter.Visible = true;
            pnlHelpCenter.BringToFront();
        }

        private void btnCommunity_Click(object sender, EventArgs e)
        {
            pnlCommunity.Visible = true;
            pnlMigrate.Visible = false;
            pnlSettings.Visible = false;
            pnlHelpCenter.Visible = false;
            pnlCommunity.BringToFront();
        }

        private void btnMigrate_Click(object sender, EventArgs e)
        {
            pnlCommunity.Visible = false;
            pnlMigrate.Visible = true;
            pnlSettings.Visible = false;
            pnlHelpCenter.Visible = false;
            pnlMigrate.BringToFront();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlCommunity.Visible = false;
            pnlMigrate.Visible = false;
            pnlSettings.Visible = true;
            pnlHelpCenter.Visible = false;
            pnlSettings.BringToFront();
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxHandler(object sender, MouseEventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void minHandler(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

    }
}
