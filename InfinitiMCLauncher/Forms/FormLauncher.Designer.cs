namespace InfinitiMCLauncher
{
    partial class FormLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLauncher));
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.tb_Username = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.check_Remember = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prog_Download = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            this.assetsDler = new System.ComponentModel.BackgroundWorker();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.link_ReportBug = new System.Windows.Forms.LinkLabel();
            this.packDler = new System.ComponentModel.BackgroundWorker();
            this.lnkLbl_ChangeLog = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(12, 174);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(170, 24);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Gray;
            this.lbl_Status.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.ForeColor = System.Drawing.Color.Black;
            this.lbl_Status.Location = new System.Drawing.Point(10, 199);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(49, 19);
            this.lbl_Status.TabIndex = 2;
            this.lbl_Status.Text = "Status";
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Username
            // 
            this.tb_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_Username.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Username.Location = new System.Drawing.Point(12, 120);
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.Size = new System.Drawing.Size(218, 23);
            this.tb_Username.TabIndex = 1;
            // 
            // tb_Password
            // 
            this.tb_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_Password.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Password.Location = new System.Drawing.Point(12, 147);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(218, 23);
            this.tb_Password.TabIndex = 2;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.WordWrap = false;
            // 
            // check_Remember
            // 
            this.check_Remember.AutoSize = true;
            this.check_Remember.BackColor = System.Drawing.Color.Gray;
            this.check_Remember.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Remember.Location = new System.Drawing.Point(189, 174);
            this.check_Remember.Name = "check_Remember";
            this.check_Remember.Size = new System.Drawing.Size(146, 23);
            this.check_Remember.TabIndex = 8;
            this.check_Remember.Text = "Remember login?";
            this.check_Remember.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.prog_Download);
            this.panel1.Location = new System.Drawing.Point(-2, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 137);
            this.panel1.TabIndex = 9;
            // 
            // prog_Download
            // 
            this.prog_Download.Location = new System.Drawing.Point(3, 114);
            this.prog_Download.Name = "prog_Download";
            this.prog_Download.Size = new System.Drawing.Size(351, 23);
            this.prog_Download.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prog_Download.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(352, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Java Options";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(101, 22);
            this.toolStripLabel2.Text = "Launcher Options";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::InfinitiMCLauncher.Properties.Resources.mc_logo;
            this.pictureBox3.Location = new System.Drawing.Point(-2, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(357, 84);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::InfinitiMCLauncher.Properties.Resources.ftb_logo;
            this.pictureBox2.Location = new System.Drawing.Point(265, 317);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InfinitiMCLauncher.Properties.Resources.ftb_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 317);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pb_Logo
            // 
            this.pb_Logo.Image = global::InfinitiMCLauncher.Properties.Resources.infinitylogo;
            this.pb_Logo.Location = new System.Drawing.Point(103, 245);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(150, 150);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_Logo.TabIndex = 0;
            this.pb_Logo.TabStop = false;
            // 
            // assetsDler
            // 
            this.assetsDler.WorkerReportsProgress = true;
            this.assetsDler.WorkerSupportsCancellation = true;
            this.assetsDler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.assetsDler_DoWork);
            this.assetsDler.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.assetsDler_ProgressChanged);
            this.assetsDler.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.assetsDler_RunWorkerCompleted);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Version.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Version.ForeColor = System.Drawing.Color.Silver;
            this.lbl_Version.Location = new System.Drawing.Point(1, 249);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(106, 22);
            this.lbl_Version.TabIndex = 12;
            this.lbl_Version.Text = "Version: #.#";
            // 
            // link_ReportBug
            // 
            this.link_ReportBug.AutoSize = true;
            this.link_ReportBug.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_ReportBug.Location = new System.Drawing.Point(2, 271);
            this.link_ReportBug.Name = "link_ReportBug";
            this.link_ReportBug.Size = new System.Drawing.Size(79, 16);
            this.link_ReportBug.TabIndex = 13;
            this.link_ReportBug.TabStop = true;
            this.link_ReportBug.Text = "Report a bug";
            this.link_ReportBug.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_ReportBug_LinkClicked);
            // 
            // packDler
            // 
            this.packDler.WorkerReportsProgress = true;
            this.packDler.WorkerSupportsCancellation = true;
            this.packDler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.packDler_DoWork);
            this.packDler.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.packDler_ProgressChanged);
            this.packDler.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.packDler_RunWorkerCompleted);
            // 
            // lnkLbl_ChangeLog
            // 
            this.lnkLbl_ChangeLog.AutoSize = true;
            this.lnkLbl_ChangeLog.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLbl_ChangeLog.Location = new System.Drawing.Point(2, 287);
            this.lnkLbl_ChangeLog.Name = "lnkLbl_ChangeLog";
            this.lnkLbl_ChangeLog.Size = new System.Drawing.Size(65, 16);
            this.lnkLbl_ChangeLog.TabIndex = 14;
            this.lnkLbl_ChangeLog.TabStop = true;
            this.lnkLbl_ChangeLog.Text = "Changelog";
            this.lnkLbl_ChangeLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLbl_ChangeLog_LinkClicked);
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(352, 387);
            this.Controls.Add(this.lnkLbl_ChangeLog);
            this.Controls.Add(this.link_ReportBug);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.check_Remember);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_Logo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Infiniti Launcher";
            this.Load += new System.EventHandler(this.FormLauncher_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Logo;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox check_Remember;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ProgressBar prog_Download;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.LinkLabel link_ReportBug;
        public System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.LinkLabel lnkLbl_ChangeLog;
        public System.ComponentModel.BackgroundWorker assetsDler;
        public System.ComponentModel.BackgroundWorker packDler;
    }
}