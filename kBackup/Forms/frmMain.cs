using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using kBackup.Classes;
using kBackup.Properties;
using Newtonsoft.Json;
using Syncfusion.Windows.Forms;

namespace kBackup.Forms
{
    public partial class FrmMain : MetroForm
    {
        private readonly Requests _requests = new Requests();
        private readonly FileSystem _fileSystem = new FileSystem();
        private Dictionary<long, string> Categories = new Dictionary<long, string>();

        /// <summary>
        /// Required for application initialization.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles loading of Main form.
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            // sync the data to List<object>
            WindowState = Settings.Default.windowState;

            SyncAllData();
            // load lists into grid based on cat and sect filters
            //_fileSystem.read
            //dgCategories.DataSource = new List<string> {"Category1","Category2","Category3","","","","","","","","","","","",""};

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

        private async void SyncAllData()
        {
            var catData = await _fileSystem.ReadCategoryData();

            foreach (var cat in catData.categories)
            {
                Categories.Add(cat.id, cat.name);

            }

            RefreshCategoryDG();













            // check if user can login

            // sync user data
            //  profile pic
            //  profile info

            // sync application data
            //  get help center data
            //  get community data
        }

        private void ReadUserData()
        {
            // Read existing json data
            var jsonData = File.ReadAllText(Settings.Default.dataFolder + "\\user\\profile.json");

            // De-serialize to object or create new list
            var employeeList = JsonConvert.DeserializeObject<List<ZApiModel.UserCollection>>(jsonData) ?? new List<ZApiModel.UserCollection>();

            //add to list here
            if (employeeList.Count <= 0)
            {
                //add entry here
            }

            // Update json data string
            jsonData = JsonConvert.SerializeObject(employeeList);
            File.WriteAllText(Settings.Default.dataFolder + "\\user\\profile.json", jsonData);
        }

        public List<ZApiModel.CategoryCollection> ReadCategoryData()
        {
            // Read existing json data
            var jsonData = File.ReadAllText(Settings.Default.dataFolder + "\\data\\json\\categories.json");

            // De-serialize to object or create new list
            var categories = JsonConvert.DeserializeObject<List<ZApiModel.CategoryCollection>>(jsonData); //?? new List<ZApiModel.CategoryCollection>();

            ////add to list here
            //if (categories.Count <= 0)
            //{
            //    //add entry here
            //}

            return categories;

            //// Update json data string
            //jsonData = JsonConvert.SerializeObject(categories);
            //File.WriteAllText(Settings.Default.dataFolder + "\\user\\profile.json", jsonData);
        }

        private void ReadSectionData()
        {
        }

        private void ReadArticleData()
        {
        }

        private void ReadArticleCommentData()
        {
        }

        private void ReadTopicData()
        {
        }

        private void ReadPostData()
        {
        }

        private void ReadPostCommentData()
        {
        }

        private async void RefreshCategoryDG()
        {
            var sortedData =  Categories.OrderBy(s => s, StringComparer.CurrentCultureIgnoreCase);
            var categoryData = from row in Categories select new { name = row.Value };
            dgCategories.DataSource = categoryData.ToArray();
        }

        private async void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Delete user data if Remember Me was false.
        }
    }
}
