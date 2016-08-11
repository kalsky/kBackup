namespace kBackup.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDomain = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.btnBackup = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.fldrBackupLocation = new Syncfusion.Windows.Forms.FolderBrowser(this.components);
            this.cmbPortal = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(45)))), ((int)(((byte)(59)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.BackColor = System.Drawing.Color.White;
            this.txtDomain.BeforeTouchSize = new System.Drawing.Size(232, 29);
            this.txtDomain.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.txtDomain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDomain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDomain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDomain.FocusBorderColor = System.Drawing.Color.White;
            this.txtDomain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomain.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDomain.Location = new System.Drawing.Point(117, 180);
            this.txtDomain.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDomain.MinimumSize = new System.Drawing.Size(8, 4);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(130, 29);
            this.txtDomain.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtDomain.TabIndex = 0;
            this.txtDomain.UseBorderColorOnFocus = true;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Transparent;
            this.btnBackup.BeforeTouchSize = new System.Drawing.Size(96, 36);
            this.btnBackup.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Flat;
            this.btnBackup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBackup.IsBackStageButton = false;
            this.btnBackup.Location = new System.Drawing.Point(253, 331);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(96, 36);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BeforeTouchSize = new System.Drawing.Size(232, 29);
            this.txtPassword.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusBorderColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPassword.Location = new System.Drawing.Point(117, 248);
            this.txtPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPassword.MinimumSize = new System.Drawing.Size(8, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(232, 29);
            this.txtPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseBorderColorOnFocus = true;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BeforeTouchSize = new System.Drawing.Size(232, 29);
            this.txtEmail.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.FocusBorderColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtEmail.Location = new System.Drawing.Point(117, 214);
            this.txtEmail.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtEmail.MinimumSize = new System.Drawing.Size(8, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(232, 29);
            this.txtEmail.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtEmail.TabIndex = 1;
            this.txtEmail.UseBorderColorOnFocus = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(247, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = ".zendesk.com";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.pnlMain.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.pnlMain.BorderColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pictureBox2);
            this.pnlMain.Location = new System.Drawing.Point(961, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(941, 683);
            this.pnlMain.TabIndex = 6;
            this.pnlMain.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 683);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-1, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(913, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 50);
            this.label2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(240, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 621);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(857, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // fldrBackupLocation
            // 
            this.fldrBackupLocation.StartLocation = Syncfusion.Windows.Forms.FolderBrowserFolder.MyComputer;
            // 
            // cmbPortal
            // 
            this.cmbPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPortal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPortal.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbPortal.FormattingEnabled = true;
            this.cmbPortal.ItemHeight = 21;
            this.cmbPortal.Items.AddRange(new object[] {
            "Help Center",
            "Web Portal"});
            this.cmbPortal.Location = new System.Drawing.Point(117, 283);
            this.cmbPortal.Name = "cmbPortal";
            this.cmbPortal.Size = new System.Drawing.Size(232, 29);
            this.cmbPortal.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::kBackup.Properties.Resources.app_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderThickness = 0;
            captionImage1.BackColor = System.Drawing.Color.White;
            captionImage1.ForeColor = System.Drawing.Color.White;
            captionImage1.Location = new System.Drawing.Point(0, 0);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(26, 26);
            this.CaptionImages.Add(captionImage1);
            this.ClientSize = new System.Drawing.Size(418, 384);
            this.Controls.Add(this.cmbPortal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.DoubleBuffered = true;
            this.DropShadow = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDomain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDomain;
        private Syncfusion.Windows.Forms.ButtonAdv btnBackup;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel pnlMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.FolderBrowser fldrBackupLocation;
        private System.Windows.Forms.ComboBox cmbPortal;
    }
}

