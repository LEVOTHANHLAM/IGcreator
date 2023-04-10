namespace InstargramCreator
{
    partial class frmProxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProxy));
            this.label1 = new System.Windows.Forms.Label();
            this.radioNoProxy = new System.Windows.Forms.RadioButton();
            this.radioHTTP = new System.Windows.Forms.RadioButton();
            this.txtFileProxy = new System.Windows.Forms.TextBox();
            this.btnProxy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioFileProxy = new System.Windows.Forms.RadioButton();
            this.radioUrl = new System.Windows.Forms.RadioButton();
            this.radioSock5 = new System.Windows.Forms.RadioButton();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(85, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proxy Source";
            // 
            // radioNoProxy
            // 
            this.radioNoProxy.AutoSize = true;
            this.radioNoProxy.Location = new System.Drawing.Point(3, 14);
            this.radioNoProxy.Name = "radioNoProxy";
            this.radioNoProxy.Size = new System.Drawing.Size(74, 19);
            this.radioNoProxy.TabIndex = 16;
            this.radioNoProxy.TabStop = true;
            this.radioNoProxy.Text = "No Proxy";
            this.radioNoProxy.UseVisualStyleBackColor = true;
            this.radioNoProxy.CheckedChanged += new System.EventHandler(this.radioNoProxy_CheckedChanged);
            // 
            // radioHTTP
            // 
            this.radioHTTP.AutoSize = true;
            this.radioHTTP.Location = new System.Drawing.Point(3, 50);
            this.radioHTTP.Name = "radioHTTP";
            this.radioHTTP.Size = new System.Drawing.Size(59, 19);
            this.radioHTTP.TabIndex = 17;
            this.radioHTTP.TabStop = true;
            this.radioHTTP.Text = " HTTP ";
            this.radioHTTP.UseVisualStyleBackColor = true;
            this.radioHTTP.CheckedChanged += new System.EventHandler(this.radioHTTP_CheckedChanged);
            // 
            // txtFileProxy
            // 
            this.txtFileProxy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFileProxy.Location = new System.Drawing.Point(121, 32);
            this.txtFileProxy.Name = "txtFileProxy";
            this.txtFileProxy.Size = new System.Drawing.Size(135, 23);
            this.txtFileProxy.TabIndex = 19;
            this.txtFileProxy.TextChanged += new System.EventHandler(this.txtFileProxy_TextChanged);
            // 
            // btnProxy
            // 
            this.btnProxy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnProxy.Location = new System.Drawing.Point(262, 31);
            this.btnProxy.Name = "btnProxy";
            this.btnProxy.Size = new System.Drawing.Size(60, 25);
            this.btnProxy.TabIndex = 20;
            this.btnProxy.Text = "Open";
            this.btnProxy.UseVisualStyleBackColor = false;
            this.btnProxy.Click += new System.EventHandler(this.btnProxy_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSave.Location = new System.Drawing.Point(141, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancel.Location = new System.Drawing.Point(240, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radioFileProxy
            // 
            this.radioFileProxy.AutoSize = true;
            this.radioFileProxy.Location = new System.Drawing.Point(31, 32);
            this.radioFileProxy.Name = "radioFileProxy";
            this.radioFileProxy.Size = new System.Drawing.Size(79, 19);
            this.radioFileProxy.TabIndex = 26;
            this.radioFileProxy.TabStop = true;
            this.radioFileProxy.Text = " File Proxy";
            this.radioFileProxy.UseVisualStyleBackColor = true;
            this.radioFileProxy.CheckedChanged += new System.EventHandler(this.radioFileProxy_CheckedChanged);
            // 
            // radioUrl
            // 
            this.radioUrl.AutoSize = true;
            this.radioUrl.Location = new System.Drawing.Point(31, 86);
            this.radioUrl.Name = "radioUrl";
            this.radioUrl.Size = new System.Drawing.Size(87, 19);
            this.radioUrl.TabIndex = 27;
            this.radioUrl.TabStop = true;
            this.radioUrl.Text = "Default URL";
            this.radioUrl.UseVisualStyleBackColor = true;
            this.radioUrl.CheckedChanged += new System.EventHandler(this.radioUrl_CheckedChanged);
            // 
            // radioSock5
            // 
            this.radioSock5.AutoSize = true;
            this.radioSock5.Location = new System.Drawing.Point(110, 50);
            this.radioSock5.Name = "radioSock5";
            this.radioSock5.Size = new System.Drawing.Size(64, 19);
            this.radioSock5.TabIndex = 29;
            this.radioSock5.TabStop = true;
            this.radioSock5.Text = " Socks5";
            this.radioSock5.UseVisualStyleBackColor = true;
            this.radioSock5.CheckedChanged += new System.EventHandler(this.radioSock5_CheckedChanged);
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtUrl.Location = new System.Drawing.Point(121, 85);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(201, 23);
            this.txtUrl.TabIndex = 30;
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioSock5);
            this.panel1.Controls.Add(this.radioHTTP);
            this.panel1.Controls.Add(this.radioNoProxy);
            this.panel1.Location = new System.Drawing.Point(32, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 72);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnProxy);
            this.panel2.Controls.Add(this.txtUrl);
            this.panel2.Controls.Add(this.txtFileProxy);
            this.panel2.Controls.Add(this.radioUrl);
            this.panel2.Controls.Add(this.radioFileProxy);
            this.panel2.Location = new System.Drawing.Point(1, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 194);
            this.panel2.TabIndex = 32;
            //this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // frmProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(328, 358);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProxy";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Instagram Creator";
            this.Load += new System.EventHandler(this.frmProxy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private RadioButton radioNoProxy;
        private RadioButton radioHTTP;
        private TextBox txtFileProxy;
        private Button btnProxy;
        private Button btnSave;
        private Button btnCancel;
        private RadioButton radioFileProxy;
        private RadioButton radioUrl;
        private RadioButton radioSock5;
        private TextBox txtUrl;
        private Panel panel1;
        private Panel panel2;
    }
}