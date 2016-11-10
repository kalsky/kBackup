using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Properties;
using Syncfusion.Windows.Forms;

namespace kBackup.Forms
{
    public partial class frmLogin : MetroForm
    {
        private readonly Requests requests = new Requests();
        private readonly AutoResetEvent doneEvent = new AutoResetEvent(false);

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmbPortal.selectedIndex = 0;
            InitializeApplication();
            //MessageBox.Show(Settings.Default.dataFolder.ToString());

            //ZendeskApi.Domain = txtDomain.Text.Trim();
            //ZendeskApi.Password = txtPassword.Text.Trim();
            //ZendeskApi.Email = txtEmail.Text.Trim();
            //ZendeskApi.Query = "?page=";

            ////Settings.Default.pbAvatar = pbProfile;
            //Settings.Default.Save();
            //Requests.GetUser(ZendeskApi.Email, cmbPortal);


            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////Set properties 
            //ZendeskApi.Domain = txtDomain.Text.Trim();
            //ZendeskApi.Password = txtPassword.Text.Trim();
            //ZendeskApi.Email = txtEmail.Text.Trim();
            //ZendeskApi.Query = "?page=";

            ////Check that a domain was provided by the user.
            //if (ZendeskApi.Domain.Trim() != string.Empty)
            //{
            //    //Validate the users credentials.
            //    if (!Requests.ValidateUser()) return;

            //    //Retrieve all articles and associated images.
            //    if (Requests.GetArticles(cmbPortal))
            //    {
            //        MessageBox.Show(this, @"Backup completed to path: " + ZendeskApi.BackupFolder, @"Backup Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show(this, @"The backup did not complete successfully.", @"Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(this, @"Please enter a domain before continuing.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Requests.GetCollections("http://adwadawaf.awdawa.dwaa");

            ////Set properties 
            //ZendeskApi.Domain = txtDomain.Text.Trim();
            //ZendeskApi.Password = txtPassword.Text.Trim();
            //ZendeskApi.Email = txtEmail.Text.Trim();
            //ZendeskApi.Query = "?page=";

            ////Settings.Default.pbAvatar = pbProfile;
            //Settings.Default.Save();

            ////ZendeskApi.GetUser(ZendeskApi.Email,cmbPortal);

            ////ZendeskApi.Post("","");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Text = @"Connecting...";

            //Settings
            Settings.Default.windowState = WindowState;
            Settings.Default.email = txtEmail.Text.Trim();
            Settings.Default.password = txtPassword.Text.Trim();
            Settings.Default.domain = txtDomain.Text.Trim();
            Settings.Default.Save();

            bgwSyncUser.RunWorkerAsync();
            doneEvent.WaitOne();
            if (!requests.UserValidated) return;

            btnConnect.Text = @"Syncing data...";
            bgwSyncData.RunWorkerAsync();
            doneEvent.WaitOne();

            Hide();
            var mf = new FrmMain();
            mf.Show();
        }

        private void bgwSyncData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (!e.Cancel)
                {

                }
            }
            finally
            {
                doneEvent.Set();
            }

            // check if user can login

            // sync user data
            //  profile pic
            //  profile info

            // sync application data
            //  get help center data
            //  get community data
        }

        private void bgwSyncData_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void bgwSyncData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnConnect.Text = @"Successful!";
        }

        private void bgwSyncUser_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (!e.Cancel)
                {
                    requests.UserValidated = Requests.GetUserData();
                }
            }
            finally
            {
                doneEvent.Set();
            }
        }

        private void bgwSyncUser_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            btnConnect.Text = requests.UserValidated ? @"Connected!" : @"Login Failed!";
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

        private static void InitializeApplication()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\kbackup"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\kbackup");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\kbackup\\user");
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\kbackup\\data");
            }

            Settings.Default.dataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Settings.Default.Save();
        }

        #region UnderlineAnim

        private void txtDomain_Enter(object sender, EventArgs e)
        {
            lnDomain.ForeColor = Color.FromArgb(46, 139, 87);
            lnDomain.Visible = false;
            animUnderline.ShowSync(lnDomain, true);
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            lnEmail.ForeColor = Color.FromArgb(46, 139, 87);
            lnEmail.Visible = false;
            animUnderline.ShowSync(lnEmail, true);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            lnPassword.ForeColor = Color.FromArgb(46, 139, 87);
            lnPassword.Visible = false;
            animUnderline.ShowSync(lnPassword, true);
        }

        private void cmbPortal_Enter(object sender, EventArgs e)
        {
            lnPortal.ForeColor = Color.FromArgb(46, 139, 87);
            lnPortal.Visible = false;
            animUnderline.ShowSync(lnPortal, true);
        }

        private void txtDomain_Leave(object sender, EventArgs e)
        {
            lnDomain.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            lnEmail.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            lnPassword.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void cmbPortal_Leave(object sender, EventArgs e)
        {
            lnPortal.ForeColor = Color.FromArgb(64, 64, 64);
        }

        #endregion
    }
}
