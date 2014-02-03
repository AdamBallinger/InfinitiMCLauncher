namespace InfinitiMCLauncher2
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMinecraft = new System.Windows.Forms.TabPage();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabJava = new System.Windows.Forms.TabPage();
            this.tabLauncher = new System.Windows.Forms.TabPage();
            this.tabChangelog = new System.Windows.Forms.TabPage();
            this.tbChangeLog = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabMinecraft.SuspendLayout();
            this.tabChangelog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(7, 345);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 49);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlay.Location = new System.Drawing.Point(388, 5);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(161, 49);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Location = new System.Drawing.Point(-4, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 62);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::InfinitiMCLauncher2.Properties.Resources.FTBLogo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(299, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 59);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::InfinitiMCLauncher2.Properties.Resources.infinitylogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(201, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMinecraft);
            this.tabControl.Controls.Add(this.tabJava);
            this.tabControl.Controls.Add(this.tabLauncher);
            this.tabControl.Controls.Add(this.tabChangelog);
            this.tabControl.Location = new System.Drawing.Point(-1, 94);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(555, 220);
            this.tabControl.TabIndex = 3;
            // 
            // tabMinecraft
            // 
            this.tabMinecraft.Controls.Add(this.cbRemember);
            this.tabMinecraft.Controls.Add(this.tbPassword);
            this.tabMinecraft.Controls.Add(this.label2);
            this.tabMinecraft.Controls.Add(this.tbUsername);
            this.tabMinecraft.Controls.Add(this.label1);
            this.tabMinecraft.Location = new System.Drawing.Point(4, 22);
            this.tabMinecraft.Name = "tabMinecraft";
            this.tabMinecraft.Padding = new System.Windows.Forms.Padding(3);
            this.tabMinecraft.Size = new System.Drawing.Size(547, 194);
            this.tabMinecraft.TabIndex = 0;
            this.tabMinecraft.Text = "Minecraft";
            this.tabMinecraft.UseVisualStyleBackColor = true;
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRemember.Location = new System.Drawing.Point(9, 145);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(129, 21);
            this.cbRemember.TabIndex = 4;
            this.cbRemember.Text = "Remember login";
            this.cbRemember.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(9, 92);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(264, 27);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(9, 38);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(264, 27);
            this.tbUsername.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username / email:";
            // 
            // tabJava
            // 
            this.tabJava.Location = new System.Drawing.Point(4, 22);
            this.tabJava.Name = "tabJava";
            this.tabJava.Padding = new System.Windows.Forms.Padding(3);
            this.tabJava.Size = new System.Drawing.Size(547, 194);
            this.tabJava.TabIndex = 1;
            this.tabJava.Text = "Java Settings";
            this.tabJava.UseVisualStyleBackColor = true;
            // 
            // tabLauncher
            // 
            this.tabLauncher.Location = new System.Drawing.Point(4, 22);
            this.tabLauncher.Name = "tabLauncher";
            this.tabLauncher.Padding = new System.Windows.Forms.Padding(3);
            this.tabLauncher.Size = new System.Drawing.Size(547, 194);
            this.tabLauncher.TabIndex = 2;
            this.tabLauncher.Text = "Launcher Options";
            this.tabLauncher.UseVisualStyleBackColor = true;
            // 
            // tabChangelog
            // 
            this.tabChangelog.Controls.Add(this.tbChangeLog);
            this.tabChangelog.Location = new System.Drawing.Point(4, 22);
            this.tabChangelog.Name = "tabChangelog";
            this.tabChangelog.Padding = new System.Windows.Forms.Padding(3);
            this.tabChangelog.Size = new System.Drawing.Size(547, 194);
            this.tabChangelog.TabIndex = 3;
            this.tabChangelog.Text = "Changelog";
            this.tabChangelog.UseVisualStyleBackColor = true;
            // 
            // tbChangeLog
            // 
            this.tbChangeLog.BackColor = System.Drawing.Color.Silver;
            this.tbChangeLog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChangeLog.ForeColor = System.Drawing.Color.DimGray;
            this.tbChangeLog.Location = new System.Drawing.Point(8, 7);
            this.tbChangeLog.Multiline = true;
            this.tbChangeLog.Name = "tbChangeLog";
            this.tbChangeLog.ReadOnly = true;
            this.tbChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbChangeLog.Size = new System.Drawing.Size(531, 181);
            this.tbChangeLog.TabIndex = 0;
            this.tbChangeLog.WordWrap = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Gray;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(0, -12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(551, 107);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblVersion.Location = new System.Drawing.Point(293, 94);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(171, 20);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Launcher version: #.#.#";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(7, 317);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(94, 21);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status: Idle";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(-3, 401);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(558, 32);
            this.pbDownload.TabIndex = 7;
            this.pbDownload.Value = 100;
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(552, 431);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pbDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Infiniti Launcher";
            this.Load += new System.EventHandler(this.FormLauncher_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabMinecraft.ResumeLayout(false);
            this.tabMinecraft.PerformLayout();
            this.tabChangelog.ResumeLayout(false);
            this.tabChangelog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMinecraft;
        private System.Windows.Forms.TabPage tabJava;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabPage tabLauncher;
        private System.Windows.Forms.TabPage tabChangelog;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox tbChangeLog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar pbDownload;
    }
}

