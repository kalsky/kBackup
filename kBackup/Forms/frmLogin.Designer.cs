namespace kBackup.Forms
{
    partial class frmLogin
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
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPortal = new Bunifu.Framework.UI.BunifuDropdown();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnMax = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClose = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dcTopBar = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtDomain = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtPassword = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtEmail = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.lnPortal = new System.Windows.Forms.Label();
            this.lnEmail = new System.Windows.Forms.Label();
            this.lnPassword = new System.Windows.Forms.Label();
            this.lnDomain = new System.Windows.Forms.Label();
            this.animUnderline = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.swRememberMe = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.btnConnect = new Bunifu.Framework.UI.BunifuFlatButton();
            this.animForm = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bgwSyncData = new System.ComponentModel.BackgroundWorker();
            this.bgwSyncUser = new System.ComponentModel.BackgroundWorker();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(187, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 44;
            this.label3.Text = "Domain";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuCustomLabel1.AutoSize = true;
            this.animUnderline.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCustomLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(258, 400);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(108, 21);
            this.bunifuCustomLabel1.TabIndex = 49;
            this.bunifuCustomLabel1.Text = "Remember me";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(392, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 43;
            this.label1.Text = ".zendesk.com";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(204, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "Email";
            // 
            // cmbPortal
            // 
            this.cmbPortal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPortal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.cmbPortal.BorderRadius = 3;
            this.animUnderline.SetDecoration(this.cmbPortal, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.cmbPortal, BunifuAnimatorNS.DecorationType.None);
            this.cmbPortal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPortal.ForeColor = System.Drawing.Color.White;
            this.cmbPortal.Items = new string[] {
        "Help Center",
        "Web Portal"};
            this.cmbPortal.Location = new System.Drawing.Point(767, 120);
            this.cmbPortal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPortal.Name = "cmbPortal";
            this.cmbPortal.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.cmbPortal.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.cmbPortal.selectedIndex = 0;
            this.cmbPortal.Size = new System.Drawing.Size(232, 35);
            this.cmbPortal.TabIndex = 3;
            this.cmbPortal.Visible = false;
            this.cmbPortal.Enter += new System.EventHandler(this.cmbPortal_Enter);
            this.cmbPortal.Leave += new System.EventHandler(this.cmbPortal_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(176, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 46;
            this.label5.Text = "Password";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.pnlTopBar.Controls.Add(this.btnMax);
            this.pnlTopBar.Controls.Add(this.btnMin);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.animForm.SetDecoration(this.pnlTopBar, BunifuAnimatorNS.DecorationType.None);
            this.animUnderline.SetDecoration(this.pnlTopBar, BunifuAnimatorNS.DecorationType.None);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(760, 39);
            this.pnlTopBar.TabIndex = 50;
            this.pnlTopBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.maxHandler);
            // 
            // btnMax
            // 
            this.btnMax.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMax.BorderRadius = 0;
            this.btnMax.ButtonText = "";
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animUnderline.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
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
            this.btnMax.Location = new System.Drawing.Point(677, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnMax.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
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
            this.btnMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.BorderRadius = 0;
            this.btnMin.ButtonText = "";
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animUnderline.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
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
            this.btnMin.Location = new System.Drawing.Point(634, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnMin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
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
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderRadius = 0;
            this.btnClose.ButtonText = "";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animUnderline.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
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
            this.btnClose.Location = new System.Drawing.Point(720, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
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
            // dcTopBar
            // 
            this.dcTopBar.Fixed = true;
            this.dcTopBar.Horizontal = true;
            this.dcTopBar.TargetControl = this.pnlTopBar;
            this.dcTopBar.Vertical = true;
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.txtDomain.BorderColor = System.Drawing.Color.White;
            this.txtDomain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animUnderline.SetDecoration(this.txtDomain, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.txtDomain, BunifuAnimatorNS.DecorationType.None);
            this.txtDomain.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomain.ForeColor = System.Drawing.Color.White;
            this.txtDomain.Location = new System.Drawing.Point(262, 281);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(130, 22);
            this.txtDomain.TabIndex = 0;
            this.txtDomain.Enter += new System.EventHandler(this.txtDomain_Enter);
            this.txtDomain.Leave += new System.EventHandler(this.txtDomain_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.txtPassword.BorderColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animUnderline.SetDecoration(this.txtPassword, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.txtPassword, BunifuAnimatorNS.DecorationType.None);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(262, 351);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(232, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.txtEmail.BorderColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animUnderline.SetDecoration(this.txtEmail, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.txtEmail, BunifuAnimatorNS.DecorationType.None);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(262, 317);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(232, 22);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lnPortal
            // 
            this.lnPortal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnPortal.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.lnPortal, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.lnPortal, BunifuAnimatorNS.DecorationType.None);
            this.lnPortal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnPortal.Location = new System.Drawing.Point(764, 143);
            this.lnPortal.Name = "lnPortal";
            this.lnPortal.Size = new System.Drawing.Size(274, 23);
            this.lnPortal.TabIndex = 51;
            this.lnPortal.Text = "______________________________________";
            this.lnPortal.Visible = false;
            // 
            // lnEmail
            // 
            this.lnEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnEmail.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.lnEmail, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.lnEmail, BunifuAnimatorNS.DecorationType.None);
            this.lnEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnEmail.Location = new System.Drawing.Point(259, 327);
            this.lnEmail.Name = "lnEmail";
            this.lnEmail.Size = new System.Drawing.Size(274, 23);
            this.lnEmail.TabIndex = 52;
            this.lnEmail.Text = "______________________________________";
            // 
            // lnPassword
            // 
            this.lnPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnPassword.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.lnPassword, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.lnPassword, BunifuAnimatorNS.DecorationType.None);
            this.lnPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnPassword.Location = new System.Drawing.Point(259, 361);
            this.lnPassword.Name = "lnPassword";
            this.lnPassword.Size = new System.Drawing.Size(274, 23);
            this.lnPassword.TabIndex = 53;
            this.lnPassword.Text = "______________________________________";
            // 
            // lnDomain
            // 
            this.lnDomain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnDomain.BackColor = System.Drawing.Color.Transparent;
            this.animUnderline.SetDecoration(this.lnDomain, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.lnDomain, BunifuAnimatorNS.DecorationType.None);
            this.lnDomain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnDomain.Location = new System.Drawing.Point(260, 291);
            this.lnDomain.Name = "lnDomain";
            this.lnDomain.Size = new System.Drawing.Size(143, 23);
            this.lnDomain.TabIndex = 54;
            this.lnDomain.Text = "______________________________________";
            // 
            // animUnderline
            // 
            this.animUnderline.AnimationType = BunifuAnimatorNS.AnimationType.HorizBlind;
            this.animUnderline.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.animUnderline.DefaultAnimation = animation3;
            this.animUnderline.MaxAnimationTime = 250;
            this.animUnderline.TimeStep = 0.05F;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = global::kBackup.Properties.Resources.app_background_2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.animUnderline.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Location = new System.Drawing.Point(262, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // swRememberMe
            // 
            this.swRememberMe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.swRememberMe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swRememberMe.BackgroundImage")));
            this.swRememberMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.swRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animForm.SetDecoration(this.swRememberMe, BunifuAnimatorNS.DecorationType.None);
            this.animUnderline.SetDecoration(this.swRememberMe, BunifuAnimatorNS.DecorationType.None);
            this.swRememberMe.Location = new System.Drawing.Point(449, 397);
            this.swRememberMe.Name = "swRememberMe";
            this.swRememberMe.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.swRememberMe.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.swRememberMe.Size = new System.Drawing.Size(43, 25);
            this.swRememberMe.TabIndex = 4;
            this.swRememberMe.Value = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnect.BorderRadius = 0;
            this.btnConnect.ButtonText = "Connect";
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animUnderline.SetDecoration(this.btnConnect, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this.btnConnect, BunifuAnimatorNS.DecorationType.None);
            this.btnConnect.DisabledColor = System.Drawing.Color.Gray;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Iconcolor = System.Drawing.Color.Transparent;
            this.btnConnect.Iconimage = null;
            this.btnConnect.Iconimage_right = null;
            this.btnConnect.Iconimage_right_Selected = null;
            this.btnConnect.Iconimage_Selected = null;
            this.btnConnect.IconRightVisible = true;
            this.btnConnect.IconRightZoom = 0D;
            this.btnConnect.IconVisible = true;
            this.btnConnect.IconZoom = 90D;
            this.btnConnect.IsTab = false;
            this.btnConnect.Location = new System.Drawing.Point(262, 444);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnConnect.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnConnect.OnHoverTextColor = System.Drawing.Color.White;
            this.btnConnect.selected = false;
            this.btnConnect.Size = new System.Drawing.Size(231, 51);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConnect.Textcolor = System.Drawing.Color.White;
            this.btnConnect.TextFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // animForm
            // 
            this.animForm.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.animForm.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 1F;
            this.animForm.DefaultAnimation = animation4;
            // 
            // bgwSyncData
            // 
            this.bgwSyncData.WorkerReportsProgress = true;
            this.bgwSyncData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSyncData_DoWork);
            this.bgwSyncData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSyncData_ProgressChanged);
            this.bgwSyncData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSyncData_RunWorkerCompleted);
            // 
            // bgwSyncUser
            // 
            this.bgwSyncUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSyncUser_DoWork);
            this.bgwSyncUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSyncUser_RunWorkerCompleted);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(760, 572);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.swRememberMe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPortal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lnPortal);
            this.Controls.Add(this.lnPassword);
            this.Controls.Add(this.lnEmail);
            this.Controls.Add(this.lnDomain);
            this.animUnderline.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.animForm.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnlTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuiOSSwitch swRememberMe;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnConnect;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuDropdown cmbPortal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTopBar;
        private Bunifu.Framework.UI.BunifuFlatButton btnMax;
        private Bunifu.Framework.UI.BunifuFlatButton btnMin;
        private Bunifu.Framework.UI.BunifuFlatButton btnClose;
        private Bunifu.Framework.UI.BunifuDragControl dcTopBar;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtDomain;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtPassword;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtEmail;
        private System.Windows.Forms.Label lnPortal;
        private System.Windows.Forms.Label lnEmail;
        private System.Windows.Forms.Label lnPassword;
        private System.Windows.Forms.Label lnDomain;
        private BunifuAnimatorNS.BunifuTransition animUnderline;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BunifuAnimatorNS.BunifuTransition animForm;
        private System.ComponentModel.BackgroundWorker bgwSyncData;
        private System.ComponentModel.BackgroundWorker bgwSyncUser;
    }
}