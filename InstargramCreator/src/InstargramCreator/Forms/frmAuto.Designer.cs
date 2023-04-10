namespace InstargramCreator
{
    partial class frmAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuto));
            label1 = new Label();
            label3 = new Label();
            radioFullnameRandom = new RadioButton();
            radioPasswordCustomize = new RadioButton();
            label4 = new Label();
            txtPasswordCustomize = new TextBox();
            radioFullnameCustomize = new RadioButton();
            radioPasswordRandom = new RadioButton();
            label5 = new Label();
            label7 = new Label();
            radioUserRandom = new RadioButton();
            radioUserCustomize = new RadioButton();
            btnUser = new Button();
            label8 = new Label();
            cbAvatar = new CheckBox();
            btnAvatar = new Button();
            btnPause = new Button();
            txtFullname = new TextBox();
            txtUser = new TextBox();
            txtAvatar = new TextBox();
            label11 = new Label();
            NumberThreads = new NumericUpDown();
            NumberRun = new NumericUpDown();
            panel1 = new Panel();
            txtPasswordRandom = new NumericUpDown();
            panel3 = new Panel();
            radioRandomVN = new RadioButton();
            pFullname = new Panel();
            btnLastname = new Button();
            label12 = new Label();
            txtLastName = new TextBox();
            btnFullname = new Button();
            label9 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnlog = new Button();
            rtbLog = new RichTextBox();
            tabPage2 = new TabPage();
            btnResult = new Button();
            rtbResult = new RichTextBox();
            btnStart = new Button();
            label10 = new Label();
            btnSort = new Button();
            btn_exit = new Button();
            txtBio = new TextBox();
            btnBio = new Button();
            cbBio = new CheckBox();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            MenuItemsSetting = new ToolStripMenuItem();
            proxySettingToolStripMenuItem = new ToolStripMenuItem();
            MailSettingsToolStripMenuItem = new ToolStripMenuItem();
            SettingsLDPlayer = new ToolStripMenuItem();
            MenuIremsData = new ToolStripMenuItem();
            txtPost = new TextBox();
            btnPost = new Button();
            cbPost = new CheckBox();
            label6 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)NumberThreads).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumberRun).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPasswordRandom).BeginInit();
            panel3.SuspendLayout();
            pFullname.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(856, 214);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 10;
            label1.Text = "Profile Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(17, 17);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 14;
            label3.Text = "Full Name :";
            // 
            // radioFullnameRandom
            // 
            radioFullnameRandom.AutoSize = true;
            radioFullnameRandom.ForeColor = SystemColors.ButtonHighlight;
            radioFullnameRandom.Location = new Point(206, 17);
            radioFullnameRandom.Name = "radioFullnameRandom";
            radioFullnameRandom.Size = new Size(88, 19);
            radioFullnameRandom.TabIndex = 15;
            radioFullnameRandom.TabStop = true;
            radioFullnameRandom.Text = "Random EN";
            radioFullnameRandom.UseVisualStyleBackColor = true;
            radioFullnameRandom.CheckedChanged += radioFullnameRandom_CheckedChanged;
            // 
            // radioPasswordCustomize
            // 
            radioPasswordCustomize.AutoSize = true;
            radioPasswordCustomize.ForeColor = SystemColors.ButtonHighlight;
            radioPasswordCustomize.Location = new Point(5, 7);
            radioPasswordCustomize.Name = "radioPasswordCustomize";
            radioPasswordCustomize.Size = new Size(81, 19);
            radioPasswordCustomize.TabIndex = 16;
            radioPasswordCustomize.TabStop = true;
            radioPasswordCustomize.Text = "Customize";
            radioPasswordCustomize.UseVisualStyleBackColor = true;
            radioPasswordCustomize.CheckedChanged += radioPasswordCustomize_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(668, 268);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 17;
            label4.Text = "Password 2FA :";
            // 
            // txtPasswordCustomize
            // 
            txtPasswordCustomize.Location = new Point(108, 7);
            txtPasswordCustomize.MaxLength = 30;
            txtPasswordCustomize.Name = "txtPasswordCustomize";
            txtPasswordCustomize.Size = new Size(225, 23);
            txtPasswordCustomize.TabIndex = 18;
            txtPasswordCustomize.TextChanged += txtPasswordCustomize_TextChanged;
            // 
            // radioFullnameCustomize
            // 
            radioFullnameCustomize.AutoSize = true;
            radioFullnameCustomize.ForeColor = SystemColors.ButtonHighlight;
            radioFullnameCustomize.Location = new Point(103, 17);
            radioFullnameCustomize.Name = "radioFullnameCustomize";
            radioFullnameCustomize.Size = new Size(81, 19);
            radioFullnameCustomize.TabIndex = 19;
            radioFullnameCustomize.TabStop = true;
            radioFullnameCustomize.Text = "Customize";
            radioFullnameCustomize.UseVisualStyleBackColor = true;
            radioFullnameCustomize.CheckedChanged += radioFullnameCustomize_CheckedChanged;
            // 
            // radioPasswordRandom
            // 
            radioPasswordRandom.AutoSize = true;
            radioPasswordRandom.ForeColor = SystemColors.ButtonHighlight;
            radioPasswordRandom.Location = new Point(5, 44);
            radioPasswordRandom.Name = "radioPasswordRandom";
            radioPasswordRandom.Size = new Size(140, 19);
            radioPasswordRandom.TabIndex = 20;
            radioPasswordRandom.TabStop = true;
            radioPasswordRandom.Text = "Create Password With";
            radioPasswordRandom.UseVisualStyleBackColor = true;
            radioPasswordRandom.CheckedChanged += radioPasswordRandom_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(220, 44);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 23;
            label5.Text = "Characters";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(705, 515);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 27;
            label7.Text = "User  :";
            // 
            // radioUserRandom
            // 
            radioUserRandom.AutoSize = true;
            radioUserRandom.ForeColor = SystemColors.ButtonHighlight;
            radioUserRandom.Location = new Point(760, 512);
            radioUserRandom.Name = "radioUserRandom";
            radioUserRandom.Size = new Size(70, 19);
            radioUserRandom.TabIndex = 28;
            radioUserRandom.TabStop = true;
            radioUserRandom.Text = "Random";
            radioUserRandom.UseVisualStyleBackColor = true;
            radioUserRandom.CheckedChanged += radioUserRandom_CheckedChanged;
            // 
            // radioUserCustomize
            // 
            radioUserCustomize.AutoSize = true;
            radioUserCustomize.ForeColor = SystemColors.ButtonHighlight;
            radioUserCustomize.Location = new Point(846, 512);
            radioUserCustomize.Name = "radioUserCustomize";
            radioUserCustomize.Size = new Size(81, 19);
            radioUserCustomize.TabIndex = 29;
            radioUserCustomize.TabStop = true;
            radioUserCustomize.Text = "Customize";
            radioUserCustomize.UseVisualStyleBackColor = true;
            radioUserCustomize.CheckedChanged += radioUserCustomize_CheckedChanged;
            // 
            // btnUser
            // 
            btnUser.BackColor = SystemColors.ControlDarkDark;
            btnUser.ForeColor = SystemColors.ButtonHighlight;
            btnUser.Location = new Point(1054, 503);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(80, 30);
            btnUser.TabIndex = 30;
            btnUser.Text = "Open";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(6, 48);
            label8.Name = "label8";
            label8.Size = new Size(85, 15);
            label8.TabIndex = 31;
            label8.Text = "Image Folder  :";
            // 
            // cbAvatar
            // 
            cbAvatar.AutoSize = true;
            cbAvatar.ForeColor = SystemColors.ButtonHighlight;
            cbAvatar.Location = new Point(6, 8);
            cbAvatar.Name = "cbAvatar";
            cbAvatar.Size = new Size(104, 19);
            cbAvatar.TabIndex = 32;
            cbAvatar.Text = "UpLoad Avatar";
            cbAvatar.UseVisualStyleBackColor = true;
            cbAvatar.CheckedChanged += cbAvatar_CheckedChanged;
            // 
            // btnAvatar
            // 
            btnAvatar.BackColor = SystemColors.ControlDarkDark;
            btnAvatar.ForeColor = SystemColors.ButtonHighlight;
            btnAvatar.Location = new Point(393, 40);
            btnAvatar.Name = "btnAvatar";
            btnAvatar.Size = new Size(80, 30);
            btnAvatar.TabIndex = 34;
            btnAvatar.Text = "Open";
            btnAvatar.UseVisualStyleBackColor = false;
            btnAvatar.Click += btnAvatar_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = SystemColors.ControlDarkDark;
            btnPause.ForeColor = SystemColors.ButtonHighlight;
            btnPause.Location = new Point(792, 68);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(99, 30);
            btnPause.TabIndex = 35;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(100, 7);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(284, 23);
            txtFullname.TabIndex = 36;
            txtFullname.TabStop = false;
            txtFullname.TextChanged += txtFullname_TextChanged;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(928, 506);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(120, 23);
            txtUser.TabIndex = 37;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // txtAvatar
            // 
            txtAvatar.Location = new Point(116, 45);
            txtAvatar.Name = "txtAvatar";
            txtAvatar.Size = new Size(272, 23);
            txtAvatar.TabIndex = 38;
            txtAvatar.TextChanged += txtAvatar_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(697, 146);
            label11.Name = "label11";
            label11.Size = new Size(41, 20);
            label11.TabIndex = 41;
            label11.Text = "Run :";
            // 
            // NumberThreads
            // 
            NumberThreads.Location = new Point(989, 146);
            NumberThreads.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            NumberThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumberThreads.Name = "NumberThreads";
            NumberThreads.Size = new Size(74, 23);
            NumberThreads.TabIndex = 42;
            NumberThreads.Value = new decimal(new int[] { 3, 0, 0, 0 });
            NumberThreads.ValueChanged += numberThreads_ValueChanged;
            // 
            // NumberRun
            // 
            NumberRun.Location = new Point(772, 146);
            NumberRun.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
            NumberRun.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumberRun.Name = "NumberRun";
            NumberRun.Size = new Size(74, 23);
            NumberRun.TabIndex = 44;
            NumberRun.Value = new decimal(new int[] { 5, 0, 0, 0 });
            NumberRun.ValueChanged += numberRun_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtPasswordRandom);
            panel1.Controls.Add(radioPasswordRandom);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtPasswordCustomize);
            panel1.Controls.Add(radioPasswordCustomize);
            panel1.Location = new Point(759, 259);
            panel1.Name = "panel1";
            panel1.Size = new Size(389, 72);
            panel1.TabIndex = 48;
            // 
            // txtPasswordRandom
            // 
            txtPasswordRandom.Location = new Point(162, 42);
            txtPasswordRandom.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            txtPasswordRandom.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            txtPasswordRandom.Name = "txtPasswordRandom";
            txtPasswordRandom.Size = new Size(52, 23);
            txtPasswordRandom.TabIndex = 24;
            txtPasswordRandom.Value = new decimal(new int[] { 6, 0, 0, 0 });
            txtPasswordRandom.ValueChanged += txtPasswordRandom_ValueChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(radioRandomVN);
            panel3.Controls.Add(pFullname);
            panel3.Controls.Add(radioFullnameRandom);
            panel3.Controls.Add(radioFullnameCustomize);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(661, 347);
            panel3.Name = "panel3";
            panel3.Size = new Size(487, 153);
            panel3.TabIndex = 50;
            // 
            // radioRandomVN
            // 
            radioRandomVN.AutoSize = true;
            radioRandomVN.ForeColor = SystemColors.ButtonHighlight;
            radioRandomVN.Location = new Point(319, 17);
            radioRandomVN.Name = "radioRandomVN";
            radioRandomVN.Size = new Size(89, 19);
            radioRandomVN.TabIndex = 38;
            radioRandomVN.TabStop = true;
            radioRandomVN.Text = "Random VN";
            radioRandomVN.UseVisualStyleBackColor = true;
            radioRandomVN.CheckedChanged += radioRandomVN_CheckedChanged;
            // 
            // pFullname
            // 
            pFullname.Controls.Add(btnLastname);
            pFullname.Controls.Add(label12);
            pFullname.Controls.Add(txtLastName);
            pFullname.Controls.Add(btnFullname);
            pFullname.Controls.Add(label9);
            pFullname.Controls.Add(txtFullname);
            pFullname.Location = new Point(3, 47);
            pFullname.Name = "pFullname";
            pFullname.Size = new Size(484, 103);
            pFullname.TabIndex = 37;
            // 
            // btnLastname
            // 
            btnLastname.BackColor = SystemColors.ControlDarkDark;
            btnLastname.ForeColor = SystemColors.ButtonHighlight;
            btnLastname.Location = new Point(390, 47);
            btnLastname.Name = "btnLastname";
            btnLastname.Size = new Size(80, 30);
            btnLastname.TabIndex = 65;
            btnLastname.Text = "Open";
            btnLastname.UseVisualStyleBackColor = false;
            btnLastname.Click += btnLastname_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.ControlLightLight;
            label12.Location = new Point(7, 54);
            label12.Name = "label12";
            label12.Size = new Size(66, 15);
            label12.TabIndex = 64;
            label12.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(100, 51);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(284, 23);
            txtLastName.TabIndex = 63;
            txtLastName.TabStop = false;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // btnFullname
            // 
            btnFullname.BackColor = SystemColors.ControlDarkDark;
            btnFullname.ForeColor = SystemColors.ButtonHighlight;
            btnFullname.Location = new Point(390, 3);
            btnFullname.Name = "btnFullname";
            btnFullname.Size = new Size(80, 30);
            btnFullname.TabIndex = 62;
            btnFullname.Text = "Open";
            btnFullname.UseVisualStyleBackColor = false;
            btnFullname.Click += btnFullname_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(7, 10);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 38;
            label9.Text = "First Name:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(646, 713);
            tabControl1.TabIndex = 55;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(50, 50, 50);
            tabPage1.BackgroundImageLayout = ImageLayout.None;
            tabPage1.Controls.Add(btnlog);
            tabPage1.Controls.Add(rtbLog);
            tabPage1.ForeColor = SystemColors.ButtonHighlight;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(638, 685);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Logs";
            // 
            // btnlog
            // 
            btnlog.BackColor = Color.FromArgb(50, 50, 50);
            btnlog.Location = new Point(533, 19);
            btnlog.Name = "btnlog";
            btnlog.Size = new Size(85, 36);
            btnlog.TabIndex = 1;
            btnlog.Text = "All Logs";
            btnlog.UseVisualStyleBackColor = false;
            btnlog.Click += btnlog_Click;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(50, 50, 50);
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.ForeColor = Color.Yellow;
            rtbLog.Location = new Point(3, 3);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(632, 679);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            rtbLog.TextChanged += rtbLog_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(50, 50, 50);
            tabPage2.Controls.Add(btnResult);
            tabPage2.Controls.Add(rtbResult);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(638, 615);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Result";
            // 
            // btnResult
            // 
            btnResult.BackColor = Color.FromArgb(50, 50, 50);
            btnResult.ForeColor = SystemColors.ButtonHighlight;
            btnResult.Location = new Point(534, 20);
            btnResult.Name = "btnResult";
            btnResult.Size = new Size(85, 36);
            btnResult.TabIndex = 1;
            btnResult.Text = "All Result";
            btnResult.UseVisualStyleBackColor = false;
            btnResult.Click += btnResult_Click;
            // 
            // rtbResult
            // 
            rtbResult.BackColor = Color.FromArgb(50, 50, 50);
            rtbResult.Dock = DockStyle.Fill;
            rtbResult.ForeColor = Color.Yellow;
            rtbResult.Location = new Point(3, 3);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(632, 609);
            rtbResult.TabIndex = 0;
            rtbResult.Text = "";
            rtbResult.TextChanged += rtbResult_TextChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.ControlDarkDark;
            btnStart.ForeColor = SystemColors.ButtonHighlight;
            btnStart.Location = new Point(661, 68);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(103, 30);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(901, 149);
            label10.Name = "label10";
            label10.Size = new Size(68, 20);
            label10.TabIndex = 40;
            label10.Text = "Threads :";
            // 
            // btnSort
            // 
            btnSort.BackColor = SystemColors.ControlDarkDark;
            btnSort.ForeColor = SystemColors.ButtonHighlight;
            btnSort.Location = new Point(912, 68);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(103, 30);
            btnSort.TabIndex = 56;
            btnSort.Text = "Sort LDPlayer";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = SystemColors.ControlDarkDark;
            btn_exit.ForeColor = SystemColors.ButtonHighlight;
            btn_exit.Location = new Point(1037, 68);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(93, 30);
            btn_exit.TabIndex = 51;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // txtBio
            // 
            txtBio.Location = new Point(812, 729);
            txtBio.Name = "txtBio";
            txtBio.Size = new Size(237, 23);
            txtBio.TabIndex = 60;
            txtBio.TextChanged += txtBio_TextChanged;
            // 
            // btnBio
            // 
            btnBio.BackColor = SystemColors.ControlDarkDark;
            btnBio.ForeColor = SystemColors.ButtonHighlight;
            btnBio.Location = new Point(1050, 724);
            btnBio.Name = "btnBio";
            btnBio.Size = new Size(80, 30);
            btnBio.TabIndex = 59;
            btnBio.Text = "Open";
            btnBio.UseVisualStyleBackColor = false;
            btnBio.Click += btnBio_Click;
            // 
            // cbBio
            // 
            cbBio.AutoSize = true;
            cbBio.ForeColor = SystemColors.ButtonHighlight;
            cbBio.Location = new Point(707, 694);
            cbBio.Name = "cbBio";
            cbBio.Size = new Size(87, 19);
            cbBio.TabIndex = 58;
            cbBio.Text = "UpLoad Bio";
            cbBio.UseVisualStyleBackColor = true;
            cbBio.CheckedChanged += cbBio_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(702, 732);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 57;
            label2.Text = "Image Folder  :";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuItemsSetting, MenuIremsData });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1152, 24);
            menuStrip1.TabIndex = 61;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemsSetting
            // 
            MenuItemsSetting.BackColor = Color.FromArgb(50, 50, 50);
            MenuItemsSetting.Checked = true;
            MenuItemsSetting.CheckState = CheckState.Checked;
            MenuItemsSetting.DropDownItems.AddRange(new ToolStripItem[] { proxySettingToolStripMenuItem, MailSettingsToolStripMenuItem, SettingsLDPlayer });
            MenuItemsSetting.ForeColor = SystemColors.ButtonHighlight;
            MenuItemsSetting.Name = "MenuItemsSetting";
            MenuItemsSetting.Size = new Size(61, 20);
            MenuItemsSetting.Text = "Settings";
            // 
            // proxySettingToolStripMenuItem
            // 
            proxySettingToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            proxySettingToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            proxySettingToolStripMenuItem.Name = "proxySettingToolStripMenuItem";
            proxySettingToolStripMenuItem.Size = new Size(165, 22);
            proxySettingToolStripMenuItem.Text = "Proxy Settings";
            proxySettingToolStripMenuItem.Click += proxySettingToolStripMenuItem_Click;
            // 
            // MailSettingsToolStripMenuItem
            // 
            MailSettingsToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            MailSettingsToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            MailSettingsToolStripMenuItem.Name = "MailSettingsToolStripMenuItem";
            MailSettingsToolStripMenuItem.Size = new Size(165, 22);
            MailSettingsToolStripMenuItem.Text = "Mail Settings";
            MailSettingsToolStripMenuItem.Click += MailSettingsToolStripMenuItem_Click;
            // 
            // SettingsLDPlayer
            // 
            SettingsLDPlayer.BackColor = Color.FromArgb(50, 50, 50);
            SettingsLDPlayer.ForeColor = SystemColors.ButtonHighlight;
            SettingsLDPlayer.Name = "SettingsLDPlayer";
            SettingsLDPlayer.Size = new Size(165, 22);
            SettingsLDPlayer.Text = "LDPlayer Settings";
            SettingsLDPlayer.Click += SettingsLDPlayer_Click;
            // 
            // MenuIremsData
            // 
            MenuIremsData.BackColor = Color.FromArgb(50, 50, 50);
            MenuIremsData.ForeColor = SystemColors.ButtonHighlight;
            MenuIremsData.Name = "MenuIremsData";
            MenuIremsData.Size = new Size(43, 20);
            MenuIremsData.Text = "Data";
            MenuIremsData.Click += MenuIremsData_Click;
            // 
            // txtPost
            // 
            txtPost.Location = new Point(115, 111);
            txtPost.Name = "txtPost";
            txtPost.Size = new Size(273, 23);
            txtPost.TabIndex = 66;
            txtPost.TextChanged += txtPost_TextChanged;
            // 
            // btnPost
            // 
            btnPost.BackColor = SystemColors.ControlDarkDark;
            btnPost.ForeColor = SystemColors.ButtonHighlight;
            btnPost.Location = new Point(393, 106);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(80, 30);
            btnPost.TabIndex = 65;
            btnPost.Text = "Open";
            btnPost.UseVisualStyleBackColor = false;
            btnPost.Click += btnPost_Click;
            // 
            // cbPost
            // 
            cbPost.AutoSize = true;
            cbPost.ForeColor = SystemColors.ButtonHighlight;
            cbPost.Location = new Point(3, 79);
            cbPost.Name = "cbPost";
            cbPost.Size = new Size(93, 19);
            cbPost.TabIndex = 67;
            cbPost.Text = "UpLoad Post";
            cbPost.UseVisualStyleBackColor = true;
            cbPost.CheckedChanged += cbPost_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(8, 119);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 68;
            label6.Text = "Image Folder  :";
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cbAvatar);
            panel2.Controls.Add(cbPost);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtPost);
            panel2.Controls.Add(btnAvatar);
            panel2.Controls.Add(btnPost);
            panel2.Controls.Add(txtAvatar);
            panel2.Location = new Point(661, 542);
            panel2.Name = "panel2";
            panel2.Size = new Size(487, 146);
            panel2.TabIndex = 51;
            panel2.Paint += panel2_Paint;
            // 
            // frmAuto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1152, 767);
            Controls.Add(panel2);
            Controls.Add(txtBio);
            Controls.Add(btnBio);
            Controls.Add(cbBio);
            Controls.Add(label2);
            Controls.Add(btnSort);
            Controls.Add(label10);
            Controls.Add(btnStart);
            Controls.Add(tabControl1);
            Controls.Add(btn_exit);
            Controls.Add(btnPause);
            Controls.Add(panel3);
            Controls.Add(label11);
            Controls.Add(panel1);
            Controls.Add(NumberThreads);
            Controls.Add(NumberRun);
            Controls.Add(txtUser);
            Controls.Add(btnUser);
            Controls.Add(radioUserCustomize);
            Controls.Add(radioUserRandom);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ButtonHighlight;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAuto";
            Text = "InstagramCreator";
            Load += frmAuto_Load;
            ((System.ComponentModel.ISupportInitialize)NumberThreads).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumberRun).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPasswordRandom).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pFullname.ResumeLayout(false);
            pFullname.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label3;
        private RadioButton radioFullnameRandom;
        private RadioButton radioPasswordCustomize;
        private Label label4;
        private TextBox txtPasswordCustomize;
        private RadioButton radioFullnameCustomize;
        private RadioButton radioPasswordRandom;
        private Label label5;
        private DataGridView dataGridView1;
        private Label label7;
        private RadioButton radioUserRandom;
        private RadioButton radioUserCustomize;
        private Button btnUser;
        private Label label8;
        private CheckBox CheckBoxAvatar;
        private CheckBox CheckBoxBio;
        private CheckBox cbAvatar;
        private Button btnAvatar;
        private Button btnPause;
        private TextBox txtFullname;
        private TextBox txtUser;
        private TextBox txtAvatar;
        private Label label11;
        private NumericUpDown NumberThreads;
        private NumericUpDown NumberRun;
        private Panel panel1;
        private Panel panel3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox rtbLog;
        private RichTextBox rtbResult;
        private Button btnlog;
        private Button btnResult;
        private Button btnStart;
        private Label label10;
        private Button btnSort;
        private Button btn_exit;
        private TextBox txtBio;
        private Button btnBio;
        private CheckBox cbBio;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuItemsSetting;
        private ToolStripMenuItem proxySettingToolStripMenuItem;
        private ToolStripMenuItem MailSettingsToolStripMenuItem;
        private ToolStripMenuItem MenuIremsData;
        private ToolStripMenuItem SettingsLDPlayer;
        private NumericUpDown txtPasswordRandom;
        private TextBox txtPost;
        private Button btnPost;
        private CheckBox cbPost;
        private Label label6;
        private Panel panel2;
        private RadioButton radioRandomVN;
        private Panel pFullname;
        private Button btnLastname;
        private Label label12;
        private TextBox txtLastName;
        private Button btnFullname;
        private Label label9;
    }
}