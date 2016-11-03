using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Properties;
using Syncfusion.Windows.Forms;

namespace kBackup.Forms
{
    public partial class frmLogin : MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmbPortal.selectedIndex = 0;
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

            //Settings.Default.windowState = WindowState;
            Settings.Default.Save();
            Hide();

            Task task = new Task(StartSync);
            task.Start();
            task.Wait();
            Console.ReadLine();

            var mf = new frmMain();
            mf.Show();
        }

        static async void StartSync()
        {
            Task<int> task = SyncData();
            int x = await task;
        }

        static async Task<int> SyncData()
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(""))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
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
