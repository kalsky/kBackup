using System;
using System.Windows.Forms;
using kBackup.Classes;
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
            cmbPortal.SelectedIndex = 0;
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
                if (!ZendeskApi.ValidateUser()) return;

                string folder = @"c:\temp\zen"; //set a default one here if you don't want to open the dialog
                if (folder.Trim() == string.Empty)
                { 
                    fldrBackupLocation.ShowDialog();
                    folder = fldrBackupLocation.DirectoryPath;
                }
                ZendeskApi.BackupFolder = folder + @"\Backup_" + DateTime.Now.ToString("yyyyMMdd-hhmmss");

                //Ensures that path is not empty string e.g. user cancels or X out of folder browser dialog.
                if (folder.Trim() == string.Empty)
                {
                    ZendeskApi.BackupFolder = string.Empty;
                    return;
                }

                ZendeskApi.GetTopics(1);

                if (postsChk.Checked)
                {
                    //Retrieve all posts and associated images.
                    if (ZendeskApi.GetPosts(cmbPortal, 1))
                    {
                        //MessageBox.Show(this, @"Posts backup completed to path: " + ZendeskApi.BackupFolder, @"Backup Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, @"The posts backup did not complete successfully.", @"Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                System.Threading.Thread.Sleep(2000);
                ZendeskApi.GetSections(1);

                if (articlesChk.Checked)
                {
                    //Retrieve all articles and associated images.
                    if (ZendeskApi.GetArticles(cmbPortal, 1))
                    {
                        MessageBox.Show(this, @"Articles backup completed to path: " + ZendeskApi.BackupFolder, @"Backup Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, @"The articles backup did not complete successfully.", @"Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, @"Please enter a domain before continuing.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
