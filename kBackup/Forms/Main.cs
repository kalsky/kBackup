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
        /// Validates provided credentials and domain, starts backup of articles and associated images.
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            //Set properties
            ZendeskApi.Domain = txtDomain.Text;
            ZendeskApi.Password = txtPassword.Text;
            ZendeskApi.Email = txtEmail.Text;
            ZendeskApi.Query = "?page=";

            //Check that a domain was provided by the user.
            if (ZendeskApi.Domain.Trim() != string.Empty)
            {
                //Validate the users credentials.
                if (!ZendeskApi.ValidateUser()) return;
                fldrBackupLocation.ShowDialog();
                ZendeskApi.BackupFolder = fldrBackupLocation.DirectoryPath + @"\Backup_" + DateTime.Now.ToString("yyyyMMdd-hhmmss");
                if (ZendeskApi.BackupFolder.Trim() == string.Empty) return;

                //Retrieve all articles and associated images.
                if (ZendeskApi.GetArticles())
                {
                    MessageBox.Show(this, @"Backup completed to path: " + ZendeskApi.BackupFolder);
                }
                else
                {
                    MessageBox.Show(this, @"The backup did not complete successfully.");
                }
            }
            else
            {
                MessageBox.Show(this, @"Please enter a domain before continuing.");
            }
        }
    }
}
