using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Properties;
using Syncfusion.Windows.Forms;

namespace kBackup.Forms
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmbPortal.selectedIndex = 0;
        }

        /// <summary>
        /// Validates provided credentials and domain, starts backup of articles and associated images.
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            //Set properties 
            ZendeskApi.Domain = txtDomain.Text.Trim();
            ZendeskApi.Password = txtPassword.Text.Trim();
            ZendeskApi.Email = txtEmail.Text.Trim();
            ZendeskApi.Query = "?page=";

            //Check that a domain was provided by the user.
            if (ZendeskApi.Domain.Trim() != string.Empty)
            {
                //Validate the users credentials.
                if (!Requests.ValidateUser()) return;

                //Retrieve all articles and associated images.
                if (Requests.GetArticles(cmbPortal))
                {
                    MessageBox.Show(this, @"Backup completed to path: " + ZendeskApi.BackupFolder, @"Backup Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, @"The backup did not complete successfully.", @"Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, @"Please enter a domain before continuing.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Requests.GetCollections("http://adwadawaf.awdawa.dwaa");

            //Set properties 
            ZendeskApi.Domain = txtDomain.Text.Trim();
            ZendeskApi.Password = txtPassword.Text.Trim();
            ZendeskApi.Email = txtEmail.Text.Trim();
            ZendeskApi.Query = "?page=";

            //Settings.Default.pbAvatar = pbProfile;
            Settings.Default.Save();

            //ZendeskApi.GetUser(ZendeskApi.Email,cmbPortal);

            //ZendeskApi.Post("","");
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            //myControl.Left = (this.ClientSize.Width - myControl.Width) / 2;
            //myControl.Top = (this.ClientSize.Height - myControl.Height) / 2;
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            ZendeskApi.Domain = txtDomain.Text.Trim();
            ZendeskApi.Password = txtPassword.Text.Trim();
            ZendeskApi.Email = txtEmail.Text.Trim();
            ZendeskApi.Query = "?page=";

            //Settings.Default.pbAvatar = pbProfile;
            Settings.Default.Save();
            Requests.GetUser(ZendeskApi.Email, cmbPortal);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
