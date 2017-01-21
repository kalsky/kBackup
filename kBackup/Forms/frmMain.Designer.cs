namespace kBackup.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            this.fldrBackupLocation = new Syncfusion.Windows.Forms.FolderBrowser(this.components);
            this.dcTopBar = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnMax = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClose = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlSideMenu = new System.Windows.Forms.Panel();
            this.btnSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.btnMigrate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLogout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCommunity = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHelpCenter = new Bunifu.Framework.UI.BunifuFlatButton();
            this.animMenu = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.pnlHelpCenter = new System.Windows.Forms.Panel();
            this.pnlArticles = new System.Windows.Forms.Panel();
            this.dgArticles = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pnlSections = new System.Windows.Forms.Panel();
            this.dgSections = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pnlCategories = new System.Windows.Forms.Panel();
            this.dgCategories = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.pnlNoContent = new System.Windows.Forms.Panel();
            this.lblRefresh = new System.Windows.Forms.LinkLabel();
            this.pbNoContent = new System.Windows.Forms.PictureBox();
            this.pnlCommunity = new System.Windows.Forms.Panel();
            this.pnlMigrate = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            this.pnlSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            this.pnlHelpCenter.SuspendLayout();
            this.pnlArticles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticles)).BeginInit();
            this.pnlSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSections)).BeginInit();
            this.pnlCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).BeginInit();
            this.pnlNoContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoContent)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // fldrBackupLocation
            // 
            this.fldrBackupLocation.StartLocation = Syncfusion.Windows.Forms.FolderBrowserFolder.MyComputer;
            // 
            // dcTopBar
            // 
            this.dcTopBar.Fixed = true;
            this.dcTopBar.Horizontal = true;
            this.dcTopBar.TargetControl = this.pnlTopBar;
            this.dcTopBar.Vertical = true;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.pnlTopBar.Controls.Add(this.btnMax);
            this.pnlTopBar.Controls.Add(this.btnMin);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.animMenu.SetDecoration(this.pnlTopBar, BunifuAnimatorNS.DecorationType.None);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(925, 39);
            this.pnlTopBar.TabIndex = 29;
            this.pnlTopBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.maxHandler);
            // 
            // btnMax
            // 
            this.btnMax.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMax.BorderRadius = 0;
            this.btnMax.ButtonText = "";
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
            this.btnMax.DisabledColor = System.Drawing.Color.Gray;
            this.btnMax.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMax.Iconimage = global::kBackup.Properties.Resources.Maximize4_WF;
            this.btnMax.Iconimage_right = null;
            this.btnMax.Iconimage_right_Selected = null;
            this.btnMax.Iconimage_Selected = null;
            this.btnMax.IconRightVisible = true;
            this.btnMax.IconRightZoom = 0D;
            this.btnMax.IconVisible = true;
            this.btnMax.IconZoom = 90D;
            this.btnMax.IsTab = false;
            this.btnMax.Location = new System.Drawing.Point(842, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMax.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnMax.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(11)))), ((int)(((byte)(32)))));
            this.btnMax.selected = false;
            this.btnMax.Size = new System.Drawing.Size(40, 40);
            this.btnMax.TabIndex = 41;
            this.btnMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMax.Textcolor = System.Drawing.Color.White;
            this.btnMax.TextFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.maxHandler);
            // 
            // btnMin
            // 
            this.btnMin.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.BorderRadius = 0;
            this.btnMin.ButtonText = "";
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
            this.btnMin.DisabledColor = System.Drawing.Color.Gray;
            this.btnMin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMin.Iconimage = global::kBackup.Properties.Resources.Minimize_WF1;
            this.btnMin.Iconimage_right = null;
            this.btnMin.Iconimage_right_Selected = null;
            this.btnMin.Iconimage_Selected = null;
            this.btnMin.IconRightVisible = true;
            this.btnMin.IconRightZoom = 0D;
            this.btnMin.IconVisible = true;
            this.btnMin.IconZoom = 90D;
            this.btnMin.IsTab = false;
            this.btnMin.Location = new System.Drawing.Point(799, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnMin.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(11)))), ((int)(((byte)(32)))));
            this.btnMin.selected = false;
            this.btnMin.Size = new System.Drawing.Size(40, 40);
            this.btnMin.TabIndex = 40;
            this.btnMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMin.Textcolor = System.Drawing.Color.White;
            this.btnMin.TextFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Click += new System.EventHandler(this.minHandler);
            // 
            // btnClose
            // 
            this.btnClose.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(83)))), ((int)(((byte)(86)))));
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderRadius = 0;
            this.btnClose.ButtonText = "";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.DisabledColor = System.Drawing.Color.Gray;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClose.Iconimage = global::kBackup.Properties.Resources.Close_WF1111;
            this.btnClose.Iconimage_right = null;
            this.btnClose.Iconimage_right_Selected = null;
            this.btnClose.Iconimage_Selected = null;
            this.btnClose.IconRightVisible = true;
            this.btnClose.IconRightZoom = 0D;
            this.btnClose.IconVisible = true;
            this.btnClose.IconZoom = 90D;
            this.btnClose.IsTab = false;
            this.btnClose.Location = new System.Drawing.Point(885, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnClose.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(83)))), ((int)(((byte)(86)))));
            this.btnClose.OnHoverTextColor = System.Drawing.Color.White;
            this.btnClose.selected = false;
            this.btnClose.Size = new System.Drawing.Size(41, 40);
            this.btnClose.TabIndex = 39;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Textcolor = System.Drawing.Color.White;
            this.btnClose.TextFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlSideMenu
            // 
            this.pnlSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.pnlSideMenu.Controls.Add(this.btnSettings);
            this.pnlSideMenu.Controls.Add(this.pbProfile);
            this.pnlSideMenu.Controls.Add(this.btnMigrate);
            this.pnlSideMenu.Controls.Add(this.btnLogout);
            this.pnlSideMenu.Controls.Add(this.btnHome);
            this.pnlSideMenu.Controls.Add(this.btnCommunity);
            this.pnlSideMenu.Controls.Add(this.btnHelpCenter);
            this.animMenu.SetDecoration(this.pnlSideMenu, BunifuAnimatorNS.DecorationType.None);
            this.pnlSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideMenu.Location = new System.Drawing.Point(0, 39);
            this.pnlSideMenu.Name = "pnlSideMenu";
            this.pnlSideMenu.Size = new System.Drawing.Size(50, 561);
            this.pnlSideMenu.TabIndex = 28;
            // 
            // btnSettings
            // 
            this.btnSettings.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.BorderRadius = 0;
            this.btnSettings.ButtonText = "Settings";
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnSettings, BunifuAnimatorNS.DecorationType.None);
            this.btnSettings.DisabledColor = System.Drawing.Color.Gray;
            this.btnSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSettings.Iconimage = global::kBackup.Properties.Resources.Settings___09;
            this.btnSettings.Iconimage_right = null;
            this.btnSettings.Iconimage_right_Selected = null;
            this.btnSettings.Iconimage_Selected = null;
            this.btnSettings.IconRightVisible = true;
            this.btnSettings.IconRightZoom = 0D;
            this.btnSettings.IconVisible = true;
            this.btnSettings.IconZoom = 90D;
            this.btnSettings.IsTab = false;
            this.btnSettings.Location = new System.Drawing.Point(1, 463);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnSettings.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSettings.selected = false;
            this.btnSettings.Size = new System.Drawing.Size(147, 48);
            this.btnSettings.TabIndex = 23;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Textcolor = System.Drawing.Color.White;
            this.btnSettings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pbProfile
            // 
            this.pbProfile.BackColor = System.Drawing.Color.Transparent;
            this.pbProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.animMenu.SetDecoration(this.pbProfile, BunifuAnimatorNS.DecorationType.None);
            this.pbProfile.Image = global::kBackup.Properties.Resources.Debug2_png;
            this.pbProfile.Location = new System.Drawing.Point(6, 8);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(35, 35);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile.TabIndex = 16;
            this.pbProfile.TabStop = false;
            this.pbProfile.Click += new System.EventHandler(this.pbProfile_Click);
            // 
            // btnMigrate
            // 
            this.btnMigrate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMigrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnMigrate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMigrate.BorderRadius = 0;
            this.btnMigrate.ButtonText = "Migrate";
            this.btnMigrate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnMigrate, BunifuAnimatorNS.DecorationType.None);
            this.btnMigrate.DisabledColor = System.Drawing.Color.Gray;
            this.btnMigrate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMigrate.Iconimage = global::kBackup.Properties.Resources.Export_WF;
            this.btnMigrate.Iconimage_right = null;
            this.btnMigrate.Iconimage_right_Selected = null;
            this.btnMigrate.Iconimage_Selected = null;
            this.btnMigrate.IconRightVisible = true;
            this.btnMigrate.IconRightZoom = 0D;
            this.btnMigrate.IconVisible = true;
            this.btnMigrate.IconZoom = 90D;
            this.btnMigrate.IsTab = false;
            this.btnMigrate.Location = new System.Drawing.Point(1, 247);
            this.btnMigrate.Name = "btnMigrate";
            this.btnMigrate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnMigrate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMigrate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMigrate.selected = false;
            this.btnMigrate.Size = new System.Drawing.Size(147, 48);
            this.btnMigrate.TabIndex = 22;
            this.btnMigrate.Text = "Migrate";
            this.btnMigrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMigrate.Textcolor = System.Drawing.Color.White;
            this.btnMigrate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMigrate.Click += new System.EventHandler(this.btnMigrate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.BorderRadius = 0;
            this.btnLogout.ButtonText = "Logout";
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnLogout, BunifuAnimatorNS.DecorationType.None);
            this.btnLogout.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogout.Iconimage = global::kBackup.Properties.Resources.Exit_01_WF;
            this.btnLogout.Iconimage_right = null;
            this.btnLogout.Iconimage_right_Selected = null;
            this.btnLogout.Iconimage_Selected = null;
            this.btnLogout.IconRightVisible = true;
            this.btnLogout.IconRightZoom = 0D;
            this.btnLogout.IconVisible = true;
            this.btnLogout.IconZoom = 90D;
            this.btnLogout.IsTab = false;
            this.btnLogout.Location = new System.Drawing.Point(0, 514);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnLogout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(83)))), ((int)(((byte)(86)))));
            this.btnLogout.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogout.selected = false;
            this.btnLogout.Size = new System.Drawing.Size(177, 48);
            this.btnLogout.TabIndex = 21;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Textcolor = System.Drawing.Color.White;
            this.btnLogout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnHome
            // 
            this.btnHome.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.BorderRadius = 0;
            this.btnHome.ButtonText = "";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnHome, BunifuAnimatorNS.DecorationType.None);
            this.btnHome.DisabledColor = System.Drawing.Color.Gray;
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = global::kBackup.Properties.Resources.Menu_01;
            this.btnHome.Iconimage_right = null;
            this.btnHome.Iconimage_right_Selected = null;
            this.btnHome.Iconimage_Selected = null;
            this.btnHome.IconRightVisible = true;
            this.btnHome.IconRightZoom = 0D;
            this.btnHome.IconVisible = true;
            this.btnHome.IconZoom = 90D;
            this.btnHome.IsTab = false;
            this.btnHome.Location = new System.Drawing.Point(1, 91);
            this.btnHome.Name = "btnHome";
            this.btnHome.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnHome.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnHome.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHome.selected = false;
            this.btnHome.Size = new System.Drawing.Size(51, 48);
            this.btnHome.TabIndex = 18;
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Textcolor = System.Drawing.Color.White;
            this.btnHome.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Click += new System.EventHandler(this.bunifuFlatButton7_Click);
            // 
            // btnCommunity
            // 
            this.btnCommunity.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCommunity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCommunity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommunity.BorderRadius = 0;
            this.btnCommunity.ButtonText = "Community";
            this.btnCommunity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnCommunity, BunifuAnimatorNS.DecorationType.None);
            this.btnCommunity.DisabledColor = System.Drawing.Color.Gray;
            this.btnCommunity.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCommunity.Iconimage = global::kBackup.Properties.Resources.Team_01_WF;
            this.btnCommunity.Iconimage_right = null;
            this.btnCommunity.Iconimage_right_Selected = null;
            this.btnCommunity.Iconimage_Selected = null;
            this.btnCommunity.IconRightVisible = true;
            this.btnCommunity.IconRightZoom = 0D;
            this.btnCommunity.IconVisible = true;
            this.btnCommunity.IconZoom = 90D;
            this.btnCommunity.IsTab = false;
            this.btnCommunity.Location = new System.Drawing.Point(1, 196);
            this.btnCommunity.Name = "btnCommunity";
            this.btnCommunity.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCommunity.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCommunity.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCommunity.selected = false;
            this.btnCommunity.Size = new System.Drawing.Size(147, 48);
            this.btnCommunity.TabIndex = 19;
            this.btnCommunity.Text = "Community";
            this.btnCommunity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommunity.Textcolor = System.Drawing.Color.White;
            this.btnCommunity.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommunity.Click += new System.EventHandler(this.btnCommunity_Click);
            // 
            // btnHelpCenter
            // 
            this.btnHelpCenter.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnHelpCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnHelpCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelpCenter.BorderRadius = 0;
            this.btnHelpCenter.ButtonText = "Help Center";
            this.btnHelpCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animMenu.SetDecoration(this.btnHelpCenter, BunifuAnimatorNS.DecorationType.None);
            this.btnHelpCenter.DisabledColor = System.Drawing.Color.Gray;
            this.btnHelpCenter.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHelpCenter.Iconimage = global::kBackup.Properties.Resources.Paper;
            this.btnHelpCenter.Iconimage_right = null;
            this.btnHelpCenter.Iconimage_right_Selected = null;
            this.btnHelpCenter.Iconimage_Selected = null;
            this.btnHelpCenter.IconRightVisible = true;
            this.btnHelpCenter.IconRightZoom = 0D;
            this.btnHelpCenter.IconVisible = true;
            this.btnHelpCenter.IconZoom = 90D;
            this.btnHelpCenter.IsTab = false;
            this.btnHelpCenter.Location = new System.Drawing.Point(1, 145);
            this.btnHelpCenter.Name = "btnHelpCenter";
            this.btnHelpCenter.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnHelpCenter.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnHelpCenter.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHelpCenter.selected = true;
            this.btnHelpCenter.Size = new System.Drawing.Size(147, 48);
            this.btnHelpCenter.TabIndex = 17;
            this.btnHelpCenter.Text = "Help Center";
            this.btnHelpCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelpCenter.Textcolor = System.Drawing.Color.White;
            this.btnHelpCenter.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpCenter.Click += new System.EventHandler(this.btnHelpCenter_Click);
            // 
            // animMenu
            // 
            this.animMenu.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.animMenu.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.animMenu.DefaultAnimation = animation1;
            // 
            // pnlHelpCenter
            // 
            this.pnlHelpCenter.Controls.Add(this.pnlArticles);
            this.pnlHelpCenter.Controls.Add(this.pnlSections);
            this.pnlHelpCenter.Controls.Add(this.pnlCategories);
            this.animMenu.SetDecoration(this.pnlHelpCenter, BunifuAnimatorNS.DecorationType.None);
            this.pnlHelpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHelpCenter.Location = new System.Drawing.Point(50, 39);
            this.pnlHelpCenter.Name = "pnlHelpCenter";
            this.pnlHelpCenter.Size = new System.Drawing.Size(875, 561);
            this.pnlHelpCenter.TabIndex = 30;
            // 
            // pnlArticles
            // 
            this.pnlArticles.Controls.Add(this.dgArticles);
            this.animMenu.SetDecoration(this.pnlArticles, BunifuAnimatorNS.DecorationType.None);
            this.pnlArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArticles.Location = new System.Drawing.Point(253, 0);
            this.pnlArticles.Name = "pnlArticles";
            this.pnlArticles.Size = new System.Drawing.Size(622, 561);
            this.pnlArticles.TabIndex = 2;
            // 
            // dgArticles
            // 
            this.dgArticles.AllowUserToAddRows = false;
            this.dgArticles.AllowUserToDeleteRows = false;
            this.dgArticles.AllowUserToResizeColumns = false;
            this.dgArticles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgArticles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgArticles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgArticles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.dgArticles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgArticles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgArticles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgArticles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticles.ColumnHeadersVisible = false;
            this.animMenu.SetDecoration(this.dgArticles, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgArticles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgArticles.DoubleBuffered = true;
            this.dgArticles.EnableHeadersVisualStyles = false;
            this.dgArticles.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgArticles.HeaderForeColor = System.Drawing.Color.SeaGreen;
            this.dgArticles.Location = new System.Drawing.Point(0, 0);
            this.dgArticles.Name = "dgArticles";
            this.dgArticles.ReadOnly = true;
            this.dgArticles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgArticles.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgArticles.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgArticles.RowTemplate.DividerHeight = 1;
            this.dgArticles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgArticles.Size = new System.Drawing.Size(622, 561);
            this.dgArticles.TabIndex = 0;
            // 
            // pnlSections
            // 
            this.pnlSections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSections.Controls.Add(this.dgSections);
            this.animMenu.SetDecoration(this.pnlSections, BunifuAnimatorNS.DecorationType.None);
            this.pnlSections.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSections.Location = new System.Drawing.Point(127, 0);
            this.pnlSections.Name = "pnlSections";
            this.pnlSections.Size = new System.Drawing.Size(126, 561);
            this.pnlSections.TabIndex = 1;
            // 
            // dgSections
            // 
            this.dgSections.AllowUserToAddRows = false;
            this.dgSections.AllowUserToDeleteRows = false;
            this.dgSections.AllowUserToResizeColumns = false;
            this.dgSections.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgSections.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSections.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.dgSections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSections.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgSections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSections.ColumnHeadersVisible = false;
            this.animMenu.SetDecoration(this.dgSections, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSections.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSections.DoubleBuffered = true;
            this.dgSections.EnableHeadersVisualStyles = false;
            this.dgSections.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgSections.HeaderForeColor = System.Drawing.Color.SeaGreen;
            this.dgSections.Location = new System.Drawing.Point(0, 0);
            this.dgSections.Name = "dgSections";
            this.dgSections.ReadOnly = true;
            this.dgSections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgSections.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgSections.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgSections.RowTemplate.DividerHeight = 1;
            this.dgSections.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSections.Size = new System.Drawing.Size(124, 559);
            this.dgSections.TabIndex = 1;
            // 
            // pnlCategories
            // 
            this.pnlCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategories.Controls.Add(this.dgCategories);
            this.animMenu.SetDecoration(this.pnlCategories, BunifuAnimatorNS.DecorationType.None);
            this.pnlCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCategories.Location = new System.Drawing.Point(0, 0);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(127, 561);
            this.pnlCategories.TabIndex = 0;
            // 
            // dgCategories
            // 
            this.dgCategories.AllowUserToAddRows = false;
            this.dgCategories.AllowUserToDeleteRows = false;
            this.dgCategories.AllowUserToResizeColumns = false;
            this.dgCategories.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgCategories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCategories.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.dgCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategories.ColumnHeadersVisible = false;
            this.animMenu.SetDecoration(this.dgCategories, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCategories.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCategories.DoubleBuffered = true;
            this.dgCategories.EnableHeadersVisualStyles = false;
            this.dgCategories.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgCategories.HeaderForeColor = System.Drawing.Color.SeaGreen;
            this.dgCategories.Location = new System.Drawing.Point(0, 0);
            this.dgCategories.Name = "dgCategories";
            this.dgCategories.ReadOnly = true;
            this.dgCategories.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgCategories.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgCategories.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgCategories.RowTemplate.DividerHeight = 1;
            this.dgCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgCategories.Size = new System.Drawing.Size(125, 559);
            this.dgCategories.TabIndex = 1;
            // 
            // pnlNoContent
            // 
            this.pnlNoContent.Controls.Add(this.lblRefresh);
            this.pnlNoContent.Controls.Add(this.pbNoContent);
            this.animMenu.SetDecoration(this.pnlNoContent, BunifuAnimatorNS.DecorationType.None);
            this.pnlNoContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoContent.Location = new System.Drawing.Point(50, 39);
            this.pnlNoContent.Name = "pnlNoContent";
            this.pnlNoContent.Size = new System.Drawing.Size(875, 561);
            this.pnlNoContent.TabIndex = 1;
            // 
            // lblRefresh
            // 
            this.lblRefresh.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRefresh.AutoSize = true;
            this.animMenu.SetDecoration(this.lblRefresh, BunifuAnimatorNS.DecorationType.None);
            this.lblRefresh.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefresh.LinkColor = System.Drawing.Color.SeaGreen;
            this.lblRefresh.Location = new System.Drawing.Point(383, 360);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(74, 25);
            this.lblRefresh.TabIndex = 1;
            this.lblRefresh.TabStop = true;
            this.lblRefresh.Text = "Refresh";
            this.lblRefresh.VisitedLinkColor = System.Drawing.Color.SeaGreen;
            this.lblRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRefresh_LinkClicked);
            // 
            // pbNoContent
            // 
            this.pbNoContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.animMenu.SetDecoration(this.pbNoContent, BunifuAnimatorNS.DecorationType.None);
            this.pbNoContent.Image = global::kBackup.Properties.Resources.ncf;
            this.pbNoContent.Location = new System.Drawing.Point(273, 76);
            this.pbNoContent.Name = "pbNoContent";
            this.pbNoContent.Size = new System.Drawing.Size(300, 300);
            this.pbNoContent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNoContent.TabIndex = 0;
            this.pbNoContent.TabStop = false;
            // 
            // pnlCommunity
            // 
            this.animMenu.SetDecoration(this.pnlCommunity, BunifuAnimatorNS.DecorationType.None);
            this.pnlCommunity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCommunity.Location = new System.Drawing.Point(50, 39);
            this.pnlCommunity.Name = "pnlCommunity";
            this.pnlCommunity.Size = new System.Drawing.Size(875, 561);
            this.pnlCommunity.TabIndex = 31;
            this.pnlCommunity.Visible = false;
            // 
            // pnlMigrate
            // 
            this.animMenu.SetDecoration(this.pnlMigrate, BunifuAnimatorNS.DecorationType.None);
            this.pnlMigrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMigrate.Location = new System.Drawing.Point(50, 39);
            this.pnlMigrate.Name = "pnlMigrate";
            this.pnlMigrate.Size = new System.Drawing.Size(875, 561);
            this.pnlMigrate.TabIndex = 32;
            this.pnlMigrate.Visible = false;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.button1);
            this.animMenu.SetDecoration(this.pnlSettings, BunifuAnimatorNS.DecorationType.None);
            this.pnlSettings.Location = new System.Drawing.Point(294, 73);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(83, 171);
            this.pnlSettings.TabIndex = 33;
            this.pnlSettings.Visible = false;
            // 
            // button1
            // 
            this.animMenu.SetDecoration(this.button1, BunifuAnimatorNS.DecorationType.None);
            this.button1.Location = new System.Drawing.Point(309, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderColor = System.Drawing.Color.Transparent;
            this.BorderThickness = 0;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            this.CaptionBarHeight = 45;
            this.CaptionButtonColor = System.Drawing.SystemColors.Control;
            captionImage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(131)))), ((int)(((byte)(169)))));
            captionImage1.ForeColor = System.Drawing.Color.White;
            captionImage1.Location = new System.Drawing.Point(0, 0);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(26, 26);
            this.CaptionImages.Add(captionImage1);
            this.ClientSize = new System.Drawing.Size(925, 600);
            this.Controls.Add(this.pnlNoContent);
            this.Controls.Add(this.pnlCommunity);
            this.Controls.Add(this.pnlMigrate);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlHelpCenter);
            this.Controls.Add(this.pnlSideMenu);
            this.Controls.Add(this.pnlTopBar);
            this.animMenu.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.DropShadow = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlSideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            this.pnlHelpCenter.ResumeLayout(false);
            this.pnlArticles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArticles)).EndInit();
            this.pnlSections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSections)).EndInit();
            this.pnlCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).EndInit();
            this.pnlNoContent.ResumeLayout(false);
            this.pnlNoContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNoContent)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.Windows.Forms.FolderBrowser fldrBackupLocation;
        private Bunifu.Framework.UI.BunifuDragControl dcTopBar;
        public System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.Panel pnlSideMenu;
        private Bunifu.Framework.UI.BunifuFlatButton btnCommunity;
        private Bunifu.Framework.UI.BunifuFlatButton btnHelpCenter;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogout;
        private Bunifu.Framework.UI.BunifuFlatButton btnMigrate;
        private Bunifu.Framework.UI.BunifuFlatButton btnHome;
        private BunifuAnimatorNS.BunifuTransition animMenu;
        private Bunifu.Framework.UI.BunifuFlatButton btnSettings;
        private System.Windows.Forms.Panel pnlTopBar;
        private Bunifu.Framework.UI.BunifuFlatButton btnMax;
        private Bunifu.Framework.UI.BunifuFlatButton btnMin;
        private Bunifu.Framework.UI.BunifuFlatButton btnClose;
        private System.Windows.Forms.Panel pnlHelpCenter;
        private System.Windows.Forms.Panel pnlCommunity;
        private System.Windows.Forms.Panel pnlMigrate;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlArticles;
        private System.Windows.Forms.Panel pnlSections;
        private System.Windows.Forms.Panel pnlCategories;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgArticles;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgSections;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgCategories;
        private System.Windows.Forms.Panel pnlNoContent;
        private System.Windows.Forms.LinkLabel lblRefresh;
        private System.Windows.Forms.PictureBox pbNoContent;
    }
}

