using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Properties;
using Quartz.Util;
using Syncfusion.Windows.Forms;

namespace kBackup.Forms
{
    public partial class FrmLogin : MetroForm
    {
        private readonly Requests _requests = new Requests();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Mimic form AcceptButton property. 
            //BunifuControls currently don't implement IButtonControl required.
            KeyDown += ConnectOnEnterClicked;
            txtDomain.KeyDown += ConnectOnEnterClicked;
            txtEmail.KeyDown += ConnectOnEnterClicked;
            txtPassword.KeyDown += ConnectOnEnterClicked;
            btnConnect.KeyDown += ConnectOnEnterClicked;

            swRememberMe.KeyDown += RemeberMeOnEnterClicked;

            cmbPortal.selectedIndex = 0;
            InitializeApplication();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // validate user exists in application
            if (!CheckCompletedFields()) return;
            txtError.Text = string.Empty;
            txtError.Visible = false;
            btnConnect.Text = @"Connecting...";

            #region Settings

            Settings.Default.windowState = WindowState;
            Settings.Default.email = txtEmail.Text.Trim();
            Settings.Default.password = txtPassword.Text.Trim();
            Settings.Default.domain = txtDomain.Text.Trim();
            Settings.Default.Save();

            #endregion

            #region User Data

            //var userValidated = await _requests.GetUserData();
            //if (!userValidated)
            //{
            //    btnConnect.DisabledColor = Color.FromArgb(215, 83, 86);
            //    btnConnect.Enabled = false;
            //    txtError.Text = Requests.ErrorMessage;
            //    txtError.Visible = true;
            //    btnConnect.Text = @"Login Failed!";
            //    btnConnect.Activecolor = Color.FromArgb(215, 83, 86);
            //    btnConnect.BackColor = Color.FromArgb(215, 83, 86);
            //    btnConnect.OnHovercolor = Color.FromArgb(215, 83, 86);
            //    if (txtError.Text.Contains("does not exist"))
            //    {
            //        lnDomain.ForeColor = Color.FromArgb(215, 83, 86);
            //    }
            //    else
            //    {
            //        lnEmail.ForeColor = Color.FromArgb(215, 83, 86);
            //        lnPassword.ForeColor = Color.FromArgb(215, 83, 86);
            //    }

            //    tmrButtonColor.Start();
            //    Requests.ErrorOccurred = false;
            //    return;
            //}

            #endregion

            #region Help Center Data

            var catData = await _requests.GetCategoryData();
            var sectData = await _requests.GetSectionData();
            //var artData = await _requests.GetArticleData();
            //var artCommentData

            #endregion

            #region ErrorCheck

            ErrorCheck();

            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConnectOnEnterClicked(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnConnect_Click(this, null);
            e.Handled = true;
        }

        private void RemeberMeOnEnterClicked(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            swRememberMe.Value = !swRememberMe.Value;
            e.Handled = true;
        }

        private void maxHandler(object sender, MouseEventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void minHandler(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void InitializeApplication()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Settings.Default.dataFolder = appDataPath;

            if (!Directory.Exists(appDataPath + "\\kbackup"))
            {
                Directory.CreateDirectory(appDataPath + "\\kbackup");
            }

            if (!Directory.Exists(appDataPath + "\\kbackup\\user"))
            {
                Directory.CreateDirectory(appDataPath + "\\kbackup\\user");
            }

            if (!Directory.Exists(appDataPath + "\\kbackup\\data"))
            {
                Directory.CreateDirectory(appDataPath + "\\kbackup\\data");
            }

            if (!Directory.Exists(appDataPath + "\\kbackup\\data\\json"))
            {
                Directory.CreateDirectory(appDataPath + "\\kbackup\\data\\json");
            }

            if (Settings.Default.rememberMe)
            {
                swRememberMe.Value = Settings.Default.rememberMe;
                txtDomain.Text = Settings.Default.domain;
                txtEmail.Text = Settings.Default.email;
                txtPassword.Text = Settings.Default.password;
            }

            Settings.Default.Save();
        }

        private bool CheckCompletedFields()
        {
            var result = true;
            if (txtDomain.Text.Trim() == string.Empty)
            {
                lnDomain.ForeColor = Color.FromArgb(215, 83, 86);
                result = false;
            }

            if (txtEmail.Text.Trim() == string.Empty)
            {
                lnEmail.ForeColor = Color.FromArgb(215, 83, 86);
                result = false;
            }

            if (txtPassword.Text.Trim() == string.Empty)
            {
                lnPassword.ForeColor = Color.FromArgb(215, 83, 86);
                result = false;
            }
            return result;
        }

        private void ErrorCheck()
        {
            if (Requests.ErrorOccurred)
            {
                txtError.Text = Requests.ErrorMessage;
                txtError.Visible = true;
            }
            else
            {
                btnConnect.Text = @"Connected!";
                tmrLoginSuccessful.Start();
            }
        }

        private void LoginSuccessful()
        {
            Hide();

            if (!swRememberMe.Value)
            {
                Settings.Default.domain = string.Empty;
                Settings.Default.email = string.Empty;
                Settings.Default.password = string.Empty;
            }

            Settings.Default.rememberMe = swRememberMe.Value;
            Settings.Default.Save();

            var mf = new FrmMain();
            mf.Show();
        }

        private void tmrButtonColor_Tick(object sender, EventArgs e)
        {
            btnConnect.Text = @"Connect";
            btnConnect.Activecolor = Color.FromArgb(46, 139, 87);
            btnConnect.BackColor = Color.FromArgb(46, 139, 87);
            btnConnect.OnHovercolor = Color.FromArgb(46, 139, 87);
            btnConnect.Enabled = true;
            tmrButtonColor.Stop();
        }

        private void tmrLoginSuccessful_Tick(object sender, EventArgs e)
        {
            LoginSuccessful();
            tmrLoginSuccessful.Stop();
        }

        private void txtBoxes_TextChanged(object sender, EventArgs e)
        {
            txtError.Text = string.Empty;
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